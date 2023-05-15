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

using System.Collections.Generic;

namespace Rock.ViewModels.Blocks.Engagement.SignUp.SignUpAttendanceDetail
{
    /// <summary>
    /// The box that contains all the initialization information for the Sign-Up Attendance Detail block.
    /// </summary>
    public class SignUpAttendanceDetailInitializationBox : BlockBox
    {
        /// <summary>
        /// Gets or sets the header HTML.
        /// </summary>
        /// <value>
        /// The header HTML.
        /// </value>
        public string HeaderHtml { get; set; }

        /// <summary>
        /// Gets or sets the attendees.
        /// </summary>
        /// <value>
        /// The attendees.
        /// </value>
        public List<SignUpAttendeeBag> Attendees { get; set; }
    }
}
