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
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;
using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// 
    /// </summary>
    [RockDomain( "Group" )]
    [Table( "GroupMemberAssignment" )]
    [DataContract]
    [Rock.SystemGuid.EntityTypeGuid( "22BF14ED-E882-4BB0-9328-D12545BF5F61")]
    public class GroupMemberAssignment : Model<GroupMemberAssignment>
    {
        #region Entity Properties

        /// <summary>
        /// Gets or sets the <see cref="Rock.Model.GroupMember"/> identifier.
        /// </summary>
        /// <value>
        /// The group member identifier.
        /// </value>
        [DataMember]
#if REVIEW_WEBFORMS
        [Index( "IX_GroupMemberIdLocationIdScheduleId", IsUnique = true, Order = 0 )]
#endif
        [IgnoreCanDelete]
        public int GroupMemberId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Rock.Model.Location"/> identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        [DataMember]
#if REVIEW_WEBFORMS
        [Index( "IX_GroupMemberIdLocationIdScheduleId", IsUnique = true, Order = 1 )]
#endif
        public int? LocationId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Rock.Model.Schedule"/> identifier.
        /// </summary>
        /// <value>
        /// The schedule identifier.
        /// </value>
        [DataMember]
#if REVIEW_WEBFORMS
        [Index( "IX_GroupMemberIdLocationIdScheduleId", IsUnique = true, Order = 2 )]
#endif
        public int? ScheduleId { get; set; }

        /// <summary>
        /// The date and time when the last RSVP reminder sent.
        /// </summary>
        /// <value>
        /// The last RSVP reminder sent.
        /// </value>
        [DataMember]
        public DateTime? LastRSVPReminderSentDateTime { get; set; }

        /// <summary>
        /// The date and time when the confirmation is sent.
        /// </summary>
        /// <value>
        /// The confirmation is sent.
        /// </value>
        [DataMember]
        public DateTime? ConfirmationSentDateTime { get; set; }

        #endregion Entity Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the <see cref="Rock.Model.GroupMember"/>.
        /// </summary>
        /// <value>
        /// The group member.
        /// </value>
        public virtual GroupMember GroupMember { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Rock.Model.Location"/>.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [DataMember]
        public virtual Location Location { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Rock.Model.Schedule"/>.
        /// </summary>
        /// <value>
        /// The schedule.
        /// </value>
        [DataMember]
        public virtual Schedule Schedule { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if ( GroupMember != null )
            {
                return $"{GroupMember} in {this.GroupMember.Group} is assigned to {Location.ToString( true ) ?? "any location"} at {Schedule.ToString() ?? "any schedule"}. ";
            }
            else
            {
                return base.ToString();
            }
        }

        #endregion
    }

    /// <summary>
    /// GroupMemberAssignment EntityTypeConfiguration
    /// </summary>
    public class GroupMemberAssignmentConfiguration : EntityTypeConfiguration<GroupMemberAssignment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMemberAssignmentConfiguration"/> class.
        /// </summary>
        public GroupMemberAssignmentConfiguration()
        {
            this.HasRequired( a => a.GroupMember ).WithMany( a => a.GroupMemberAssignments ).HasForeignKey( a => a.GroupMemberId ).WillCascadeOnDelete( false );
            this.HasOptional( a => a.Schedule ).WithMany().HasForeignKey( a => a.ScheduleId ).WillCascadeOnDelete( false );
            this.HasOptional( a => a.Location ).WithMany().HasForeignKey( a => a.LocationId ).WillCascadeOnDelete( false );
        }
    }
}
