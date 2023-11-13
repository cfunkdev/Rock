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
//
using System;
using System.Collections.Generic;

using Rock.Tests.Shared;

using static Rock.Jobs.RockCleanup;

namespace Rock.Tests.Integration.TestData.Core
{
    /// <summary>
    /// Provides actions to manage Jobs and authorization data for users.
    /// </summary>
    public class JobsDataManager
    {
        private static Lazy<JobsDataManager> _dataManager = new Lazy<JobsDataManager>();
        public static JobsDataManager Instance => _dataManager.Value;

        /// <summary>
        /// This job must be run after a new Rock database is created.
        /// It populates required support data tables.
        /// </summary>
        /// <returns></returns>
        public bool RunJobPostInstallDataMigrations()
        {
            var job = new Rock.Jobs.PostInstallDataMigrations();

            var success = ExecuteRockJob( "PostInstallDataMigrations", () => { job.Execute(); } );

            return success;
        }

        public bool RunJobRockCleanup( RockCleanupActionArgs args = null )
        {
            var job = new Rock.Jobs.RockCleanup();

            args = args ?? Jobs.RockCleanup.RockCleanupActionArgs.NewDefault();

            var success = ExecuteRockJob( "RockCleanup", () => { job.Execute( args ); } );
            return success;
        }

        public bool RunJobCalculateFamilyAnalytics()
        {
            var job = new Rock.Jobs.CalculateFamilyAnalytics();

            var success = ExecuteRockJob( "CalculateFamilyAnalytics", () => { job.ExecuteInternal( new Dictionary<string, string>() ); } );

            return success;
        }

        public bool RunJobProcessBiAnalytics()
        {
            var job = new Rock.Jobs.ProcessBIAnalytics();

            var biAnalyticsSettings = new Dictionary<string, string>();
            biAnalyticsSettings.AddOrReplace( Rock.Jobs.ProcessBIAnalytics.AttributeKey.ProcessPersonBIAnalytics, "true" );
            biAnalyticsSettings.AddOrReplace( Rock.Jobs.ProcessBIAnalytics.AttributeKey.ProcessFamilyBIAnalytics, "true" );
            biAnalyticsSettings.AddOrReplace( Rock.Jobs.ProcessBIAnalytics.AttributeKey.ProcessAttendanceBIAnalytics, "true" );

            var success = ExecuteRockJob( "ProcessBiAnalytics", () => { job.ExecuteInternal( biAnalyticsSettings ); } );

            return success;
        }

        private static bool ExecuteRockJob( string jobName, Action action )
        {
            try
            {
                TestHelper.Log( $"Job Started: {jobName}..." );
                action();
                TestHelper.Log( $"Job Completed: {jobName}..." );
                return true;
            }
            catch ( Exception ex )
            {
                TestHelper.Log( $"WARNING: Job failed. [Job={jobName}]\n{ex.ToString()}" );
                return false;
            }
        }

    }
}

