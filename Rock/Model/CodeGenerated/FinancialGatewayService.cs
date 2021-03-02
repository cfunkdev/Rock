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

using Rock.Attribute;
using Rock.Data;
using Rock.ViewModel;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// FinancialGateway Service class
    /// </summary>
    public partial class FinancialGatewayService : Service<FinancialGateway>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialGatewayService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public FinancialGatewayService(RockContext context) : base(context)
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
        public bool CanDelete( FinancialGateway item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<FinancialPersonSavedAccount>( Context ).Queryable().Any( a => a.FinancialGatewayId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", FinancialGateway.FriendlyTypeName, FinancialPersonSavedAccount.FriendlyTypeName );
                return false;
            }

            if ( new Service<FinancialScheduledTransaction>( Context ).Queryable().Any( a => a.FinancialGatewayId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", FinancialGateway.FriendlyTypeName, FinancialScheduledTransaction.FriendlyTypeName );
                return false;
            }

            if ( new Service<FinancialTransaction>( Context ).Queryable().Any( a => a.FinancialGatewayId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", FinancialGateway.FriendlyTypeName, FinancialTransaction.FriendlyTypeName );
                return false;
            }

            if ( new Service<RegistrationTemplate>( Context ).Queryable().Any( a => a.FinancialGatewayId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", FinancialGateway.FriendlyTypeName, RegistrationTemplate.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// FinancialGateway View Model Helper
    /// </summary>
    public partial class FinancialGatewayViewModelHelper : ViewModelHelper<FinancialGateway, Rock.ViewModel.FinancialGatewayViewModel>
    {
        /// <summary>
        /// Converts to viewmodel.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override Rock.ViewModel.FinancialGatewayViewModel CreateViewModel( FinancialGateway model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new Rock.ViewModel.FinancialGatewayViewModel
            {
                Id = model.Id,
                Guid = model.Guid,
                Description = model.Description,
                EntityTypeId = model.EntityTypeId,
                IsActive = model.IsActive,
                Name = model.Name,
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
    public static partial class FinancialGatewayExtensionMethods
    {
        /// <summary>
        /// Clones this FinancialGateway object to a new FinancialGateway object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static FinancialGateway Clone( this FinancialGateway source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as FinancialGateway;
            }
            else
            {
                var target = new FinancialGateway();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another FinancialGateway object to this FinancialGateway object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this FinancialGateway target, FinancialGateway source )
        {
            target.Id = source.Id;
            target.Description = source.Description;
            target.EntityTypeId = source.EntityTypeId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.IsActive = source.IsActive;
            target.Name = source.Name;
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
        public static Rock.ViewModel.FinancialGatewayViewModel ToViewModel( this FinancialGateway model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new FinancialGatewayViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
