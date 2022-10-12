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
    /// RemoteAuthenticationSession Service class
    /// </summary>
    public partial class RemoteAuthenticationSessionService : Service<RemoteAuthenticationSession>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteAuthenticationSessionService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public RemoteAuthenticationSessionService(RockContext context) : base(context)
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
        public bool CanDelete( RemoteAuthenticationSession item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// RemoteAuthenticationSession View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( RemoteAuthenticationSession ) )]
    public partial class RemoteAuthenticationSessionViewModelHelper : ViewModelHelper<RemoteAuthenticationSession, RemoteAuthenticationSessionBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override RemoteAuthenticationSessionBag CreateViewModel( RemoteAuthenticationSession model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new RemoteAuthenticationSessionBag
            {
                IdKey = model.IdKey,
                AuthenticationIpAddress = model.AuthenticationIpAddress,
                AuthorizedPersonAliasId = model.AuthorizedPersonAliasId,
                ClientIpAddress = model.ClientIpAddress,
                Code = model.Code,
                DeviceUniqueIdentifier = model.DeviceUniqueIdentifier,
                SessionAuthenticatedDateTime = model.SessionAuthenticatedDateTime,
                SessionEndDateTime = model.SessionEndDateTime,
                SessionStartDateTime = model.SessionStartDateTime,
                SiteId = model.SiteId,
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
    public static partial class RemoteAuthenticationSessionExtensionMethods
    {
        /// <summary>
        /// Clones this RemoteAuthenticationSession object to a new RemoteAuthenticationSession object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static RemoteAuthenticationSession Clone( this RemoteAuthenticationSession source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as RemoteAuthenticationSession;
            }
            else
            {
                var target = new RemoteAuthenticationSession();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this RemoteAuthenticationSession object to a new RemoteAuthenticationSession object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static RemoteAuthenticationSession CloneWithoutIdentity( this RemoteAuthenticationSession source )
        {
            var target = new RemoteAuthenticationSession();
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
        /// Copies the properties from another RemoteAuthenticationSession object to this RemoteAuthenticationSession object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this RemoteAuthenticationSession target, RemoteAuthenticationSession source )
        {
            target.Id = source.Id;
            target.AuthenticationIpAddress = source.AuthenticationIpAddress;
            target.AuthorizedPersonAliasId = source.AuthorizedPersonAliasId;
            target.ClientIpAddress = source.ClientIpAddress;
            target.Code = source.Code;
            target.DeviceUniqueIdentifier = source.DeviceUniqueIdentifier;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.SessionAuthenticatedDateTime = source.SessionAuthenticatedDateTime;
            target.SessionEndDateTime = source.SessionEndDateTime;
            target.SessionStartDateTime = source.SessionStartDateTime;
            target.SiteId = source.SiteId;
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
        public static RemoteAuthenticationSessionBag ToViewModel( this RemoteAuthenticationSession model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new RemoteAuthenticationSessionViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
