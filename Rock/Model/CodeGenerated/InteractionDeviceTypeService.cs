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
    /// InteractionDeviceType Service class
    /// </summary>
    public partial class InteractionDeviceTypeService : Service<InteractionDeviceType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionDeviceTypeService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public InteractionDeviceTypeService(RockContext context) : base(context)
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
        public bool CanDelete( InteractionDeviceType item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<InteractionSession>( Context ).Queryable().Any( a => a.DeviceTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", InteractionDeviceType.FriendlyTypeName, InteractionSession.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// InteractionDeviceType View Model Helper
    /// </summary>
    public partial class InteractionDeviceTypeViewModelHelper : ViewModelHelper<InteractionDeviceType, Rock.ViewModel.InteractionDeviceTypeViewModel>
    {
        /// <summary>
        /// Converts to viewmodel.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override Rock.ViewModel.InteractionDeviceTypeViewModel CreateViewModel( InteractionDeviceType model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new Rock.ViewModel.InteractionDeviceTypeViewModel
            {
                Id = model.Id,
                Guid = model.Guid,
                Application = model.Application,
                ClientType = model.ClientType,
                DeviceTypeData = model.DeviceTypeData,
                Name = model.Name,
                OperatingSystem = model.OperatingSystem,
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
    public static partial class InteractionDeviceTypeExtensionMethods
    {
        /// <summary>
        /// Clones this InteractionDeviceType object to a new InteractionDeviceType object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static InteractionDeviceType Clone( this InteractionDeviceType source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as InteractionDeviceType;
            }
            else
            {
                var target = new InteractionDeviceType();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another InteractionDeviceType object to this InteractionDeviceType object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this InteractionDeviceType target, InteractionDeviceType source )
        {
            target.Id = source.Id;
            target.Application = source.Application;
            target.ClientType = source.ClientType;
            target.DeviceTypeData = source.DeviceTypeData;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.Name = source.Name;
            target.OperatingSystem = source.OperatingSystem;
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
        public static Rock.ViewModel.InteractionDeviceTypeViewModel ToViewModel( this InteractionDeviceType model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new InteractionDeviceTypeViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
