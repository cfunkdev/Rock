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
    /// NcoaHistory View Model
    /// </summary>
    [ViewModelOf( typeof( Rock.Model.NcoaHistory ) )]
    public partial class NcoaHistoryViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the AddressInvalidReason.
        /// </summary>
        /// <value>
        /// The AddressInvalidReason.
        /// </value>
        public int AddressInvalidReason { get; set; }

        /// <summary>
        /// Gets or sets the AddressStatus.
        /// </summary>
        /// <value>
        /// The AddressStatus.
        /// </value>
        public int AddressStatus { get; set; }

        /// <summary>
        /// Gets or sets the FamilyId.
        /// </summary>
        /// <value>
        /// The FamilyId.
        /// </value>
        public int FamilyId { get; set; }

        /// <summary>
        /// Gets or sets the LocationId.
        /// </summary>
        /// <value>
        /// The LocationId.
        /// </value>
        public int? LocationId { get; set; }

        /// <summary>
        /// Gets or sets the MatchFlag.
        /// </summary>
        /// <value>
        /// The MatchFlag.
        /// </value>
        public int MatchFlag { get; set; }

        /// <summary>
        /// Gets or sets the MoveDate.
        /// </summary>
        /// <value>
        /// The MoveDate.
        /// </value>
        public DateTime? MoveDate { get; set; }

        /// <summary>
        /// Gets or sets the MoveDistance.
        /// </summary>
        /// <value>
        /// The MoveDistance.
        /// </value>
        public decimal? MoveDistance { get; set; }

        /// <summary>
        /// Gets or sets the MoveType.
        /// </summary>
        /// <value>
        /// The MoveType.
        /// </value>
        public int MoveType { get; set; }

        /// <summary>
        /// Gets or sets the NcoaNote.
        /// </summary>
        /// <value>
        /// The NcoaNote.
        /// </value>
        public string NcoaNote { get; set; }

        /// <summary>
        /// Gets or sets the NcoaRunDateTime.
        /// </summary>
        /// <value>
        /// The NcoaRunDateTime.
        /// </value>
        public DateTime NcoaRunDateTime { get; set; }

        /// <summary>
        /// Gets or sets the NcoaType.
        /// </summary>
        /// <value>
        /// The NcoaType.
        /// </value>
        public int NcoaType { get; set; }

        /// <summary>
        /// Gets or sets the OriginalCity.
        /// </summary>
        /// <value>
        /// The OriginalCity.
        /// </value>
        public string OriginalCity { get; set; }

        /// <summary>
        /// Gets or sets the OriginalPostalCode.
        /// </summary>
        /// <value>
        /// The OriginalPostalCode.
        /// </value>
        public string OriginalPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the OriginalState.
        /// </summary>
        /// <value>
        /// The OriginalState.
        /// </value>
        public string OriginalState { get; set; }

        /// <summary>
        /// Gets or sets the OriginalStreet1.
        /// </summary>
        /// <value>
        /// The OriginalStreet1.
        /// </value>
        public string OriginalStreet1 { get; set; }

        /// <summary>
        /// Gets or sets the OriginalStreet2.
        /// </summary>
        /// <value>
        /// The OriginalStreet2.
        /// </value>
        public string OriginalStreet2 { get; set; }

        /// <summary>
        /// Gets or sets the PersonAliasId.
        /// </summary>
        /// <value>
        /// The PersonAliasId.
        /// </value>
        public int PersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the Processed.
        /// </summary>
        /// <value>
        /// The Processed.
        /// </value>
        public int Processed { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedAddressType.
        /// </summary>
        /// <value>
        /// The UpdatedAddressType.
        /// </value>
        public int UpdatedAddressType { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedBarcode.
        /// </summary>
        /// <value>
        /// The UpdatedBarcode.
        /// </value>
        public string UpdatedBarcode { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedCity.
        /// </summary>
        /// <value>
        /// The UpdatedCity.
        /// </value>
        public string UpdatedCity { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedCountry.
        /// </summary>
        /// <value>
        /// The UpdatedCountry.
        /// </value>
        public string UpdatedCountry { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedPostalCode.
        /// </summary>
        /// <value>
        /// The UpdatedPostalCode.
        /// </value>
        public string UpdatedPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedState.
        /// </summary>
        /// <value>
        /// The UpdatedState.
        /// </value>
        public string UpdatedState { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedStreet1.
        /// </summary>
        /// <value>
        /// The UpdatedStreet1.
        /// </value>
        public string UpdatedStreet1 { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedStreet2.
        /// </summary>
        /// <value>
        /// The UpdatedStreet2.
        /// </value>
        public string UpdatedStreet2 { get; set; }

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
        public virtual void SetPropertiesFrom( Rock.Model.NcoaHistory model, Person currentPerson = null, bool loadAttributes = true )
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

            AddressInvalidReason = ( int ) model.AddressInvalidReason;
            AddressStatus = ( int ) model.AddressStatus;
            FamilyId = model.FamilyId;
            LocationId = model.LocationId;
            MatchFlag = ( int ) model.MatchFlag;
            MoveDate = model.MoveDate;
            MoveDistance = model.MoveDistance;
            MoveType = ( int ) model.MoveType;
            NcoaNote = model.NcoaNote;
            NcoaRunDateTime = model.NcoaRunDateTime;
            NcoaType = ( int ) model.NcoaType;
            OriginalCity = model.OriginalCity;
            OriginalPostalCode = model.OriginalPostalCode;
            OriginalState = model.OriginalState;
            OriginalStreet1 = model.OriginalStreet1;
            OriginalStreet2 = model.OriginalStreet2;
            PersonAliasId = model.PersonAliasId;
            Processed = ( int ) model.Processed;
            UpdatedAddressType = ( int ) model.UpdatedAddressType;
            UpdatedBarcode = model.UpdatedBarcode;
            UpdatedCity = model.UpdatedCity;
            UpdatedCountry = model.UpdatedCountry;
            UpdatedPostalCode = model.UpdatedPostalCode;
            UpdatedState = model.UpdatedState;
            UpdatedStreet1 = model.UpdatedStreet1;
            UpdatedStreet2 = model.UpdatedStreet2;
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
        public static NcoaHistoryViewModel From( Rock.Model.NcoaHistory model, Person currentPerson = null, bool loadAttributes = true )
        {
            var viewModel = new NcoaHistoryViewModel();
            viewModel.SetPropertiesFrom( model, currentPerson, loadAttributes );
            return viewModel;
        }
    }
}
