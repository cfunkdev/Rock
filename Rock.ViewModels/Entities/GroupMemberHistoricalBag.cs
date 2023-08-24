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
    /// GroupMemberHistorical View Model
    /// </summary>
    public partial class GroupMemberHistoricalBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the PersonAliasId that archived (soft deleted) this group member at this point in history
        /// </summary>
        /// <value>
        /// The archived by person alias identifier.
        /// </value>
        public int? ArchivedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the archived date time value of this group member at this point in history
        /// </summary>
        /// <value>
        /// The archived date time.
        /// </value>
        public DateTime? ArchivedDateTime { get; set; }

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
        /// Gets or sets GroupId for this group member record at this point in history
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public int GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group member id of the group member for this group member historical record
        /// </summary>
        /// <value>
        /// The group member identifier.
        /// </value>
        public int GroupMemberId { get; set; }

        /// <summary>
        /// Gets or sets the group member status of this group member at this point in history
        /// </summary>
        /// <value>
        /// The group member status.
        /// </value>
        public int GroupMemberStatus { get; set; }

        /// <summary>
        /// Gets or sets the group role id for this group member at this point in history
        /// </summary>
        /// <value>
        /// The group role identifier.
        /// </value>
        public int GroupRoleId { get; set; }

        /// <summary>
        /// Gets or sets the group role name at this point in history
        /// </summary>
        /// <value>
        /// The name of the group role.
        /// </value>
        public string GroupRoleName { get; set; }

        /// <summary>
        /// Gets or sets the InActiveDateTime value of the group member at this point in history (the time when the group member status was changed to GroupMemberStatus.Inactive)
        /// </summary>
        /// <value>
        /// The in active date time.
        /// </value>
        public DateTime? InactiveDateTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this group member was archived at this point in history
        /// </summary>
        /// <value>
        ///   true if this instance is archived; otherwise, false.
        /// </value>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the group member was IsLeader (which is determined by GroupRole.IsLeader) at this point in history
        /// </summary>
        /// <value>
        ///   true if this instance is leader; otherwise, false.
        /// </value>
        public bool IsLeader { get; set; }

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