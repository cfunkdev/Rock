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

/** A bag that contains information about a schedule preference assignment to be saved for the group schedule toolbox block. */
export type SaveAssignmentRequestBag = {
    /**
     * Gets or sets the unique identifier of an existing assignment that is being edited.
     * If this value is null, the request represents an attempt to add a new assignment.
     */
    editAssignmentGuid?: Guid | null;

    /** Gets or sets the selected group unique identifier. */
    selectedGroupGuid?: Guid | null;

    /** Gets or sets the selected location unique identifier, if any. */
    selectedLocationGuid?: Guid | null;

    /** Gets or sets the selected person unique identifier. */
    selectedPersonGuid?: Guid | null;

    /** Gets or sets the selected schedule unique identifier. */
    selectedScheduleGuid?: Guid | null;
};
