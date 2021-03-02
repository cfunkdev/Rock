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
using System.Linq;

using Rock.Attribute;
using Rock.Data;
using Rock.ViewModel;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// ContentChannel Service class
    /// </summary>
    public partial class ContentChannelService : Service<ContentChannel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentChannelService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public ContentChannelService(RockContext context) : base(context)
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
        public bool CanDelete( ContentChannel item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<ContentChannelItem>( Context ).Queryable().Any( a => a.ContentChannelId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", ContentChannel.FriendlyTypeName, ContentChannelItem.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// ContentChannel View Model Helper
    /// </summary>
    public partial class ContentChannelViewModelHelper : ViewModelHelper<ContentChannel, Rock.ViewModel.ContentChannelViewModel>
    {
        /// <summary>
        /// Converts to viewmodel.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override Rock.ViewModel.ContentChannelViewModel CreateViewModel( ContentChannel model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new Rock.ViewModel.ContentChannelViewModel
            {
                Id = model.Id,
                Guid = model.Guid,
                ChannelUrl = model.ChannelUrl,
                ChildItemsManuallyOrdered = model.ChildItemsManuallyOrdered,
                ContentChannelTypeId = model.ContentChannelTypeId,
                ContentControlType = ( int ) model.ContentControlType,
                Description = model.Description,
                EnableRss = model.EnableRss,
                IconCssClass = model.IconCssClass,
                IsIndexEnabled = model.IsIndexEnabled,
                IsStructuredContent = model.IsStructuredContent,
                IsTaggingEnabled = model.IsTaggingEnabled,
                ItemsManuallyOrdered = model.ItemsManuallyOrdered,
                ItemTagCategoryId = model.ItemTagCategoryId,
                ItemUrl = model.ItemUrl,
                Name = model.Name,
                RequiresApproval = model.RequiresApproval,
                RootImageDirectory = model.RootImageDirectory,
                StructuredContentToolValueId = model.StructuredContentToolValueId,
                TimeToLive = model.TimeToLive,
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
    public static partial class ContentChannelExtensionMethods
    {
        /// <summary>
        /// Clones this ContentChannel object to a new ContentChannel object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static ContentChannel Clone( this ContentChannel source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as ContentChannel;
            }
            else
            {
                var target = new ContentChannel();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another ContentChannel object to this ContentChannel object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this ContentChannel target, ContentChannel source )
        {
            target.Id = source.Id;
            target.ChannelUrl = source.ChannelUrl;
            target.ChildItemsManuallyOrdered = source.ChildItemsManuallyOrdered;
            target.ContentChannelTypeId = source.ContentChannelTypeId;
            target.ContentControlType = source.ContentControlType;
            target.Description = source.Description;
            target.EnableRss = source.EnableRss;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.IconCssClass = source.IconCssClass;
            target.IsIndexEnabled = source.IsIndexEnabled;
            target.IsStructuredContent = source.IsStructuredContent;
            target.IsTaggingEnabled = source.IsTaggingEnabled;
            target.ItemsManuallyOrdered = source.ItemsManuallyOrdered;
            target.ItemTagCategoryId = source.ItemTagCategoryId;
            target.ItemUrl = source.ItemUrl;
            target.Name = source.Name;
            target.RequiresApproval = source.RequiresApproval;
            target.RootImageDirectory = source.RootImageDirectory;
            target.StructuredContentToolValueId = source.StructuredContentToolValueId;
            target.TimeToLive = source.TimeToLive;
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
        public static Rock.ViewModel.ContentChannelViewModel ToViewModel( this ContentChannel model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new ContentChannelViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
