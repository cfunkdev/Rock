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
    /// EventItemOccurrence View Model
    /// </summary>
    [ViewModelOf( typeof( Rock.Model.EventItemOccurrence ) )]
    public partial class EventItemOccurrenceViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the CampusId.
        /// </summary>
        /// <value>
        /// The CampusId.
        /// </value>
        public int? CampusId { get; set; }

        /// <summary>
        /// Gets or sets the ContactEmail.
        /// </summary>
        /// <value>
        /// The ContactEmail.
        /// </value>
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the ContactPersonAliasId.
        /// </summary>
        /// <value>
        /// The ContactPersonAliasId.
        /// </value>
        public int? ContactPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the ContactPhone.
        /// </summary>
        /// <value>
        /// The ContactPhone.
        /// </value>
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the EventItemId.
        /// </summary>
        /// <value>
        /// The EventItemId.
        /// </value>
        public int EventItemId { get; set; }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        /// <value>
        /// The Location.
        /// </value>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Note.
        /// </summary>
        /// <value>
        /// The Note.
        /// </value>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the ScheduleId.
        /// </summary>
        /// <value>
        /// The ScheduleId.
        /// </value>
        public int? ScheduleId { get; set; }

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
        public virtual void SetPropertiesFrom( Rock.Model.EventItemOccurrence model, Person currentPerson = null, bool loadAttributes = true )
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

            CampusId = model.CampusId;
            ContactEmail = model.ContactEmail;
            ContactPersonAliasId = model.ContactPersonAliasId;
            ContactPhone = model.ContactPhone;
            EventItemId = model.EventItemId;
            Location = model.Location;
            Note = model.Note;
            ScheduleId = model.ScheduleId;
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
        public static EventItemOccurrenceViewModel From( Rock.Model.EventItemOccurrence model, Person currentPerson = null, bool loadAttributes = true )
        {
            var viewModel = new EventItemOccurrenceViewModel();
            viewModel.SetPropertiesFrom( model, currentPerson, loadAttributes );
            return viewModel;
        }
    }
}
