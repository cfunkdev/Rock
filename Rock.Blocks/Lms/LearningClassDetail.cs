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
using System.Data.Entity;
using System.Linq;

using Rock.Attribute;
using Rock.Constants;
using Rock.Data;
using Rock.Lms;
using Rock.Model;
using Rock.Obsidian.UI;
using Rock.Security;
using Rock.ViewModels.Blocks;
using Rock.ViewModels.Blocks.Lms.LearningClassDetail;
using Rock.ViewModels.Utility;
using Rock.Web;
using Rock.Web.Cache;

namespace Rock.Blocks.Lms
{
    /// <summary>
    /// Displays the details of a particular learning class.
    /// </summary>

    [DisplayName( "Learning Class Detail" )]
    [Category( "LMS" )]
    [Description( "Displays the details of a particular learning class." )]
    [IconCssClass( "fa fa-question" )]
    // [SupportedSiteTypes( Model.SiteType.Web )]

    #region Block Attributes

    [LinkedPage( "Activity Detail Page",
        Description = "The page that will be navigated to when clicking an activity row.",
        Key = AttributeKey.ActivityDetailPage,
        IsRequired = false,
        Order = 1 )]

    [LinkedPage( "Attendance Page",
        Description = "The page that to be used for taking attendance for the class.",
        Key = AttributeKey.AttendancePage,
        IsRequired = false,
        Order = 2 )]

    [LinkedPage( "Participant Detail Page",
        Description = "The page that to be used for taking attendance for the class.",
        Key = AttributeKey.ParticipantDetailPage,
        IsRequired = false,
        Order = 3 )]

    [LinkedPage( "Content Page Detail Page",
        Description = "The page that will be navigated to when clicking a content page row.",
        Key = AttributeKey.ContentPageDetailPage,
        IsRequired = false,
        Order = 4 )]

    [LinkedPage( "Announcement Detail Page",
        Description = "The page that will be navigated to when clicking a content page row.",
        Key = AttributeKey.AnnouncementDetailPage,
        IsRequired = false,
        Order = 5 )]

    #endregion

    [Rock.SystemGuid.EntityTypeGuid( "08b8da88-be2e-4237-883d-b9a2db5f6260" )]
    [Rock.SystemGuid.BlockTypeGuid( "d5369f8d-11aa-482b-ae08-2b3c519d8d87" )]
    public class LearningClassDetail : RockEntityDetailBlockType<LearningClass, LearningClassBag>, IBreadCrumbBlock
    {
        #region Keys

        private static class AttributeKey
        {
            public const string ActivityDetailPage = "ActivityDetailPage";
            public const string AnnouncementDetailPage = "AnnouncementDetailPage";
            public const string AttendancePage = "AttendancePage";
            public const string ContentPageDetailPage = "ContentPageDetailPage";
            public const string ParticipantDetailPage = "ParticipantDetailPage";
            public const string ParentPage = "ParentPage";
        }

        private static class PageParameterKey
        {
            public const string LearningActivityId = "LearningActivityId";
            public const string LearningClassId = "LearningClassId";
            public const string LearningClassContentPageId = "LearningClassContentPageId";
            public const string LearningClassAnnouncementId = "LearningClassAnnouncementId";
            public const string LearningCourseId = "LearningCourseId";
            public const string LearningParticipantId = "LearningParticipantId";
            public const string LearningProgramId = "LearningProgramId";
        }

        private static class NavigationUrlKey
        {
            public const string ActivityDetailPage = "ActivityDetailPage";
            public const string AnnouncementDetailPage = "AnnouncementDetailPage";
            public const string AttendancePage = "AttendancePage";
            public const string ContentPageDetailPage = "ContentPageDetailPage";
            public const string ParticipantDetailPage = "ParticipantDetailPage";
            public const string ParentPage = "ParentPage";
        }

        #endregion Keys

        #region Methods

        /// <inheritdoc/>
        public override object GetObsidianBlockInitialization()
        {
            var box = new DetailBlockBox<LearningClassBag, LearningClassDetailOptionsBag>();

            SetBoxInitialEntityState( box );

            box.NavigationUrls = GetBoxNavigationUrls();
            box.Options = GetBoxOptions( box.IsEditable );

            return box;
        }

