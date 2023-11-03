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
using System.Collections.Generic;

namespace Rock.ViewModels.Blocks.Group.Scheduling.GroupScheduleToolbox
{
    /// <summary>
    /// A bag that contains information about unavailability to be saved for the group schedule toolbox block.
    /// </summary>
    public class SaveUnavailabilityRequestBag
    {
        /// <summary>
        /// Gets or sets the selected person unique identifier.
        /// </summary>
        public Guid SelectedPersonGuid { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the group unique identifier, if this unavailability is for a specific group.
        /// </summary>
        public Guid? GroupGuid { get; set; }

        /// <summary>
        /// Gets or sets the person unique identifiers to which is unavailability should be applied.
        /// </summary>
        public List<Guid> PersonGuids { get; set; }
    }
}
