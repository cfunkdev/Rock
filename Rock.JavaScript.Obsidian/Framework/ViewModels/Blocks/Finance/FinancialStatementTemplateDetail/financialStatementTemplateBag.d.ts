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
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type FinancialStatementTemplateBag = {
    /** Gets or sets the account selection option. */
    accountSelectionOption?: string | null;

    /** Gets or sets the transaction settings for view mode. */
    accountsForTransactions?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the currency types for cash gift guids. */
    currencyTypesForCashGifts?: Guid[] | null;

    /** Gets or sets the currency types for non cash guids. */
    currencyTypesForNonCashGifts?: Guid[] | null;

    /** Gets or sets the description. */
    description?: string | null;

    /** Gets or sets the footer template HTML fragment. */
    footerTemplateHtmlFragment?: string | null;

    /** Gets or sets a value indicating whether [hide corrected transaction on same data]. */
    hideCorrectedTransactionOnSameData: boolean;

    /** Gets or sets a value indicating whether [hide refunded transactions]. */
    hideRefundedTransactions: boolean;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets a value indicating whether [include child accounts custom]. */
    includeChildAccountsCustom: boolean;

    /** Gets or sets a value indicating whether [include child accounts pledges]. */
    includeChildAccountsPledges: boolean;

    /** Gets or sets a value indicating whether [include non cash gifts pledge]. */
    includeNonCashGiftsPledge: boolean;

    /** Gets or sets a flag indicating if this is an active financial statement template. This value is required. */
    isActive: boolean;

    /** Gets or sets the logo binary file. */
    logoBinaryFile?: ListItemBag | null;

    /** Gets or sets the margin bottom for pdf design. */
    marginBottomMillimeters?: number | null;

    /** Gets or sets the margin left for pdf design. */
    marginLeftMillimeters?: number | null;

    /** Gets or sets the margin right for pdf design. */
    marginRightMillimeters?: number | null;

    /** Gets or sets the margin top for pdf design. */
    marginTopMillimeters?: number | null;

    /** Gets or sets the name of the Financial Statement Template */
    name?: string | null;

    /** Gets or sets the size of the paper when generating pdfs. */
    paperSize?: string | null;

    /** Gets or sets the pledge accounts. */
    pledgeAccounts?: ListItemBag[] | null;

    /** Gets or sets the report template. */
    reportTemplate?: string | null;

    /** Gets or sets the selected accounts. */
    selectedAccounts?: ListItemBag[] | null;

    /** Gets or sets the selected transaction types. */
    selectedTransactionTypes?: string | null;

    /** Gets or sets the transaction type guids. */
    transactionTypes?: Guid[] | null;

    /** Gets or sets a value indicating whether [use custom account ids]. */
    useCustomAccountIds: boolean;
};