        /// <summary>
        /// Gets the box options required for the component to render the view
        /// or edit the entity.
        /// </summary>
        /// <param name="isEditable"><c>true</c> if the entity is editable; otherwise <c>false</c>.</param>
        /// <returns>The options that provide additional details to the block.</returns>
        private LearningClassDetailOptionsBag GetBoxOptions( bool isEditable )
        {
            var programId = RequestContext.PageParameterAsId( PageParameterKey.LearningProgramId );
            var options = new LearningClassDetailOptionsBag();

            if ( programId > 0 )
            {
                var programService = new LearningProgramService( RockContext );
                options.ProgramConfigurationMode = programService.GetConfigurationMode( programId );
                options.Semesters = programService.Semesters( programId ).ToListItemBagList();
            }

            options.GradingSystems = new LearningGradingSystemService( RockContext ).Queryable().Where( g => g.IsActive ).ToListItemBagList();

            return options;
        }

        /// <summary>
        /// Validates the LearningClass for any final information that might not be
        /// valid after storing all the data from the client.
        /// </summary>
        /// <param name="learningClass">The LearningClass to be validated.</param>
        /// <param name="errorMessage">On <c>false</c> return, contains the error message.</param>
        /// <returns><c>true</c> if the LearningClass is valid, <c>false</c> otherwise.</returns>
        private bool ValidateLearningClass( LearningClass learningClass, out string errorMessage )
        {
            errorMessage = null;

            return true;
        }

        /// <summary>
        /// Sets the initial entity state of the box. Populates the Entity or
        /// ErrorMessage properties depending on the entity and permissions.
        /// </summary>
        /// <param name="box">The box to be populated.</param>
        private void SetBoxInitialEntityState( DetailBlockBox<LearningClassBag, LearningClassDetailOptionsBag> box )
        {
            var entity = GetInitialEntity();

            if ( entity == null )
            {
                box.ErrorMessage = $"The {LearningClass.FriendlyTypeName} was not found.";
                return;
            }

            var isViewable = entity.IsAuthorized( Authorization.VIEW, RequestContext.CurrentPerson );
            box.IsEditable = entity.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson );

            if ( entity.Id != 0 )
            {
                // Existing entity was found, prepare for view mode by default.
                if ( isViewable )
                {
                    box.Entity = GetEntityBagForView( entity );
                }
                else
                {
                    box.ErrorMessage = EditModeMessage.NotAuthorizedToView( LearningClass.FriendlyTypeName );
                }
            }
            else
            {
                // New entity is being created, prepare for edit mode by default.
                if ( box.IsEditable )
                {
                    box.Entity = GetEntityBagForEdit( entity );
                }
                else
                {
                    box.ErrorMessage = EditModeMessage.NotAuthorizedToEdit( LearningClass.FriendlyTypeName );
                }
            }

            PrepareDetailBox( box, entity );
        }

        /// <summary>
        /// Gets the entity bag that is common between both view and edit modes.
        /// </summary>
        /// <param name="entity">The entity to be represented as a bag.</param>
        /// <returns>A <see cref="LearningClassBag"/> that represents the entity.</returns>
        private LearningClassBag GetCommonEntityBag( LearningClass entity )
        {
            if ( entity == null )
            {
                return null;
            }

            var locationItem = entity.GroupLocations?.FirstOrDefault();

            return new LearningClassBag
            {
                IdKey = entity.IdKey,
                Campus = entity.Campus?.ToListItemBag() ?? new ListItemBag(),
                TakesAttendance = entity.GroupType?.TakesAttendance ?? false,
                Description = entity.Description,
                Location = locationItem?.ToListItemBag( locationItem.Location.Name ) ?? new ListItemBag(),
                IsActive = entity.IsActive,
                IsPublic = entity.IsPublic,
                CourseCode = entity.LearningCourse?.CourseCode,
                CourseName = entity.LearningCourse?.Name,
                GradingSystem = entity.LearningGradingSystem?.ToListItemBag() ?? new ListItemBag(),
                Semester = entity.LearningSemester?.ToListItemBag() ?? new ListItemBag(),
                StudentCount = new LearningParticipantService( RockContext ).GetStudents( entity.Id ).Count(),
                Name = entity.Name,
                Schedule = entity.Schedule?.ToListItemBag() ?? new ListItemBag()
            };
        }

        /// <inheritdoc/>
        protected override LearningClassBag GetEntityBagForView( LearningClass entity )
        {
            if ( entity == null )
            {
                return null;
            }

            var bag = GetCommonEntityBag( entity );

            // Get just what we need for the facilitators info.
            bag.Facilitators = new LearningParticipantService( RockContext )
                .GetFacilitatorBags( entity.Id )
                .ToList()
                .Select( f => new LearningClassFacilitatorBag
                {
                    IdKey = f.IdKey,
                    FacilitatorName = f.Name,
                    FacilitatorRole = f.RoleName,
                    Facilitator = new ListItemBag
                    {
                        Value = f.Guid.ToString(),
                        Text = f.Name
                    }
                } )
                .ToList();

            return bag;
        }

