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
import { RegistrantBag } from "@Obsidian/ViewModels/Blocks/Event/RegistrationEntry/registrantBag";
import { RegistrarBag } from "@Obsidian/ViewModels/Blocks/Event/RegistrationEntry/registrarBag";
import { RegistrationEntryPaymentPlanBag } from "@Obsidian/ViewModels/Blocks/Event/RegistrationEntry/registrationEntryPaymentPlanBag";

/** RegistrationEntryBlockSession */
export type RegistrationEntrySessionBag = {
    /** Gets or sets the active payment plan that has been configured for the registration. */
    activePaymentPlan?: RegistrationEntryPaymentPlanBag | null;

    /** Gets or sets the amount to pay now. */
    amountToPayNow: number;

    /** Gets or sets the discount. */
    discountAmount: number;

    /** Gets or sets the discount code. */
    discountCode?: string | null;

    /** Gets or sets the discount maximum registrants. */
    discountMaxRegistrants?: number | null;

    /** Gets or sets the discount. */
    discountPercentage: number;

    /** Gets or sets the field values. */
    fieldValues?: Record<Guid, unknown> | null;

    /** Gets or sets the gateway token. */
    gatewayToken?: string | null;

    /** Gets or sets the group identifier used for this RegistrationInstance. Note a RegistrationInstance can have multiple GroupIds so the one used (based on the linkage slug) has to be stored. */
    groupId?: number | null;

    /** Gets or sets the previously paid. */
    previouslyPaid: number;

    /** Gets or sets the registrants. */
    registrants?: RegistrantBag[] | null;

    /** Gets or sets the registrar. */
    registrar?: RegistrarBag | null;

    /** Gets or sets the registration unique identifier. */
    registrationGuid?: Guid | null;

    /** Gets or sets the registration session unique identifier. */
    registrationSessionGuid: Guid;

    /** Gets or sets the slug used for this RegistrationInstance. Note a RegistrationInstance can have multiple slugs so the one used has to be stored. */
    slug?: string | null;
};
