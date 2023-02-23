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
import { AccountEntryCompletedStepBag } from "@Obsidian/ViewModels/Blocks/Security/AccountEntry/accountEntryCompletedStepBag";
import { AccountEntryConfirmationSentStepBag } from "@Obsidian/ViewModels/Blocks/Security/AccountEntry/accountEntryConfirmationSentStepBag";
import { AccountEntryDuplicatePersonSelectionStepBag } from "@Obsidian/ViewModels/Blocks/Security/AccountEntry/accountEntryDuplicatePersonSelectionStepBag";
import { AccountEntryExistingAccountStepBag } from "@Obsidian/ViewModels/Blocks/Security/AccountEntry/accountEntryExistingAccountStepBag";
import { AccountEntryPasswordlessConfirmationSentStepBag } from "@Obsidian/ViewModels/Blocks/Security/AccountEntry/accountEntryPasswordlessConfirmationSentStepBag";

/** A bag that contains the register response information. */
export type AccountEntryRegisterResponseBox = {
    /** Completed step bag. */
    completedStepBag?: AccountEntryCompletedStepBag | null;

    /** Confirmation sent step bag. */
    confirmationSentStepBag?: AccountEntryConfirmationSentStepBag | null;

    /** Duplicate person selection step bag. */
    duplicatePersonSelectionStepBag?: AccountEntryDuplicatePersonSelectionStepBag | null;

    /** Existing account step bag. */
    existingAccountStepBag?: AccountEntryExistingAccountStepBag | null;

    /** Passwordless confirmation sent step bag. */
    passwordlessConfirmationSentStepBag?: AccountEntryPasswordlessConfirmationSentStepBag | null;

    /** The account entry step. */
    step?: AccountEntryStep | null;
};