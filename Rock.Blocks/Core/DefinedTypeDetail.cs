﻿// <copyright>
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
using System.ComponentModel;
using System.Linq;

using Rock.Attribute;
using Rock.Constants;
using Rock.Data;
using Rock.Model;
using Rock.Security;
using Rock.ViewModels.Blocks;
using Rock.ViewModels.Blocks.Core.DefinedTypeDetail;
using Rock.ViewModels.Utility;
using Rock.Web;
using Rock.Web.Cache;
using Rock.Web.UI.Controls;

namespace Rock.Blocks.Core
{
    /// <summary>
    /// Displays the details of a particular defined type.
    /// </summary>

    [DisplayName( "Defined Type Detail" )]
    [Category( "Core" )]
    [Description( "Displays the details of a particular defined type." )]
    [IconCssClass( "fa fa-question" )]
    // [SupportedSiteTypes( Model.SiteType.Web )]

    #region Block Attributes
    [DefinedTypeField( "Defined Type",
        Description = "If a Defined Type is set, only details for it will be displayed (regardless of the querystring parameters).",
        IsRequired = false,
        Key = AttributeKey.DefinedType )]
    #endregion

    [Rock.SystemGuid.EntityTypeGuid( "bcd79456-ebd5-4a2f-94e5-c7387b0ea4b7" )]
    [Rock.SystemGuid.BlockTypeGuid( "73fd23b4-fa3a-49ea-b271-ffb228c6a49e" )]
    public class DefinedTypeDetail : RockDetailBlockType
    {
        #region Keys

        private static class PageParameterKey
        {
            public const string DefinedTypeId = "DefinedTypeId";
        }

        private static class NavigationUrlKey
        {
            public const string ParentPage = "ParentPage";
        }

        public static class AttributeKey
        {
            public const string DefinedType = "DefinedType";
        }

        #endregion Keys

        // If block is being used on a stand alone page ( i.e. not navigated to through defined type list )
        private bool _isStandAlone = false;

        #region Methods

        /// <inheritdoc/>
        public override object GetObsidianBlockInitialization()
        {
            using ( var rockContext = new RockContext() )
            {
                var box = new DetailBlockBox<DefinedTypeBag, DefinedTypeDetailOptionsBag>();

                SetBoxInitialEntityState( box, rockContext );

                box.NavigationUrls = GetBoxNavigationUrls();
                box.Options = GetBoxOptions( box.IsEditable, rockContext );
                box.QualifiedAttributeProperties = AttributeCache.GetAttributeQualifiedColumns<DefinedType>();

                return box;
            }
        }

        /// <summary>
        /// Gets the box options required for the component to render the view
        /// or edit the entity.
        /// </summary>
        /// <param name="isEditable"><c>true</c> if the entity is editable; otherwise <c>false</c>.</param>
        /// <param name="rockContext">The rock context.</param>
        /// <returns>The options that provide additional details to the block.</returns>
        private DefinedTypeDetailOptionsBag GetBoxOptions( bool isEditable, RockContext rockContext )
        {
            var options = new DefinedTypeDetailOptionsBag();

            return options;
        }

        /// <summary>
        /// Validates the DefinedType for any final information that might not be
        /// valid after storing all the data from the client.
        /// </summary>
        /// <param name="definedType">The DefinedType to be validated.</param>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="errorMessage">On <c>false</c> return, contains the error message.</param>
        /// <returns><c>true</c> if the DefinedType is valid, <c>false</c> otherwise.</returns>
        private bool ValidateDefinedType( DefinedType definedType, RockContext rockContext, out string errorMessage )
        {
            errorMessage = null;

            return true;
        }

        /// <summary>
        /// Sets the initial entity state of the box. Populates the Entity or
        /// ErrorMessage properties depending on the entity and permissions.
        /// </summary>
        /// <param name="box">The box to be populated.</param>
        /// <param name="rockContext">The rock context.</param>
        private void SetBoxInitialEntityState( DetailBlockBox<DefinedTypeBag, DefinedTypeDetailOptionsBag> box, RockContext rockContext )
        {
            var entity = GetInitialEntity( rockContext );

            if ( entity == null )
            {
                box.ErrorMessage = $"The {DefinedType.FriendlyTypeName} was not found.";
                return;
            }

            var isViewable = entity.IsAuthorized( Authorization.VIEW, RequestContext.CurrentPerson );
            box.IsEditable = entity.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson );

