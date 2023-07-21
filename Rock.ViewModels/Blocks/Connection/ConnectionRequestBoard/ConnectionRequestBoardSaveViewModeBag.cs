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

namespace Rock.ViewModels.Blocks.Connection.ConnectionRequestBoard
{
    /// <summary>
    /// A bag that contains information to save the view mode preference for the connection request board.
    /// </summary>
    public class ConnectionRequestBoardSaveViewModeBag
    {
        /// <summary>
        /// Gets or sets the identifier of the connection opportunity to which this preference relates.
        /// </summary>
        public int ConnectionOpportunityId { get; set; }

        /// <summary>
        /// Gets or sets whether card view mode is currently selected.
        /// </summary>
        public bool IsCardViewMode { get; set; }
    }
}
