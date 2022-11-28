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
    /// Group View Model
    /// </summary>
    public partial class GroupBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets whether group allows members to specify additional "guests" that will be part of the group (i.e. attend event)
        /// </summary>
        /// <value>
        /// The allow guests flag
        /// </value>
        public bool? AllowGuests { get; set; }

        /// <summary>
        /// Gets or sets the PersonAliasId that archived (soft deleted) this group
        /// </summary>
        /// <value>
        /// The archived by person alias identifier.
        /// </value>
        public int? ArchivedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the date time that this group was archived (soft deleted)
        /// </summary>
        /// <value>
        /// The archived date time.
        /// </value>
        public DateTime? ArchivedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the attendance record required for check in.
        /// </summary>
        /// <value>
        /// The attendance record required for check in.
        /// </value>
        public int AttendanceRecordRequiredForCheckIn { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.Campus that this Group is associated with.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Rock.Model.Campus that the Group is associated with. If the group is not 
        /// associated with a campus, this value is null.
        /// </value>
        public int? CampusId { get; set; }

        /// <summary>
        /// Gets or sets the confirmation additional details.
        /// </summary>
        /// <value>
        /// The confirmation additional details.
        /// </value>
        public string ConfirmationAdditionalDetails { get; set; }

        /// <summary>
        /// Gets or sets the optional description of the group.
        /// </summary>
        /// <value>
        /// A System.String representing the description of the group.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the schedule toolbox access is disabled.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the schedule toolbox access is disabled; otherwise false.
        /// </value>
        public bool DisableScheduleToolboxAccess { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if scheduling is disabled.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if scheduling is disabled; otherwise false.
        /// </value>
        public bool DisableScheduling { get; set; }

        /// <summary>
        /// Gets or sets the elevated security level. This setting is used to determine the group member's Account Protection Profile.
        /// </summary>
        /// <value>
        /// The elevated security level.
        /// </value>
        public int ElevatedSecurityLevel { get; set; }

        /// <summary>
        /// Gets or sets the group capacity.
        /// </summary>
        /// <value>
        /// The group capacity.
        /// </value>
        public int? GroupCapacity { get; set; }

        /// <summary>
        /// List leaders names, in order by males → females.
        /// Examples: Ted &amp; Cindy Decker -or- Ted Decker &amp; Cindy Wright.
        /// This is populated from the logic in Rock.Model.Person.GetFamilySalutation(Rock.Model.Person,System.Boolean,System.Boolean,System.Boolean,System.String,System.String)
        /// with includeChildren=false, and useFormalNames=false.
        /// </summary>
        /// <value>
        /// The group salutation.
        /// </value>
        public string GroupSalutation { get; set; }

        /// <summary>
        /// List all active group members, or order by leaders males → females - non leaders by age.
        /// Examples: Ted, Cindy, Noah and Alex Decker.
        /// This is populated from the logic in Rock.Model.Person.GetFamilySalutation(Rock.Model.Person,System.Boolean,System.Boolean,System.Boolean,System.String,System.String)
        /// with includeChildren=true, and useFormalNames=false.
        /// </summary>
        /// <value>
        /// The group salutation.
        /// </value>
        public string GroupSalutationFull { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.GroupType that this Group is a member belongs to. This property is required.
        /// </summary>
        /// <value>
        /// An System.Int32 representing the Id of the Rock.Model.GroupType that this group is a member of.
        /// </value>
        public int GroupTypeId { get; set; }

        /// <summary>
        /// Gets or sets the date that this group became inactive
        /// </summary>
        /// <value>
        /// The in active date time.
        /// </value>
        public DateTime? InactiveDateTime { get; set; }

        /// <summary>
        /// Gets or sets the inactive reason note.
        /// </summary>
        /// <value>
        /// The inactive reason note.
        /// </value>
        public string InactiveReasonNote { get; set; }

        /// <summary>
        /// Gets or sets the inactive reason value identifier.
        /// </summary>
        /// <value>
        /// The inactive reason value identifier.
        /// </value>
        public int? InactiveReasonValueId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this is an active group. This value is required.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this group is active, otherwise false.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this group is archived (soft deleted)
        /// </summary>
        /// <value>
        ///   true if this instance is archived; otherwise, false.
        /// </value>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the group should be shown in group finders
        /// </summary>
        /// <value>
        ///   true if this instance is public; otherwise, false.
        /// </value>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Indicates this Group is a Security Role even though it isn't a SecurityRole Group Type.
        /// Note: Don't use this alone to determine if a Group is a security role group. Use Rock.Model.Group.IsSecurityRoleOrSecurityGroupType to see if a Group is for a Security Role.
        /// </summary>
        public bool IsSecurityRole { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this Group is a part of the Rock core system/framework. This property is required.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this Group is part of the Rock core system/framework; otherwise false.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Group. This property is required.
        /// </summary>
        /// <value>
        /// A System.String representing the name of the Group. 
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display order of the group in the group list and group hierarchy. The lower the number the higher the 
        /// display priority this group has. This property is required.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the display order of the group.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Group's Parent Group.
        /// </summary>
        /// <value>
        /// An System.Int32 representing the Id of the Group's Parent Group.
        /// </value>
        public int? ParentGroupId { get; set; }

        /// <summary>
        /// Gets or sets the reminder additional details.
        /// </summary>
        /// <value>
        /// The reminder additional details.
        /// </value>
        public string ReminderAdditionalDetails { get; set; }

        /// <summary>
        /// Gets or sets the number of days prior to an event date that a reminder should be sent.
        /// </summary>
        /// <value>
        /// The number of days.
        /// </value>
        public int? ReminderOffsetDays { get; set; }

        /// <summary>
        /// Gets or sets the system communication to use for sending a reminder.
        /// </summary>
        /// <value>
        /// The reminder system communication identifier.
        /// </value>
        public int? ReminderSystemCommunicationId { get; set; }

        /// <summary>
        /// Gets or sets the required signature document type identifier.
        /// </summary>
        /// <value>
        /// The required signature document type identifier.
        /// </value>
        public int? RequiredSignatureDocumentTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the number of days prior to the RSVP date that a reminder should be sent.
        /// </summary>
        /// <value>
        /// The number of days.
        /// </value>
        public int? RSVPReminderOffsetDays { get; set; }

        /// <summary>
        /// Gets or sets the system communication to use for sending an RSVP reminder.
        /// </summary>
        /// <value>
        /// The RSVP reminder system communication identifier.
        /// </value>
        public int? RSVPReminderSystemCommunicationId { get; set; }

        /// <summary>
        /// Gets or sets the PersonAliasId of the person to notify when a person cancels
        /// </summary>
        /// <value>
        /// The schedule cancellation person alias identifier.
        /// </value>
        public int? ScheduleCancellationPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.Schedule identifier.
        /// </summary>
        /// <value>
        /// The schedule identifier.
        /// </value>
        public int? ScheduleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether GroupMembers must meet GroupMemberRequirements before they can be scheduled.
        /// </summary>
        /// <value>
        ///   true if [scheduling must meet requirements]; otherwise, false.
        /// </value>
        public bool SchedulingMustMeetRequirements { get; set; }

        /// <summary>
        /// Gets or sets the Group Status Id.  DefinedType depends on this group's Rock.Model.GroupType.GroupStatusDefinedType
        /// </summary>
        /// <value>
        /// The status value identifier.
        /// </value>
        public int? StatusValueId { get; set; }

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
