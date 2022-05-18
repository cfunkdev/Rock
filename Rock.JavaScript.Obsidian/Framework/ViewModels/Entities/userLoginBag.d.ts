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

/** UserLogin View Model */
export type UserLoginBag = {
    /** Gets or sets the ApiKey. */
    apiKey?: string | null;

    /** Gets or sets the EntityTypeId. */
    entityTypeId?: number | null;

    /** Gets or sets the FailedPasswordAttemptCount. */
    failedPasswordAttemptCount?: number | null;

    /** Gets or sets the FailedPasswordAttemptWindowStartDateTime. */
    failedPasswordAttemptWindowStartDateTime?: string | null;

    /** Gets or sets the IsConfirmed. */
    isConfirmed?: boolean | null;

    /** Gets or sets the IsLockedOut. */
    isLockedOut?: boolean | null;

    /** Gets or sets the IsOnLine. */
    isOnLine?: boolean | null;

    /** Gets or sets the IsPasswordChangeRequired. */
    isPasswordChangeRequired?: boolean | null;

    /** Gets or sets the LastActivityDateTime. */
    lastActivityDateTime?: string | null;

    /** Gets or sets the LastLockedOutDateTime. */
    lastLockedOutDateTime?: string | null;

    /** Gets or sets the LastLoginDateTime. */
    lastLoginDateTime?: string | null;

    /** Gets or sets the LastPasswordChangedDateTime. */
    lastPasswordChangedDateTime?: string | null;

    /** Gets or sets the LastPasswordExpirationWarningDateTime. */
    lastPasswordExpirationWarningDateTime?: string | null;

    /** Gets or sets the Password. */
    password?: string | null;

    /** Gets or sets the PersonId. */
    personId?: number | null;

    /** Gets or sets the UserName. */
    userName?: string | null;

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
