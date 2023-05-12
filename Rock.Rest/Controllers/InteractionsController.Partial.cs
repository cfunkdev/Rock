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
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Rock.Model;
using Rock.Rest.Filters;
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
    }
}