            entity.LoadAttributes( rockContext );

            if ( entity.Id != 0 )
            {
                // Existing entity was found, prepare for view mode by default.
                if ( isViewable )
                {
                    box.Entity = GetEntityBagForView( entity, rockContext );
                    box.SecurityGrantToken = GetSecurityGrantToken( entity );
                }
                else
                {
                    box.ErrorMessage = EditModeMessage.NotAuthorizedToView( DefinedType.FriendlyTypeName );
                }
            }
            else
            {
                // New entity is being created, prepare for edit mode by default.
                if ( box.IsEditable )
                {
                    box.Entity = GetEntityBagForEdit( entity );
                    box.SecurityGrantToken = GetSecurityGrantToken( entity );
                }
                else
                {
                    box.ErrorMessage = EditModeMessage.NotAuthorizedToEdit( DefinedType.FriendlyTypeName );
                }
            }
        }

        /// <summary>
        /// Gets the entity bag that is common between both view and edit modes.
        /// </summary>
        /// <param name="entity">The entity to be represented as a bag.</param>
        /// <returns>A <see cref="DefinedTypeBag"/> that represents the entity.</returns>
        private DefinedTypeBag GetCommonEntityBag( DefinedType entity )
        {
            if ( entity == null )
            {
                return null;
            }

            return new DefinedTypeBag
            {
                IdKey = entity.IdKey,
                CategorizedValuesEnabled = entity.CategorizedValuesEnabled,
                Category = entity.Category.ToListItemBag(),
                Description = entity.Description,
                EnableSecurityOnValues = entity.EnableSecurityOnValues,
                HelpText = entity.HelpText,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem,
                Name = entity.Name,
                IsStandAlone = _isStandAlone
            };
        }

        /// <summary>
        /// Gets the bag for viewing the specified entity.
        /// </summary>
        /// <param name="entity">The entity to be represented for view purposes.</param>
        /// <returns>A <see cref="DefinedTypeBag"/> that represents the entity.</returns>
        private DefinedTypeBag GetEntityBagForView( DefinedType entity, RockContext rockContext )
        {
            if ( entity == null )
            {
                return null;
            }

            var bag = GetCommonEntityBag( entity );

            bag.DefinedTypeAttributes = GetAttributes( entity.Id, rockContext ).ConvertAll( a => PublicAttributeHelper.GetPublicEditableAttributeViewModel( a ) );
            bag.LoadAttributesAndValuesForPublicView( entity, RequestContext.CurrentPerson );
            if ( entity.CategorizedValuesEnabled == true )
            {
                var reportDetailQueryParams = new Dictionary<string, string>()
                    {
                        { "EntityTypeId", EntityTypeCache.GetId<DefinedValue>().ToString() },
                        { "EntityQualifierColumn", "DefinedTypeId" },
                        { "EntityQualifierValue", entity.Id.ToString() }
                    };

                var pageReference = new PageReference( PageCache.GetId( Rock.SystemGuid.Page.HISTORY_CATEGORIES.AsGuid() ).GetValueOrDefault() );
                pageReference.Parameters = reportDetailQueryParams;

                bag.ReportDetailPageUrl = pageReference.BuildUrl();
            }

            return bag;
        }

        /// <summary>
        /// Gets the bag for editing the specified entity.
        /// </summary>
        /// <param name="entity">The entity to be represented for edit purposes.</param>
        /// <returns>A <see cref="DefinedTypeBag"/> that represents the entity.</returns>
        private DefinedTypeBag GetEntityBagForEdit( DefinedType entity )
        {
            if ( entity == null )
            {
                return null;
            }

            var bag = GetCommonEntityBag( entity );

            bag.LoadAttributesAndValuesForPublicEdit( entity, RequestContext.CurrentPerson );

            return bag;
        }

