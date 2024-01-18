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

import { FinancialBatchAccountTotalsBag } from "@Obsidian/ViewModels/Blocks/Finance/FinancialBatchDetail/financialBatchAccountTotalsBag";
import { FinancialBatchCurrencyTotalsBag } from "@Obsidian/ViewModels/Blocks/Finance/FinancialBatchDetail/financialBatchCurrencyTotalsBag";

export type FinancialBatchDetailOptionsBag = {
    /** Gets or sets the accounts. */
    accounts?: FinancialBatchAccountTotalsBag[] | null;

    /** The message to be shown on the frontend if the batch is automated. */
    automatedToolTip?: string | null;

    /** Gets or sets the currency types. */
    currencyTypes?: FinancialBatchCurrencyTotalsBag[] | null;

    /** The message to be displayed if the batch is not editable. */
    editModeMessage?: string | null;

    /** Whether the Account Totals section is configured to be hidden. */
    isAccountTotalsHidden: boolean;

    /**
     * Motive: a user who does not have the ReopenBatch permission should not be able to open a batch
     * once closed even if they themselves were the ones who closed it.
     * The front end is required to check this flag and not show the edit block button if the flag is set to true and the batch is closed.
     */
    isReopenAuthorized: boolean;

    /** The flag which the frontend should use to determine if the status can be edited */
    isStatusChangeDisabled: boolean;

    /** Gets or sets the transaction amount. */
    transactionAmount: number;

    /** Gets or sets the transaction item count. */
    transactionItemCount: number;
};
