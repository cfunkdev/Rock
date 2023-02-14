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

namespace Rock.ViewModels.Blocks.Security.ConfirmAccount
{
    /// <summary>
    /// A bag containing the required information to display an alert control.
    /// </summary>
    public class ConfirmAccountAlertControlBag
    {
        /// <summary>
        /// The type of the alert.
        /// </summary>
        /// <remarks>
        /// See <see cref="Rock.Enums.Blocks.Security.ConfirmAccount.ConfirmAccountAlertType"/> for values.
        /// </remarks>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the alert content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="Content"/> is HTML.
        /// </summary>
        public bool IsHtml { get; set; }
    }
}