        /// <summary>
        /// Updates the entity from the data in the save box.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <param name="box">The box containing the information to be updated.</param>
        /// <param name="rockContext">The rock context.</param>
        /// <returns><c>true</c> if the box was valid and the entity was updated, <c>false</c> otherwise.</returns>
        private bool UpdateEntityFromBox( DefinedType entity, DetailBlockBox<DefinedTypeBag, DefinedTypeDetailOptionsBag> box, RockContext rockContext )
        {
            if ( box.ValidProperties == null )
            {
                return false;
            }

            box.IfValidProperty( nameof( box.Entity.CategorizedValuesEnabled ),
                () => entity.CategorizedValuesEnabled = box.Entity.CategorizedValuesEnabled );

            box.IfValidProperty( nameof( box.Entity.Category ),
                () => entity.CategoryId = box.Entity.Category.GetEntityId<Category>( rockContext ) );

            box.IfValidProperty( nameof( box.Entity.Description ),
                () => entity.Description = box.Entity.Description );

            box.IfValidProperty( nameof( box.Entity.EnableSecurityOnValues ),
                () => entity.EnableSecurityOnValues = box.Entity.EnableSecurityOnValues );

            box.IfValidProperty( nameof( box.Entity.HelpText ),
                () => entity.HelpText = box.Entity.HelpText );

            box.IfValidProperty( nameof( box.Entity.IsActive ),
                () => entity.IsActive = box.Entity.IsActive );

            box.IfValidProperty( nameof( box.Entity.Name ),
                () => entity.Name = box.Entity.Name );

            box.IfValidProperty( nameof( box.Entity.AttributeValues ),
                () =>
                {
                    entity.LoadAttributes( rockContext );

                    entity.SetPublicAttributeValues( box.Entity.AttributeValues, RequestContext.CurrentPerson );
                } );

            return true;
        }

        /// <summary>
        /// Gets the initial entity from page parameters or creates a new entity
        /// if page parameters requested creation.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <returns>The <see cref="DefinedType"/> to be viewed or edited on the page.</returns>
        private DefinedType GetInitialEntity( RockContext rockContext )
        {
            Guid? definedTypeGuid = GetAttributeValue( AttributeKey.DefinedType ).AsGuidOrNull();

            // A configured defined type takes precedence over any definedTypeId param value that is passed in.
            if ( definedTypeGuid.HasValue )
            {
                _isStandAlone = true;
                var definedTypeService = new DefinedTypeService( rockContext );
                var definedType = definedTypeService.Get( definedTypeGuid.Value );
                return definedType ?? new DefinedType()
                {
                    Id = 0,
                    Guid = Guid.Empty
                };
            }
            else
            {
                return GetInitialEntity<DefinedType, DefinedTypeService>( rockContext, PageParameterKey.DefinedTypeId ); 
            }
        }

        /// <summary>
        /// Gets the box navigation URLs required for the page to operate.
        /// </summary>
        /// <returns>A dictionary of key names and URL values.</returns>
        private Dictionary<string, string> GetBoxNavigationUrls()
        {
            return new Dictionary<string, string>
            {
                [NavigationUrlKey.ParentPage] = this.GetParentPageUrl()
            };
        }

        /// <inheritdoc/>
        protected override string RenewSecurityGrantToken()
        {
            using ( var rockContext = new RockContext() )
            {
                var entity = GetInitialEntity( rockContext );

                if ( entity != null )
                {
                    entity.LoadAttributes( rockContext );
                }

                return GetSecurityGrantToken( entity );
            }
        }

        /// <summary>
        /// Gets the security grant token that will be used by UI controls on
        /// this block to ensure they have the proper permissions.
        /// </summary>
        /// <returns>A string that represents the security grant token.</string>
        private string GetSecurityGrantToken( DefinedType entity )
        {
            var securityGrant = new Rock.Security.SecurityGrant();

            securityGrant.AddRulesForAttributes( entity, RequestContext.CurrentPerson );

            return securityGrant.ToToken();
        }

