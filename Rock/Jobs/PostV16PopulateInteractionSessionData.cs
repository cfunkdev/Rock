﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//

using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.SystemKey;
using System.ComponentModel;
using static Rock.Jobs.PopulateInteractionSessionData;

namespace Rock.Jobs
{
    /// <summary>
    /// Run once job for v16 to populate interaction session data for interaction sessions that were missed by the <see cref="PopulateInteractionSessionData"/>
    /// </summary>
    [DisplayName( "Rock Update Helper v16.0 - Populate Interaction Session Data." )]
    [Description( "This job updates all interaction sessions missed by the PopulateInteractionSessionData with their interaction data." )]

    [IntegerField(
    "Command Timeout",
    Key = AttributeKey.CommandTimeout,
    Description = "Maximum amount of time (in seconds) to wait for each SQL command to complete. On a large database with lots of transactions, this could take several minutes or more.",
    IsRequired = false,
    DefaultIntegerValue = 14400 )]
    public class PostV16PopulateInteractionSessionData : RockJob
    {
        private static class AttributeKey
        {
            public const string CommandTimeout = "CommandTimeout";
        }

        /// <inheritdoc />
        public override void Execute()
        {
            // get the configured timeout, or default to 240 minutes if it is blank
            var commandTimeout = GetAttributeValue( AttributeKey.CommandTimeout ).AsIntegerOrNull() ?? 14400;
            var jobMigration = new JobMigration( commandTimeout );
            var jobSettings = new PopulateInteractionSessionDataJobSettings();
            var lastSuccessfulJobRunDateTime = jobSettings.LastSuccessfulJobRunDateTime ?? RockDateTime.Now;

            jobMigration.Sql( $@"
DECLARE @batchId INT
DECLARE @lastBatchId INT
DECLARE @batchSize INT

SET @batchSize = 5000
SET @batchId = 0
SET @lastBatchId = (SELECT MAX([Id]) FROM [InteractionSession])

WHILE (@batchId <= @lastBatchId)
	BEGIN
        UPDATE [IS] SET
        	[DurationSeconds] = [IQ].[DurationInSeconds]
        	, [InteractionCount] = [IQ].[InteractionCount]
        	, [DurationLastCalculatedDateTime] = DATEADD(DAY, -1, GETDATE())
        FROM [InteractionSession] AS [IS]
        INNER JOIN (
        	SELECT
        		[InteractionSessionId]
        		, COUNT(*) AS [InteractionCount]
        		, CASE WHEN COUNT(*) = 1 THEN 60 ELSE DATEDIFF(SECOND, MIN([InteractionDateTime]), MAX([InteractionDateTime])) END AS [DurationInSeconds]
        	FROM [Interaction]
        	WHERE [InteractionSessionId] IN (SELECT [Id] FROM [InteractionSession] WHERE [DurationLastCalculatedDateTime] IS NULL)
            AND CAST([InteractionDateTime] AS DATE) < CAST('{lastSuccessfulJobRunDateTime}' AS DATE)
        	GROUP BY [InteractionSessionId]
        ) AS [IQ] ON [IQ].[InteractionSessionId] = [IS].[Id]
        WHERE ([IS].[Id] > @batchId AND [IS].Id <= @batchId + @batchSize)
        AND [IS].[DurationLastCalculatedDateTime] IS NULL 

		-- next batch
		SET @batchId = @batchId + @batchSize
	END
" );
            DeleteJob();
        }

        /// <summary>
        /// Deletes the job.
        /// </summary>
        private void DeleteJob()
        {
            using ( var rockContext = new RockContext() )
            {
                var jobService = new ServiceJobService( rockContext );
                var job = jobService.Get( GetJobId() );

                if ( job != null )
                {
                    jobService.Delete( job );
                    rockContext.SaveChanges();
                }
            }
        }
    }
}
