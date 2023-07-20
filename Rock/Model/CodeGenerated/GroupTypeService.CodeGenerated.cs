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
using System.Collections.Generic;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// GroupType Service class
    /// </summary>
    public partial class GroupTypeService : Service<GroupType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTypeService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public GroupTypeService(RockContext context) : base(context)
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
        public bool CanDelete( GroupType item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<ConnectionOpportunityGroupConfig>( Context ).Queryable().Any( a => a.GroupTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", GroupType.FriendlyTypeName, ConnectionOpportunityGroupConfig.FriendlyTypeName );
                return false;
            }

            if ( new Service<Group>( Context ).Queryable().Any( a => a.GroupTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", GroupType.FriendlyTypeName, Group.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupHistorical>( Context ).Queryable().Any( a => a.GroupTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", GroupType.FriendlyTypeName, GroupHistorical.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupMember>( Context ).Queryable().Any( a => a.GroupTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", GroupType.FriendlyTypeName, GroupMember.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupMemberScheduleTemplate>( Context ).Queryable().Any( a => a.GroupTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", GroupType.FriendlyTypeName, GroupMemberScheduleTemplate.FriendlyTypeName );
                return false;
            }

            // ignoring GroupRequirement,GroupTypeId

            if ( new Service<GroupType>( Context ).Queryable().Any( a => a.InheritedGroupTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", GroupType.FriendlyTypeName, GroupType.FriendlyTypeName );
                return false;
            }

            if ( new Service<RegistrationTemplate>( Context ).Queryable().Any( a => a.GroupTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", GroupType.FriendlyTypeName, RegistrationTemplate.FriendlyTypeName );
                return false;
            }

            if ( new Service<RegistrationTemplatePlacement>( Context ).Queryable().Any( a => a.GroupTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", GroupType.FriendlyTypeName, RegistrationTemplatePlacement.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    public partial class GroupType : IHasQueryableAttributes<GroupType.GroupTypeQueryableAttributeValue>
    {
        /// <inheritdoc/>
        public virtual ICollection<GroupTypeQueryableAttributeValue> EntityAttributeValues { get; set; } 

        /// <inheritdoc/>
        public class GroupTypeQueryableAttributeValue : QueryableAttributeValue
        {
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class GroupTypeExtensionMethods
    {
        /// <summary>
        /// Clones this GroupType object to a new GroupType object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static GroupType Clone( this GroupType source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as GroupType;
            }
            else
            {
                var target = new GroupType();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this GroupType object to a new GroupType object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static GroupType CloneWithoutIdentity( this GroupType source )
        {
            var target = new GroupType();
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
        /// Copies the properties from another GroupType object to this GroupType object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this GroupType target, GroupType source )
        {
            target.Id = source.Id;
            target.AdministratorTerm = source.AdministratorTerm;
            target.AllowAnyChildGroupType = source.AllowAnyChildGroupType;
            target.AllowedScheduleTypes = source.AllowedScheduleTypes;
            target.AllowGroupSync = source.AllowGroupSync;
            target.AllowMultipleLocations = source.AllowMultipleLocations;
            target.AllowSpecificGroupMemberAttributes = source.AllowSpecificGroupMemberAttributes;
            target.AllowSpecificGroupMemberWorkflows = source.AllowSpecificGroupMemberWorkflows;
            target.AttendanceCountsAsWeekendService = source.AttendanceCountsAsWeekendService;
            target.AttendancePrintTo = source.AttendancePrintTo;
            target.AttendanceReminderFollowupDays = source.AttendanceReminderFollowupDays;
            target.AttendanceReminderFollowupDaysList = source.AttendanceReminderFollowupDaysList;
            target.AttendanceReminderSendStartOffsetMinutes = source.AttendanceReminderSendStartOffsetMinutes;
            target.AttendanceReminderSystemCommunicationId = source.AttendanceReminderSystemCommunicationId;
            target.AttendanceRule = source.AttendanceRule;
            target.DefaultGroupRoleId = source.DefaultGroupRoleId;
            target.Description = source.Description;
            target.EnableGroupHistory = source.EnableGroupHistory;
            target.EnableGroupTag = source.EnableGroupTag;
            target.EnableInactiveReason = source.EnableInactiveReason;
            target.EnableLocationSchedules = source.EnableLocationSchedules;
            target.EnableRSVP = source.EnableRSVP;
            target.EnableSpecificGroupRequirements = source.EnableSpecificGroupRequirements;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.GroupAttendanceRequiresLocation = source.GroupAttendanceRequiresLocation;
            target.GroupAttendanceRequiresSchedule = source.GroupAttendanceRequiresSchedule;
            target.GroupCapacityRule = source.GroupCapacityRule;
            target.GroupMemberTerm = source.GroupMemberTerm;
            target.GroupsRequireCampus = source.GroupsRequireCampus;
            target.GroupStatusDefinedTypeId = source.GroupStatusDefinedTypeId;
            target.GroupTerm = source.GroupTerm;
            target.GroupTypeColor = source.GroupTypeColor;
            target.GroupTypePurposeValueId = source.GroupTypePurposeValueId;
            target.GroupViewLavaTemplate = source.GroupViewLavaTemplate;
            target.IconCssClass = source.IconCssClass;
            target.IgnorePersonInactivated = source.IgnorePersonInactivated;
            target.InheritedGroupTypeId = source.InheritedGroupTypeId;
            target.IsCapacityRequired = source.IsCapacityRequired;
            target.IsIndexEnabled = source.IsIndexEnabled;
            target.IsSchedulingEnabled = source.IsSchedulingEnabled;
            target.IsSystem = source.IsSystem;
            target.LocationSelectionMode = source.LocationSelectionMode;
            target.Name = source.Name;
            target.Order = source.Order;
            target.RequiresInactiveReason = source.RequiresInactiveReason;
            target.RequiresReasonIfDeclineSchedule = source.RequiresReasonIfDeclineSchedule;
            target.RSVPReminderOffsetDays = source.RSVPReminderOffsetDays;
            target.RSVPReminderSystemCommunicationId = source.RSVPReminderSystemCommunicationId;
            target.ScheduleCancellationWorkflowTypeId = source.ScheduleCancellationWorkflowTypeId;
            target.ScheduleConfirmationEmailOffsetDays = source.ScheduleConfirmationEmailOffsetDays;
            target.ScheduleConfirmationLogic = source.ScheduleConfirmationLogic;
            target.ScheduleConfirmationSystemCommunicationId = source.ScheduleConfirmationSystemCommunicationId;
            target.ScheduleReminderEmailOffsetDays = source.ScheduleReminderEmailOffsetDays;
            target.ScheduleReminderSystemCommunicationId = source.ScheduleReminderSystemCommunicationId;
            target.SendAttendanceReminder = source.SendAttendanceReminder;
            target.ShowAdministrator = source.ShowAdministrator;
            target.ShowConnectionStatus = source.ShowConnectionStatus;
            target.ShowInGroupList = source.ShowInGroupList;
            target.ShowInNavigation = source.ShowInNavigation;
            target.ShowMaritalStatus = source.ShowMaritalStatus;
            target.TakesAttendance = source.TakesAttendance;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}
