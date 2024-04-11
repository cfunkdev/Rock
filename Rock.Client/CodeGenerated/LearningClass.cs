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
using System.Collections.Generic;


namespace Rock.Client
{
    /// <summary>
    /// Base client model for LearningClass that only includes the non-virtual fields. Use this for PUT/POSTs
    /// </summary>
    public partial class LearningClassEntity
    {
        /// <summary />
        public int Id { get; set; }

        /// <summary />
        public bool? AllowGuests { get; set; }

        /// <summary />
        public int? ArchivedByPersonAliasId { get; set; }

        /// <summary />
        public DateTime? ArchivedDateTime { get; set; }

        /// <summary />
        public Rock.Client.Enums.AttendanceRecordRequiredForCheckIn AttendanceRecordRequiredForCheckIn { get; set; }

        /// <summary />
        public int? CampusId { get; set; }

        /// <summary />
        public string ConfirmationAdditionalDetails { get; set; }

        /// <summary />
        public string Description { get; set; }

        /// <summary />
        public bool DisableScheduleToolboxAccess { get; set; }

        /// <summary />
        public bool DisableScheduling { get; set; }

        /// <summary />
        public int /* ElevatedSecurityLevel*/ ElevatedSecurityLevel { get; set; }

        /// <summary />
        public Guid? ForeignGuid { get; set; }

        /// <summary />
        public string ForeignKey { get; set; }

        /// <summary />
        public int? GroupCapacity { get; set; }

        /// <summary />
        public string GroupSalutation { get; set; }

        /// <summary />
        public string GroupSalutationFull { get; set; }

        /// <summary />
        public int GroupTypeId { get; set; }

        /// <summary />
        public DateTime? InactiveDateTime { get; set; }

        /// <summary />
        public string InactiveReasonNote { get; set; }

        /// <summary />
        public int? InactiveReasonValueId { get; set; }

        /// <summary />
        public bool IsActive { get; set; } = true;

        /// <summary />
        public bool IsArchived { get; set; }

        /// <summary />
        public bool IsPublic { get; set; } = true;

        /// <summary />
        public bool IsSecurityRole { get; set; }

        /// <summary />
        public bool IsSystem { get; set; }

        /// <summary />
        public int LearningCourseId { get; set; }

        /// <summary />
        public int LearningGradingSystemId { get; set; }

        /// <summary />
        public int? LearningSemesterId { get; set; }

        /// <summary>
        /// If the ModifiedByPersonAliasId is being set manually and should not be overwritten with current user when saved, set this value to true
        /// </summary>
        public bool ModifiedAuditValuesAlreadyUpdated { get; set; }

        /// <summary />
        public string Name { get; set; }

        /// <summary />
        public int Order { get; set; }

        /// <summary />
        public int? ParentGroupId { get; set; }

        /// <summary />
        public string ReminderAdditionalDetails { get; set; }

        /// <summary />
        public int? ReminderOffsetDays { get; set; }

        /// <summary />
        public int? ReminderSystemCommunicationId { get; set; }

        /// <summary />
        public int? RequiredSignatureDocumentTemplateId { get; set; }

        /// <summary />
        public int? RSVPReminderOffsetDays { get; set; }

        /// <summary />
        public int? RSVPReminderSystemCommunicationId { get; set; }

        /// <summary />
        public int? ScheduleCancellationPersonAliasId { get; set; }

        /// <summary />
        public Rock.Client.Enums.Group.ScheduleConfirmationLogic? ScheduleConfirmationLogic { get; set; }

        /// <summary />
        public int? ScheduleId { get; set; }

        /// <summary />
        public bool SchedulingMustMeetRequirements { get; set; }

        /// <summary />
        public int? StatusValueId { get; set; }

        /// <summary>
        /// Leave this as NULL to let Rock set this
        /// </summary>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// This does not need to be set or changed. Rock will always set this to the current date/time when saved to the database.
        /// </summary>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Leave this as NULL to let Rock set this
        /// </summary>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// If you need to set this manually, set ModifiedAuditValuesAlreadyUpdated=True to prevent Rock from setting it
        /// </summary>
        public int? ModifiedByPersonAliasId { get; set; }

        /// <summary />
        public Guid Guid { get; set; }

        /// <summary />
        public int? ForeignId { get; set; }

