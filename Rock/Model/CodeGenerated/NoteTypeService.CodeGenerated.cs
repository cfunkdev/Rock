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
    /// NoteType Service class
    /// </summary>
    public partial class NoteTypeService : Service<NoteType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoteTypeService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public NoteTypeService(RockContext context) : base(context)
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
        public bool CanDelete( NoteType item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<NoteWatch>( Context ).Queryable().Any( a => a.NoteTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", NoteType.FriendlyTypeName, NoteWatch.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// NoteType View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( NoteType ) )]
    public partial class NoteTypeViewModelHelper : ViewModelHelper<NoteType, NoteTypeBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override NoteTypeBag CreateViewModel( NoteType model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new NoteTypeBag
            {
                IdKey = model.IdKey,
                AllowsAttachments = model.AllowsAttachments,
                AllowsReplies = model.AllowsReplies,
                AllowsWatching = model.AllowsWatching,
                ApprovalUrlTemplate = model.ApprovalUrlTemplate,
                AutoWatchAuthors = model.AutoWatchAuthors,
                BackgroundColor = model.BackgroundColor,
                BinaryFileTypeId = model.BinaryFileTypeId,
                BorderColor = model.BorderColor,
                EntityTypeId = model.EntityTypeId,
                EntityTypeQualifierColumn = model.EntityTypeQualifierColumn,
                EntityTypeQualifierValue = model.EntityTypeQualifierValue,
                FontColor = model.FontColor,
                IconCssClass = model.IconCssClass,
                IsSystem = model.IsSystem,
                MaxReplyDepth = model.MaxReplyDepth,
                Name = model.Name,
                Order = model.Order,
                RequiresApprovals = model.RequiresApprovals,
                SendApprovalNotifications = model.SendApprovalNotifications,
                UserSelectable = model.UserSelectable,
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
    public static partial class NoteTypeExtensionMethods
    {
        /// <summary>
        /// Clones this NoteType object to a new NoteType object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static NoteType Clone( this NoteType source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as NoteType;
            }
            else
            {
                var target = new NoteType();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this NoteType object to a new NoteType object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static NoteType CloneWithoutIdentity( this NoteType source )
        {
            var target = new NoteType();
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
        /// Copies the properties from another NoteType object to this NoteType object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this NoteType target, NoteType source )
        {
            target.Id = source.Id;
            target.AllowsAttachments = source.AllowsAttachments;
            target.AllowsReplies = source.AllowsReplies;
            target.AllowsWatching = source.AllowsWatching;
            target.ApprovalUrlTemplate = source.ApprovalUrlTemplate;
            target.AutoWatchAuthors = source.AutoWatchAuthors;
            target.BackgroundColor = source.BackgroundColor;
            target.BinaryFileTypeId = source.BinaryFileTypeId;
            target.BorderColor = source.BorderColor;
            target.EntityTypeId = source.EntityTypeId;
            target.EntityTypeQualifierColumn = source.EntityTypeQualifierColumn;
            target.EntityTypeQualifierValue = source.EntityTypeQualifierValue;
            target.FontColor = source.FontColor;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.IconCssClass = source.IconCssClass;
            target.IsSystem = source.IsSystem;
            target.MaxReplyDepth = source.MaxReplyDepth;
            target.Name = source.Name;
            target.Order = source.Order;
            target.RequiresApprovals = source.RequiresApprovals;
            target.SendApprovalNotifications = source.SendApprovalNotifications;
            target.UserSelectable = source.UserSelectable;
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
        public static NoteTypeBag ToViewModel( this NoteType model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new NoteTypeViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
