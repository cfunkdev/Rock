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

using System.Collections.Generic;
using System.Net;

using Rock.Rest.Filters;
using Rock.Security;
using Rock.ViewModels.Core;
using Rock.ViewModels.Rest.Models;

namespace Rock.Rest.v2.Models
{
#if WEBFORMS
    using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
    using IActionResult = System.Web.Http.IHttpActionResult;
    using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
    using RouteAttribute = System.Web.Http.RouteAttribute;
    using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
    using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
    using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
    using HttpPatchAttribute = System.Web.Http.HttpPatchAttribute;
    using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
#endif

    /// <summary>
    /// Provides data API endpoints for People.
    /// </summary>
    [RoutePrefix( "api/v2/models/people" )]
    [SecurityAction( "UnrestrictedView", "Allows viewing entities regardless of per-entity security authorization." )]
    [SecurityAction( "UnrestrictedEdit", "Allows editing entities regardless of per-entity security authorization." )]
    [Rock.SystemGuid.RestControllerGuid( "4a9b77fe-18fc-44f1-b43d-1c2c6e3c15ff" )]
    public partial class PeopleController : ApiControllerBase
    {
        /// <summary>
        /// Gets a single item from the database.
        /// </summary>
        /// <param name="id">The identifier as either an Id, Guid or IdKey value.</param>
        /// <returns>The requested item.</returns>
        [HttpGet]
        [Authenticate]
        [Secured]
        [Route( "{id}" )]
        [ProducesResponseType( HttpStatusCode.OK, Type = typeof( Rock.Model.Person ) )]
        [ProducesResponseType( HttpStatusCode.BadRequest )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "bd02dd88-383a-47e2-bb16-6d04693f361f" )]
        public IActionResult GetItem( string id )
        {
            return new RestApiHelper<Rock.Model.Person, Rock.Model.PersonService>( this ).Get( id );
        }

