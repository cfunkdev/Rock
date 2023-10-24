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
    /// Provides data API endpoints for Content Channel Items.
    /// </summary>
    [RoutePrefix( "api/v2/models/contentchannelitems" )]
    [SecurityAction( "UnrestrictedView", "Allows viewing entities regardless of per-entity security authorization." )]
    [SecurityAction( "UnrestrictedEdit", "Allows editing entities regardless of per-entity security authorization." )]
    [Rock.SystemGuid.RestControllerGuid( "e1b0a1a9-014d-4e97-88f7-cf52fc00626a" )]
    public partial class ContentChannelItemsController : ApiControllerBase
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
        [ProducesResponseType( HttpStatusCode.OK, Type = typeof( Rock.Model.ContentChannelItem ) )]
        [ProducesResponseType( HttpStatusCode.BadRequest )]
        [ProducesResponseType( HttpStatusCode.NotFound )]
        [ProducesResponseType( HttpStatusCode.Unauthorized )]
        [SystemGuid.RestActionGuid( "969041d4-4e5f-4ad5-abeb-8030e4d55bdd" )]
        public IActionResult GetItem( string id )
        {
            return new RestApiHelper<Rock.Model.ContentChannelItem, Rock.Model.ContentChannelItemService>( this ).Get( id );
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
        [SystemGuid.RestActionGuid( "c26b789e-cd04-4950-917c-780b18a406d1" )]
        public IActionResult PostItem( [FromBody] Rock.Model.ContentChannelItem value )
        {
            return new RestApiHelper<Rock.Model.ContentChannelItem, Rock.Model.ContentChannelItemService>( this ).Create( value );
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
        [SystemGuid.RestActionGuid( "b63eea4d-ae34-45bf-b8f8-9e9703d2999f" )]
        public IActionResult PutItem( string id, [FromBody] Rock.Model.ContentChannelItem value )
        {
            return new RestApiHelper<Rock.Model.ContentChannelItem, Rock.Model.ContentChannelItemService>( this ).Update( id, value );
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
        [SystemGuid.RestActionGuid( "7fb069aa-7a68-4c75-8722-2b37406dc6ae" )]
        public IActionResult PatchItem( string id, [FromBody] Dictionary<string, object> values )
        {
            return new RestApiHelper<Rock.Model.ContentChannelItem, Rock.Model.ContentChannelItemService>( this ).Patch( id, values );
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
        [SystemGuid.RestActionGuid( "f467053d-a3c1-488b-a9f3-2ea65b720f87" )]
        public IActionResult DeleteItem( string id )
        {
            return new RestApiHelper<Rock.Model.ContentChannelItem, Rock.Model.ContentChannelItemService>( this ).Delete( id );
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
        [SystemGuid.RestActionGuid( "5f4ea178-fb8b-41bd-b384-dc95f9c56fcf" )]
        public IActionResult GetAttributeValues( string id )
        {
            return new RestApiHelper<Rock.Model.ContentChannelItem, Rock.Model.ContentChannelItemService>( this ).GetAttributeValues( id );
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
        [SystemGuid.RestActionGuid( "744b3d4e-2cb4-45dd-bbda-16ff17580a17" )]
        public IActionResult PatchAttributeValues( string id, [FromBody] Dictionary<string, string> values )
        {
            return new RestApiHelper<Rock.Model.ContentChannelItem, Rock.Model.ContentChannelItemService>( this ).PatchAttributeValues( id, values );
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
        [SystemGuid.RestActionGuid( "81e7f01f-777b-4546-8ba8-53d7de0d7db1" )]
        public IActionResult GetSearch( string searchKey )
        {
            return new RestApiHelper<Rock.Model.ContentChannelItem, Rock.Model.ContentChannelItemService>( this ).Search( searchKey, null );
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
        [SystemGuid.RestActionGuid( "d3d52f46-1f0c-4f36-ad38-efef1fa4f8dd" )]
        public IActionResult PostSearch( [FromBody] EntitySearchQueryBag query, string searchKey )
        {
            return new RestApiHelper<Rock.Model.ContentChannelItem, Rock.Model.ContentChannelItemService>( this ).Search( searchKey, query );
        }
    }
}
