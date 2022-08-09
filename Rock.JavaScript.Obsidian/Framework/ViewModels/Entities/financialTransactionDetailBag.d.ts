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
    /**
     * Gets or sets the AccountId of the Rock.Model.FinancialAccount/account that the Rock.Model.FinancialTransactionDetail.Amount of this 
     * detail line item should be credited towards.
     */
    accountId: number;

    /** Gets or sets the total amount of the transaction detail. This total amount includes any associated fees. */
    amount: number;

    /** Gets or sets the entity id. */
    entityId?: number | null;

    /** Gets or sets the entity. */
    entityTypeId?: number | null;

    /** Gets or sets the fee amount of the transaction detail, which is a subset of the Amount. */
    feeAmount?: number | null;

    /** Gets or sets the fee coverage amount. */
    feeCoverageAmount?: number | null;

    /** Gets or sets the foreign currency amount. */
    foreignCurrencyAmount?: number | null;

    /** Gets or sets the summary of the transaction detail. */
    summary?: string | null;

    /**
     * Gets or sets the TransactionId of the Rock.Model.FinancialTransaction that this 
     * detail item is a part of.
     */
    transactionId: number;

    /** Gets or sets the created date time. */
    createdDateTime?: string | null;

    /** Gets or sets the modified date time. */
    modifiedDateTime?: string | null;

    /** Gets or sets the created by person alias identifier. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the modified by person alias identifier. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;
};
