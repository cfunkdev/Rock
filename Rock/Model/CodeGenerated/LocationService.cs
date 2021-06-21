//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
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

using System;
using System.Linq;

using Rock.Attribute;
using Rock.Data;
using Rock.ViewModel;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// Location Service class
    /// </summary>
    public partial class LocationService : Service<Location>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public LocationService(RockContext context) : base(context)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( Location item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<BenevolenceRequest>( Context ).Queryable().Any( a => a.LocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, BenevolenceRequest.FriendlyTypeName );
                return false;
            }

            if ( new Service<Campus>( Context ).Queryable().Any( a => a.LocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, Campus.FriendlyTypeName );
                return false;
            }

            if ( new Service<Device>( Context ).Queryable().Any( a => a.LocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, Device.FriendlyTypeName );
                return false;
            }

            if ( new Service<FinancialPaymentDetail>( Context ).Queryable().Any( a => a.BillingLocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, FinancialPaymentDetail.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupLocationHistorical>( Context ).Queryable().Any( a => a.LocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, GroupLocationHistorical.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupMemberAssignment>( Context ).Queryable().Any( a => a.LocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, GroupMemberAssignment.FriendlyTypeName );
                return false;
            }

            if ( new Service<Location>( Context ).Queryable().Any( a => a.ParentLocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} contains one or more child {1}.", Location.FriendlyTypeName, Location.FriendlyTypeName.Pluralize().ToLower() );
                return false;
            }

            if ( new Service<Streak>( Context ).Queryable().Any( a => a.LocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, Streak.FriendlyTypeName );
                return false;
            }

            if ( new Service<StreakTypeExclusion>( Context ).Queryable().Any( a => a.LocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, StreakTypeExclusion.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Location View Model Helper
    /// </summary>
    public partial class LocationViewModelHelper : ViewModelHelper<Location, Rock.ViewModel.LocationViewModel>
    {
        /// <summary>
        /// Converts to viewmodel.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override Rock.ViewModel.LocationViewModel CreateViewModel( Location model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new Rock.ViewModel.LocationViewModel
            {
                Id = model.Id,
                Guid = model.Guid,
                AssessorParcelId = model.AssessorParcelId,
                Barcode = model.Barcode,
                City = model.City,
                Country = model.Country,
                County = model.County,
                FirmRoomThreshold = model.FirmRoomThreshold,
                GeocodeAttemptedDateTime = model.GeocodeAttemptedDateTime,
                GeocodeAttemptedResult = model.GeocodeAttemptedResult,
                GeocodeAttemptedServiceType = model.GeocodeAttemptedServiceType,
                GeocodedDateTime = model.GeocodedDateTime,
                GeoFence = model.GeoFence,
                GeoPoint = model.GeoPoint,
                ImageId = model.ImageId,
                IsActive = model.IsActive,
                IsGeoPointLocked = model.IsGeoPointLocked,
                LocationTypeValueId = model.LocationTypeValueId,
                Name = model.Name,
                ParentLocationId = model.ParentLocationId,
                PostalCode = model.PostalCode,
                PrinterDeviceId = model.PrinterDeviceId,
                SoftRoomThreshold = model.SoftRoomThreshold,
                StandardizeAttemptedDateTime = model.StandardizeAttemptedDateTime,
                StandardizeAttemptedResult = model.StandardizeAttemptedResult,
                StandardizeAttemptedServiceType = model.StandardizeAttemptedServiceType,
                StandardizedDateTime = model.StandardizedDateTime,
                State = model.State,
                Street1 = model.Street1,
                Street2 = model.Street2,
                CreatedDateTime = model.CreatedDateTime,
                ModifiedDateTime = model.ModifiedDateTime,
                CreatedByPersonAliasId = model.CreatedByPersonAliasId,
                ModifiedByPersonAliasId = model.ModifiedByPersonAliasId,
            };

            AddAttributesToViewModel( model, viewModel, currentPerson, loadAttributes );
            ApplyAdditionalPropertiesAndSecurityToViewModel( model, viewModel, currentPerson, loadAttributes );
            return viewModel;
        }
    }


    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class LocationExtensionMethods
    {
        /// <summary>
        /// Clones this Location object to a new Location object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static Location Clone( this Location source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as Location;
            }
            else
            {
                var target = new Location();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this Location object to a new Location object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Location CloneWithoutIdentity( this Location source )
        {
            var target = new Location();
            target.CopyPropertiesFrom( source );

            target.Id = 0;
            target.Guid = Guid.NewGuid();
            target.ForeignKey = null;
            target.ForeignId = null;
            target.ForeignGuid = null;
            target.CreatedByPersonAliasId = null;
            target.CreatedDateTime = RockDateTime.Now;
            target.ModifiedByPersonAliasId = null;
            target.ModifiedDateTime = RockDateTime.Now;

            return target;
        }

        /// <summary>
        /// Copies the properties from another Location object to this Location object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this Location target, Location source )
        {
            target.Id = source.Id;
            target.AssessorParcelId = source.AssessorParcelId;
            target.Barcode = source.Barcode;
            target.City = source.City;
            target.Country = source.Country;
            target.County = source.County;
            target.FirmRoomThreshold = source.FirmRoomThreshold;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.GeocodeAttemptedDateTime = source.GeocodeAttemptedDateTime;
            target.GeocodeAttemptedResult = source.GeocodeAttemptedResult;
            target.GeocodeAttemptedServiceType = source.GeocodeAttemptedServiceType;
            target.GeocodedDateTime = source.GeocodedDateTime;
            target.GeoFence = source.GeoFence;
            target.GeoPoint = source.GeoPoint;
            target.ImageId = source.ImageId;
            target.IsActive = source.IsActive;
            target.IsGeoPointLocked = source.IsGeoPointLocked;
            target.LocationTypeValueId = source.LocationTypeValueId;
            target.Name = source.Name;
            target.ParentLocationId = source.ParentLocationId;
            target.PostalCode = source.PostalCode;
            target.PrinterDeviceId = source.PrinterDeviceId;
            target.SoftRoomThreshold = source.SoftRoomThreshold;
            target.StandardizeAttemptedDateTime = source.StandardizeAttemptedDateTime;
            target.StandardizeAttemptedResult = source.StandardizeAttemptedResult;
            target.StandardizeAttemptedServiceType = source.StandardizeAttemptedServiceType;
            target.StandardizedDateTime = source.StandardizedDateTime;
            target.State = source.State;
            target.Street1 = source.Street1;
            target.Street2 = source.Street2;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }

        /// <summary>
        /// Creates a view model from this entity
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson" >The currentPerson.</param>
        /// <param name="loadAttributes" >Load attributes?</param>
        public static Rock.ViewModel.LocationViewModel ToViewModel( this Location model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new LocationViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
