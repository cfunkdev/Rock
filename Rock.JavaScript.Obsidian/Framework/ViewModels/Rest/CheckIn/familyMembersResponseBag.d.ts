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

import { AttendanceBag } from "@Obsidian/ViewModels/CheckIn/attendanceBag";
import { AttendeeBag } from "@Obsidian/ViewModels/CheckIn/attendeeBag";
import { ScheduleOpportunityBag } from "@Obsidian/ViewModels/CheckIn/scheduleOpportunityBag";

/**
 * The response that will be returned by the list family members check-in
 * REST endpoint.
 */
export type FamilyMembersResponseBag = {
    /** Gets or sets the current attendance records that can be checked out. */
    currentlyCheckedInAttendances?: AttendanceBag[] | null;

    /** Gets or sets the family identifier. */
    familyId?: string | null;

    /**
     * Gets or sets the people that can be potentially checked in for
     * the family.
     */
    people?: AttendeeBag[] | null;

    /**
     * Gets or sets all possible schedules that are available across all
     * of the people in this family. If schedule A is available for the
     * first person and schedule B is available for the second person then
     * both schedule A and B will be included.
     */
    possibleSchedules?: ScheduleOpportunityBag[] | null;
};
