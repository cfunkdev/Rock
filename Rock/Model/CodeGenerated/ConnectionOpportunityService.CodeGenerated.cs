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
    /// ConnectionOpportunity Service class
    /// </summary>
    public partial class ConnectionOpportunityService : Service<ConnectionOpportunity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionOpportunityService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public ConnectionOpportunityService(RockContext context) : base(context)
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
        public bool CanDelete( ConnectionOpportunity item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<ConnectionRequestActivity>( Context ).Queryable().Any( a => a.ConnectionOpportunityId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", ConnectionOpportunity.FriendlyTypeName, ConnectionRequestActivity.FriendlyTypeName );
                return false;
            }

            if ( new Service<FinancialTransactionAlertType>( Context ).Queryable().Any( a => a.ConnectionOpportunityId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", ConnectionOpportunity.FriendlyTypeName, FinancialTransactionAlertType.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// ConnectionOpportunity View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( ConnectionOpportunity ) )]
    public partial class ConnectionOpportunityViewModelHelper : ViewModelHelper<ConnectionOpportunity, ConnectionOpportunityBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override ConnectionOpportunityBag CreateViewModel( ConnectionOpportunity model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new ConnectionOpportunityBag
            {
                IdKey = model.IdKey,
                ConnectionTypeId = model.ConnectionTypeId,
                Description = model.Description,
                IconCssClass = model.IconCssClass,
                IsActive = model.IsActive,
                Name = model.Name,
                Order = model.Order,
                PhotoId = model.PhotoId,
                PublicName = model.PublicName,
                ShowCampusOnTransfer = model.ShowCampusOnTransfer,
                ShowConnectButton = model.ShowConnectButton,
                ShowStatusOnTransfer = model.ShowStatusOnTransfer,
                Summary = model.Summary,
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
    public static partial class ConnectionOpportunityExtensionMethods
    {
        /// <summary>
        /// Clones this ConnectionOpportunity object to a new ConnectionOpportunity object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static ConnectionOpportunity Clone( this ConnectionOpportunity source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as ConnectionOpportunity;
            }
            else
            {
                var target = new ConnectionOpportunity();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this ConnectionOpportunity object to a new ConnectionOpportunity object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static ConnectionOpportunity CloneWithoutIdentity( this ConnectionOpportunity source )
        {
            var target = new ConnectionOpportunity();
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
        /// Copies the properties from another ConnectionOpportunity object to this ConnectionOpportunity object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this ConnectionOpportunity target, ConnectionOpportunity source )
        {
            target.Id = source.Id;
            target.ConnectionTypeId = source.ConnectionTypeId;
            target.Description = source.Description;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.IconCssClass = source.IconCssClass;
            target.IsActive = source.IsActive;
            target.Name = source.Name;
            target.Order = source.Order;
            target.PhotoId = source.PhotoId;
            target.PublicName = source.PublicName;
            target.ShowCampusOnTransfer = source.ShowCampusOnTransfer;
            target.ShowConnectButton = source.ShowConnectButton;
            target.ShowStatusOnTransfer = source.ShowStatusOnTransfer;
            target.Summary = source.Summary;
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
        public static ConnectionOpportunityBag ToViewModel( this ConnectionOpportunity model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new ConnectionOpportunityViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
