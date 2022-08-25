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
using System.Linq;

using Rock.Attribute;
using Rock.Data;
using Rock.ViewModels;
using Rock.ViewModels.Entities;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// Note Service class
    /// </summary>
    public partial class NoteService : Service<Note>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoteService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public NoteService(RockContext context) : base(context)
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
        public bool CanDelete( Note item, out string errorMessage )
        {
            errorMessage = string.Empty;

            // ignoring Note,ParentNoteId
            return true;
        }
    }

    /// <summary>
    /// Note View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( Note ) )]
    public partial class NoteViewModelHelper : ViewModelHelper<Note, NoteBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override NoteBag CreateViewModel( Note model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new NoteBag
            {
                IdKey = model.IdKey,
                ApprovalsSent = model.ApprovalsSent,
                ApprovalStatus = ( int ) model.ApprovalStatus,
                ApprovedByPersonAliasId = model.ApprovedByPersonAliasId,
                ApprovedDateTime = model.ApprovedDateTime,
                Caption = model.Caption,
                EditedByPersonAliasId = model.EditedByPersonAliasId,
                EditedDateTime = model.EditedDateTime,
                EntityId = model.EntityId,
                IsAlert = model.IsAlert,
                IsPrivateNote = model.IsPrivateNote,
                IsSystem = model.IsSystem,
                NoteTypeId = model.NoteTypeId,
                NoteUrl = model.NoteUrl,
                NotificationsSent = model.NotificationsSent,
                ParentNoteId = model.ParentNoteId,
                Text = model.Text,
                CreatedDateTime = model.CreatedDateTime,
                ModifiedDateTime = model.ModifiedDateTime,
                CreatedByPersonAliasId = model.CreatedByPersonAliasId,
                ModifiedByPersonAliasId = model.ModifiedByPersonAliasId,
            };

            AddAttributesToViewModel( model, viewModel, currentPerson, loadAttributes );
            ApplyAdditionalPropertiesAndSecurityToViewModel( model, viewModel, currentPerson, loadAttributes );
            return viewModel;
        }
    }


    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class NoteExtensionMethods
    {
        /// <summary>
        /// Clones this Note object to a new Note object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static Note Clone( this Note source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as Note;
            }
            else
            {
                var target = new Note();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this Note object to a new Note object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Note CloneWithoutIdentity( this Note source )
        {
            var target = new Note();
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
        /// Copies the properties from another Note object to this Note object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this Note target, Note source )
        {
            target.Id = source.Id;
            target.ApprovalsSent = source.ApprovalsSent;
            target.ApprovalStatus = source.ApprovalStatus;
            target.ApprovedByPersonAliasId = source.ApprovedByPersonAliasId;
            target.ApprovedDateTime = source.ApprovedDateTime;
            target.Caption = source.Caption;
            target.EditedByPersonAliasId = source.EditedByPersonAliasId;
            target.EditedDateTime = source.EditedDateTime;
            target.EntityId = source.EntityId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.IsAlert = source.IsAlert;
            target.IsPrivateNote = source.IsPrivateNote;
            target.IsSystem = source.IsSystem;
            target.NoteTypeId = source.NoteTypeId;
            target.NoteUrl = source.NoteUrl;
            target.NotificationsSent = source.NotificationsSent;
            target.ParentNoteId = source.ParentNoteId;
            target.Text = source.Text;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }

        /// <summary>
        /// Creates a view model from this entity
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson" >The currentPerson.</param>
        /// <param name="loadAttributes" >Load attributes?</param>
        public static NoteBag ToViewModel( this Note model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new NoteViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
