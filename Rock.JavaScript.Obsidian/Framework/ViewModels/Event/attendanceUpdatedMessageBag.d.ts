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

import { AttendanceStatus } from "@Obsidian/Enums/Event/attendanceStatus";
import { Guid } from "@Obsidian/Types";

/**
 * Details about an attendance record that is transmitted over
 * the RealTime engine.
 */
export type AttendanceUpdatedMessageBag = {
    /** Gets or sets the attendance unique identifier. */
    attendanceGuid?: Guid | null;

    /** Gets or sets the unique identifier of the group the person attended. */
    groupGuid?: Guid | null;

    /**
     * Gets or sets the group type unique identifier of the group the
     * person attended.
     */
    groupTypeGuid?: Guid | null;

    /** Gets or sets the unique identifier of the location that was attended. */
    locationGuid?: Guid | null;

    /** Gets or sets the occurrence unique identifier. */
    occurrenceGuid?: Guid | null;

    /** Gets or sets the full name of the person this attendance record is for. */
    personFullName?: string | null;

    /** Gets or sets the unique identifier of the person that attended. */
    personGuid?: Guid | null;

    /** Gets or sets the photo URL of the person this attendance record is for. */
    personPhotoUrl?: string | null;

    /** Gets or sets the RSVP state of this attendance record. */
    rSVP: number;

    /**
     * Gets or sets the attendance status which indicates if the persent
     * attended or not.
     */
    status: AttendanceStatus;
};
