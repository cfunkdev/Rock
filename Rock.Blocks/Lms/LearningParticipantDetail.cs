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
using Rock.Model;
using Rock.Obsidian.UI;
using Rock.Security;
using Rock.Utility;
using Rock.ViewModels.Blocks;
using Rock.ViewModels.Blocks.Lms.LearningParticipantDetail;
using Rock.Web.Cache;

namespace Rock.Blocks.Lms
{
    /// <summary>
    /// Displays the details of a particular learning participant.
    /// </summary>
    [DisplayName( "Learning Participant Detail" )]
    [Category( "LMS" )]
    [Description( "Displays the details of a particular learning participant." )]
    [IconCssClass( "fa fa-question" )]
    [SupportedSiteTypes( Model.SiteType.Web )]

    #region Block Attributes

    #endregion

    [Rock.SystemGuid.EntityTypeGuid( "7f3752ef-7a4a-4f96-bd5c-e6609f0bfac6" )]
    [Rock.SystemGuid.BlockTypeGuid( "f1179439-31a1-4897-ab2e-b991d60455aa" )]
    public class LearningParticipantDetail : RockDetailBlockType
    {
        #region Keys

        private static class PageParameterKey
        {
            public const string LearningProgramId = "LearningProgramId";
            public const string LearningCourseId = "LearningCourseId";
            public const string LearningParticipantId = "LearningParticipantId";
            public const string LearningClassId = "LearningClassId";
        }

        private static class NavigationUrlKey
        {
            public const string ParentPage = "ParentPage";
        }

        #endregion Keys

        #region Methods

