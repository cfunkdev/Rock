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

/** SystemPhoneNumber View Model */
export type SystemPhoneNumberBag = {
    /**
     * Gets or sets the identifier of the person alias who should receive
     * responses to the SMS number. This person must have a phone number
     * with SMS enabled or no response will be sent.
     */
    assignedToPersonAliasId?: number | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the created by person alias identifier. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the created date time. */
    createdDateTime?: string | null;

    /** Gets or sets the description. */
    description?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets a value indicating whether this phone number is active. */
    isActive: boolean;

    /** Gets or sets a value indicating whether this instance support SMS. */
    isSmsEnabled: boolean;

    /**
     * Gets or sets a value indicating whether this phone number will
     * forward incoming messages to Rock.Model.SystemPhoneNumber.AssignedToPersonAliasId.
     */
    isSmsForwardingEnabled: boolean;

    /**
     * Gets or sets the mobile application site identifier. This is
     * used when determining what devices to send push notifications to.
     */
    mobileApplicationSiteId?: number | null;

    /** Gets or sets the modified by person alias identifier. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the modified date time. */
    modifiedDateTime?: string | null;

    /** Gets or sets the friendly name of the phone number. */
    name?: string | null;

    /**
     * Gets or sets the phone number. This should be in E.123 format,
     * such as +16235553324.
     */
    number?: string | null;

    /**
     * Gets or sets the sort and display order of the Rock.Model.SystemPhoneNumber.
     * This is an ascending order, so the lower the value the higher the
     * sort priority.
     */
    order: number;

    /** Gets or sets the provider identifier. */
    providerIdentifier?: string | null;

    /**
     * Gets or sets the notification group identifier. Active members of
     * this group will be notified when a new SMS message comes in to
     * this phone number.
     */
    smsNotificationGroupId?: number | null;

    /**
     * Gets or sets the identifier of the workflow type that will be
     * launched when an SMS message is received on this number.
     */
    smsReceivedWorkflowTypeId?: number | null;
};