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

namespace Rock.ViewModels.Blocks.Bus.QueueDetail
{
    public class QueueBag
    {
        /// <summary>
        /// Gets the name. Each instance of Rock shares this name for this queue.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the time to live in seconds.
        /// </summary>
        public int? TimeToLiveSeconds { get; set; }

        /// <summary>
        /// Gets the messages consumed last minute.
        /// Specific to one Rock instance.
        /// </summary>
        public int? MessagesConsumedLastMinute { get; set; }

        /// <summary>
        /// Gets the messages consumed last hour.
        /// Specific to one Rock instance.
        /// </summary>
        public int? MessagesConsumedLastHour { get; set; }

        /// <summary>
        /// Gets the messages consumed last day.
        /// Specific to one Rock instance.
        /// </summary>
        public int? MessagesConsumedLastDay { get; set; }
    }
}
