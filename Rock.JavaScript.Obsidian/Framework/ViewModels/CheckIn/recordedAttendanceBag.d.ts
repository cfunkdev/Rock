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

import { AchievementBag } from "@Obsidian/ViewModels/CheckIn/achievementBag";
import { AttendanceBag } from "@Obsidian/ViewModels/CheckIn/attendanceBag";

/** Details about a newly recorded attendance record. */
export type RecordedAttendanceBag = {
    /** Gets or sets the attendance details. */
    attendance?: AttendanceBag | null;

    /** Gets or sets the in progress achievements. */
    inProgressAchievements?: AchievementBag[] | null;

    /**
     * Gets or sets the achievements that were just completed by this
     * new attendance record.
     */
    justCompletedAchievements?: AchievementBag[] | null;

    /**
     * Gets or sets the achievements that were completed before the new
     * attendance record was created.
     */
    previouslyCompletedAchievements?: AchievementBag[] | null;
};
