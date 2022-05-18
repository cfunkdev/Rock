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

/** FinancialTransactionDetail View Model */
export type FinancialTransactionDetailBag = {
    /** Gets or sets the AccountId. */
    accountId: number;

    /** Gets or sets the Amount. */
    amount?: number;

    /** Gets or sets the EntityId. */
    entityId?: number | null;

    /** Gets or sets the EntityTypeId. */
    entityTypeId?: number | null;

    /** Gets or sets the FeeAmount. */
    feeAmount?: number | null;

    /** Gets or sets the FeeCoverageAmount. */
    feeCoverageAmount?: number | null;

    /** Gets or sets the ForeignCurrencyAmount. */
    foreignCurrencyAmount?: number | null;

    /** Gets or sets the Summary. */
    summary?: string | null;

    /** Gets or sets the TransactionId. */
    transactionId: number;

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
