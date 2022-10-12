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
    /// ConnectionStatus Service class
    /// </summary>
    public partial class ConnectionStatusService : Service<ConnectionStatus>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionStatusService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public ConnectionStatusService(RockContext context) : base(context)
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
        public bool CanDelete( ConnectionStatus item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<ConnectionRequest>( Context ).Queryable().Any( a => a.ConnectionStatusId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", ConnectionStatus.FriendlyTypeName, ConnectionRequest.FriendlyTypeName );
                return false;
            }

            if ( new Service<ConnectionStatusAutomation>( Context ).Queryable().Any( a => a.DestinationStatusId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", ConnectionStatus.FriendlyTypeName, ConnectionStatusAutomation.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// ConnectionStatus View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( ConnectionStatus ) )]
    public partial class ConnectionStatusViewModelHelper : ViewModelHelper<ConnectionStatus, ConnectionStatusBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override ConnectionStatusBag CreateViewModel( ConnectionStatus model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new ConnectionStatusBag
            {
                IdKey = model.IdKey,
                AutoInactivateState = model.AutoInactivateState,
                ConnectionTypeId = model.ConnectionTypeId,
                Description = model.Description,
                HighlightColor = model.HighlightColor,
                IsActive = model.IsActive,
                IsCritical = model.IsCritical,
                IsDefault = model.IsDefault,
                Name = model.Name,
                Order = model.Order,
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
    public static partial class ConnectionStatusExtensionMethods
    {
        /// <summary>
        /// Clones this ConnectionStatus object to a new ConnectionStatus object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static ConnectionStatus Clone( this ConnectionStatus source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as ConnectionStatus;
            }
            else
            {
                var target = new ConnectionStatus();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this ConnectionStatus object to a new ConnectionStatus object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static ConnectionStatus CloneWithoutIdentity( this ConnectionStatus source )
        {
            var target = new ConnectionStatus();
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
        /// Copies the properties from another ConnectionStatus object to this ConnectionStatus object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this ConnectionStatus target, ConnectionStatus source )
        {
            target.Id = source.Id;
            target.AutoInactivateState = source.AutoInactivateState;
            target.ConnectionTypeId = source.ConnectionTypeId;
            target.Description = source.Description;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.HighlightColor = source.HighlightColor;
            target.IsActive = source.IsActive;
            target.IsCritical = source.IsCritical;
            target.IsDefault = source.IsDefault;
            target.Name = source.Name;
            target.Order = source.Order;
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
        public static ConnectionStatusBag ToViewModel( this ConnectionStatus model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new ConnectionStatusViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