        //// <inheritdoc/>
        protected override LearningClassBag GetEntityBagForEdit( LearningClass entity )
        {
            if ( entity == null )
            {
                return null;
            }

            var bag = GetCommonEntityBag( entity );

            return bag;
        }

        /// <inheritdoc/>
        protected override bool UpdateEntityFromBox( LearningClass entity, ValidPropertiesBox<LearningClassBag> box )
        {
            if ( box.ValidProperties == null )
            {
                return false;
            }

            if ( entity.GroupTypeId == 0 )
            {
                if ( Guid.TryParse( SystemGuid.GroupType.GROUPTYPE_LMS_CLASS, out var groupTypeGuid ) )
                {
                    entity.GroupTypeId = new GroupTypeService( RockContext ).GetId( groupTypeGuid ).Value;
                }
            }

            box.IfValidProperty( nameof( box.Bag.Campus ),
                () => entity.CampusId = box.Bag.Campus.GetEntityId<Campus>( RockContext ) );

            box.IfValidProperty( nameof( box.Bag.Description ),
                () => entity.Description = box.Bag.Description );

            var deleteLocatonError = string.Empty;

            box.IfValidProperty( nameof( box.Bag.Location ),
                () =>
                {
                    var locationId = box.Bag.Location.GetEntityId<Location>( RockContext );
                    var currentLocation = entity.GroupLocations.FirstOrDefault();
                    if ( currentLocation?.LocationId != locationId )
                    {
                        var groupLocationService = new GroupLocationService( RockContext );

                        // Remove the current location if it doesn't match.
                        if ( currentLocation != null )
                        {
                            groupLocationService.CanDelete( currentLocation, out deleteLocatonError );

                            groupLocationService.Delete( currentLocation );
                        }

                        // If there's a new location add it.
                        if ( locationId > 0 )
                        {
                            entity.GroupLocations.Add( groupLocationService.GetByLocation( locationId.Value ).FirstOrDefault() );
                        }
                    }

                } );

            // If there was an error deleting the location then return false to notify the caller of the error.
            if ( deleteLocatonError.Length > 0 )
            {
                return false;
            }

            box.IfValidProperty( nameof( box.Bag.IsActive ),
                () => entity.IsActive = box.Bag.IsActive );

            box.IfValidProperty( nameof( box.Bag.IsPublic ),
                () => entity.IsPublic = box.Bag.IsPublic );

            // Only allow the UI to set the grading system if it's not yet set.
            // Because existing ActivityCompletions may be set using it.
            if ( entity.LearningGradingSystemId == 0 )
            {
                box.IfValidProperty( nameof( box.Bag.GradingSystem ),
                () => entity.LearningGradingSystemId = box.Bag.GradingSystem.GetEntityId<LearningGradingSystem>( RockContext ).Value );
            }

            box.IfValidProperty( nameof( box.Bag.Semester ),
                () => entity.LearningSemesterId = box.Bag.Semester.GetEntityId<LearningSemester>( RockContext ) );

            box.IfValidProperty( nameof( box.Bag.Name ),
                () => entity.Name = box.Bag.Name );

            box.IfValidProperty( nameof( box.Bag.Schedule ),
                () => entity.ScheduleId = box.Bag.Schedule.GetEntityId<Schedule>( RockContext ) );

            return true;
        }

        /// <inheritdoc/>
        protected override LearningClass GetInitialEntity()
        {
            // Parse out the Id if the parameter is an IdKey or take the Id
            // If the site allows predictable Ids in parameters.
            var entityId = RequestContext.PageParameterAsId( PageParameterKey.LearningClassId );

            // If a zero identifier is specified then create a new entity.
            if ( entityId == 0 )
            {
                return new LearningClass
                {
                    Id = 0,
                    Guid = Guid.Empty
                };
            }

            var entityService = new LearningClassService( RockContext );

            return entityService
                .Queryable()
                .Include( c => c.GroupType )
                .Include( c => c.Campus )
                .Include( c => c.LearningCourse )
                .Include( c => c.LearningCourse.LearningProgram )
                .Include( c => c.LearningGradingSystem )
                .FirstOrDefault( a => a.Id == entityId );
        }

