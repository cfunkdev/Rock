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
    /// GroupLocationHistorical View Model
    /// </summary>
    public partial class GroupLocationHistoricalBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether [current row indicator].
        /// This will be True if this represents the same values as the current tracked record for this
        /// </summary>
        /// <value>
        ///   true if [current row indicator]; otherwise, false.
        /// </value>
        public bool CurrentRowIndicator { get; set; }

        /// <summary>
        /// Gets or sets the effective date.
        /// This is the starting date that the tracked record had the values reflected in this record
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        public DateTime EffectiveDateTime { get; set; }

        /// <summary>
        /// Gets or sets the expire date time
        /// This is the last date that the tracked record had the values reflected in this record
        /// For example, if a tracked record's Name property changed on '2016-07-14', the ExpireDate of the previously current record will be '2016-07-13', and the EffectiveDate of the current record will be '2016-07-14'
        /// If this is most current record, the ExpireDate will be '9999-01-01'
        /// </summary>
        /// <value>
        /// The expire date.
        /// </value>
        public DateTime ExpireDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.Group id for this group's location at this point in history
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public int GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group location identifier that this is a Historical snapshot for
        /// </summary>
        /// <value>
        /// The group location identifier.
        /// </value>
        public int? GroupLocationId { get; set; }

        /// <summary>
        /// Gets or sets the group's location type name at this point in history (Group.GroupLocation.GroupLocationTypeValue.Value)
        /// </summary>
        /// <value>
        /// The name of the group location type.
        /// </value>
        public string GroupLocationTypeName { get; set; }

        /// <summary>
        /// Gets or sets the group location type value identifier for this group location at this point in history
        /// </summary>
        /// <value>
        /// The group location type value identifier.
        /// </value>
        public int? GroupLocationTypeValueId { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.Location id of this group's location at this point in history
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the Location's ModifiedDateTime. This is used internally to detect if the group's location has changed
        /// </summary>
        /// <value>
        /// The schedule's iCalendarContent
        /// </value>
        public DateTime? LocationModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.Location name of this group's location at this point in history (Group.GroupLocation.Location.ToString())
        /// </summary>
        /// <value>
        /// The location name.
        /// </value>
        public string LocationName { get; set; }

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
