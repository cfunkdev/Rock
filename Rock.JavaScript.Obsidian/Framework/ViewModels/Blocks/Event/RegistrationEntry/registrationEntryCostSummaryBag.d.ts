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

import { RegistrationCostSummaryType } from "@Obsidian/Enums/Event/registrationCostSummaryType";

/** Contains the cost summary information for the Registration Entry block. */
export type RegistrationEntryCostSummaryBag = {
    /** Gets or sets the cost. */
    cost: number;

    /** Gets or sets the default payment amount. */
    defaultPaymentAmount?: number | null;

    /** Gets or sets the description. */
    description?: string | null;

    /** Gets or sets the discounted cost. */
    discountedCost: number;

    /** Gets or sets the minimum payment amount. */
    minimumPaymentAmount: number;

    /** Gets or sets the cost summary type. */
    type: RegistrationCostSummaryType;
};
