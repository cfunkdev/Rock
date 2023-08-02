﻿// <copyright>
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

using Rock.ViewModels.Utility;
using System;

namespace Rock.ViewModels.Blocks.Connection.ConnectionRequestBoard
{
    /// <summary>
    /// A bag that contains connection request activity information for the connection request board.
    /// </summary>
    public class ConnectionRequestBoardConnectionRequestActivityBag
    {
        #region Add/Edit Properties (for adding or editing new or existing connection request activites)

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the connection activity type.
        /// </summary>
        public ListItemBag ActivityType { get; set; }

        /// <summary>
        /// Gets or sets the "connector" person.
        /// </summary>
        public ListItemBag Connector { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        public string Note { get; set; }

        #endregion Add/Edit Properties (for adding or editing new or existing connection request activites)

        #region Grid Data Properties (for displaying existing connection request activities)

        /// <summary>
        /// Gets or sets the date this connection request activity was added.
        /// </summary>
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// Get or sets the connection activity type name.
        /// </summary>
        public string ActivityTypeName { get; set; }

        /// <summary>
        /// Gets or sets the "connector" person's full name.
        /// </summary>
        public string ConnectorPersonFullName { get; set; }

        /// <summary>
        /// Gets or sets the connection opportunity name.
        /// </summary>
        public string OpportunityName { get; set; }

        #endregion Grid Data Properties (for displaying existing connection request activities)
    }
}
