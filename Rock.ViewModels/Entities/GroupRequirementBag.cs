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
    /// GroupRequirement View Model
    /// </summary>
    public partial class GroupRequirementBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets whether leaders are allowed to mark requirements as met manually.
        /// </summary>
        public bool AllowLeadersToOverride { get; set; }

        /// <summary>
        /// Gets or sets the "Applies To" Age Classification.
        /// </summary>
        /// <value>
        /// The Age Classification.
        /// </value>
        public int AppliesToAgeClassification { get; set; }

        /// <summary>
        /// Gets or sets the "Applies To" Rock.Model.DataView identifier.
        /// If this property is set, the requirement is only applied to those people who are included in the specified Data View.
        /// Group members that do not exist in this Data View will be assigned a status of "Not Applicable" for this requirement.
        /// </summary>
        /// <value>
        /// The data view identifier.
        /// </value>
        public int? AppliesToDataViewId { get; set; }

        /// <summary>
        /// Gets or sets the "Due Date" attribute identifier for when the Rock.Model.GroupRequirementType.DueDateType is <see cref="F:Rock.Model.DueDateType.GroupAttribute" />.
        /// </summary>
        /// <value>
        /// The attribute identifier.
        /// </value>
        public int? DueDateAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the configured date for when the Rock.Model.GroupRequirementType.DueDateType is <see cref="F:Rock.Model.DueDateType.ConfiguredDate" />.
        /// </summary>
        /// <value>
        /// The due date time.
        /// </value>
        public DateTime? DueDateStaticDate { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.Group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public int? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group requirement type identifier.
        /// </summary>
        /// <value>
        /// The group requirement type identifier.
        /// </value>
        public int GroupRequirementTypeId { get; set; }

        /// <summary>
        /// The specific GroupRoleId that this requirement is for. NULL means this requirement applies to all roles.
        /// </summary>
        /// <value>
        /// The group role identifier.
        /// </value>
        public int? GroupRoleId { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.GroupType identifier.
        /// </summary>
        /// <value>
        /// The group type identifier.
        /// </value>
        public int? GroupTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a member must meet this requirement before adding (only applies to DataView and SQL RequirementCheckType)
        /// </summary>
        /// <value>
        /// true if [must meet requirement to add member]; otherwise, false.
        /// </value>
        public bool MustMeetRequirementToAddMember { get; set; }

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
