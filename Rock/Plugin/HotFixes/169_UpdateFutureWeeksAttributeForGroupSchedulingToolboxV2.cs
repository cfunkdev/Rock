// <copyright>
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

namespace Rock.Plugin.HotFixes
{
    /// <summary>
    /// Plug-in migration
    /// </summary>
    /// <seealso cref="Rock.Plugin.Migration" />
    [MigrationNumber( 169, "1.14.1" )]
    public class UpdateFutureWeeksAttributeForGroupSchedulingToolboxV2 : Migration
    {
        private const string _169_UpdateFutureWeeksAttributeForGroupSchedulingToolboxV2 = @"
DECLARE @EntityTypeId_BlockType INT = (SELECT [Id] FROM [EntityType] WHERE [Name] = 'Rock.Model.Block');
DECLARE @BlockTypeId_ScheduleToolboxV2 INT = (SELECT [Id] FROM [BlockType] WHERE [Guid] = '18A6DCE3-376C-4A62-B1DD-5E5177C11595');
DECLARE @FieldTypeId_SlidingDateRange INT = (SELECT [Id] FROM [FieldType] WHERE [Guid] = '55810BC5-45EA-4044-B783-0CCE0A445C6F');

/*
NOTE:  This migration has already been run in some existing systems to update the attribute value, so it must be safe to run again when
they get the migration in Rock.  Because the Attribute Key changes, this migration should not perform any actions when run a second time.
*/
UPDATE [AttributeValue]
SET
	  [Value] = 'Next|' + [Value] + '|Week||'
	, [ValueAsNumeric] = NULL
	, [PersistedTextValue] = NULL
	, [PersistedHtmlValue] = NULL
	, [PersistedCondensedTextValue] = NULL
	, [PersistedCondensedHtmlValue] = NULL
	, [IsPersistedValueDirty] = 1
WHERE [AttributeId] IN (
	SELECT [Id]
	FROM [Attribute]
	WHERE	[EntityTypeId] = @EntityTypeId_BlockType
		AND	EntityTypeQualifierColumn = 'BlockTypeId'
		AND	EntityTypeQualifierValue = @BlockTypeId_ScheduleToolboxV2
		AND	[Key] = 'FutureWeeksToShow'
	);

UPDATE	[Attribute]
SET
	  [FieldTypeId] = @FieldTypeId_SlidingDateRange
	, [Key] = 'FutureWeekDateRange'
	, [Name] = 'Future Week Date Range'
	, [AbbreviatedName] = 'Future Week Date Range'
	, [Description] = 'The date range of future weeks to allow users to sign up for a schedule. Please note that only future dates will be accepted.'
	, [IsRequired] = 1
	, [DefaultValue] = 'Next|6|Week||'
	, [IsDefaultPersistedValueDirty] = 1
WHERE	[EntityTypeId] = @EntityTypeId_BlockType
	AND	EntityTypeQualifierColumn = 'BlockTypeId'
	AND	EntityTypeQualifierValue = @BlockTypeId_ScheduleToolboxV2
	AND	[Key] = 'FutureWeeksToShow';
";
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            //----------------------------------------------------------------------------------
            // <auto-generated>
            //     This Up() migration method was generated by the Rock.CodeGeneration project.
            //     The purpose is to prevent hotfix migrations from running when they are not
            //     needed. The migrations in this file are run by an EF migration instead.
            // </auto-generated>
            //----------------------------------------------------------------------------------
        }

        private void OldUp()
        {
            Sql( _169_UpdateFutureWeeksAttributeForGroupSchedulingToolboxV2 );
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            // Down migrations are not yet supported in plug-in migrations.
        }
    }
}