        /// <inheritdoc/>
        public override object GetObsidianBlockInitialization()
        {
            using ( var rockContext = new RockContext() )
            {
                var box = new DetailBlockBox<LearningParticipantBag, LearningParticipantDetailOptionsBag>();

                SetBoxInitialEntityState( box, rockContext );

                box.NavigationUrls = GetBoxNavigationUrls();
                box.Options = GetBoxOptions( box.IsEditable, rockContext );
                box.QualifiedAttributeProperties = AttributeCache.GetAttributeQualifiedColumns<LearningParticipant>();

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
        private LearningParticipantDetailOptionsBag GetBoxOptions( bool isEditable, RockContext rockContext )
        {
            var options = new LearningParticipantDetailOptionsBag();

            var classId = PageParameter( PageParameterKey.LearningClassId );

            options.ClassRoles = new LearningClassService( rockContext ).GetClassRoles( classId )?.ToListItemBagList();

            return options;
        }

        /// <summary>
        /// Validates the LearningParticipant for any final information that might not be
        /// valid after storing all the data from the client.
        /// </summary>
        /// <param name="learningParticipant">The LearningParticipant to be validated.</param>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="errorMessage">On <c>false</c> return, contains the error message.</param>
        /// <returns><c>true</c> if the LearningParticipant is valid, <c>false</c> otherwise.</returns>
        private bool ValidateLearningParticipant( LearningParticipant learningParticipant, RockContext rockContext, out string errorMessage )
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
        private void SetBoxInitialEntityState( DetailBlockBox<LearningParticipantBag, LearningParticipantDetailOptionsBag> box, RockContext rockContext )
        {
            var entity = GetInitialEntity( rockContext );

            if ( entity == null )
            {
                box.ErrorMessage = $"The {LearningParticipant.FriendlyTypeName} was not found.";
                return;
            }

            var isViewable = BlockCache.IsAuthorized( Authorization.VIEW, RequestContext.CurrentPerson );
            box.IsEditable = BlockCache.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson );

            entity.LoadAttributes( rockContext );

            if ( entity.Id != 0 )
            {
                // Existing entity was found, prepare for view mode by default.
                if ( isViewable )
                {
                    box.Entity = GetEntityBagForView( entity );
                    box.SecurityGrantToken = GetSecurityGrantToken( entity );
                }
                else
                {
                    box.ErrorMessage = EditModeMessage.NotAuthorizedToView( LearningParticipant.FriendlyTypeName );
                }
            }
            else
            {
                // New entity is being created, prepare for edit mode by default.
                if ( box.IsEditable )
                {
                    var bag = GetEntityBagForEdit( entity );
                    box.Entity = bag;
                    box.ValidProperties = bag.GetType().GetProperties().Select( p => p.Name ).ToList();

                    box.SecurityGrantToken = GetSecurityGrantToken( entity );
                }
                else
                {
                    box.ErrorMessage = EditModeMessage.NotAuthorizedToEdit( LearningParticipant.FriendlyTypeName );
                }
            }
        }

        /// <summary>
        /// Gets the entity bag that is common between both view and edit modes.
        /// </summary>
        /// <param name="entity">The entity to be represented as a bag.</param>
        /// <returns>A <see cref="LearningParticipantBag"/> that represents the entity.</returns>
        private LearningParticipantBag GetCommonEntityBag( LearningParticipant entity )
        {
            if ( entity == null )
            {
                return null;
            }

            var absences = GetAbsences( entity );
            return new LearningParticipantBag
            {
                IdKey = entity.IdKey,
                Absences = absences,
                AbsencesLabelStyle = entity.LearningClass?.AbsencesLabelStyle( absences ?? 0 ),
                CurrentGradePercent = entity.LearningGradePercent,
                CurrentGradeText = entity.LearningGradingSystemScale?.Name,
                ParticipantRole = entity.GroupRole?.ToListItemBag(),
                PersonAlias = entity.Person?.PrimaryAlias?.ToListItemBag(),
                IsFacilitator = entity.GroupRole?.IsLeader ?? false
            };
        }

        /// <summary>
        /// Gets the bag for viewing the specified entity.
        /// </summary>
        /// <param name="entity">The entity to be represented for view purposes.</param>
        /// <returns>A <see cref="LearningParticipantBag"/> that represents the entity.</returns>
        private LearningParticipantBag GetEntityBagForView( LearningParticipant entity )
        {
            if ( entity == null )
            {
                return null;
            }

            var bag = GetCommonEntityBag( entity );

            bag.LoadAttributesAndValuesForPublicView( entity, RequestContext.CurrentPerson );

            return bag;
        }

        /// <summary>
        /// Gets the bag for editing the specified entity.
        /// </summary>
        /// <param name="entity">The entity to be represented for edit purposes.</param>
        /// <returns>A <see cref="LearningParticipantBag"/> that represents the entity.</returns>
        private LearningParticipantBag GetEntityBagForEdit( LearningParticipant entity )
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
        private bool UpdateEntityFromBox( LearningParticipant entity, DetailBlockBox<LearningParticipantBag, LearningParticipantDetailOptionsBag> box, RockContext rockContext )
        {
            if ( box.ValidProperties == null )
            {
                return false;
            }

            if ( Guid.TryParse( box.Entity.PersonAlias.Value, out var primaryAliasGuid ) )
            {
                var person = new PersonAliasService( rockContext ).Get( primaryAliasGuid );
                entity.PersonId = person.PersonId;
            }

            var classId = PageParameterAsId( PageParameterKey.LearningClassId );

            if ( classId > 0 && Guid.TryParse( box.Entity.ParticipantRole.Value, out var roleGuid ) )
            {
                entity.GroupRoleId = new LearningClassService( rockContext ).GetClassRoles( classId ).First( r => r.Guid == roleGuid ).Id;
            }

            box.IfValidProperty( nameof( box.Entity.CurrentGradePercent ),
                () => entity.LearningGradePercent = box.Entity.CurrentGradePercent );

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
        /// <returns>The <see cref="LearningParticipant"/> to be viewed or edited on the page.</returns>
        private LearningParticipant GetInitialEntity( RockContext rockContext )
        {
            var partipicantId = PageParameterAsId( PageParameterKey.LearningParticipantId );

            if ( partipicantId == 0 )
            {
                return new LearningParticipant();
            }

            return new LearningParticipantService( rockContext )
                .Queryable()
                .AsNoTracking()
                .Include( p => p.Person )
                .Include( p => p.Group.GroupType )
                .Include( p => p.GroupRole )
                .Include( p => p.LearningGradingSystemScale )
                .Include( p => p.LearningClass )
                .Include( p => p.LearningClass.LearningSemester )
                .FirstOrDefault( p => p.Id == partipicantId );
        }

        private int? GetAbsences( LearningParticipant entity )
        {

            if ( entity.LearningClass?.GroupType?.TakesAttendance != true )
            {
                return null;
            }

            using ( var rockContext = new RockContext() )
            {
                return new AttendanceService( rockContext )
                    .Queryable()
                    .AsNoTracking()
                    .Count( a =>
                        a.DidAttend.HasValue &&
                        a.DidAttend.Value &&
                        a.Occurrence.GroupId == entity.LearningClassId &&
                        a.PersonAlias != null &&
                        a.PersonAlias.PersonId == entity.PersonId );
            }
        }

        /// <summary>
        /// Gets the box navigation URLs required for the page to operate.
        /// </summary>
        /// <returns>A dictionary of key names and URL values.</returns>
        private Dictionary<string, string> GetBoxNavigationUrls()
        {
            var queryParams = new Dictionary<string, string>
            {
                [PageParameterKey.LearningProgramId] = PageParameter( PageParameterKey.LearningProgramId ),
                [PageParameterKey.LearningCourseId] = PageParameter( PageParameterKey.LearningCourseId ),
                [PageParameterKey.LearningClassId] = PageParameter( PageParameterKey.LearningClassId )
            };

            return new Dictionary<string, string>
            {
                [NavigationUrlKey.ParentPage] = this.GetParentPageUrl( queryParams )
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
        private string GetSecurityGrantToken( LearningParticipant entity )
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
        private bool TryGetEntityForEditAction( string idKey, RockContext rockContext, out LearningParticipant entity, out BlockActionResult error )
        {
            var entityService = new LearningParticipantService( rockContext );
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
                entity = new LearningParticipant();

                var classIdKey = PageParameter( PageParameterKey.LearningClassId );
                if ( classIdKey.IsNotNullOrWhiteSpace() )
                {
                    var classId = IdHasher.Instance.GetId( classIdKey );
                    entity.LearningClass = new LearningClassService( rockContext ).Queryable().Include( c => c.GroupType ).FirstOrDefault( c => c.Id == classId );
                }

                entity.GroupId = IdHasher.Instance.GetId( classIdKey ) ?? 0;

                entityService.Add( entity );
            }

            if ( entity == null )
            {
                error = ActionBadRequest( $"{LearningParticipant.FriendlyTypeName} not found." );
                return false;
            }

            if ( !BlockCache.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
            {
                error = ActionBadRequest( $"Not authorized to edit {LearningParticipant.FriendlyTypeName}." );
                return false;
            }

            return true;
        }

        /// <summary>
        /// Attempts to load an entity to be used for an edit action.
        /// </summary>
        /// <param name="participantBag">The bag containing the values to save.</param>
        /// <param name="rockContext">The database context to load the entity from.</param>
        /// <param name="entity">Contains the entity that was loaded when <c>true</c> is returned.</param>
        /// <param name="error">Contains the action error result when <c>false</c> is returned.</param>
        /// <returns><c>true</c> if the entity was loaded and passed security checks.</returns>
        private bool TryGetEntityForEditAction( LearningParticipantBag participantBag, RockContext rockContext, out LearningParticipant entity, out BlockActionResult error )
        {
            var entityService = new LearningParticipantService( rockContext );
            error = null;

            // Determine if we are editing an existing entity or creating a new one.
            if ( participantBag.IdKey.IsNotNullOrWhiteSpace() )
            {
                // If editing an existing entity then load it and make sure it
                // was found and can still be edited.
                entity = entityService.Get( participantBag.IdKey, !PageCache.Layout.Site.DisablePredictableIds );
            }
            else
            {
                // Create a new entity.
                entity = new LearningParticipant();

                // Get the related Class.
                var classId = IdHasher.Instance.GetId( PageParameter( PageParameterKey.LearningClassId ) ).ToIntSafe();
                if ( classId == 0 )
                {
                    error = ActionBadRequest( $"{LearningClass.FriendlyTypeName} not found." );
                    return false;
                }

                var group = new LearningClassService( rockContext ).Get( classId );

                if ( group == null )
                {
                    error = ActionBadRequest( $"{LearningClass.FriendlyTypeName} not found." );
                    return false;
                }

                entity.LearningClass = group;
                entity.GroupId = classId;

                // Get the selected person.
                if ( !Guid.TryParse( participantBag.PersonAlias.Value, out var aliasGuid ) )
                {
                    error = ActionBadRequest( $"Missing {LearningParticipant.FriendlyTypeName}." );
                }

                var personId = new PersonAliasService( rockContext ).GetPersonId( aliasGuid ).ToIntSafe();

                if ( personId == 0 )
                {
                    error = ActionBadRequest( $"{LearningParticipant.FriendlyTypeName} not found." );
                }

                entity.PersonId = personId;

                // Get the Role type.
                if ( !Guid.TryParse( participantBag.ParticipantRole.Value, out var roleTypeGuid ) )
                {
                    error = ActionBadRequest( $"{GroupTypeRole.FriendlyTypeName} not found." );
                }

                var groupRole = new GroupTypeRoleService( rockContext ).Get( roleTypeGuid );

                if ( groupRole == null )
                {
                    error = ActionBadRequest( $"{GroupTypeRole.FriendlyTypeName} not found." );
                }

                entity.GroupRole = groupRole;

                entityService.Add( entity );
            }

            if ( entity == null )
            {
                error = ActionBadRequest( $"{LearningParticipant.FriendlyTypeName} not found." );
                return false;
            }

            if ( !BlockCache.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
            {
                error = ActionBadRequest( $"Not authorized to edit {LearningParticipant.FriendlyTypeName}." );
                return false;
            }

            return true;
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

                var bag = GetEntityBagForEdit( entity );
                var box = new DetailBlockBox<LearningParticipantBag, LearningParticipantDetailOptionsBag>
                {
                    Entity = bag,
                    ValidProperties = bag.GetType().GetProperties().Select( p => p.Name ).ToList()
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
        public BlockActionResult Save( DetailBlockBox<LearningParticipantBag, LearningParticipantDetailOptionsBag> box )
        {
            using ( var rockContext = new RockContext() )
            {

                if ( !TryGetEntityForEditAction( box.Entity, rockContext, out var entity, out var actionError ) )
                {
                    return actionError;
                }

                // Update the entity instance from the information in the bag.
                if ( !UpdateEntityFromBox( entity, box, rockContext ) )
                {
                    return ActionBadRequest( "Invalid data." );
                }

                // Ensure everything is valid before saving.
                if ( !ValidateLearningParticipant( entity, rockContext, out var validationMessage ) )
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
                        [PageParameterKey.LearningParticipantId] = entity.IdKey
                    } ) );
                }

                // Ensure navigation properties will work now.
                entity = new LearningParticipantService( rockContext ).Get( entity.Id );
                entity.LoadAttributes( rockContext );

                return ActionOk( GetEntityBagForView( entity ) );
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
                var entityService = new LearningParticipantService( rockContext );

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
        public BlockActionResult RefreshAttributes( DetailBlockBox<LearningParticipantBag, LearningParticipantDetailOptionsBag> box )
        {
            using ( var rockContext = new RockContext() )
            {
                if ( !TryGetEntityForEditAction( box.Entity, rockContext, out var entity, out var actionError ) )
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

                var refreshedBox = new DetailBlockBox<LearningParticipantBag, LearningParticipantDetailOptionsBag>
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
        /// Gets a list of activities for the current course.
        /// </summary>
        /// <returns>A list of Courses</returns>
        [BlockAction]
        public BlockActionResult GetLearningPlan()
        {
            using ( var rockContext = new RockContext() )
            {
                var entity = GetInitialEntity( rockContext );

                if ( entity == null )
                {
                    return ActionBadRequest( $"The {LearningParticipant.FriendlyTypeName} was not found." );
                }

                var now = DateTime.Now;

                // Get the grade scales first since we'll need them for the grade caluculations.
                var gradeScales = new LearningParticipantService( rockContext ).Queryable()
                    .Where( p => p.Id == entity.Id )
                    .Include( c => c.LearningClass.LearningGradingSystem.LearningGradingSystemScales )
                    .SelectMany( c => c.LearningClass.LearningGradingSystem.LearningGradingSystemScales )
                    .ToList()
                    .OrderByDescending( g => g.ThresholdPercentage );

                var learningPlan = new LearningActivityCompletionService( rockContext ).Queryable()
                    .Include( a => a.LearningActivity )
                    .Where( a => a.StudentId == entity.Id )
                    .AsNoTracking()
                    .ToList()
                    .OrderBy( a => a.LearningActivity.Order );

                // Return all activities for the course.
                // TODO: Update Component selections once those classes are defined.
                var gridBuilder = new GridBuilder<LearningActivityCompletion>()
                    .AddTextField( "idKey", a => a.IdKey )
                    .AddTextField( "name", a => a.LearningActivity.Name )
                    .AddField( "type", a => a.LearningActivity.ActivityComponentId )
                    .AddField( "componentIconCssClass", a => "fa fa-list" )
                    .AddField( "componentHighlightColor", a => "#735f95" )
                    .AddField( "componentName", a => "Check-Off" )
                    .AddField( "dateCompleted", a => a.CompletedDateTime )
                    .AddField( "dateAvailable", a => a.AvailableDateTime )
                    .AddField( "dueDate", a => a.DueDate )
                    .AddField( "isPastDue", a => a.DueDate != null && a.DueDate >= now && !a.CompletedDateTime.HasValue )
                    .AddField( "isAvailableNow", a => a.AvailableDateTime != null && now >= a.AvailableDateTime )
                    .AddTextField( "grade", a => a.GradeText( gradeScales ) );

                return ActionOk( gridBuilder.Build( learningPlan ) );
            }
        }

        #endregion
    }
}
