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

import { Guid } from "@Obsidian/Types";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

/**
 * A bag that represents a single schedule and the one or more campuses
 * that are associated with the schedule.
 */
export type InteractiveExperienceScheduleBag = {
    /** Gets or sets the campuses that are tied to this schedule. */
    campuses?: ListItemBag[] | null;

    /** Gets or sets the data view to use for filtering. */
    dataView?: ListItemBag | null;

    /** Gets or sets the group to use for filtering. */
    group?: ListItemBag | null;

    /** Gets or sets the unique identifier of this schedule. */
    guid?: Guid | null;

    /** Gets or sets the schedule. */
    schedule?: ListItemBag | null;
};
