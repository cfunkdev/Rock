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

using System;
using System.Linq;

using Rock.ViewModels.Utility;

namespace Rock.ViewModels.Entities
{
    /// <summary>
    /// SystemPhoneNumber View Model
    /// </summary>
    public partial class SystemPhoneNumberBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the identifier of the person alias who should receive
        /// responses to the SMS number. This person must have a phone number
        /// with SMS enabled or no response will be sent.
        /// </summary>
        /// <value>
        /// The person alias identifier who should receive responses.
        /// </value>
        public int? AssignedToPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this phone number is active.
        /// </summary>
        /// <value>
        ///   true if this phone number is active; otherwise, false.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance support SMS.
        /// </summary>
        /// <value>
        /// true if this instance supports SMS; otherwise, false.
        /// </value>
        public bool IsSmsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this phone number will
        /// forward incoming messages to Rock.Model.SystemPhoneNumber.AssignedToPersonAliasId.
        /// </summary>
        /// <value>
        /// true if this phohe number will forward incoming messages; otherwise, false.
        /// </value>
        public bool IsSmsForwardingEnabled { get; set; }

        /// <summary>
        /// Gets or sets the mobile application site identifier. This is
        /// used when determining what devices to send push notifications to.
        /// </summary>
        /// <value>
        /// The mobile application site identifier.
        /// </value>
        public int? MobileApplicationSiteId { get; set; }

        /// <summary>
        /// Gets or sets the friendly name of the phone number.
        /// </summary>
        /// <value>
        /// The friendly name of the phone number.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone number. This should be in E.123 format,
        /// such as +16235553324.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the sort and display order of the Rock.Model.SystemPhoneNumber.
        /// This is an ascending order, so the lower the value the higher the
        /// sort priority.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the sort order of the Rock.Model.SystemPhoneNumber.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the provider identifier.
        /// </summary>
        /// <value>
        /// The provider identifier.
        /// </value>
        public string ProviderIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the notification group identifier. Active members of
        /// this group will be notified when a new SMS message comes in to
        /// this phone number.
        /// </summary>
        /// <value>
        /// The SMS notification group identifier.
        /// </value>
        public int? SmsNotificationGroupId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the workflow type that will be
        /// launched when an SMS message is received on this number.
        /// </summary>
        /// <value>
        /// The workflow type identifier to be launched when an SMS message is received.
        /// </value>
        public int? SmsReceivedWorkflowTypeId { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the created by person alias identifier.
        /// </summary>
        /// <value>
        /// The created by person alias identifier.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the modified by person alias identifier.
        /// </summary>
        /// <value>
        /// The modified by person alias identifier.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

    }
}