        private Dictionary<string, string> GetCurrentPageParams( string keyPlaceholder = "" )
        {
            if ( !string.IsNullOrWhiteSpace( keyPlaceholder ) )
            {
                return new Dictionary<string, string>
                {
                    [PageParameterKey.LearningProgramId] = PageParameter( PageParameterKey.LearningProgramId ),
                    [PageParameterKey.LearningCourseId] = PageParameter( PageParameterKey.LearningCourseId ),
                    [PageParameterKey.LearningClassId] = PageParameter( PageParameterKey.LearningClassId ),
                    [keyPlaceholder] = "((Key))"
                };
            }

            return new Dictionary<string, string>
            {
                [PageParameterKey.LearningProgramId] = PageParameter( PageParameterKey.LearningProgramId ),
                [PageParameterKey.LearningCourseId] = PageParameter( PageParameterKey.LearningCourseId ),
                [PageParameterKey.LearningClassId] = PageParameter( PageParameterKey.LearningClassId ),
            };
        }

        /// <summary>
        /// Gets the box navigation URLs required for the page to operate.
        /// </summary>
        /// <returns>A dictionary of key names and URL values.</returns>
        private Dictionary<string, string> GetBoxNavigationUrls()
        {
            var currentPageParams = GetCurrentPageParams();
            var activityParams = GetCurrentPageParams( PageParameterKey.LearningActivityId );
            var participantParams = GetCurrentPageParams( PageParameterKey.LearningParticipantId );
            var contentPageParams = GetCurrentPageParams( PageParameterKey.LearningClassContentPageId );
            var announcementParams = GetCurrentPageParams( PageParameterKey.LearningClassAnnouncementId );

            return new Dictionary<string, string>
            {
                [NavigationUrlKey.AnnouncementDetailPage] = this.GetLinkedPageUrl( AttributeKey.AnnouncementDetailPage, announcementParams ),
                [NavigationUrlKey.ActivityDetailPage] = this.GetLinkedPageUrl( AttributeKey.ActivityDetailPage, activityParams ),
                [NavigationUrlKey.AttendancePage] = this.GetLinkedPageUrl( AttributeKey.AttendancePage, currentPageParams ),
                [NavigationUrlKey.ContentPageDetailPage] = this.GetLinkedPageUrl( AttributeKey.ContentPageDetailPage, contentPageParams ),
                [NavigationUrlKey.ParticipantDetailPage] = this.GetLinkedPageUrl( AttributeKey.ParticipantDetailPage, participantParams ),
                [NavigationUrlKey.ParentPage] = this.GetParentPageUrl( currentPageParams ),
            };
        }

        /// <inheritdoc/>
        protected override bool TryGetEntityForEditAction( string idKey, out LearningClass entity, out BlockActionResult error )
        {
            var entityService = new LearningClassService( RockContext );
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
                entity = new LearningClass();

                entity.LearningCourseId = RequestContext.PageParameterAsId( PageParameterKey.LearningCourseId );

                entityService.Add( entity );
            }

            if ( entity == null )
            {
                error = ActionBadRequest( $"{LearningClass.FriendlyTypeName} not found." );
                return false;
            }

