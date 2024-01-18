﻿//------------------------------------------------------------------------------
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
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using Microsoft.Extensions.Logging;

using Rock.Data;
using Rock.Logging;
using Rock.Model;
using Rock.Rest.Filters;
using Rock.Transactions;
using Rock.Utility;
using Rock.Web.Cache;

namespace Rock.Rest.Controllers
{
    /// <summary>
    /// Additional methods on the Interactions REST API
    /// </summary>
    public partial class InteractionsController
    {
        #region Import related

        /// <summary>
        /// Import Interaction Records using BulkInsert
        /// </summary>
        /// <param name="interactionsImport">The interactions import.</param>
        /// <exception cref="HttpResponseException"></exception>
        /// <remarks>
        /// For InteractionChannel* and InteractionComponent*: Id, Guid, or ForeignKey (and Name) must be specified. 
        /// For best performance, limit to 1000 records at a time.
        /// </remarks>
        [Authenticate, Secured]
        [HttpPost]
        [System.Web.Http.Route( "api/Interactions/Import" )]
        [Rock.SystemGuid.RestActionGuid( "C686F292-F77D-441E-83F4-DE5D1DE8CCD6" )]
        public void InteractionImport( Rock.BulkImport.InteractionsImport interactionsImport )
        {
            if ( interactionsImport == null )
            {
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent( "InteractionsImport data is required" )
                };

                throw new HttpResponseException( response );
            }

            InteractionService.BulkInteractionImport( interactionsImport );
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Writes the interactions.
        /// </summary>
        /// <param name="interactionTransactionItems">The interaction transaction items.</param>
        /// <param name="immediate">A boolean depicting whether or not the interaction item should be queued
        /// or immediately posted to the database.</param>
        [Authenticate, Secured]
        [HttpPost]
        [System.Web.Http.Route( "api/Interactions/WriteInteractions" )]
        [Rock.SystemGuid.RestActionGuid( "993B380F-6059-4E39-8A82-07126FCF5C1D" )]
        public void WriteInteractions( [FromBody] List<Rock.Transactions.InteractionTransactionInfo> interactionTransactionItems, bool immediate = false )
        {
            // Enqueue individual interactions based on the transaction info provided.
            foreach( var interactionTransactionInfo in interactionTransactionItems )
            {
                if ( !interactionTransactionInfo.ChannelTypeMediumValueId.HasValue )
                {
                    // Do nothing if a ChannelTypeMediumValueId wasn't specified.
                    return;
                }

                var channelTypeMediumValue = DefinedValueCache.Get( interactionTransactionInfo.ChannelTypeMediumValueId.Value );
                if ( channelTypeMediumValue == null )
                {
                    // Do nothing if an invalid ChannelTypeMediumValueId was specified.
                    return;
                }

                var interactionTransaction = new Rock.Transactions.InteractionTransaction( interactionTransactionInfo );

                // Either queue the interaction to be sent or
                // immediately post it to the database.
                if( immediate )
                {
                    interactionTransaction.Execute();
                }
                else
                {
                    interactionTransaction.Enqueue();
                }
            }
        }

        #endregion

        #region Action: RegisterPageInteraction

        /// <summary>
        /// Describes a processing request to register a page interaction.
        /// </summary>
        public class RegisterPageInteractionActionInfo
        {
            /// <summary>
            /// The unique identifier of the page.
            /// </summary>
            public int PageId { get; set; }

            /// <summary>
            /// The name of the action being registered.
            /// </summary>
            public string ActionName { get; set; } = "View";

            /// <summary>
            /// The unique identifier for the browser session.
            /// </summary>
            public Guid BrowserSessionGuid { get; set; }

            /// <summary>
            /// The server date and time on which the page was requested.
            /// </summary>
            public DateTime PageRequestDateTime { get; set; }

            /// <summary>
            /// The time in seconds required to serve the initial page request.
            /// </summary>
            public double? PageRequestTimeToServe { get; set; }

            /// <summary>
            /// Gets the raw user agent string of the client browser.
            /// </summary>
            public string UserAgent { get; set; }

            /// <summary>
            /// Gets the IP host address of the remote client.
            /// </summary>
            public string UserHostAddress { get; set; }

            /// <summary>
            /// Gets the DNS host name or IP address of the client's previous request that linked to the current URL.
            /// </summary>
            public string UrlReferrerHostAddress { get; set; }

            /// <summary>
            /// Gets the query search terms of the client's previous request that linked to the current URL.
            /// </summary>
            public string UrlReferrerSearchTerms { get; set; }
        }

        /// <summary>
        /// Registers a page interaction.
        /// </summary>
        /// <param name="interactionInfo">A data object containing details about the interaction.</param>
        /// <param name="immediate">A flag indicating if the action should be processed immediately. If false, the action will be added to the transaction queue.</param>
        /// <returns>A status code that indicates if the request was successful.</returns>
        [System.Web.Http.Route( "api/Interactions/RegisterPageInteraction" )]
        [HttpPost]
        [Rock.SystemGuid.RestActionGuid( "44781195-9125-4B51-9509-94B2F54C0AFE" )]
        public IHttpActionResult RegisterPageInteraction( [FromBody] PageInteractionInfo interactionInfo, bool immediate = false )
        {
            var httpContext = System.Web.HttpContext.Current;
            var request = httpContext?.Request;
            if ( request != null )
            {
                // If the client details are not populated, set default values from the current request
                // because we can assume this is a callback from the same client as the initial interaction.
                if ( string.IsNullOrWhiteSpace( interactionInfo.UserAgent ) )
                {
                    interactionInfo.UserAgent = request.UserAgent;
                }
                if ( string.IsNullOrWhiteSpace( interactionInfo.UserHostAddress ) )
                {
                    interactionInfo.UserHostAddress = request.UserHostAddress;
                }
            }

            var rockContext = new RockContext();

            if ( string.IsNullOrWhiteSpace( interactionInfo.UserIdKey ) )
            {
                // This is a visitor who has not yet been assigned an identifier.
                // If cookies are enabled in the client browser, the first-time visitor cookie will have been set in the initial page request
                // and we can initiate session tracking for this user.
                var firstTimeCookie = WebRequestHelper.GetCookieFromContext( httpContext, Rock.Personalization.RequestCookieKey.ROCK_FIRSTTIME_VISITOR );
                if ( firstTimeCookie != null )
                {
                    // Create a new Anonymous Visitor alias and use it to record this and all subsequent interactions
                    // by returning the new identifier in the visitor key cookie.
                    var visitorPersonAlias = new PersonAliasService( rockContext ).CreateAnonymousVisitorAlias();
                    rockContext.SaveChanges();

                    // Assign this page interaction to the new Anonymous Visitor alias.
                    interactionInfo.UserIdKey = visitorPersonAlias.IdKey;

                    var visitorKeyCookie = new HttpCookie( Rock.Personalization.RequestCookieKey.ROCK_VISITOR_KEY, interactionInfo.UserIdKey )
                    {
                        Expires = WebRequestHelper.GetPersistedCookieExpirationDateTime()
                    };

                    WebRequestHelper.AddOrUpdateCookie( httpContext, visitorKeyCookie );
                }
            }

            var interactionService = new InteractionService( rockContext );
            try
            {
                interactionService.RegisterPageInteraction( interactionInfo, immediate );
            }
            catch ( Exception ex )
            {
                var logger = RockLogger.LoggerFactory.CreateLogger<InteractionsController>();
                // If there is a problem creating the interaction, record it but do not generate an error for the caller.
                logger.LogError( ex.Message, ex );
            }

            return Ok();
        }

        #endregion 
    }
}