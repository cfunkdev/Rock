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

using Rock.ViewModels.Utility;

namespace Rock.ViewModels.Entities
{
    /// <summary>
    /// EventItemOccurrence View Model
    /// </summary>
    public partial class EventItemOccurrenceBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the Rock.Model.Campus identifier.
        /// </summary>
        /// <value>
        /// The campus identifier.
        /// </value>
        public int? CampusId { get; set; }

        /// <summary>
        /// Gets or sets the Contact Person's email address.
        /// </summary>
        /// <value>
        /// A System.String containing the Contact Person's email address.
        /// </value>
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.PersonAlias for the EventItemOccurrence's contact person. This property is required.
        /// </summary>
        /// <value>
        /// An System.Int32 representing the Id of the Rock.Model.PersonAlias who is the EventItemOccurrence's contact person.
        /// </value>
        public int? ContactPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the Contact Person's phone number.
        /// </summary>
        /// <value>
        /// A System.String containing the Contact Person's phone number.
        /// </value>
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.EventItem identifier.
        /// </summary>
        /// <value>
        /// The event item identifier.
        /// </value>
        public int EventItemId { get; set; }

        /// <summary>
        /// Gets or sets the Description of the Location.
        /// </summary>
        /// <value>
        /// A System.String representing the description of the Location.
        /// </value>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the datetime for the next scheduled occurrence of this event. 
        /// </summary>
        /// <value>
        /// The datetime of the next occurrence.
        /// </value>
        public DateTime? NextStartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the campus note.
        /// </summary>
        /// <value>
        /// A System.String representing the campus note.
        /// </value>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.Schedule identifier.
        /// </summary>
        /// <value>
        /// The schedule identifier.
        /// </value>
        public int? ScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the created by person alias identifier.
        /// </summary>
        /// <value>
        /// The created by person alias identifier.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the modified by person alias identifier.
        /// </summary>
        /// <value>
        /// The modified by person alias identifier.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

    }
}
