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

namespace Rock.Enums.Blocks.Groups.GroupAttendanceDetail
{
    /// <summary>
    /// The group location selection mode options available in the Group Attendance Detail block.
    /// </summary>
    public enum GroupAttendanceDetailLocationSelectionMode
    {
        /// <summary>
        /// No location selection will be available.
        /// </summary>
        None = 0,

        /// <summary>
        /// A read-only location will be presented to the individual.
        /// </summary>
        Readonly = 1,

        /// <summary>
        /// A group location picker will be presented to the individual.
        /// </summary>
        GroupLocationPicker = 2
    }
}
