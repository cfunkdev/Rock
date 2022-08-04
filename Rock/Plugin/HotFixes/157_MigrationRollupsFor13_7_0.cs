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

namespace Rock.Plugin.HotFixes
{
    /// <summary>
    /// Plug-in migration
    /// </summary>
    /// <seealso cref="Rock.Plugin.Migration" />
    [MigrationNumber( 157, "1.13.6" )]
    public class MigrationRollupsFor13_7_0 : Migration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddCampusContextSetter();
            ChartShortcodeYAxisLabelFix();
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            // Down migrations are not yet supported in plug-in migrations.
        }

        /// <summary>
        /// KA: Data Migration to Add Campus Context Setter and "Context" Zone to v13.7 (found in Migration Rollups)
        /// </summary>
        private void AddCampusContextSetter()
        {
            RockMigrationHelper.AddBlock( true, "6E46BC35-1FCB-4619-84F0-BB6926D2DDD5", null, "4A5AAFFC-B1C7-4EFD-A9E4-84363242EA85", "Campus Context Setter", "Context", @"", @"", 0, "6B2FD4C7-0EF7-4906-97D0-8DF69A3F45A7" );
            RockMigrationHelper.AddBlockAttributeValue( "6B2FD4C7-0EF7-4906-97D0-8DF69A3F45A7", "CC702570-A662-47E2-82EA-F1EF27E233D8", "All Campuses" );
            RockMigrationHelper.AddBlockAttributeValue( "6B2FD4C7-0EF7-4906-97D0-8DF69A3F45A7", "555B3C64-EBF0-4389-B601-5A21F9953F5C", "All Campuses" );
            RockMigrationHelper.UpdatePageContext( "6E46BC35-1FCB-4619-84F0-BB6926D2DDD5", "Rock.Model.Campus", "CampusId", "62440081-FCFB-41AF-AEC2-FC84B1BDD941" );

            RockMigrationHelper.AddBlock( true, "8E78F9DC-657D-41BF-BE0F-56916B6BF92F", null, "4A5AAFFC-B1C7-4EFD-A9E4-84363242EA85", "Campus Context Setter", "Context", @"", @"", 0, "81D440A0-D25E-4EA8-A9C2-926AE742CBF8" );
            RockMigrationHelper.AddBlockAttributeValue( "81D440A0-D25E-4EA8-A9C2-926AE742CBF8", "CC702570-A662-47E2-82EA-F1EF27E233D8", "All Campuses" );
            RockMigrationHelper.AddBlockAttributeValue( "81D440A0-D25E-4EA8-A9C2-926AE742CBF8", "555B3C64-EBF0-4389-B601-5A21F9953F5C", "All Campuses" );
            RockMigrationHelper.UpdatePageContext( "8E78F9DC-657D-41BF-BE0F-56916B6BF92F", "Rock.Model.Campus", "CampusId", "1E8FA2DA-D216-4E07-8552-2110159304CA" );
        }

        /// <summary>
        /// GJ: Chart Shortcode YAxis Label Fix
        /// </summary>
        private void ChartShortcodeYAxisLabelFix()
        {
            Sql( HotFixMigrationResource._157_MigrationRollupsFor13_7_0_ChartShortcodeYAxisLabelFix );
        }
    }
}