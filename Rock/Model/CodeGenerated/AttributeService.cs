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
using Rock.ViewModel;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// Attribute Service class
    /// </summary>
    public partial class AttributeService : Service<Attribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public AttributeService(RockContext context) : base(context)
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
        public bool CanDelete( Attribute item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<MediaFolder>( Context ).Queryable().Any( a => a.ContentChannelAttributeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Attribute.FriendlyTypeName, MediaFolder.FriendlyTypeName );
                return false;
            }

            if ( new Service<RegistrationTemplateFormField>( Context ).Queryable().Any( a => a.AttributeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Attribute.FriendlyTypeName, RegistrationTemplateFormField.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Attribute View Model Helper
    /// </summary>
    public partial class AttributeViewModelHelper : ViewModelHelper<Attribute, Rock.ViewModel.AttributeViewModel>
    {
        /// <summary>
        /// Converts to viewmodel.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override Rock.ViewModel.AttributeViewModel CreateViewModel( Attribute model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new Rock.ViewModel.AttributeViewModel
            {
                Id = model.Id,
                Guid = model.Guid,
                AbbreviatedName = model.AbbreviatedName,
                AllowSearch = model.AllowSearch,
                DefaultValue = model.DefaultValue,
                Description = model.Description,
                EnableHistory = model.EnableHistory,
                EntityTypeId = model.EntityTypeId,
                EntityTypeQualifierColumn = model.EntityTypeQualifierColumn,
                EntityTypeQualifierValue = model.EntityTypeQualifierValue,
                FieldTypeId = model.FieldTypeId,
                IconCssClass = model.IconCssClass,
                IsActive = model.IsActive,
                IsAnalytic = model.IsAnalytic,
                IsAnalyticHistory = model.IsAnalyticHistory,
                IsGridColumn = model.IsGridColumn,
                IsIndexEnabled = model.IsIndexEnabled,
                IsMultiValue = model.IsMultiValue,
                IsPublic = model.IsPublic,
                IsRequired = model.IsRequired,
                IsSystem = model.IsSystem,
                Key = model.Key,
                Name = model.Name,
                Order = model.Order,
                PostHtml = model.PostHtml,
                PreHtml = model.PreHtml,
                ShowOnBulk = model.ShowOnBulk,
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
    public static partial class AttributeExtensionMethods
    {
        /// <summary>
        /// Clones this Attribute object to a new Attribute object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static Attribute Clone( this Attribute source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as Attribute;
            }
            else
            {
                var target = new Attribute();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this Attribute object to a new Attribute object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Attribute CloneWithoutIdentity( this Attribute source )
        {
            var target = new Attribute();
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
        /// Copies the properties from another Attribute object to this Attribute object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this Attribute target, Attribute source )
        {
            target.Id = source.Id;
            target.AbbreviatedName = source.AbbreviatedName;
            target.AllowSearch = source.AllowSearch;
            target.DefaultValue = source.DefaultValue;
            target.Description = source.Description;
            target.EnableHistory = source.EnableHistory;
            target.EntityTypeId = source.EntityTypeId;
            target.EntityTypeQualifierColumn = source.EntityTypeQualifierColumn;
            target.EntityTypeQualifierValue = source.EntityTypeQualifierValue;
            target.FieldTypeId = source.FieldTypeId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.IconCssClass = source.IconCssClass;
            target.IsActive = source.IsActive;
            target.IsAnalytic = source.IsAnalytic;
            target.IsAnalyticHistory = source.IsAnalyticHistory;
            target.IsGridColumn = source.IsGridColumn;
            target.IsIndexEnabled = source.IsIndexEnabled;
            target.IsMultiValue = source.IsMultiValue;
            target.IsPublic = source.IsPublic;
            target.IsRequired = source.IsRequired;
            target.IsSystem = source.IsSystem;
            target.Key = source.Key;
            target.Name = source.Name;
            target.Order = source.Order;
            target.PostHtml = source.PostHtml;
            target.PreHtml = source.PreHtml;
            target.ShowOnBulk = source.ShowOnBulk;
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
        public static Rock.ViewModel.AttributeViewModel ToViewModel( this Attribute model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new AttributeViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
