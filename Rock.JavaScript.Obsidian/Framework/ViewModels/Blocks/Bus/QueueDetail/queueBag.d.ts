//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright>
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

export type QueueBag = {
    /**
     * Gets the messages consumed last day.
     * Specific to one Rock instance.
     */
    messagesConsumedLastDay?: number | null;

    /**
     * Gets the messages consumed last hour.
     * Specific to one Rock instance.
     */
    messagesConsumedLastHour?: number | null;

    /**
     * Gets the messages consumed last minute.
     * Specific to one Rock instance.
     */
    messagesConsumedLastMinute?: number | null;

    /** Gets the name. Each instance of Rock shares this name for this queue. */
    name?: string | null;

    /** Gets or sets the time to live in seconds. */
    timeToLiveSeconds?: number | null;
};
