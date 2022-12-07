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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quartz;
using Rock.IpAddress;
using Rock.Jobs;
using Rock.Tests.Integration.Jobs;
using Rock.Tests.Shared;

namespace Rock.Tests.Integration.Interactions
{
    [TestClass]
    public class PopulateInteractionSessionTests
    {
        /// <summary>
        /// The API Keys associated with a valid ipregistry.com account.
        /// For testing purposes, create a free account at http://ipregistery.co
        /// and use the default API Key associated with the account.
        /// </summary>
        private const string IpRegistryApiKeyHasZeroCredit = "6y3c071363eqou2y";
        private const string IpRegistryApiKeyHasPositiveCredit = "rg5z35nb9f8or00u";

        #region Lookup IP Addresses

        [TestMethod]
        public void IpRegistryComponent_IpAddressHavingNoLocation_IsResolvedCorrectly()
        {
            var registryComponent = new IpRegistryMock();

            // Attempt to resolve a loopback address that has no location.
            var ipAddresses = new List<string> { "192.168.0.1" };

            try
            {
                var results = registryComponent.BulkLookup( ipAddresses, out var message );
            }
            catch ( Exception ex )
            {
                // Deserialization of Latitude/Longitude fails.
                Assert.Fail( ex.Message );
            }
        }

        /// <summary>
        /// Verifies that a request to check the account credit balance can be made without incurring any charges.
        /// </summary>
        [TestMethod]
        public void IpRegistryComponent_ServiceStatusRequest_DoesNotExpendCredit()
        {
            IpRegistryMock registryComponent;
            IpRegistryStatusInfo status1;
            IpRegistryStatusInfo status2;

            registryComponent = new IpRegistryMock()
            {
                ApiKey = IpRegistryApiKeyHasPositiveCredit
            };

            // Request the service status twice, to verify that the available credits remain the same.
            // The request has been framed in a way that it does not itself consume any account credit,
            // but this could be impacted by future changes by the third-party service provider.
            status1 = registryComponent.GetServiceStatus();
            status2 = registryComponent.GetServiceStatus();

            Assert.IsTrue( status1.IsAvailable, "Service Status Request is invalid." );
            Assert.IsTrue( status1.AvailableCreditTotal == status2.AvailableCreditTotal, "Service Status Request incurred an unexpected charge." );

            // Verify that the status is returned correctly for an account with a zero balance.
            registryComponent = new IpRegistryMock()
            {
                ApiKey = IpRegistryApiKeyHasZeroCredit
            };

            status1 = registryComponent.GetServiceStatus();
            Assert.IsTrue( status1.AvailableCreditTotal == 0, "Service Status Request returned an unexpected value." );
        }

        [TestMethod]
        public void IpRegistryComponent_InvalidIpAddress_ReturnsError()
        {
            var registryComponent = new IpRegistryMock();

            // Attempt to resolve a loopback address that has no location.
            var ipAddresses = new List<string> { "a.b.c.d" };

            try
            {
                var results = registryComponent.BulkLookup( ipAddresses, out var message );
            }
            catch ( Exception ex )
            {
                // Deserialization of Latitude/Longitude fails.
                Assert.Fail( ex.Message );
            }
        }
        /// <summary>
        /// If there is an issue with the IP Registry Provider, batch processing should terminate early.
        /// </summary>
        [TestMethod]
        public void IpRegistryComponent_WithValidAccount_ResolvesAddressesCorrectly()
        {
            var registryComponent = new IpRegistryMock();

            // Get a randomized collection of IP Addresses.
            var ipAddresses = new List<string>();
            var random = new Random();
            for ( int i = 0; i < 10; i++ )
            {
                ipAddresses.Add( $"{random.Next( 0, 255 )}.{random.Next( 0, 255 )}.{random.Next( 0, 255 )}.{random.Next( 0, 255 )}" );
            }

            var results = registryComponent.BulkLookup( ipAddresses, out var message );

            Assert.IsTrue( results.Count > 0 );
        }

        #endregion

        #region Populate Interaction Sessions Job.

        /// <summary>
        /// If the IP Registry Provider is correctly configured, batch processing should complete successfully.
        /// </summary>
        [TestMethod]
        public void InteractionSessionPopulateLocation_WithConfiguredIpRegistryProvider_CompletesSuccessfully()
        {
            var jobContext = new TestJobContext();

            var dataMap = jobContext.JobDetail.JobDataMap;
            dataMap[PopulateInteractionSessionData.AttributeKey.MaxRecordsToProcessPerRun] = "10";

            var registryComponent = new IpRegistryMock()
            {
                ApiKey = IpRegistryApiKeyHasPositiveCredit
            };
            var job = new PopulateInteractionSessionDataMock()
            {
                LookupComponent = registryComponent
            };

            var jobOutput = job.ProcessInteractionSessionForIP( jobContext );

            // Check for success badge.
            Assert.That.Contains( jobOutput, "<i class='fa fa-circle text-success'></i>" );
        }

        /// <summary>
        /// If there is a fatal issue with the IP Registry Provider, batch processing should terminate early.
        /// </summary>
        [TestMethod]
        public void InteractionSessionPopulateLocation_WithIpRegistryProviderAccountHavingNoCredit_TerminatesWithError()
        {
            var jobContext = new TestJobContext();

            var dataMap = jobContext.JobDetail.JobDataMap;
            dataMap[PopulateInteractionSessionData.AttributeKey.MaxRecordsToProcessPerRun] = "10";

            var registryComponent = new IpRegistryMock()
            {
                ApiKey = IpRegistryApiKeyHasZeroCredit
            };
            var job = new PopulateInteractionSessionDataMock()
            {
                LookupComponent = registryComponent
            };

            var jobOutput = job.ProcessInteractionSessionForIP( jobContext );

            Assert.That.Contains( jobOutput, "Insufficient account credit to process the request" );
        }

        #endregion

        #region Support classes

        public class PopulateInteractionSessionDataMock : PopulateInteractionSessionData
        {
            public IpAddressLookupComponent LookupComponent { get; set; }

            internal override IpAddressLookupComponent GetLookupComponent( string configuredProvider )
            {
                return LookupComponent;
            }
        }

        public class IpRegistryMock : IpRegistry
        {
            public string ApiKey { get; set; } = IpRegistryApiKeyHasPositiveCredit;

            public override string GetAttributeValue( string key )
            {
                if ( key == "APIKey" )
                {
                    return ApiKey;
                }
                throw new Exception( "Invalid Test Attribute Key." );
            }
        }

        #endregion
    }
}
