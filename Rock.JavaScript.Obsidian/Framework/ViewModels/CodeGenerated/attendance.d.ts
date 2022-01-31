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

import { IEntity } from "../entity";

export type Attendance = IEntity & {
    attendanceCheckInSessionId?: number | null;
    attendanceCodeId?: number | null;
    campusId?: number | null;
    checkedInByPersonAliasId?: number | null;
    checkedOutByPersonAliasId?: number | null;
    declineReasonValueId?: number | null;
    deviceId?: number | null;
    didAttend?: boolean | null;
    endDateTime?: string | null;
    isFirstTime?: boolean | null;
    note?: string | null;
    occurrenceId?: number;
    personAliasId?: number | null;
    presentByPersonAliasId?: number | null;
    presentDateTime?: string | null;
    processed?: boolean | null;
    qualifierValueId?: number | null;
    requestedToAttend?: boolean | null;
    rSVP?: number;
    rSVPDateTime?: string | null;
    scheduleConfirmationSent?: boolean | null;
    scheduledByPersonAliasId?: number | null;
    scheduledToAttend?: boolean | null;
    scheduleReminderSent?: boolean | null;
    searchResultGroupId?: number | null;
    searchTypeValueId?: number | null;
    searchValue?: string | null;
    startDateTime?: string;
    createdDateTime?: string | null;
    modifiedDateTime?: string | null;
    createdByPersonAliasId?: number | null;
    modifiedByPersonAliasId?: number | null;
};
