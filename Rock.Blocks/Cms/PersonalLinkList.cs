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

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Obsidian.UI;
using Rock.Security;
using Rock.ViewModels.Blocks;
using Rock.ViewModels.Blocks.Cms.PersonalLinkList;
using Rock.Web.Cache;
using Rock.Web.UI.Controls;

namespace Rock.Blocks.Cms
{
    /// <summary>
    /// Displays a list of personal links.
    /// </summary>

    [DisplayName( "Personal Link List" )]
    [Category( "CMS" )]
    [Description( "Displays a list of personal links." )]
    [IconCssClass( "fa fa-list" )]
    // [SupportedSiteTypes( Model.SiteType.Web )]

    [Rock.SystemGuid.EntityTypeGuid( "06f055e8-d396-4ad6-b542-342ee5907d74" )]
    [Rock.SystemGuid.BlockTypeGuid( "6c9e7ebf-8f27-48ef-94c4-900ac3a2c167" )]
    [CustomizedGrid]
    public class PersonalLinkList : RockListBlockType<PersonalLinkList.PersonalLinkListBag>
    {
        #region Keys

        private static class PageParameterKey
        {
            public const string SectionId = "SectionId";
        }

        private static class UserPreferenceKey
        {
            public const string Name = "Name";
        }

        #endregion Keys

        #region Methods

        /// <inheritdoc/>
        public override object GetObsidianBlockInitialization()
        {
            var box = new ListBlockBox<PersonalLinkListOptionsBag>();
            var builder = GetGridBuilder();

            // anybody can add a non-shared link
            // EDIT auth users can add shared link
            box.IsAddEnabled = true;
            // edit and delete buttons will be enabled/disabled per row based on security
            box.IsDeleteEnabled = true;
            box.ExpectedRowCount = null;
            box.Options = GetBoxOptions();
            box.GridDefinition = builder.BuildDefinition();

            return box;
        }

        /// <summary>
        /// Gets the box options required for the component to render the list.
        /// </summary>
        /// <returns>The options that provide additional details to the block.</returns>
        private PersonalLinkListOptionsBag GetBoxOptions()
        {
            var options = new PersonalLinkListOptionsBag();
            var sectionId = GetPersonalLinkSectionId();

            if ( sectionId.HasValue )
            {
                using ( var rockContext = new RockContext() )
                {
                    var personalLinkSection = new PersonalLinkSectionService( rockContext ).Queryable().FirstOrDefault( a => a.Id == sectionId.Value );
                    options.PersonalLinkSectionName = personalLinkSection?.Name;
                    options.IsBlockVisible = personalLinkSection != null;
                    options.IsPersonalLinkSectionShared = personalLinkSection?.IsShared ?? false;
                }
            }

            return options;
        }

        /// <inheritdoc/>
        protected override IQueryable<PersonalLinkListBag> GetListQueryable( RockContext rockContext )
        {
            return GetGridDataSourceQueryable( rockContext );
        }

        /// <inheritdoc/>
        protected override IQueryable<PersonalLinkListBag> GetOrderedListQueryable( IQueryable<PersonalLinkListBag> queryable, RockContext rockContext )
        {
            return queryable.OrderBy( g => g.Order ).ThenBy( g => g.Name );
        }

        /// <inheritdoc/>
        protected override GridBuilder<PersonalLinkListBag> GetGridBuilder()
        {
            return new GridBuilder<PersonalLinkListBag>()
                .WithBlock( this )
                .AddTextField( "idKey", a => a.IdKey )
                .AddTextField( "name", a => a.Name )
                .AddTextField( "url", a => a.Url )
                .AddTextField( "canEdit", a => a.CanEdit.ToString() )
                .AddTextField( "canDelete", a => a.CanDelete.ToString() );
        }

        /// <summary>
        /// Gets the personal links that will be displayed in the grid
        /// </summary>
        /// <returns></returns>
        private IQueryable<PersonalLinkListBag> GetGridDataSourceQueryable( RockContext rockContext )
        {
            int? sectionId = GetPersonalLinkSectionId();
            var currentPerson = this.GetCurrentPerson();
            var qry = new PersonalLinkService( rockContext ).Queryable().Where( a => a.SectionId == sectionId );

            // Filter by: Name
            var name = GetBlockPersonPreferences().GetValue( UserPreferenceKey.Name );

            if ( !string.IsNullOrWhiteSpace( name ) )
            {
                qry = qry.Where( a => a.Name.Contains( name ) );
            }

            qry = qry.OrderBy( g => g.Order ).ThenBy( g => g.Name );

            var dataGridList = qry.AsEnumerable()
                .Where( a => a.IsAuthorized( Rock.Security.Authorization.VIEW, currentPerson ) )
                .Select( a => new PersonalLinkListBag()
                {
                    CanDelete = a.IsAuthorized( Authorization.EDIT, currentPerson ),
                    CanEdit = a.PersonAliasId == currentPerson.PrimaryAliasId || a.IsAuthorized( Authorization.EDIT, currentPerson ),
                    IdKey = a.IdKey,
                    Name = a.Name,
                    Order = a.Order,
                    PersonalLink = a,
                    Url = a.Url,
                } )
                .ToList();

            return dataGridList.AsQueryable();
        }

