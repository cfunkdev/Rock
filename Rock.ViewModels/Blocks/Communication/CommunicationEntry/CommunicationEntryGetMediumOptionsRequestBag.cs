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

using System;

namespace Rock.ViewModels.Blocks.Communication.CommunicationEntry
{
    /// <summary>
    /// Bag containing the information required to get medium options for the Communication Entry block.
    /// </summary>
    public class CommunicationEntryGetMediumOptionsRequestBag
    {
        /// <summary>
        /// Gets or sets the medium entity type unique identifier.
        /// </summary>
        /// <value>
        /// The medium entity type unique identifier.
        /// </value>
        public Guid MediumEntityTypeGuid { get; set; }
    }
}
