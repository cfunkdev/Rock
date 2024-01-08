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

import { ToolboxActionType } from "@Obsidian/Enums/Blocks/Group/Scheduling/toolboxActionType";
import { CommunicationEntryAuthorizationBag } from "@Obsidian/ViewModels/Blocks/Communication/CommunicationEntry/communicationEntryAuthorizationBag";
import { CommunicationEntryCommunicationBag } from "@Obsidian/ViewModels/Blocks/Communication/CommunicationEntry/communicationEntryCommunicationBag";
import { CommunicationEntryMediumOptionsBaseBag } from "@Obsidian/ViewModels/Blocks/Communication/CommunicationEntry/communicationEntryMediumOptionsBaseBag";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

/** Box containing initialization information for the Communication Entry block. */
export type CommunicationEntryInitializationBox = {
    /** Gets or sets the action header HTML. */
    actionHeaderHtml?: string | null;

    /** Gets or sets the additional merge fields. */
    additionalMergeFields?: string[] | null;

    /** Gets or sets the additional time sign-ups button text. */
    additionalTimeSignUpsButtonText?: string | null;

    /** Gets or sets the additional time sign-ups header HTML. */
    additionalTimeSignUpsHeaderHtml?: string | null;

    /** Gets or sets the authorization details for the block. */
    authorization?: CommunicationEntryAuthorizationBag | null;

    /** Gets or sets the communication details being created/edited. */
    communication?: CommunicationEntryCommunicationBag | null;

    /** Gets or sets the current schedule button text. */
    currentScheduleButtonText?: string | null;

    /** Gets or sets the current schedule header HTML. */
    currentScheduleHeaderHtml?: string | null;

    /**
     * Gets or sets the error message. A non-empty value indicates that
     * an error is preventing the block from being displayed.
     */
    errorMessage?: string | null;

    /** Gets or sets the immediate needs introduction. */
    immediateNeedsIntroduction?: string | null;

    /** Gets or sets the immediate needs title. */
    immediateNeedsTitle?: string | null;

    /** Gets or sets whether the "additional time sign-ups" feature is enabled. */
    isAdditionalTimeSignUpsEnabled: boolean;

    /** Gets or sets a value indicating whether the block should use full mode. */
    isFullMode: boolean;

    /**
     * Gets or sets a value indicating whether the entire Communication Entry block is hidden.
     * There should be another block on the page that will display the Communication details in view mode when this is true.
     */
    isHidden: boolean;

    /** Gets or sets whether the "schedule preferences" feature is enabled. */
    isSchedulePreferencesEnabled: boolean;

    /** Gets or sets whether the "schedule unavailability" feature is enabled. */
    isScheduleUnavailabilityEnabled: boolean;

    /** Gets or sets the options for the selected communication medium. */
    mediumOptions?: CommunicationEntryMediumOptionsBaseBag | null;

    /** Gets or sets the mediums for the tab control. */
    mediums?: ListItemBag[] | null;

    /** Gets or sets the navigation urls. */
    navigationUrls?: Record<string, string> | null;

    /**
     * Gets or sets the toolbox person's schedulable family member people. Note that the
     * toolbox person themself will always be the first person in this list, regardless
     * of whether or not they belong to any schedulable groups.
     */
    schedulableFamilyMembers?: ListItemBag[] | null;

    /** Gets or sets the schedule preferences button text. */
    schedulePreferencesButtonText?: string | null;

    /** Gets or sets the schedule preferences header HTML. */
    schedulePreferencesHeaderHtml?: string | null;

    /** Gets or sets the schedule unavailability button text. */
    scheduleUnavailabilityButtonText?: string | null;

    /** Gets or sets the schedule unavailability header HTML. */
    scheduleUnavailabilityHeaderHtml?: string | null;

    /** Gets or sets the security grant token. */
    securityGrantToken?: string | null;

    /** Gets or sets the communication templates that can be selected. */
    templates?: ListItemBag[] | null;

    /** Gets or sets the title. */
    title?: string | null;

    /** Gets or sets the toolbox action type. */
    toolboxActionType: ToolboxActionType;
};
