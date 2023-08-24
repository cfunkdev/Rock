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
    /// Note View Model
    /// </summary>
    public partial class NoteBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether [approvals sent].
        /// </summary>
        /// <value>
        ///   true if [approvals sent]; otherwise, false.
        /// </value>
        public bool ApprovalsSent { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the PersonAliasId of the Rock.Model.Person who either approved or declined the Note. If no approval action has been performed on this Note, this value will be null.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the PersonAliasId of hte Rock.Model.Person who either approved or declined the ContentItem. This value will be null if no approval action has been
        /// performed on this add.
        /// </value>
        public int? ApprovedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the approved date.
        /// </summary>
        /// <value>
        /// The approved date.
        /// </value>
        public DateTime? ApprovedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the caption
        /// </summary>
        /// <value>
        /// A System.String representing the caption of the Note.
        /// </value>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the person alias that last edited the note text. Use this instead of ModifiedByPersonAliasId to determine the last person to edit the note text
        /// </summary>
        /// <value>
        /// The edited by person alias identifier.
        /// </value>
        public int? EditedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the last time the note text was edited. Use this instead of ModifiedDateTime to determine the last time a person edited a note 
        /// </summary>
        /// <value>
        /// The edited date time.
        /// </value>
        public DateTime? EditedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Id of the entity that this note is related to.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the entity (object) that this note is related to.
        /// </value>
        public int? EntityId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this note is an alert.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this note is an alert; otherwise false.
        /// </value>
        public bool? IsAlert { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this note is viewable to only the person that created the note
        /// </summary>
        /// <value>
        /// true if this instance is private note; otherwise, false.
        /// </value>
        public bool IsPrivateNote { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this note is part of the Rock core system/framework. This property is required.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this note is part of the Rock core system/framework; otherwise false.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.NoteType. This property is required.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Rock.Model.NoteType
        /// </value>
        public int NoteTypeId { get; set; }

        /// <summary>
        /// Gets or sets the URL where the Note was created. Use NoteUrl with a hash anchor of the Note.NoteAnchorId so that Notifications and Approvals can know where to view the note
        /// </summary>
        /// <value>
        /// The note URL.
        /// </value>
        public string NoteUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [notifications sent].
        /// </summary>
        /// <value>
        ///   true if [notifications sent]; otherwise, false.
        /// </value>
        public bool NotificationsSent { get; set; }

        /// <summary>
        /// Gets or sets the parent note identifier.
        /// </summary>
        /// <value>
        /// The parent note identifier.
        /// </value>
        public int? ParentNoteId { get; set; }

        /// <summary>
        /// Gets or sets the text/body of the note.
        /// </summary>
        /// <value>
        /// A System.String representing the text/body of the note.
        /// </value>
        public string Text { get; set; }

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