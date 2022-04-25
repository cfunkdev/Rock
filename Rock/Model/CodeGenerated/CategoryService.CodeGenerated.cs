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
    /// Category Service class
    /// </summary>
    public partial class CategoryService : Service<Category>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public CategoryService(RockContext context) : base(context)
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
        public bool CanDelete( Category item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<AchievementType>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, AchievementType.FriendlyTypeName );
                return false;
            }

            if ( new Service<Category>( Context ).Queryable().Any( a => a.ParentCategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} contains one or more child {1}.", Category.FriendlyTypeName, Category.FriendlyTypeName.Pluralize().ToLower() );
                return false;
            }

            if ( new Service<CommunicationTemplate>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, CommunicationTemplate.FriendlyTypeName );
                return false;
            }

            if ( new Service<ContentChannel>( Context ).Queryable().Any( a => a.ItemTagCategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, ContentChannel.FriendlyTypeName );
                return false;
            }

            if ( new Service<DataView>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, DataView.FriendlyTypeName );
                return false;
            }

            if ( new Service<DefinedType>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, DefinedType.FriendlyTypeName );
                return false;
            }

            if ( new Service<DefinedValue>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, DefinedValue.FriendlyTypeName );
                return false;
            }

            if ( new Service<History>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, History.FriendlyTypeName );
                return false;
            }

            if ( new Service<MergeTemplate>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, MergeTemplate.FriendlyTypeName );
                return false;
            }

            if ( new Service<PrayerRequest>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, PrayerRequest.FriendlyTypeName );
                return false;
            }

            if ( new Service<RegistrationTemplate>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, RegistrationTemplate.FriendlyTypeName );
                return false;
            }

            if ( new Service<Report>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, Report.FriendlyTypeName );
                return false;
            }

            if ( new Service<Schedule>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, Schedule.FriendlyTypeName );
                return false;
            }

            if ( new Service<StepProgram>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, StepProgram.FriendlyTypeName );
                return false;
            }

            if ( new Service<SystemCommunication>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, SystemCommunication.FriendlyTypeName );
                return false;
            }

            #pragma warning disable 612, 618 // SystemEmail is obsolete, but we still need this code generated
            if ( new Service<SystemEmail>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, SystemEmail.FriendlyTypeName );
                return false;
            }
            #pragma warning restore 612, 618

            if ( new Service<Tag>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, Tag.FriendlyTypeName );
                return false;
            }

            if ( new Service<WorkflowType>( Context ).Queryable().Any( a => a.CategoryId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Category.FriendlyTypeName, WorkflowType.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Category View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( Category ) )]
    public partial class CategoryViewModelHelper : ViewModelHelper<Category, CategoryBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override CategoryBag CreateViewModel( Category model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new CategoryBag
            {
                Id = model.Id,
                IdKey = model.IdKey,
                Guid = model.Guid,
                Description = model.Description,
                EntityTypeId = model.EntityTypeId,
                EntityTypeQualifierColumn = model.EntityTypeQualifierColumn,
                EntityTypeQualifierValue = model.EntityTypeQualifierValue,
                HighlightColor = model.HighlightColor,
                IconCssClass = model.IconCssClass,
                IsSystem = model.IsSystem,
                Name = model.Name,
                Order = model.Order,
                ParentCategoryId = model.ParentCategoryId,
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
    public static partial class CategoryExtensionMethods
    {
        /// <summary>
        /// Clones this Category object to a new Category object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static Category Clone( this Category source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as Category;
            }
            else
            {
                var target = new Category();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this Category object to a new Category object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Category CloneWithoutIdentity( this Category source )
        {
            var target = new Category();
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
        /// Copies the properties from another Category object to this Category object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this Category target, Category source )
        {
            target.Id = source.Id;
            target.Description = source.Description;
            target.EntityTypeId = source.EntityTypeId;
            target.EntityTypeQualifierColumn = source.EntityTypeQualifierColumn;
            target.EntityTypeQualifierValue = source.EntityTypeQualifierValue;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.HighlightColor = source.HighlightColor;
            target.IconCssClass = source.IconCssClass;
            target.IsSystem = source.IsSystem;
            target.Name = source.Name;
            target.Order = source.Order;
            target.ParentCategoryId = source.ParentCategoryId;
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
        public static CategoryBag ToViewModel( this Category model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new CategoryViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
