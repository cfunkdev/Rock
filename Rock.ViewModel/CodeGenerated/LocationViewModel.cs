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
//

using System;
using System.Linq;
using Rock.Attribute;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.ViewModel
{
    /// <summary>
    /// Location View Model
    /// </summary>
    [ViewModelOf( typeof( Rock.Model.Location ) )]
    public partial class LocationViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the AssessorParcelId.
        /// </summary>
        /// <value>
        /// The AssessorParcelId.
        /// </value>
        public string AssessorParcelId { get; set; }

        /// <summary>
        /// Gets or sets the Barcode.
        /// </summary>
        /// <value>
        /// The Barcode.
        /// </value>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        /// <value>
        /// The City.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>
        /// The Country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the County.
        /// </summary>
        /// <value>
        /// The County.
        /// </value>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the FirmRoomThreshold.
        /// </summary>
        /// <value>
        /// The FirmRoomThreshold.
        /// </value>
        public int? FirmRoomThreshold { get; set; }

        /// <summary>
        /// Gets or sets the GeocodeAttemptedDateTime.
        /// </summary>
        /// <value>
        /// The GeocodeAttemptedDateTime.
        /// </value>
        public DateTime? GeocodeAttemptedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the GeocodeAttemptedResult.
        /// </summary>
        /// <value>
        /// The GeocodeAttemptedResult.
        /// </value>
        public string GeocodeAttemptedResult { get; set; }

        /// <summary>
        /// Gets or sets the GeocodeAttemptedServiceType.
        /// </summary>
        /// <value>
        /// The GeocodeAttemptedServiceType.
        /// </value>
        public string GeocodeAttemptedServiceType { get; set; }

        /// <summary>
        /// Gets or sets the GeocodedDateTime.
        /// </summary>
        /// <value>
        /// The GeocodedDateTime.
        /// </value>
        public DateTime? GeocodedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the GeoFence.
        /// </summary>
        /// <value>
        /// The GeoFence.
        /// </value>
        public object GeoFence { get; set; }

        /// <summary>
        /// Gets or sets the GeoPoint.
        /// </summary>
        /// <value>
        /// The GeoPoint.
        /// </value>
        public object GeoPoint { get; set; }

        /// <summary>
        /// Gets or sets the ImageId.
        /// </summary>
        /// <value>
        /// The ImageId.
        /// </value>
        public int? ImageId { get; set; }

        /// <summary>
        /// Gets or sets the IsActive.
        /// </summary>
        /// <value>
        /// The IsActive.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the IsGeoPointLocked.
        /// </summary>
        /// <value>
        /// The IsGeoPointLocked.
        /// </value>
        public bool? IsGeoPointLocked { get; set; }

        /// <summary>
        /// Gets or sets the LocationTypeValueId.
        /// </summary>
        /// <value>
        /// The LocationTypeValueId.
        /// </value>
        public int? LocationTypeValueId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ParentLocationId.
        /// </summary>
        /// <value>
        /// The ParentLocationId.
        /// </value>
        public int? ParentLocationId { get; set; }

        /// <summary>
        /// Gets or sets the PostalCode.
        /// </summary>
        /// <value>
        /// The PostalCode.
        /// </value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the PrinterDeviceId.
        /// </summary>
        /// <value>
        /// The PrinterDeviceId.
        /// </value>
        public int? PrinterDeviceId { get; set; }

        /// <summary>
        /// Gets or sets the SoftRoomThreshold.
        /// </summary>
        /// <value>
        /// The SoftRoomThreshold.
        /// </value>
        public int? SoftRoomThreshold { get; set; }

        /// <summary>
        /// Gets or sets the StandardizeAttemptedDateTime.
        /// </summary>
        /// <value>
        /// The StandardizeAttemptedDateTime.
        /// </value>
        public DateTime? StandardizeAttemptedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the StandardizeAttemptedResult.
        /// </summary>
        /// <value>
        /// The StandardizeAttemptedResult.
        /// </value>
        public string StandardizeAttemptedResult { get; set; }

        /// <summary>
        /// Gets or sets the StandardizeAttemptedServiceType.
        /// </summary>
        /// <value>
        /// The StandardizeAttemptedServiceType.
        /// </value>
        public string StandardizeAttemptedServiceType { get; set; }

        /// <summary>
        /// Gets or sets the StandardizedDateTime.
        /// </summary>
        /// <value>
        /// The StandardizedDateTime.
        /// </value>
        public DateTime? StandardizedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        /// <value>
        /// The State.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Street1.
        /// </summary>
        /// <value>
        /// The Street1.
        /// </value>
        public string Street1 { get; set; }

        /// <summary>
        /// Gets or sets the Street2.
        /// </summary>
        /// <value>
        /// The Street2.
        /// </value>
        public string Street2 { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDateTime.
        /// </summary>
        /// <value>
        /// The CreatedDateTime.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedDateTime.
        /// </summary>
        /// <value>
        /// The ModifiedDateTime.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the CreatedByPersonAliasId.
        /// </summary>
        /// <value>
        /// The CreatedByPersonAliasId.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedByPersonAliasId.
        /// </summary>
        /// <value>
        /// The ModifiedByPersonAliasId.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

        /// <summary>
        /// Sets the properties from.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        public virtual void SetPropertiesFrom( Rock.Model.Location model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return;
            }

            if ( loadAttributes && model is IHasAttributes hasAttributes )
            {
                if ( hasAttributes.Attributes == null )
                {
                    hasAttributes.LoadAttributes();
                }

                Attributes = hasAttributes.AttributeValues.Where( av =>
                {
                    var attribute = AttributeCache.Get( av.Value.AttributeId );
                    return attribute?.IsAuthorized( Rock.Security.Authorization.EDIT, currentPerson ) ?? false;
                } ).ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.ToViewModel<AttributeValueViewModel>() as object );
            }

            AssessorParcelId = model.AssessorParcelId;
            Barcode = model.Barcode;
            City = model.City;
            Country = model.Country;
            County = model.County;
            FirmRoomThreshold = model.FirmRoomThreshold;
            GeocodeAttemptedDateTime = model.GeocodeAttemptedDateTime;
            GeocodeAttemptedResult = model.GeocodeAttemptedResult;
            GeocodeAttemptedServiceType = model.GeocodeAttemptedServiceType;
            GeocodedDateTime = model.GeocodedDateTime;
            GeoFence = model.GeoFence;
            GeoPoint = model.GeoPoint;
            ImageId = model.ImageId;
            IsActive = model.IsActive;
            IsGeoPointLocked = model.IsGeoPointLocked;
            LocationTypeValueId = model.LocationTypeValueId;
            Name = model.Name;
            ParentLocationId = model.ParentLocationId;
            PostalCode = model.PostalCode;
            PrinterDeviceId = model.PrinterDeviceId;
            SoftRoomThreshold = model.SoftRoomThreshold;
            StandardizeAttemptedDateTime = model.StandardizeAttemptedDateTime;
            StandardizeAttemptedResult = model.StandardizeAttemptedResult;
            StandardizeAttemptedServiceType = model.StandardizeAttemptedServiceType;
            StandardizedDateTime = model.StandardizedDateTime;
            State = model.State;
            Street1 = model.Street1;
            Street2 = model.Street2;
            CreatedDateTime = model.CreatedDateTime;
            ModifiedDateTime = model.ModifiedDateTime;
            CreatedByPersonAliasId = model.CreatedByPersonAliasId;
            ModifiedByPersonAliasId = model.ModifiedByPersonAliasId;

            SetAdditionalPropertiesFrom( model, currentPerson, loadAttributes );
        }

        /// <summary>
        /// Creates a view model from the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="currentPerson" >The current person.</param>
        /// <param name="loadAttributes" >if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public static LocationViewModel From( Rock.Model.Location model, Person currentPerson = null, bool loadAttributes = true )
        {
            var viewModel = new LocationViewModel();
            viewModel.SetPropertiesFrom( model, currentPerson, loadAttributes );
            return viewModel;
        }
    }
}
