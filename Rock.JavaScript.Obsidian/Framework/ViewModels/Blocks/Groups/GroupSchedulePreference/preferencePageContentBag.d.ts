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
import { AssignmentScheduleAndLocationBag } from "@Obsidian/ViewModels/Blocks/Groups/GroupSchedulePreference/assignmentScheduleAndLocationBag";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

/** A class representing the content we need to pass into mobile. */
export type PreferencePageContentBag = {
    /** Gets or sets an integer representing the previously selected offset of reminder days. */
    selectedOffset: number;

    /** Gets or sets an integer representing the index of the selected schedule. */
    selectedSchedule?: Guid | null;

    /** Gets or sets a  representing the selected start date. */
    selectedStartDate?: string | null;

    /** Gets or sets a list of schedule keys and values.  */
    listItems?: ListItemBag[] | null;

    /** Gets or sets a list of schedule assignments and locations. */
    assignmentScheduleAndLocations?: AssignmentScheduleAndLocationBag[] | null;
};
