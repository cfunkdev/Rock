﻿using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using System.ComponentModel;

namespace Rock.Jobs
{
    /// <summary>
    /// Run once job for v16 to add new indices to the Interaction and InteractionSession tables.
    /// </summary>
    [DisplayName("Rock Update Helper v16.0 - Add update Interaction and InteractionSession indices.")]
    [Description("This job will add update the indices on the Interaction and InteractionSession tables.")]

    [IntegerField(
    "Command Timeout",
    Key = AttributeKey.CommandTimeout,
    Description = "Maximum amount of time (in seconds) to wait for each SQL command to complete. On a large database with lots of transactions, this could take several minutes or more.",
    IsRequired = false,
    DefaultIntegerValue = 14400)]
    public class PostV16UpdateInteractionAndInteractionSessionIndices : RockJob
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

            // Add SessionStartDateKey Index to InteractionSession
            jobMigration.Sql(@"
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_SessionStartDateKey' AND object_id = OBJECT_ID('dbo.InteractionSession'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_SessionStartDateKey] ON [dbo].[InteractionSession]
    ([SessionStartDateKey])
    INCLUDE ([DeviceTypeId], [DurationSeconds], [InteractionSessionLocationId], [InteractionCount], [InteractionChannelId])
END
");

            // Add InteractionChannelId,SessionStartDateKey Index to InteractionSession.
            jobMigration.Sql(@"
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_InteractionChannelId_SessionStartDateKey' AND object_id = OBJECT_ID('dbo.InteractionSession'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_InteractionChannelId_SessionStartDateKey] ON [InteractionSession]
    ([InteractionChannelId], [SessionStartDateKey])
    INCLUDE ([DeviceTypeId], [DurationSeconds], [InteractionSessionLocationId], [InteractionCount])
END
");

            // Add InteractionComponentId,InteractionDateKey Index to Interaction.
            jobMigration.Sql(@"
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_InteractionComponentId_InteractionDateKey' AND object_id = OBJECT_ID('dbo.Interaction'))
BEGIN
	CREATE NONCLUSTERED INDEX [IX_InteractionComponentId_InteractionDateKey]
	ON [dbo].[Interaction] ([InteractionComponentId],[InteractionDateKey])
	INCLUDE ([PersonAliasId], [InteractionSessionId], [InteractionTimeToServe], [EntityId], [InteractionSummary])
END
");

            // Drop IX_InteractionComponentId from Interaction.
            jobMigration.Sql( @"
IF EXISTS (SELECT * FROM sys.indexes WHERE name='INDEX [IX_InteractionComponentId]' AND object_id = OBJECT_ID ('dbo.Interaction'))
	DROP INDEX [IX_InteractionComponentId] ON [dbo].[Interaction]
" );
            DeleteJob();
        }

        /// <summary>
        /// Deletes the job.
        /// </summary>
        private void DeleteJob()
        {
            using (var rockContext = new RockContext())
            {
                var jobService = new ServiceJobService(rockContext);
                var job = jobService.Get(GetJobId());

                if (job != null)
                {
                    jobService.Delete(job);
                    rockContext.SaveChanges();
                }
            }
        }
    }
}