        /// <summary>
        /// Copies the base properties from a source LearningClass object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( LearningClass source )
        {
            this.Id = source.Id;
            this.AllowGuests = source.AllowGuests;
            this.ArchivedByPersonAliasId = source.ArchivedByPersonAliasId;
            this.ArchivedDateTime = source.ArchivedDateTime;
            this.AttendanceRecordRequiredForCheckIn = source.AttendanceRecordRequiredForCheckIn;
            this.CampusId = source.CampusId;
            this.ConfirmationAdditionalDetails = source.ConfirmationAdditionalDetails;
            this.Description = source.Description;
            this.DisableScheduleToolboxAccess = source.DisableScheduleToolboxAccess;
            this.DisableScheduling = source.DisableScheduling;
            this.ElevatedSecurityLevel = source.ElevatedSecurityLevel;
            this.ForeignGuid = source.ForeignGuid;
            this.ForeignKey = source.ForeignKey;
            this.GroupCapacity = source.GroupCapacity;
            this.GroupSalutation = source.GroupSalutation;
            this.GroupSalutationFull = source.GroupSalutationFull;
            this.GroupTypeId = source.GroupTypeId;
            this.InactiveDateTime = source.InactiveDateTime;
            this.InactiveReasonNote = source.InactiveReasonNote;
            this.InactiveReasonValueId = source.InactiveReasonValueId;
            this.IsActive = source.IsActive;
            this.IsArchived = source.IsArchived;
            this.IsPublic = source.IsPublic;
            this.IsSecurityRole = source.IsSecurityRole;
            this.IsSystem = source.IsSystem;
            this.LearningCourseId = source.LearningCourseId;
            this.LearningGradingSystemId = source.LearningGradingSystemId;
            this.LearningSemesterId = source.LearningSemesterId;
            this.ModifiedAuditValuesAlreadyUpdated = source.ModifiedAuditValuesAlreadyUpdated;
            this.Name = source.Name;
            this.Order = source.Order;
            this.ParentGroupId = source.ParentGroupId;
            this.ReminderAdditionalDetails = source.ReminderAdditionalDetails;
            this.ReminderOffsetDays = source.ReminderOffsetDays;
            this.ReminderSystemCommunicationId = source.ReminderSystemCommunicationId;
            this.RequiredSignatureDocumentTemplateId = source.RequiredSignatureDocumentTemplateId;
            this.RSVPReminderOffsetDays = source.RSVPReminderOffsetDays;
            this.RSVPReminderSystemCommunicationId = source.RSVPReminderSystemCommunicationId;
            this.ScheduleCancellationPersonAliasId = source.ScheduleCancellationPersonAliasId;
            this.ScheduleConfirmationLogic = source.ScheduleConfirmationLogic;
            this.ScheduleId = source.ScheduleId;
            this.SchedulingMustMeetRequirements = source.SchedulingMustMeetRequirements;
            this.StatusValueId = source.StatusValueId;
            this.CreatedDateTime = source.CreatedDateTime;
            this.ModifiedDateTime = source.ModifiedDateTime;
            this.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            this.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            this.Guid = source.Guid;
            this.ForeignId = source.ForeignId;

        }
    }

    /// <summary>
    /// Client model for LearningClass that includes all the fields that are available for GETs. Use this for GETs (use LearningClassEntity for POST/PUTs)
    /// </summary>
    public partial class LearningClass : LearningClassEntity
    {
        /// <summary />
        public PersonAlias ArchivedByPersonAlias { get; set; }

        /// <summary />
        public Campus Campus { get; set; }

        /// <summary />
        public PersonAlias GroupAdministratorPersonAlias { get; set; }

        /// <summary />
        public int? GroupAdministratorPersonAliasId { get; set; }

        /// <summary />
        public ICollection<GroupLocation> GroupLocations { get; set; }

        /// <summary />
        public ICollection<GroupRequirement> GroupRequirements { get; set; }

        /// <summary />
        public ICollection<GroupSync> GroupSyncs { get; set; }

        /// <summary />
        public GroupType GroupType { get; set; }

        /// <summary />
        public LearningCourse LearningCourse { get; set; }

        /// <summary />
        public LearningGradingSystem LearningGradingSystem { get; set; }

        /// <summary />
        public LearningSemester LearningSemester { get; set; }

        /// <summary />
        public ICollection<GroupMember> Members { get; set; }

        /// <summary />
        public SignatureDocumentTemplate RequiredSignatureDocumentTemplate { get; set; }

        /// <summary />
        public SystemCommunication RSVPReminderSystemCommunication { get; set; }

        /// <summary />
        public Schedule Schedule { get; set; }

        /// <summary />
        public DefinedValue StatusValue { get; set; }

        /// <summary>
        /// NOTE: Attributes are only populated when ?loadAttributes is specified. Options for loadAttributes are true, false, 'simple', 'expanded' 
        /// </summary>
        public Dictionary<string, Rock.Client.Attribute> Attributes { get; set; }

        /// <summary>
        /// NOTE: AttributeValues are only populated when ?loadAttributes is specified. Options for loadAttributes are true, false, 'simple', 'expanded' 
        /// </summary>
        public Dictionary<string, Rock.Client.AttributeValue> AttributeValues { get; set; }
    }
}