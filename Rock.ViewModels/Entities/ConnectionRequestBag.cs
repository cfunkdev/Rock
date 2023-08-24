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
    /// ConnectionRequest View Model
    /// </summary>
    public partial class ConnectionRequestBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the assigned Rock.Model.Group identifier.
        /// </summary>
        /// <value>
        /// The assigned group identifier.
        /// </value>
        public int? AssignedGroupId { get; set; }

        /// <summary>
        /// Gets or sets the assigned group member attribute values.
        /// </summary>
        /// <value>
        /// The assigned group member attribute values.
        /// </value>
        public string AssignedGroupMemberAttributeValues { get; set; }

        /// <summary>
        /// Gets or sets the assigned group member role identifier.
        /// </summary>
        /// <value>
        /// The assigned group member role identifier.
        /// </value>
        public int? AssignedGroupMemberRoleId { get; set; }

        /// <summary>
        /// Gets or sets the assigned group member status.
        /// </summary>
        /// <value>
        /// The assigned group member status.
        /// </value>
        public int? AssignedGroupMemberStatus { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.Campus identifier.
        /// </summary>
        /// <value>
        /// The campus identifier.
        /// </value>
        public int? CampusId { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.ConnectionOpportunity identifier.
        /// </summary>
        /// <value>
        /// The connection opportunity identifier.
        /// </value>
        public int ConnectionOpportunityId { get; set; }

        /// <summary>
        /// Gets or sets the state of the connection.
        /// </summary>
        /// <value>
        /// The state of the connection.
        /// </value>
        public int ConnectionState { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.ConnectionStatus identifier.
        /// </summary>
        /// <value>
        /// The connection status identifier.
        /// </value>
        public int ConnectionStatusId { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.ConnectionType identifier.
        /// </summary>
        /// <value>
        /// The connection type identifier.
        /// </value>
        public int ConnectionTypeId { get; set; }

        /// <summary>
        /// Gets or sets the connector Rock.Model.PersonAlias identifier.
        /// </summary>
        /// <value>
        /// The connector person alias identifier.
        /// </value>
        public int? ConnectorPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the followup date.
        /// </summary>
        /// <value>
        /// The followup date.
        /// </value>
        public DateTime? FollowupDate { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.PersonAlias identifier.
        /// </summary>
        /// <value>
        /// The person alias identifier.
        /// </value>
        public int PersonAliasId { get; set; }

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