            if ( !entity.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
            {
                error = ActionBadRequest( $"Not authorized to edit ${LearningClass.FriendlyTypeName}." );
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public BreadCrumbResult GetBreadCrumbs( PageReference pageReference )
        {
            using ( var rockContext = new RockContext() )
            {
                var entityKey = pageReference.GetPageParameter( PageParameterKey.LearningClassId ) ?? "";

                var entityName = entityKey.Length > 0 ? new Service<LearningClass>( rockContext ).GetSelect( entityKey, p => p.Name ) : "New Class";
                var breadCrumbPageRef = new PageReference( pageReference.PageId, pageReference.RouteId, pageReference.Parameters );
                var breadCrumb = new BreadCrumbLink( entityName ?? "New Class", breadCrumbPageRef );

                return new BreadCrumbResult
                {
                    BreadCrumbs = new List<IBreadCrumb>
                    {
                        breadCrumb
                    }
                };
            }
        }

        #endregion

        #region Block Actions

        /// <summary>
        /// Gets the box that will contain all the information needed to begin
        /// the clone operation.
        /// </summary>
        /// <param name="key">The identifier of the entity to be cloned.</param>
        /// <returns>A box that contains the entity and any other information required.</returns>
        [BlockAction]
        public BlockActionResult Clone( string key )
        {
            if ( !TryGetEntityForEditAction( key, out var entity, out var actionError ) )
            {
                return actionError;
            }

            var bag = GetEntityBagForEdit( entity );

            // Remove the id and update the name.
            // GetEntityBagForEdit expects to know the Entity.Id so we can't use CloneWithoutIdentity.
            bag.IdKey = string.Empty;
            bag.Name += " - Copy";

            return ActionOk( new ValidPropertiesBox<LearningClassBag>
            {
                Bag = bag,
                ValidProperties = bag.GetType().GetProperties().Select( p => p.Name ).ToList()
            } );
        }

        /// <summary>
        /// Copy the Class to create as a new Class
        /// </summary>
        [BlockAction]
        public BlockActionResult Copy( string key )
        {
            if ( !BlockCache.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
            {
                return ActionForbidden( $"Not authorized to copy {LearningClass.FriendlyTypeName}." );
            }

            if ( key.IsNullOrWhiteSpace() )
            {
                return ActionNotFound();
            }

            var copiedEntity = new LearningClassService( RockContext ).Copy( key );

            var queryParams = new Dictionary<string, string>
            {
                [PageParameterKey.LearningProgramId] = PageParameter( PageParameterKey.LearningProgramId ),
                [PageParameterKey.LearningCourseId] = PageParameter( PageParameterKey.LearningCourseId ),
                [PageParameterKey.LearningClassId] = copiedEntity.IdKey
            };

            return ActionContent( System.Net.HttpStatusCode.Created, this.GetCurrentPageUrl( queryParams ) );
        }

        /// <summary>
        /// Gets the box that will contain all the information needed to begin
        /// the edit operation.
        /// </summary>
        /// <param name="key">The identifier of the entity to be edited.</param>
        /// <returns>A box that contains the entity and any other information required.</returns>
        [BlockAction]
        public BlockActionResult Edit( string key )
        {
            if ( !TryGetEntityForEditAction( key, out var entity, out var actionError ) )
            {
                return actionError;
            }

            var bag = GetEntityBagForEdit( entity );

            return ActionOk( new ValidPropertiesBox<LearningClassBag>
            {
                Bag = bag,
                ValidProperties = bag.GetType().GetProperties().Select( p => p.Name ).ToList()
            } );
        }

        /// <summary>
        /// Saves the entity contained in the box.
        /// </summary>
        /// <param name="box">The box that contains all the information required to save.</param>
        /// <returns>A new entity bag to be used when returning to view mode, or the URL to redirect to after creating a new entity.</returns>
        [BlockAction]
        public BlockActionResult Save( ValidPropertiesBox<LearningClassBag> box )
        {
            var entityService = new LearningClassService( RockContext );

            if ( !TryGetEntityForEditAction( box.Bag.IdKey, out var entity, out var actionError ) )
            {
                return actionError;
            }

            // Update the entity instance from the information in the bag.
            if ( !UpdateEntityFromBox( entity, box ) )
            {
                return ActionBadRequest( "Invalid data." );
            }

            // Ensure everything is valid before saving.
            if ( !ValidateLearningClass( entity, out var validationMessage ) )
            {
                return ActionBadRequest( validationMessage );
            }

            var isNew = entity.Id == 0;

            RockContext.WrapTransaction( () =>
            {
                RockContext.SaveChanges();
            } );

            if ( isNew )
            {
                return ActionContent( System.Net.HttpStatusCode.Created, this.GetCurrentPageUrl( new Dictionary<string, string>
                {
                    [PageParameterKey.LearningClassId] = entity.IdKey
                } ) );
            }

            // Ensure navigation properties will work now.
            entity = entityService.Get( entity.Id );

            var bag = GetEntityBagForEdit( entity );

            return ActionOk( new ValidPropertiesBox<LearningClassBag>
            {
                Bag = bag,
                ValidProperties = bag.GetType().GetProperties().Select( p => p.Name ).ToList()
            } );
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="key">The identifier of the entity to be deleted.</param>
        /// <returns>A string that contains the URL to be redirected to on success.</returns>
        [BlockAction]
        public BlockActionResult Delete( string key )
        {
            var entityService = new LearningClassService( RockContext );

            if ( !TryGetEntityForEditAction( key, out var entity, out var actionError ) )
            {
                return actionError;
            }

            if ( !entityService.CanDelete( entity, out var errorMessage ) )
            {
                return ActionBadRequest( errorMessage );
            }

            entityService.Delete( entity );
            RockContext.SaveChanges();

            return ActionOk( this.GetParentPageUrl() );
        }

        #endregion


        /*
            2024/04/04 - JSC

            To match mock-ups of the Course Detail block (On-Demand mode)
            we had to embed several "list blocks" in the LearningCourseDetail component.
            Because each Obsidian block requires an instance of that block type on the page
            we couldn't create re-usable blocks, but instead had to route their block actions
            through the Course Detail block. We tried to componentize these grids as much as possible.
            If at a later time - we have a method of adding blocks to a tabbed control in Obsidian
            we can look at refactoring this code.
	
            Reason: Unable to embed child blocks in an Obsidian block.
        */
        #region Secondary List/Grid Block Actions

        /// <summary>
        /// Deletes the specified activity.
        /// </summary>
        /// <param name="key">The identifier of the entity to be deleted.</param>
        /// <returns>An empty result that indicates if the operation succeeded.</returns>
        [BlockAction]
        public BlockActionResult DeleteActivity( string key )
        {
            using ( var rockContext = new RockContext() )
            {
                var entityService = new LearningActivityService( rockContext );
                var entity = entityService.Get( key, !PageCache.Layout.Site.DisablePredictableIds );

                if ( entity == null )
                {
                    return ActionBadRequest( $"{LearningActivity.FriendlyTypeName} not found." );
                }

                if ( !BlockCache.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
                {
                    return ActionBadRequest( $"Not authorized to delete ${LearningActivity.FriendlyTypeName}." );
                }

                if ( !entityService.CanDelete( entity, out var errorMessage ) )
                {
                    return ActionBadRequest( errorMessage );
                }

                entityService.Delete( entity );
                rockContext.SaveChanges();

                return ActionOk();
            }
        }

        /// <summary>
        /// Deletes the specified activity.
        /// </summary>
        /// <param name="key">The identifier of the entity to be deleted.</param>
        /// <returns>An empty result that indicates if the operation succeeded.</returns>
        [BlockAction]
        public BlockActionResult DeleteAnnouncement( string key )
        {
            var entityService = new LearningClassAnnouncementService( RockContext );
            var entity = entityService.Get( key, !PageCache.Layout.Site.DisablePredictableIds );

            if ( entity == null )
            {
                return ActionBadRequest( $"{LearningClassAnnouncement.FriendlyTypeName} not found." );
            }

            if ( !BlockCache.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
            {
                return ActionBadRequest( $"Not authorized to delete ${LearningClassAnnouncement.FriendlyTypeName}." );
            }

            if ( !entityService.CanDelete( entity, out var errorMessage ) )
            {
                return ActionBadRequest( errorMessage );
            }

            entityService.Delete( entity );
            RockContext.SaveChanges();

            return ActionOk();
        }

        /// <summary>
        /// Deletes the specified activity.
        /// </summary>
        /// <param name="key">The identifier of the entity to be deleted.</param>
        /// <returns>An empty result that indicates if the operation succeeded.</returns>
        [BlockAction]
        public BlockActionResult DeleteContentPage( string key )
        {
            var entityService = new LearningClassContentPageService( RockContext );
            var entity = entityService.Get( key, !PageCache.Layout.Site.DisablePredictableIds );

            if ( entity == null )
            {
                return ActionBadRequest( $"{LearningClassContentPage.FriendlyTypeName} not found." );
            }

            if ( !BlockCache.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
            {
                return ActionBadRequest( $"Not authorized to delete ${LearningClassContentPage.FriendlyTypeName}." );
            }

            if ( !entityService.CanDelete( entity, out var errorMessage ) )
            {
                return ActionBadRequest( errorMessage );
            }

            entityService.Delete( entity );
            RockContext.SaveChanges();

            return ActionOk();
        }

        /// <summary>
        /// Deletes the specified participant.
        /// </summary>
        /// <param name="key">The identifier of the entity to be deleted.</param>
        /// <returns>An empty result that indicates if the operation succeeded.</returns>
        [BlockAction]
        public BlockActionResult DeleteParticipant( string key )
        {
            var entityService = new LearningParticipantService( RockContext );
            var entity = entityService.Get( key, !PageCache.Layout.Site.DisablePredictableIds );

            if ( entity == null )
            {
                return ActionBadRequest( $"{LearningParticipant.FriendlyTypeName} not found." );
            }

            if ( !BlockCache.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
            {
                return ActionBadRequest( $"Not authorized to delete ${LearningParticipant.FriendlyTypeName}." );
            }

            if ( !entityService.CanDelete( entity, out var errorMessage ) )
            {
                return ActionBadRequest( errorMessage );
            }

            entityService.Delete( entity );
            RockContext.SaveChanges();

            return ActionOk();
        }

        /// <summary>
        /// Gets a list of announcements for the current course/class.
        /// </summary>
        /// <returns>A list of class announcements</returns>
        [BlockAction]
        public BlockActionResult GetAnnouncements()
        {
            var entity = GetInitialEntity();

            if ( entity == null )
            {
                return ActionBadRequest( $"The {LearningClass.FriendlyTypeName} was not found." );
            }

            var announcements = new LearningClassAnnouncementService( RockContext )
                .Queryable()
                .Where( a => a.LearningClassId == entity.Id )
                .ToList();

            // Return all announcements for the course's default class.
            var gridBuilder = new GridBuilder<LearningClassAnnouncement>()
                .AddTextField( "idKey", a => a.IdKey )
                .AddTextField( "title", a => a.Title )
                .AddField( "publishDateTime", a => a.PublishDateTime )
                .AddField( "communicationMode", a => a.CommunicationMode )
                .AddField( "communicationSent", a => a.CommunicationSent );

            return ActionOk( gridBuilder.Build( announcements ) );
        }

        /// <summary>
        /// Gets a list of content pages for the current course/class.
        /// </summary>
        /// <returns>A list of class content pages</returns>
        [BlockAction]
        public BlockActionResult GetContentPages()
        {
            var entity = GetInitialEntity();

            if ( entity == null )
            {
                return ActionBadRequest( $"The {LearningCourse.FriendlyTypeName} was not found." );
            }

            var contentPages = new LearningClassContentPageService( RockContext )
                .Queryable()
                .Where( c => c.LearningClassId == entity.Id )
                .ToList();

            // Return all announcements for the course's default class.
            var gridBuilder = new GridBuilder<LearningClassContentPage>()
                .AddTextField( "idKey", a => a.IdKey )
                .AddTextField( "title", a => a.Title )
                .AddField( "startDate", a => a.StartDateTime );

            return ActionOk( gridBuilder.Build( contentPages ) );
        }

        /// <summary>
        /// Gets a list of activities for the current course.
        /// </summary>
        /// <returns>A list of Courses</returns>
        [BlockAction]
        public BlockActionResult GetFacilitators()
        {
            var entity = GetInitialEntity();

            if ( entity == null )
            {
                return ActionBadRequest( $"The {LearningClass.FriendlyTypeName} was not found." );
            }

            var facilitators = new LearningParticipantService( RockContext )
                .GetFacilitators( entity.Id )
                .ToList();

            // Return all facilitators for the course's default class.
            var gridBuilder = new GridBuilder<LearningParticipant>()
                .AddTextField( "idKey", a => a.IdKey )
                .AddPersonField( "name", a => a.Person );

            return ActionOk( gridBuilder.Build( facilitators ) );
        }

        /// <summary>
        /// Gets a list of activities for the current course.
        /// </summary>
        /// <returns>A list of Courses</returns>
        [BlockAction]
        public BlockActionResult GetLearningPlan()
        {
            var entity = GetInitialEntity();

            if ( entity == null )
            {
                return ActionBadRequest( $"The {LearningCourse.FriendlyTypeName} was not found." );
            }

            var components = LearningActivityContainer.Instance.Components;
            var now = DateTime.Now;

            // Return all activities for the course.
            var gridBuilder = new GridBuilder<LearningActivity>()
                .AddTextField( "idKey", a => a.IdKey )
                .AddTextField( "name", a => a.Name )
                .AddField( "assignTo", a => a.AssignTo )
                .AddField( "type", a => a.ActivityComponentId )
                .AddField( "dates", a => a.DatesDescription )
                .AddField( "isPastDue", a => a.DueDateCalculated == null ? false : a.DueDateCalculated <= now )
                .AddField( "count", a => a.LearningActivityCompletions.Count() )
                .AddField( "completedCount", a => a.LearningActivityCompletions.Count( c => c.IsStudentCompleted ) )
                .AddField( "componentIconCssClass", a => components.FirstOrDefault( c => c.Value.Value.EntityType.Id == a.ActivityComponentId ).Value.Value.IconCssClass )
                .AddField( "componentHighlightColor", a => components.FirstOrDefault( c => c.Value.Value.EntityType.Id == a.ActivityComponentId ).Value.Value.HighlightColor )
                .AddField( "componentName", a => components.FirstOrDefault( c => c.Value.Value.EntityType.Id == a.ActivityComponentId ).Value.Value.Name )
                .AddField( "points", a => a.Points )
                .AddField( "isAttentionNeeded", a => a.LearningActivityCompletions.Any( c => c.IsStudentCompleted && !c.IsFacilitatorCompleted ) )
                .AddField( "hasStudentComments", a => a.LearningActivityCompletions.Any( c => c.StudentComment.ToStringSafe().Length > 0 ) );

            var orderedItems = GetOrderedLearningPlan( RockContext ).AsNoTracking();
            return ActionOk( gridBuilder.Build( orderedItems ) );
        }

        /// <summary>
        /// Gets a list of students for the current class (default of the course).
        /// </summary>
        /// <returns>A list of students</returns>
        [BlockAction]
        public BlockActionResult GetStudents( bool includeAbsences = false )
        {
            var entity = GetInitialEntity();

            if ( entity == null )
            {
                return ActionBadRequest( $"The {LearningClass.FriendlyTypeName} was not found." );
            }

            // Return all students for the course's default class.
            var gridBuilder = new GridBuilder<LearningParticipant>()
                .AddTextField( "idKey", a => a.IdKey )
                .AddPersonField( "name", a => a.Person )
                .AddField( "currentGradePercent", a =>
                    a.LearningGradePercent )
                .AddField( "currentGrade", a =>
                    a.LearningGradingSystemScale?.Name )
                .AddTextField( "currentAssignment", a =>
                    a.LearningActivities
                    .OrderBy( t => t.DueDate )
                    .FirstOrDefault( t => !t.IsStudentCompleted )?
                    .LearningActivity?.Name );

            if ( includeAbsences )
            {
                var groupAttendance = new AttendanceService( RockContext )
                .Queryable()
                .AsNoTracking()
                .Where( a =>
                    a.DidAttend.HasValue &&
                    a.DidAttend.Value &&
                    a.Occurrence.GroupId == entity.Id &&
                    a.PersonAlias != null )
                .GroupBy( a => a.PersonAlias.PersonId )
                .ToList();

                gridBuilder = gridBuilder
                    .AddField( "absences", a =>
                        groupAttendance.Any() ?
                        groupAttendance.FirstOrDefault( g => g.Key == a.Person.Id )
                        .Count() : 0 )
                    .AddField( "absencesLabelStyle", a =>
                        a.LearningClass.AbsencesLabelStyle(
                            groupAttendance.Any() ?
                            groupAttendance.FirstOrDefault( g => g.Key == a.Person.Id )
                            .Count() : 0,
                            entity.LearningCourse.LearningProgram ) );
            }

            var students = new LearningParticipantService( RockContext )
                .GetStudents( entity.Id )
                .AsNoTracking()
                .ToList();

            return ActionOk( gridBuilder.Build( students ) );
        }

        /// <summary>
        /// Changes the ordered position of a single activity.
        /// </summary>
        /// <param name="key">The identifier of the item that will be moved.</param>
        /// <param name="beforeKey">The identifier of the item it will be placed before.</param>
        /// <returns>An empty result that indicates if the operation succeeded.</returns>
        [BlockAction]
        public BlockActionResult ReorderActivity( string key, string beforeKey )
        {
            using ( var rockContext = new RockContext() )
            {
                // Get the queryable and make sure it is ordered correctly.
                var items = GetOrderedLearningPlan( rockContext ).ToList();

                if ( !items.ReorderEntity( key, beforeKey ) )
                {
                    return ActionBadRequest( "Invalid reorder attempt." );
                }

                rockContext.SaveChanges();

                return ActionOk();
            }
        }

        #endregion

        #region Private methods

        private IQueryable<LearningActivity> GetOrderedLearningPlan( RockContext rockContext )
        {
            var classId = RequestContext.PageParameterAsId( PageParameterKey.LearningClassId );

            if ( classId > 0 )
            {
                return new LearningActivityService( rockContext )
                    .GetClassLearningPlan( classId )
                    .AsNoTracking();
            }

            // Get the page parameter value (either IdKey or Id).
            var courseId = RequestContext.PageParameterAsId( PageParameterKey.LearningCourseId );

            if ( courseId > 0 )
            {
                // Get the default class (prevents duplicates from showing in the activity list).
                var defaultClassId = new LearningClassService( rockContext ).GetCourseDefaultClass( courseId, c => c.Id );

                return new LearningActivityService( rockContext )
                    .GetClassLearningPlan( defaultClassId )
                    .AsNoTracking();
            }

            return new List<LearningActivity>().AsQueryable();
        }

        #endregion
    }
}
