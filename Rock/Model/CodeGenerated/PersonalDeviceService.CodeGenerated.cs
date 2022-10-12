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
    /// PersonalDevice Service class
    /// </summary>
    public partial class PersonalDeviceService : Service<PersonalDevice>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalDeviceService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public PersonalDeviceService(RockContext context) : base(context)
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
        public bool CanDelete( PersonalDevice item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<CommunicationRecipient>( Context ).Queryable().Any( a => a.PersonalDeviceId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", PersonalDevice.FriendlyTypeName, CommunicationRecipient.FriendlyTypeName );
                return false;
            }

            if ( new Service<Interaction>( Context ).Queryable().Any( a => a.PersonalDeviceId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", PersonalDevice.FriendlyTypeName, Interaction.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// PersonalDevice View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( PersonalDevice ) )]
    public partial class PersonalDeviceViewModelHelper : ViewModelHelper<PersonalDevice, PersonalDeviceBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override PersonalDeviceBag CreateViewModel( PersonalDevice model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new PersonalDeviceBag
            {
                IdKey = model.IdKey,
                DeviceRegistrationId = model.DeviceRegistrationId,
                DeviceUniqueIdentifier = model.DeviceUniqueIdentifier,
                DeviceVersion = model.DeviceVersion,
                IsActive = model.IsActive,
                LastSeenDateTime = model.LastSeenDateTime,
                LastVerifiedDateTime = model.LastVerifiedDateTime,
                MACAddress = model.MACAddress,
                Manufacturer = model.Manufacturer,
                Model = model.Model,
                Name = model.Name,
                NotificationsEnabled = model.NotificationsEnabled,
                PersonalDeviceTypeValueId = model.PersonalDeviceTypeValueId,
                PersonAliasId = model.PersonAliasId,
                PlatformValueId = model.PlatformValueId,
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
    public static partial class PersonalDeviceExtensionMethods
    {
        /// <summary>
        /// Clones this PersonalDevice object to a new PersonalDevice object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static PersonalDevice Clone( this PersonalDevice source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as PersonalDevice;
            }
            else
            {
                var target = new PersonalDevice();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this PersonalDevice object to a new PersonalDevice object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static PersonalDevice CloneWithoutIdentity( this PersonalDevice source )
        {
            var target = new PersonalDevice();
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
        /// Copies the properties from another PersonalDevice object to this PersonalDevice object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this PersonalDevice target, PersonalDevice source )
        {
            target.Id = source.Id;
            target.DeviceRegistrationId = source.DeviceRegistrationId;
            target.DeviceUniqueIdentifier = source.DeviceUniqueIdentifier;
            target.DeviceVersion = source.DeviceVersion;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.IsActive = source.IsActive;
            target.LastSeenDateTime = source.LastSeenDateTime;
            target.LastVerifiedDateTime = source.LastVerifiedDateTime;
            target.MACAddress = source.MACAddress;
            target.Manufacturer = source.Manufacturer;
            target.Model = source.Model;
            target.Name = source.Name;
            target.NotificationsEnabled = source.NotificationsEnabled;
            target.PersonalDeviceTypeValueId = source.PersonalDeviceTypeValueId;
            target.PersonAliasId = source.PersonAliasId;
            target.PlatformValueId = source.PlatformValueId;
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
        public static PersonalDeviceBag ToViewModel( this PersonalDevice model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new PersonalDeviceViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
