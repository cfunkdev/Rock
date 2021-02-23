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
using Rock.Attribute;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.ViewModel
{
    /// <summary>
    /// NoteType View Model
    /// </summary>
    [ViewModelOf( typeof( Rock.Model.NoteType ) )]
    public partial class NoteTypeViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the AllowsAttachments.
        /// </summary>
        /// <value>
        /// The AllowsAttachments.
        /// </value>
        public bool AllowsAttachments { get; set; }

        /// <summary>
        /// Gets or sets the AllowsReplies.
        /// </summary>
        /// <value>
        /// The AllowsReplies.
        /// </value>
        public bool AllowsReplies { get; set; }

        /// <summary>
        /// Gets or sets the AllowsWatching.
        /// </summary>
        /// <value>
        /// The AllowsWatching.
        /// </value>
        public bool AllowsWatching { get; set; }

        /// <summary>
        /// Gets or sets the ApprovalUrlTemplate.
        /// </summary>
        /// <value>
        /// The ApprovalUrlTemplate.
        /// </value>
        public string ApprovalUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets the AutoWatchAuthors.
        /// </summary>
        /// <value>
        /// The AutoWatchAuthors.
        /// </value>
        public bool AutoWatchAuthors { get; set; }

        /// <summary>
        /// Gets or sets the BackgroundColor.
        /// </summary>
        /// <value>
        /// The BackgroundColor.
        /// </value>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the BinaryFileTypeId.
        /// </summary>
        /// <value>
        /// The BinaryFileTypeId.
        /// </value>
        public int? BinaryFileTypeId { get; set; }

        /// <summary>
        /// Gets or sets the BorderColor.
        /// </summary>
        /// <value>
        /// The BorderColor.
        /// </value>
        public string BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the EntityTypeId.
        /// </summary>
        /// <value>
        /// The EntityTypeId.
        /// </value>
        public int EntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the EntityTypeQualifierColumn.
        /// </summary>
        /// <value>
        /// The EntityTypeQualifierColumn.
        /// </value>
        public string EntityTypeQualifierColumn { get; set; }

        /// <summary>
        /// Gets or sets the EntityTypeQualifierValue.
        /// </summary>
        /// <value>
        /// The EntityTypeQualifierValue.
        /// </value>
        public string EntityTypeQualifierValue { get; set; }

        /// <summary>
        /// Gets or sets the FontColor.
        /// </summary>
        /// <value>
        /// The FontColor.
        /// </value>
        public string FontColor { get; set; }

        /// <summary>
        /// Gets or sets the IconCssClass.
        /// </summary>
        /// <value>
        /// The IconCssClass.
        /// </value>
        public string IconCssClass { get; set; }

        /// <summary>
        /// Gets or sets the IsSystem.
        /// </summary>
        /// <value>
        /// The IsSystem.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the MaxReplyDepth.
        /// </summary>
        /// <value>
        /// The MaxReplyDepth.
        /// </value>
        public int? MaxReplyDepth { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Order.
        /// </summary>
        /// <value>
        /// The Order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the RequiresApprovals.
        /// </summary>
        /// <value>
        /// The RequiresApprovals.
        /// </value>
        public bool RequiresApprovals { get; set; }

        /// <summary>
        /// Gets or sets the SendApprovalNotifications.
        /// </summary>
        /// <value>
        /// The SendApprovalNotifications.
        /// </value>
        public bool SendApprovalNotifications { get; set; }

        /// <summary>
        /// Gets or sets the UserSelectable.
        /// </summary>
        /// <value>
        /// The UserSelectable.
        /// </value>
        public bool UserSelectable { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDateTime.
        /// </summary>
        /// <value>
        /// The CreatedDateTime.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedDateTime.
        /// </summary>
        /// <value>
        /// The ModifiedDateTime.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the CreatedByPersonAliasId.
        /// </summary>
        /// <value>
        /// The CreatedByPersonAliasId.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedByPersonAliasId.
        /// </summary>
        /// <value>
        /// The ModifiedByPersonAliasId.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

        /// <summary>
        /// Sets the properties from.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        public virtual void SetPropertiesFrom( Rock.Model.NoteType model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return;
            }

            if ( loadAttributes && model is IHasAttributes hasAttributes )
            {
                if ( hasAttributes.Attributes == null )
                {
                    hasAttributes.LoadAttributes();
                }

                Attributes = hasAttributes.AttributeValues.Where( av =>
                {
                    var attribute = AttributeCache.Get( av.Value.AttributeId );
                    return attribute?.IsAuthorized( Rock.Security.Authorization.EDIT, currentPerson ) ?? false;
                } ).ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.ToViewModel<AttributeValueViewModel>() as object );
            }

            AllowsAttachments = model.AllowsAttachments;
            AllowsReplies = model.AllowsReplies;
            AllowsWatching = model.AllowsWatching;
            ApprovalUrlTemplate = model.ApprovalUrlTemplate;
            AutoWatchAuthors = model.AutoWatchAuthors;
            BackgroundColor = model.BackgroundColor;
            BinaryFileTypeId = model.BinaryFileTypeId;
            BorderColor = model.BorderColor;
            EntityTypeId = model.EntityTypeId;
            EntityTypeQualifierColumn = model.EntityTypeQualifierColumn;
            EntityTypeQualifierValue = model.EntityTypeQualifierValue;
            FontColor = model.FontColor;
            IconCssClass = model.IconCssClass;
            IsSystem = model.IsSystem;
            MaxReplyDepth = model.MaxReplyDepth;
            Name = model.Name;
            Order = model.Order;
            RequiresApprovals = model.RequiresApprovals;
            SendApprovalNotifications = model.SendApprovalNotifications;
            UserSelectable = model.UserSelectable;
            CreatedDateTime = model.CreatedDateTime;
            ModifiedDateTime = model.ModifiedDateTime;
            CreatedByPersonAliasId = model.CreatedByPersonAliasId;
            ModifiedByPersonAliasId = model.ModifiedByPersonAliasId;

            SetAdditionalPropertiesFrom( model, currentPerson, loadAttributes );
        }

        /// <summary>
        /// Creates a view model from the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="currentPerson" >The current person.</param>
        /// <param name="loadAttributes" >if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public static NoteTypeViewModel From( Rock.Model.NoteType model, Person currentPerson = null, bool loadAttributes = true )
        {
            var viewModel = new NoteTypeViewModel();
            viewModel.SetPropertiesFrom( model, currentPerson, loadAttributes );
            return viewModel;
        }
    }
}
