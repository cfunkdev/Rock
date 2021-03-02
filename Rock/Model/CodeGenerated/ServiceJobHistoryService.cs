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
    /// ServiceJobHistory Service class
    /// </summary>
    public partial class ServiceJobHistoryService : Service<ServiceJobHistory>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceJobHistoryService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public ServiceJobHistoryService(RockContext context) : base(context)
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
        public bool CanDelete( ServiceJobHistory item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// ServiceJobHistory View Model Helper
    /// </summary>
    public partial class ServiceJobHistoryViewModelHelper : ViewModelHelper<ServiceJobHistory, Rock.ViewModel.ServiceJobHistoryViewModel>
    {
        /// <summary>
        /// Converts to viewmodel.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override Rock.ViewModel.ServiceJobHistoryViewModel CreateViewModel( ServiceJobHistory model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new Rock.ViewModel.ServiceJobHistoryViewModel
            {
                Id = model.Id,
                Guid = model.Guid,
                ServiceJobId = model.ServiceJobId,
                ServiceWorker = model.ServiceWorker,
                StartDateTime = model.StartDateTime,
                Status = model.Status,
                StatusMessage = model.StatusMessage,
                StopDateTime = model.StopDateTime,
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
    public static partial class ServiceJobHistoryExtensionMethods
    {
        /// <summary>
        /// Clones this ServiceJobHistory object to a new ServiceJobHistory object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static ServiceJobHistory Clone( this ServiceJobHistory source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as ServiceJobHistory;
            }
            else
            {
                var target = new ServiceJobHistory();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another ServiceJobHistory object to this ServiceJobHistory object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this ServiceJobHistory target, ServiceJobHistory source )
        {
            target.Id = source.Id;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.ServiceJobId = source.ServiceJobId;
            target.ServiceWorker = source.ServiceWorker;
            target.StartDateTime = source.StartDateTime;
            target.Status = source.Status;
            target.StatusMessage = source.StatusMessage;
            target.StopDateTime = source.StopDateTime;
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
        public static Rock.ViewModel.ServiceJobHistoryViewModel ToViewModel( this ServiceJobHistory model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new ServiceJobHistoryViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
