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

import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

/** FinancialTransaction View Model */
export type FinancialTransactionBag = {
    /** Gets or sets the AuthorizedPersonAliasId. */
    authorizedPersonAliasId?: number | null;

    /** Gets or sets the BatchId. */
    batchId?: number | null;

    /** Gets or sets the CheckMicrEncrypted. */
    checkMicrEncrypted?: string | null;

    /** Gets or sets the CheckMicrHash. */
    checkMicrHash?: string | null;

    /** Gets or sets the CheckMicrParts. */
    checkMicrParts?: string | null;

    /** Gets or sets the FinancialGatewayId. */
    financialGatewayId?: number | null;

    /** Gets or sets the FinancialPaymentDetailId. */
    financialPaymentDetailId?: number | null;

    /** Gets or sets the ForeignCurrencyCodeValueId. */
    foreignCurrencyCodeValueId?: number | null;

    /** Gets or sets the FutureProcessingDateTime. */
    futureProcessingDateTime?: string | null;

    /** Gets or sets the IsReconciled. */
    isReconciled?: boolean | null;

    /** Gets or sets the IsSettled. */
    isSettled?: boolean | null;

    /** Gets or sets the MICRStatus. */
    mICRStatus?: number | null;

    /** Gets or sets the NonCashAssetTypeValueId. */
    nonCashAssetTypeValueId?: number | null;

    /** Gets or sets the ProcessedByPersonAliasId. */
    processedByPersonAliasId?: number | null;

    /** Gets or sets the ProcessedDateTime. */
    processedDateTime?: string | null;

    /** Gets or sets the ScheduledTransactionId. */
    scheduledTransactionId?: number | null;

    /** Gets or sets the SettledDate. */
    settledDate?: string | null;

    /** Gets or sets the SettledGroupId. */
    settledGroupId?: string | null;

    /** Gets or sets the ShowAsAnonymous. */
    showAsAnonymous: boolean;

    /** Gets or sets the SourceTypeValueId. */
    sourceTypeValueId?: number | null;

    /** Gets or sets the Status. */
    status?: string | null;

    /** Gets or sets the StatusMessage. */
    statusMessage?: string | null;

    /** Gets or sets the Summary. */
    summary?: string | null;

    /** Gets or sets the SundayDate. */
    sundayDate?: string | null;

    /** Gets or sets the TransactionCode. */
    transactionCode?: string | null;

    /** Gets or sets the TransactionDateTime. */
    transactionDateTime?: string | null;

    /** Gets or sets the TransactionTypeValueId. */
    transactionTypeValueId: number;

    /** Gets or sets the CreatedDateTime. */
    createdDateTime?: string | null;

    /** Gets or sets the ModifiedDateTime. */
    modifiedDateTime?: string | null;

    /** Gets or sets the CreatedByPersonAliasId. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the ModifiedByPersonAliasId. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;
};
