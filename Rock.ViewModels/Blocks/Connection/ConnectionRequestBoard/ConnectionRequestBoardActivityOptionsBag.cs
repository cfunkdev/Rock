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
using System.Collections.Generic;

namespace Rock.ViewModels.Blocks.Connection.ConnectionRequestBoard
{
    /// <summary>
    /// A bag that contains options that may be assigned to a connection request activity for the connection request board.
    /// </summary>
    public class ConnectionRequestBoardActivityOptionsBag
    {
        /// <summary>
        /// Gets or sets the connection activity types that may be assigned to a connection request activity.
        /// </summary>
        public List<ListItemBag> ConnectionActivityTypes { get; set; }

        /// <summary>
        /// Gets or sets the "connector" people that may be assigned to a connection request activity.
        /// </summary>
        public List<ListItemBag> Connectors { get; set; }
    }
}
