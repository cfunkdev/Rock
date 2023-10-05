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

import { AccountEntryStep } from "@Obsidian/Enums/Blocks/Security/AccountEntry/accountEntryStep";
import { AccountEntryPhoneNumberBag } from "@Obsidian/ViewModels/Blocks/Security/AccountEntry/accountEntryPhoneNumberBag";

/** A box that contains the required information to render an account entry block. */
export type AccountEntryInitializationBox = {
    /** Gets or sets a value indicating whether phone numbers shown. */
    arePhoneNumbersShown: boolean;

    /** Gets or sets the campus picker label. */
    campusPickerLabel?: string | null;

    /** The caption when a confirmation email was sent to a selected, duplicate person. */
    confirmationSentCaption?: string | null;

    /** The email address of the registering user. */
    email?: string | null;

    /** The caption when an existing account is found. */
    existingAccountCaption?: string | null;

    /** Gets or sets a value indicating whether account information is hidden. */
    isAccountInfoHidden: boolean;

    /** Gets or sets a value indicating whether address info is required. */
    isAddressRequired: boolean;

    /** Gets or sets a value indicating whether the address fields are shown. */
    isAddressShown: boolean;

    /** Indicating whether the campus picker is shown. */
    isCampusPickerShown: boolean;

    /** Gets or sets a value indicating whether the email field is hidden. */
    isEmailHidden: boolean;

    /** Gets or sets a value indicating whether username must be an email. */
    isEmailRequiredForUsername: boolean;

    /** Indicating whether the Gender dropdown is shown. */
    isGenderPickerShown: boolean;

    /** Gets or sets a value indicating whether the mobile number is hidden. */
    isMobileNumberHidden: boolean;

    /** Indicates whether username availability checking is disabled. */
    isUsernameAvailabilityCheckDisabled: boolean;

    /** The login page URL. */
    loginPageUrl?: string | null;

    /** Gets or sets the minimum age. */
    minimumAge: number;

    /** Gets or sets the phone numbers. */
    phoneNumbers?: AccountEntryPhoneNumberBag[] | null;

    /** The caption when the username is sent via email. */
    sentLoginCaption?: string | null;

    /** The registration state. */
    state?: string | null;

    /** The account entry step. */
    step?: AccountEntryStep | null;

    /** The success caption. */
    successCaption?: string | null;

    /** Gets or sets the username field label. */
    usernameFieldLabel?: string | null;

    /** The regular expression used to determine that the username is in a valid format. */
    usernameRegex?: string | null;

    /** The friendly description of the regular expression used to determine username validity. */
    usernameRegexDescription?: string | null;
};
