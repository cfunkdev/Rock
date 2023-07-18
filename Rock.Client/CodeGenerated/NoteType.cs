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
    /// Base client model for NoteType that only includes the non-virtual fields. Use this for PUT/POSTs
    /// </summary>
    public partial class NoteTypeEntity
    {
        /// <summary />
        public int Id { get; set; }

        /// <summary />
        public bool AllowsAttachments { get; set; }

        /// <summary />
        public bool AllowsReplies { get; set; }

        /// <summary />
        public bool AllowsWatching { get; set; }

        /// <summary />
        // Made Obsolete in Rock "1.16"
        [Obsolete( "This property is no longer used and will be removed in the future.", false )]
        public string ApprovalUrlTemplate { get; set; }

        /// <summary />
        public bool AutoWatchAuthors { get; set; }

        /// <summary />
        // Made Obsolete in Rock "1.16"
        [Obsolete( "This property is no longer used and will be removed in the future.", false )]
        public string BackgroundColor { get; set; }

        /// <summary />
        public int? BinaryFileTypeId { get; set; }

        /// <summary />
        // Made Obsolete in Rock "1.16"
        [Obsolete( "This property is no longer used and will be removed in the future.", false )]
        public string BorderColor { get; set; }

        /// <summary />
        public string Color { get; set; }

        /// <summary />
        public int EntityTypeId { get; set; }

        /// <summary />
        public string EntityTypeQualifierColumn { get; set; }

        /// <summary />
        public string EntityTypeQualifierValue { get; set; }

        /// <summary />
        // Made Obsolete in Rock "1.16"
        [Obsolete( "This property is no longer used and will be removed in the future.", false )]
        public string FontColor { get; set; }

        /// <summary />
        public Guid? ForeignGuid { get; set; }

        /// <summary />
        public string ForeignKey { get; set; }

        /// <summary />
        public string IconCssClass { get; set; }

        /// <summary />
        public bool IsSystem { get; set; }

        /// <summary />
        public int? MaxReplyDepth { get; set; }

        /// <summary>
        /// If the ModifiedByPersonAliasId is being set manually and should not be overwritten with current user when saved, set this value to true
        /// </summary>
        public bool ModifiedAuditValuesAlreadyUpdated { get; set; }

        /// <summary />
        public string Name { get; set; }

        /// <summary />
        public int Order { get; set; }

        /// <summary />
        // Made Obsolete in Rock "1.16"
        [Obsolete( "This property is no longer used and will be removed in the future.", false )]
        public bool RequiresApprovals { get; set; }

        /// <summary />
        // Made Obsolete in Rock "1.16"
        [Obsolete( "This property is no longer used and will be removed in the future.", false )]
        public bool SendApprovalNotifications { get; set; }

        /// <summary />
        public bool UserSelectable { get; set; }

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
        /// Copies the base properties from a source NoteType object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( NoteType source )
        {
            this.Id = source.Id;
            this.AllowsAttachments = source.AllowsAttachments;
            this.AllowsReplies = source.AllowsReplies;
            this.AllowsWatching = source.AllowsWatching;
            #pragma warning disable 612, 618
            this.ApprovalUrlTemplate = source.ApprovalUrlTemplate;
            #pragma warning restore 612, 618
            this.AutoWatchAuthors = source.AutoWatchAuthors;
            #pragma warning disable 612, 618
            this.BackgroundColor = source.BackgroundColor;
            #pragma warning restore 612, 618
            this.BinaryFileTypeId = source.BinaryFileTypeId;
            #pragma warning disable 612, 618
            this.BorderColor = source.BorderColor;
            #pragma warning restore 612, 618
            this.Color = source.Color;
            this.EntityTypeId = source.EntityTypeId;
            this.EntityTypeQualifierColumn = source.EntityTypeQualifierColumn;
            this.EntityTypeQualifierValue = source.EntityTypeQualifierValue;
            #pragma warning disable 612, 618
            this.FontColor = source.FontColor;
            #pragma warning restore 612, 618
            this.ForeignGuid = source.ForeignGuid;
            this.ForeignKey = source.ForeignKey;
            this.IconCssClass = source.IconCssClass;
            this.IsSystem = source.IsSystem;
            this.MaxReplyDepth = source.MaxReplyDepth;
            this.ModifiedAuditValuesAlreadyUpdated = source.ModifiedAuditValuesAlreadyUpdated;
            this.Name = source.Name;
            this.Order = source.Order;
            #pragma warning disable 612, 618
            this.RequiresApprovals = source.RequiresApprovals;
            #pragma warning restore 612, 618
            #pragma warning disable 612, 618
            this.SendApprovalNotifications = source.SendApprovalNotifications;
            #pragma warning restore 612, 618
            this.UserSelectable = source.UserSelectable;
            this.CreatedDateTime = source.CreatedDateTime;
            this.ModifiedDateTime = source.ModifiedDateTime;
            this.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            this.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            this.Guid = source.Guid;
            this.ForeignId = source.ForeignId;

        }
    }

    /// <summary>
    /// Client model for NoteType that includes all the fields that are available for GETs. Use this for GETs (use NoteTypeEntity for POST/PUTs)
    /// </summary>
    public partial class NoteType : NoteTypeEntity
    {
        /// <summary />
        public BinaryFileType BinaryFileType { get; set; }

        /// <summary />
        public EntityType EntityType { get; set; }

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
