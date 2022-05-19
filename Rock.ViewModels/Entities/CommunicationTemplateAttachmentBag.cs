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
    /// CommunicationTemplateAttachment View Model
    /// </summary>
    public partial class CommunicationTemplateAttachmentBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the PersonId of the Rock.Model.Person who is being sent the Rock.Model.Communication.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the PersonId of the Rock.Model.Person who is being sent the Rock.Model.Communication.
        /// </value>
        public int BinaryFileId { get; set; }

        /// <summary>
        /// Gets or sets the CommunicationTemplateId of the Rock.Model.CommunicationTemplate.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the CommunicationId of the Rock.Model.CommunicationTemplate.
        /// </value>
        public int CommunicationTemplateId { get; set; }

        /// <summary>
        /// Indicates if the attachment is for SMS recipients or Email recipients
        /// </summary>
        /// <value>
        /// The communication type value identifier.
        /// </value>
        public int CommunicationType { get; set; }

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
