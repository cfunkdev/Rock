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
import { FamilyPreRegistrationCreateAccountRequestBag } from "@Obsidian/ViewModels/Blocks/Crm/FamilyPreRegistration/familyPreRegistrationCreateAccountRequestBag";
import { FamilyPreRegistrationPersonBag } from "@Obsidian/ViewModels/Blocks/Crm/FamilyPreRegistration/familyPreRegistrationPersonBag";
import { AddressControlBag } from "@Obsidian/ViewModels/Controls/addressControlBag";

/** The bag that contains all the save request information for the Family Pre-Registration block. */
export type FamilyPreRegistrationSaveRequestBag = {
    /** Gets or sets the address. */
    address?: AddressControlBag | null;

    /** Gets or sets the first adult. */
    adult1?: FamilyPreRegistrationPersonBag | null;

    /** Gets or sets the second adult. */
    adult2?: FamilyPreRegistrationPersonBag | null;

    /** Gets or sets the campus unique identifier. */
    campusGuid?: Guid | null;

    /** Gets or sets the children. */
    children?: FamilyPreRegistrationPersonBag[] | null;

    /** Gets or sets the create account request. */
    createAccount?: FamilyPreRegistrationCreateAccountRequestBag | null;

    /** Gets or sets the family attribute values. */
    familyAttributeValues?: Record<string, string> | null;

    /** Gets or sets the family unique identifier. */
    familyGuid?: Guid | null;

    /** Gets or sets a value indicating whether the solved captcha is valid. */
    isCaptchaValid: boolean;

    /** Gets or sets the planned visit date. */
    plannedVisitDate?: string | null;

    /** Gets or sets the schedule unique identifier. */
    scheduleGuid?: Guid | null;
};
