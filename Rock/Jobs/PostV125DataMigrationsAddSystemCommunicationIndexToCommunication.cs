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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rock.Attribute;
using Rock.Data;
using Rock.Model;

namespace Rock.Jobs
{
    /// <summary>
    /// A run once job for V12.0
    /// </summary>
    /// <seealso cref="Quartz.IJob" />
    [Quartz.DisallowConcurrentExecution]
    [DisplayName( "Rock Update Helper v12.5 - Add index for Communication SystemCommunicationId." )]
    [Description( "This job will add an index for Communication SystemCommunicationId column." )]

    [IntegerField(
        "Command Timeout",
        AttributeKey.CommandTimeout,
        Description = "Maximum amount of time (in seconds) to wait for each SQL command to complete. On a large database with lots of data, this could take several minutes or more.",
        IsRequired = false,
        DefaultIntegerValue = 60 * 60 )]
    public class PostV125DataMigrationsAddSystemCommunicationIndexToCommunication:  RockJob
    {
        private static class AttributeKey
        {
            public const string CommandTimeout = "CommandTimeout";
        }

        /// <summary>
        /// Executes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Execute( RockJobContext context )
        {
            // RockJobDataMap dataMap = context.JobDetail.JobDataMap;

            // get the configured timeout, or default to 60 minutes if it is blank
            var commandTimeout = GetAttributeValue( AttributeKey.CommandTimeout ).AsIntegerOrNull() ?? 3600;
            var migrationHelper = new MigrationHelper( new JobMigration( commandTimeout ) );

            migrationHelper.DropIndexIfExists( "Communication", "IX_SystemCommunicationId" );
            
            migrationHelper.CreateIndexIfNotExists( "Communication", new[] { "SystemCommunicationId" }, new string[0] );

            ServiceJobService.DeleteJob( context.GetJobId() );
        }
    }
}
