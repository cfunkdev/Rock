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

import { ConnectionRequestBoardActivityOptionsBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardActivityOptionsBag";
import { ConnectionRequestBoardConnectionRequestActivityBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardConnectionRequestActivityBag";
import { ConnectionRequestBoardConnectionRequestBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardConnectionRequestBag";
import { ConnectionRequestBoardGroupRequirementBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardGroupRequirementBag";
import { ConnectionRequestBoardPhoneBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardPhoneBag";
import { ConnectionRequestBoardRequestOptionsBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardRequestOptionsBag";
import { ConnectionRequestBoardTransferOptionsBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardTransferOptionsBag";
import { ConnectionRequestBoardWorkflowBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardWorkflowBag";

/** A bag that contains selected connection request information for the connection request board. */
export type ConnectionRequestBoardSelectedRequestBag = {
    /** Gets or sets the connection request activities. */
    activities?: ConnectionRequestBoardConnectionRequestActivityBag[] | null;

    /** Gets or sets the options that may be assigned to any new or existing connection request activities. */
    activityOptions?: ConnectionRequestBoardActivityOptionsBag | null;

    /** Gets or sets the comments HTML. */
    commentsHtml?: string | null;

    /** Gets or sets the selected connection request. */
    connectionRequest?: ConnectionRequestBoardConnectionRequestBag | null;

    /** Gets or sets the custom badge bar HTML. */
    customBadgeBarHtml?: string | null;

    /** Gets or sets any unmet group requirements for the "requester" person, related to the assigned placement group. */
    groupRequirements?: ConnectionRequestBoardGroupRequirementBag[] | null;

    /** Gets or sets the header labels HTML. */
    headerLabelsHtml?: string | null;

    /** Gets or sets the heading HTML, to be displayed above the "requester" person's name. */
    headingHtml?: string | null;

    /** Gets or sets whether the connection button should be visible. */
    isConnectButtonVisible: boolean;

    /** Gets or sets whether connecting is enabled. */
    isConnectEnabled: boolean;

    /** Gets or sets whether editing is enabled. */
    isEditEnabled: boolean;

    /** Gets or sets whether transferring is enabled. */
    isTransferEnabled: boolean;

    /**
     * Gets or sets the "requester" person's email HTML, which will link to the appropriate communications
     * page and might provide additional, helpful information via a tooltip.
     */
    personEmailHtml?: string | null;

    /** Gets or sets the "requester" person's full name. */
    personFullName?: string | null;

    /** Gets or sets the "requester" person's phone numbers. */
    personPhoneNumbers?: ConnectionRequestBoardPhoneBag[] | null;

    /** Gets or sets the "requester" person's photo URL. */
    personPhotoUrl?: string | null;

    /** Gets or sets the link to the "requester" person's profile page. */
    personProfileLink?: string | null;

    /** Gets or sets the options that may be assigned when editing the connection request. */
    requestOptions?: ConnectionRequestBoardRequestOptionsBag | null;

    /** Gets or sets the side description HTML. */
    sideDescriptionHtml?: string | null;

    /** Gets or sets the status icons HTML. */
    statusIconsHtml?: string | null;

    /** Gets or sets the options that may be assigned when transferring this connection request. */
    transferOptions?: ConnectionRequestBoardTransferOptionsBag | null;

    /** Gets or sets any workflows that have already been instantiated against this connection request. */
    workflows?: ConnectionRequestBoardWorkflowBag[] | null;
};
