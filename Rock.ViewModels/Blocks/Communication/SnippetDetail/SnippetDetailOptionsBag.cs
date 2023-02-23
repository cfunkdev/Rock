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

namespace Rock.ViewModels.Blocks.Communication.SnippetDetail
{
    /// <summary>
    /// Class SnippetDetailOptionsBag.
    /// </summary>
    public class SnippetDetailOptionsBag
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is authorized to edit.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is authorized to edit; otherwise, <c>false</c>.
        /// </value>
        public bool IsAuthorizedToEdit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is personal allowed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is personal allowed; otherwise, <c>false</c>.
        /// </value>
        public bool IsPersonalAllowed { get; set; }
    }
}
