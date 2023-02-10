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

import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

/** A bag that contains the passwordless login verify response information. */
export type PasswordlessLoginVerifyResponseBag = {
    /** The error message. */
    errorMessage?: string | null;

    /** Gets or sets a value indicating whether the person is authenticated. */
    isAuthenticated: boolean;

    /** Indicates whether person selection is required. */
    isPersonSelectionRequired: boolean;

    /** Indicates whether account registration is required. */
    isRegistrationRequired: boolean;

    /** The people matching the email or phone number. */
    matchingPeople?: ListItemBag[] | null;

    /** Gets or sets the registration URL. */
    registrationUrl?: string | null;
};
