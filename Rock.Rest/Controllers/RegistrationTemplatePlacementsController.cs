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
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rock.Data;
using Rock.Model;
using Rock.Rest.Filters;

namespace Rock.Rest.Controllers
{
    /// <summary>
    /// RegistrationTemplatePlacements REST API
    /// </summary>
    public partial class RegistrationTemplatePlacementsController
    {
        /// <summary>
        /// Determines whether the specified registrant can be added to a placement group. If true, than the person an be added to the group (if the group itself allows it).
        /// </summary>
        /// <param name="registrantId">The registrant identifier.</param>
        /// <param name="registrationTemplatePlacementId">The registration template placement identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <returns>
        ///   <c>true</c> if this registrant can be added a placement group based on the RegistrationTemplatePlacement configuration<c>false</c>.
        /// </returns>
        [Authenticate, Secured]
        [HttpGet]
        [System.Web.Http.Route( "api/RegistrationTemplatePlacements/CanPlaceRegistrant" )]
        [Rock.SystemGuid.RestActionGuid( "16A3B4EE-D158-402F-96C6-349EE9D2306E" )]
        public virtual HttpResponseMessage CanPlaceRegistrant( int registrantId, int registrationTemplatePlacementId, int groupId )
        {
            var rockContext = this.Service.Context as RockContext;
            RegistrationTemplatePlacementService registrationTemplatePlacementService = new RegistrationTemplatePlacementService( rockContext );

            var registrationTemplatePlacement = registrationTemplatePlacementService.Get( registrationTemplatePlacementId );

            // make sure the specified registrant, registrationTemplatePlacement, and group are found
            if ( registrationTemplatePlacement == null )
            {
                return ControllerContext.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound,
                    $"Specified RegistrationTemplatePlacement not found." );
            }

            var group = new GroupService( rockContext ).Get( groupId );

            if ( group == null )
            {
                return ControllerContext.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound,
                    $"Specified group not found." );
            }

            var registrantInfo = new RegistrationRegistrantService( rockContext ).GetSelect( registrantId, s => new
            {
                s.PersonAlias.Person,
                s.Registration.RegistrationInstance
            } );

            if ( registrantInfo == null )
            {
                return ControllerContext.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound,
                    $"Specified registrant not found." );
            }

            if ( registrationTemplatePlacement.GroupTypeId != group.GroupTypeId )
            {
                return ControllerContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    $"Specified group's group type does not match the group type of the registration placement." );
            }

            RegistrationInstanceService registrationInstanceService = new RegistrationInstanceService( rockContext );
            var sharedGroupsQuery = registrationTemplatePlacementService.GetRegistrationTemplatePlacementPlacementGroups( registrationTemplatePlacement );
            var instanceGroupsQuery = registrationInstanceService.GetRegistrationInstancePlacementGroups( registrantInfo.RegistrationInstance ).Where( a => a.GroupTypeId == registrationTemplatePlacement.GroupTypeId );
            var placementGroupsQuery = sharedGroupsQuery.Union( instanceGroupsQuery );

            // make sure the specified group is one of the placement groups

            if ( !placementGroupsQuery.Any( a => a.Id == groupId ) )
            {
                return ControllerContext.Request.CreateErrorResponse(
                        HttpStatusCode.NotFound,
                        $"{group.Name} is not a placement group for this registration template or instance." );
            }

            // If multiple placements are allowed, and there are no more things to check, we can return an OK
            if ( registrationTemplatePlacement.AllowMultiplePlacements )
            {
                return new HttpResponseMessage( HttpStatusCode.OK );
            }
            else
            {
                var personAlreadyInPlacementGroup = placementGroupsQuery.Where( a => a.Id != groupId ).Any( a => a.Members.Any( m => m.PersonId == registrantInfo.Person.Id ) );

                if ( personAlreadyInPlacementGroup )
                {
                    return ControllerContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        $"{registrantInfo.Person} can not be in more than one {registrationTemplatePlacement.Name} group" );
                }
            }

            return new HttpResponseMessage( HttpStatusCode.OK );

        }

        /// <summary>
        /// Detaches the placement group.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="registrationTemplatePlacementId">The registration template placement identifier.</param>
        /// <param name="registrationInstanceId">The registration instance identifier.</param>
        /// <returns></returns>
        [Authenticate, Secured]
        [HttpDelete]
        [System.Web.Http.Route( "api/RegistrationTemplatePlacements/DetachPlacementGroup" )]
        [Rock.SystemGuid.RestActionGuid( "566D81B3-1B99-4FE4-BE3A-307F3135106B" )]
        public virtual HttpResponseMessage DetachPlacementGroup( int groupId, int registrationTemplatePlacementId, int? registrationInstanceId = null )
        {
            // since we are doing a delete, create a new RockContext instead of this.Service.Context so that ProxyCreation, etc works
            var rockContext = new RockContext();
            var group = new GroupService( rockContext ).Get( groupId );

            if ( group == null )
            {
                return ControllerContext.Request.CreateErrorResponse( HttpStatusCode.NotFound, "Specified group not found." );
            }

            if ( registrationInstanceId.HasValue )
            {
                var registrationInstanceService = new RegistrationInstanceService( rockContext );
                var registrationInstance = registrationInstanceService.Get( registrationInstanceId.Value );

                if ( registrationInstance == null )
                {
                    return ControllerContext.Request.CreateErrorResponse( HttpStatusCode.NotFound, "Specified registration instance not found." );
                }

                registrationInstanceService.DeleteRegistrationInstancePlacementGroup( registrationInstance, group, registrationTemplatePlacementId );
            }
            else
            {
                var registrationTemplatePlacementService = new RegistrationTemplatePlacementService( rockContext );
                var registrationTemplatePlacement = registrationTemplatePlacementService.Get( registrationTemplatePlacementId );

                if ( registrationTemplatePlacement == null )
                {
                    return ControllerContext.Request.CreateErrorResponse( HttpStatusCode.NotFound, "Specified registration template placement not found." );
                }

                registrationTemplatePlacementService.DeleteRegistrationTemplatePlacementPlacementGroup( registrationTemplatePlacement, group );
            }

            rockContext.SaveChanges();

            return new HttpResponseMessage( HttpStatusCode.OK );
        }
    }
}