        /// <summary>
        /// Creates a new item in the database.
        /// </summary>
        /// <param name="value">The item to be created.</param>
        /// <returns>An object that contains the new identifier values.</returns>
        [HttpPost]
        [Authenticate]
        [Secured]
        [Route( "" )]
        [ProducesResponseType( HttpStatusCode.Created, Type = typeof( CreatedAtResponseBag ) )]
        [ProducesResponseType( HttpStatusCode.BadRequest )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "2637f1ea-c076-4e48-9859-cff0bf4c9081" )]
        public IActionResult PostItem( [FromBody] Rock.Model.Person value )
        {
            return new RestApiHelper<Rock.Model.Person, Rock.Model.PersonService>( this ).Create( value );
        }

        /// <summary>
        /// Performs a full update of the item. All property values must be
        /// specified.
        /// </summary>
        /// <param name="id">The identifier as either an Id, Guid or IdKey value.</param>
        /// <param name="value">The item that represents all the new values.</param>
        /// <returns>An empty response.</returns>
        [HttpPut]
        [Authenticate]
        [Secured]
        [Route( "{id}" )]
        [ProducesResponseType( HttpStatusCode.NoContent )]
        [ProducesResponseType( HttpStatusCode.BadRequest )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "f9ef5891-877d-4048-8aec-7285bdc22147" )]
        public IActionResult PutItem( string id, [FromBody] Rock.Model.Person value )
        {
            return new RestApiHelper<Rock.Model.Person, Rock.Model.PersonService>( this ).Update( id, value );
        }

        /// <summary>
        /// Performs a partial update of the item. Only specified property keys
        /// will be updated.
        /// </summary>
        /// <param name="id">The identifier as either an Id, Guid or IdKey value.</param>
        /// <param name="values">An object that identifies the properties and values to be updated.</param>
        /// <returns>An empty response.</returns>
        [HttpPatch]
        [Authenticate]
        [Secured]
        [Route( "{id}" )]
        [ProducesResponseType( HttpStatusCode.NoContent )]
        [ProducesResponseType( HttpStatusCode.BadRequest )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "68b06956-60d5-4f05-808b-12b9579c1039" )]
        public IActionResult PatchItem( string id, [FromBody] Dictionary<string, object> values )
        {
            return new RestApiHelper<Rock.Model.Person, Rock.Model.PersonService>( this ).Patch( id, values );
        }

        /// <summary>
        /// Deletes a single item from the database.
        /// </summary>
        /// <param name="id">The identifier as either an Id, Guid or IdKey value.</param>
        /// <returns>An empty response.</returns>
        [HttpDelete]
        [Authenticate]
        [Secured]
        [Route( "{id}" )]
        [ProducesResponseType( HttpStatusCode.NoContent )]
        [ProducesResponseType( HttpStatusCode.BadRequest )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "08af3bf2-a64a-4686-8de7-d9cf233c24d0" )]
        public IActionResult DeleteItem( string id )
        {
            return new RestApiHelper<Rock.Model.Person, Rock.Model.PersonService>( this ).Delete( id );
        }

        /// <summary>
        /// Gets all the attribute values for the specified item.
        /// </summary>
        /// <param name="id">The identifier as either an Id, Guid or IdKey value.</param>
        /// <returns>An array of objects that represent all the attribute values.</returns>
        [HttpGet]
        [Authenticate]
        [Secured]
        [Route( "{id}/attributevalues" )]
        [ProducesResponseType( HttpStatusCode.OK, Type = typeof( Dictionary<string, ModelAttributeValueBag> ) )]
        [ProducesResponseType( HttpStatusCode.BadRequest )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "7cf9355c-6958-423d-88e5-2f71557ccf46" )]
        public IActionResult GetAttributeValues( string id )
        {
            return new RestApiHelper<Rock.Model.Person, Rock.Model.PersonService>( this ).GetAttributeValues( id );
        }

        /// <summary>
        /// Performs a partial update of attribute values for the item. Only
        /// attributes specified will be updated.
        /// </summary>
        /// <param name="id">The identifier as either an Id, Guid or IdKey value.</param>
        /// <param name="values">An object that identifies the attribute keys and raw values to be updated.</param>
        /// <returns>An empty response.</returns>
        [HttpPatch]
        [Authenticate]
        [Secured]
        [Route( "{id}/attributevalues" )]
        [ProducesResponseType( HttpStatusCode.NoContent )]
        [ProducesResponseType( HttpStatusCode.BadRequest )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "449cf509-17e5-4236-bf65-2ad4db53393a" )]
        public IActionResult PatchAttributeValues( string id, [FromBody] Dictionary<string, string> values )
        {
            return new RestApiHelper<Rock.Model.Person, Rock.Model.PersonService>( this ).PatchAttributeValues( id, values );
        }

        /// <summary>
        /// Performs a search of items using the specified system query.
        /// </summary>
        /// <param name="searchKey">The key that identifies the entity search query to execute.</param>
        /// <returns>An array of objects returned by the query.</returns>
        [HttpGet]
        [Authenticate]
        [Secured]
        [Route( "search/{searchKey}" )]
        [ProducesResponseType( HttpStatusCode.OK, Type = typeof( object ) )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "aeb15a0c-997a-44d8-a99a-8758f5ccadd5" )]
        public IActionResult GetSearch( string searchKey )
        {
            return new RestApiHelper<Rock.Model.Person, Rock.Model.PersonService>( this ).Search( searchKey, null );
        }

        /// <summary>
        /// Performs a search of items using the specified system query.
        /// </summary>
        /// <param name="query">Additional query refinement options to be applied.</param>
        /// <param name="searchKey">The key that identifies the entity search query to execute.</param>
        /// <returns>An array of objects returned by the query.</returns>
        [HttpPost]
        [Authenticate]
        [Secured]
        [Route( "search/{searchKey}" )]
        [ProducesResponseType( HttpStatusCode.OK, Type = typeof( object ) )]
        [ProducesResponseType( HttpStatusCode.BadRequest )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "c9ef48ff-4649-4943-84ef-5769367d57d6" )]
        public IActionResult PostSearch( [FromBody] EntitySearchQueryBag query, string searchKey )
        {
            return new RestApiHelper<Rock.Model.Person, Rock.Model.PersonService>( this ).Search( searchKey, query );
        }
    }
}
