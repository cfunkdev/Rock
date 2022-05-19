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

/** Registration View Model */
export type RegistrationBag = {
    /** Gets or sets the confirmation email. */
    confirmationEmail?: string | null;

    /** Gets or sets the discount amount. */
    discountAmount?: number;

    /** Gets or sets the code. */
    discountCode?: string | null;

    /** Gets or sets the discount percentage. */
    discountPercentage?: number;

    /** Gets or sets the first name. */
    firstName?: string | null;

    /** Gets or sets the Rock.Model.Group identifier. */
    groupId?: number | null;

    /** Gets or sets a value indicating whether this instance is temporary. */
    isTemporary: boolean;

    /** Gets or sets the last name. */
    lastName?: string | null;

    /** Gets or sets the last payment reminder date time. */
    lastPaymentReminderDateTime?: string | null;

    /** Gets or sets the Rock.Model.PersonAlias identifier. */
    personAliasId?: number | null;

    /** Gets or sets the registration instance identifier. */
    registrationInstanceId: number;

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