        /// <summary>
        /// Attempts to load an entity to be used for an edit action.
        /// </summary>
        /// <param name="idKey">The identifier key of the entity to load.</param>
        /// <param name="rockContext">The database context to load the entity from.</param>
        /// <param name="entity">Contains the entity that was loaded when <c>true</c> is returned.</param>
        /// <param name="error">Contains the action error result when <c>false</c> is returned.</param>
        /// <returns><c>true</c> if the entity was loaded and passed security checks.</returns>
        private bool TryGetEntityForEditAction( string idKey, RockContext rockContext, out DefinedType entity, out BlockActionResult error )
        {
            var entityService = new DefinedTypeService( rockContext );
            error = null;

            // Determine if we are editing an existing entity or creating a new one.
            if ( idKey.IsNotNullOrWhiteSpace() )
            {
                // If editing an existing entity then load it and make sure it
                // was found and can still be edited.
                entity = entityService.Get( idKey, !PageCache.Layout.Site.DisablePredictableIds );
            }
            else
            {
                // Create a new entity.
                entity = new DefinedType();
                entityService.Add( entity );
            }

            if ( entity == null )
            {
                error = ActionBadRequest( $"{DefinedType.FriendlyTypeName} not found." );
                return false;
            }

            if ( !entity.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
            {
                error = ActionBadRequest( $"Not authorized to edit ${DefinedType.FriendlyTypeName}." );
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the attributes for the AttributeMatrixTemplate entity.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <param name="rockContext">The rock context.</param>
        /// <returns></returns>
        private List<Rock.Model.Attribute> GetAttributes( int id, RockContext rockContext )
        {
            string qualifierValue = id.ToString();
            var attributeService = new AttributeService( rockContext );
            return attributeService.GetByEntityTypeQualifier( new DefinedValue().TypeId, "DefinedTypeId", qualifierValue, true ).AsQueryable()
                .OrderBy( a => a.Order )
                .ThenBy( a => a.Name )
                .ToList();
        }

        #endregion

        #region Block Actions

        /// <summary>
        /// Gets the box that will contain all the information needed to begin
        /// the edit operation.
        /// </summary>
        /// <param name="key">The identifier of the entity to be edited.</param>
        /// <returns>A box that contains the entity and any other information required.</returns>
        [BlockAction]
        public BlockActionResult Edit( string key )
        {
            using ( var rockContext = new RockContext() )
            {
                if ( !TryGetEntityForEditAction( key, rockContext, out var entity, out var actionError ) )
                {
                    return actionError;
                }

                entity.LoadAttributes( rockContext );

                var box = new DetailBlockBox<DefinedTypeBag, DefinedTypeDetailOptionsBag>
                {
                    Entity = GetEntityBagForEdit( entity )
                };

                return ActionOk( box );
            }
        }

        /// <summary>
        /// Saves the entity contained in the box.
        /// </summary>
        /// <param name="box">The box that contains all the information required to save.</param>
        /// <returns>A new entity bag to be used when returning to view mode, or the URL to redirect to after creating a new entity.</returns>
        [BlockAction]
        public BlockActionResult Save( DetailBlockBox<DefinedTypeBag, DefinedTypeDetailOptionsBag> box )
        {
            using ( var rockContext = new RockContext() )
            {
                var entityService = new DefinedTypeService( rockContext );

                if ( !TryGetEntityForEditAction( box.Entity.IdKey, rockContext, out var entity, out var actionError ) )
                {
                    return actionError;
                }

                // Update the entity instance from the information in the bag.
                if ( !UpdateEntityFromBox( entity, box, rockContext ) )
                {
                    return ActionBadRequest( "Invalid data." );
                }

                // Ensure everything is valid before saving.
                if ( !ValidateDefinedType( entity, rockContext, out var validationMessage ) )
                {
                    return ActionBadRequest( validationMessage );
                }

                var isNew = entity.Id == 0;

                rockContext.WrapTransaction( () =>
                {
                    rockContext.SaveChanges();
                    entity.SaveAttributeValues( rockContext );
                } );

                if ( isNew )
                {
                    return ActionContent( System.Net.HttpStatusCode.Created, this.GetCurrentPageUrl( new Dictionary<string, string>
                    {
                        [PageParameterKey.DefinedTypeId] = entity.IdKey
                    } ) );
                }

                // Ensure navigation properties will work now.
                entity = entityService.Get( entity.Id );
                entity.LoadAttributes( rockContext );

                return ActionOk( GetEntityBagForView( entity, rockContext ) );
            }
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="key">The identifier of the entity to be deleted.</param>
        /// <returns>A string that contains the URL to be redirected to on success.</returns>
        [BlockAction]
        public BlockActionResult Delete( string key )
        {
            using ( var rockContext = new RockContext() )
            {
                var entityService = new DefinedTypeService( rockContext );

                if ( !TryGetEntityForEditAction( key, rockContext, out var entity, out var actionError ) )
                {
                    return actionError;
                }

                if ( !entityService.CanDelete( entity, out var errorMessage ) )
                {
                    return ActionBadRequest( errorMessage );
                }

                entityService.Delete( entity );
                rockContext.SaveChanges();

                return ActionOk( this.GetParentPageUrl() );
            }
        }

        /// <summary>
        /// Refreshes the list of attributes that can be displayed for editing
        /// purposes based on any modified values on the entity.
        /// </summary>
        /// <param name="box">The box that contains all the information about the entity being edited.</param>
        /// <returns>A box that contains the entity and attribute information.</returns>
        [BlockAction]
        public BlockActionResult RefreshAttributes( DetailBlockBox<DefinedTypeBag, DefinedTypeDetailOptionsBag> box )
        {
            using ( var rockContext = new RockContext() )
            {
                if ( !TryGetEntityForEditAction( box.Entity.IdKey, rockContext, out var entity, out var actionError ) )
                {
                    return actionError;
                }

                // Update the entity instance from the information in the bag.
                if ( !UpdateEntityFromBox( entity, box, rockContext ) )
                {
                    return ActionBadRequest( "Invalid data." );
                }

                // Reload attributes based on the new property values.
                entity.LoadAttributes( rockContext );

                var refreshedBox = new DetailBlockBox<DefinedTypeBag, DefinedTypeDetailOptionsBag>
                {
                    Entity = GetEntityBagForEdit( entity )
                };

                var oldAttributeGuids = box.Entity.Attributes.Values.Select( a => a.AttributeGuid ).ToList();
                var newAttributeGuids = refreshedBox.Entity.Attributes.Values.Select( a => a.AttributeGuid );

                // If the attributes haven't changed then return a 204 status code.
                if ( oldAttributeGuids.SequenceEqual( newAttributeGuids ) )
                {
                    return ActionStatusCode( System.Net.HttpStatusCode.NoContent );
                }

                // Replace any values for attributes that haven't changed with
                // the value sent by the client. This ensures any unsaved attribute
                // value changes are not lost.
                foreach ( var kvp in refreshedBox.Entity.Attributes )
                {
                    if ( oldAttributeGuids.Contains( kvp.Value.AttributeGuid ) )
                    {
                        refreshedBox.Entity.AttributeValues[kvp.Key] = box.Entity.AttributeValues[kvp.Key];
                    }
                }

                return ActionOk( refreshedBox );
            }
        }

        /// <summary>
        /// Changes the ordered position of a single item.
        /// </summary>
        /// <param name="guid">The identifier of the item that will be moved.</param>
        /// <param name="beforeGuid">The identifier of the item it will be placed before.</param>
        /// <returns>An empty result that indicates if the operation succeeded.</returns>
        [BlockAction]
        public BlockActionResult ReorderAttributes( string idKey, Guid guid, Guid? beforeGuid )
        {
            using ( var rockContext = new RockContext() )
            {
                // Get the queryable and make sure it is ordered correctly.
                var id = Rock.Utility.IdHasher.Instance.GetId( idKey );

                var attributes = GetAttributes( id ?? 0, rockContext );

                if ( !attributes.ReorderEntity( guid.ToString(), beforeGuid.ToString() ) )
                {
                    return ActionBadRequest( "Invalid reorder attempt." );
                }

                rockContext.SaveChanges();

                return ActionOk();
            }
        }

        /// <summary>
        /// Handles the save event of the DefinedTypeAttributes grid.
        /// </summary>
        /// <param name="idKey">The DefinedType identifier</param>
        /// <param name="attributebag">The attribute</param>
        /// <returns></returns>
        [BlockAction]
        public BlockActionResult SaveAttribute( string idKey, PublicEditableAttributeBag attributebag )
        {
            using ( var rockContext = new RockContext() )
            {
                string qualifierValue = Rock.Utility.IdHasher.Instance.GetId( idKey ).ToString();
                var entityTypeIdDefinedType = EntityTypeCache.GetId<DefinedValue>();
                var attribute = Helper.SaveAttributeEdits( attributebag, entityTypeIdDefinedType, "DefinedTypeId", qualifierValue, rockContext );
                attributebag = PublicAttributeHelper.GetPublicEditableAttributeViewModel( attribute );
                return ActionOk( attributebag );
            }
        }

        /// <summary>
        /// Handles the Delete event of the DefinedTypeAttributes grid.
        /// </summary>
        /// <param name="guid">The attribute identifier.</param>
        [BlockAction]
        public BlockActionResult DeleteAttribute( Guid guid )
        {
            using ( var rockContext = new RockContext() )
            {
                AttributeService attributeService = new AttributeService( rockContext );
                var attribute = attributeService.Get( guid );

                if ( attribute != null && attributeService.CanDelete( attribute, out string errorMessage ) )
                {
                    attributeService.Delete( attribute );
                    rockContext.SaveChanges();

                    return ActionOk( errorMessage );
                }

                return ActionBadRequest();
            }
        }

        #endregion
    }
}