        /// <summary>
        /// Gets the personal link section identifier for which the block is displaying Personal Links.
        /// </summary>
        /// <returns></returns>
        private int? GetPersonalLinkSectionId()
        {
            var sectionIdParam = PageParameter( PageParameterKey.SectionId );
            var sectionId = sectionIdParam.AsIntegerOrNull() ?? Rock.Utility.IdHasher.Instance.GetId( sectionIdParam );
            return sectionId;
        }

        #endregion

        #region Block Actions

        /// <summary>
        /// Changes the ordered position of a single item.
        /// </summary>
        /// <param name="key">The identifier of the item that will be moved.</param>
        /// <param name="beforeKey">The identifier of the item it will be placed before.</param>
        /// <returns>An empty result that indicates if the operation succeeded.</returns>
        [BlockAction]
        public BlockActionResult ReorderItem( string key, string beforeKey )
        {
            using ( var rockContext = new RockContext() )
            {
                // Get the queryable and make sure it is ordered correctly.
                var qry = GetListQueryable( rockContext );
                qry = GetOrderedListQueryable( qry, rockContext );

                // Get the entities from the database.
                var items = GetListItems( qry, rockContext ).ConvertAll( pl => pl.PersonalLink );

                if ( !items.ReorderEntity( key, beforeKey ) )
                {
                    return ActionBadRequest( "Invalid reorder attempt." );
                }

                rockContext.SaveChanges();

                return ActionOk();
            }
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="key">The identifier of the entity to be deleted.</param>
        /// <returns>An empty result that indicates if the operation succeeded.</returns>
        [BlockAction]
        public BlockActionResult Delete( string key )
        {
            using ( var rockContext = new RockContext() )
            {
                var entityService = new PersonalLinkService( rockContext );
                var entity = entityService.Get( key, !PageCache.Layout.Site.DisablePredictableIds );

                if ( entity == null )
                {
                    return ActionBadRequest( $"{PersonalLink.FriendlyTypeName} not found." );
                }

                if ( !entity.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
                {
                    return ActionBadRequest( $"Not authorized to delete ${PersonalLink.FriendlyTypeName}." );
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
        /// Creates or Updates tje specified Personal Link
        /// </summary>
        /// <param name="bag">The Personal Link details</param>
        /// <returns>An empty result that indicates if the operation succeeded.</returns>
        [BlockAction]
        public BlockActionResult SavePersonalLink( PersonalLinkListBag bag )
        {
            using ( var rockContext = new RockContext() )
            {
                int? sectionId = GetPersonalLinkSectionId();
                var personalLinkService = new PersonalLinkService( rockContext );
                var personalLinkSectionService = new PersonalLinkSectionService( rockContext );
                var personalLinkSection = personalLinkSectionService.Get( sectionId ?? 0 );
                var currentPerson = GetCurrentPerson();

                if ( personalLinkSection == null )
                {
                    return ActionBadRequest( "Invalid Personal Link Section Id" );
                }

                PersonalLink personalLink = null;

                if ( !string.IsNullOrWhiteSpace( bag.IdKey ) )
                {
                    var id = Rock.Utility.IdHasher.Instance.GetId( bag.IdKey );
                    personalLink = personalLinkService.Get( id ?? 0 );
                }

                if ( personalLink == null )
                {
                    personalLink = new PersonalLink
                    {
                        SectionId = personalLinkSection.Id
                    };

                    // add the new link to the bottom of the list for that section
                    var lastLinkOrder = personalLinkService.Queryable().Where( a => a.SectionId == personalLinkSection.Id ).Max( a => ( int? ) a.Order ) ?? 0;
                    personalLink.Order = lastLinkOrder + 1;

                    personalLinkService.Add( personalLink );
                }
                else
                {
                    if ( personalLink.PersonAliasId != currentPerson.PrimaryAliasId && !personalLink.IsAuthorized( Authorization.EDIT, currentPerson ) )
                    {
                        return ActionBadRequest( "Not authorized to make changes to this link." );
                    }
                }

                if ( personalLinkSection.IsShared )
                {
                    personalLink.PersonAliasId = null;
                }
                else
                {
                    personalLink.PersonAliasId = currentPerson.PrimaryAliasId;
                }

                personalLink.Name = bag.Name;
                personalLink.Url = bag.Url;

                rockContext.SaveChanges();

                return ActionOk();
            }
        }

        #endregion

        #region Helper Classes

        /// <summary>
        /// The data displayed in the Personal Link Section List block.
        /// </summary>
        public class PersonalLinkListBag
        {
            public string IdKey { get; set; }

            public int Order { get; set; }

            public string Name { get; set; }

            public string Url { get; set; }

            public int SectionId { get; set; }

            public bool CanDelete { get; set; }

            public bool CanEdit { get; set; }

            public PersonalLink PersonalLink { get; set; }
        }

        #endregion
    }
}
