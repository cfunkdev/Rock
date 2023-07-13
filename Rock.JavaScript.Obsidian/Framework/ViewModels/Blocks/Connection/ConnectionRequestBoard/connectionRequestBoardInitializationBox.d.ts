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

import { ConnectionRequestBoardConnectionTypeBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardConnectionTypeBag";
import { ConnectionRequestBoardSelectedOpportunityBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardSelectedOpportunityBag";

/** The box that contains all the initialization information for the Connection Request Board block. */
export type ConnectionRequestBoardInitializationBox = {
    /** Gets or sets the connection types that are available to be selected within the opportunities sidebar. */
    connectionTypes?: ConnectionRequestBoardConnectionTypeBag[] | null;

    /**
     * Gets or sets the error message. A non-empty value indicates that
     * an error is preventing the block from being displayed.
     */
    errorMessage?: string | null;

    /** Gets or sets the maximum number of cards that should be displayed per column in card view mode. */
    maxCardsPerColumn: number;

    /** Gets or sets the navigation urls. */
    navigationUrls?: Record<string, string> | null;

    /** Gets or sets the security grant token. */
    securityGrantToken?: string | null;

    /** Gets or sets the selected connection opportunity and supporting information. */
    selectedOpportunity?: ConnectionRequestBoardSelectedOpportunityBag | null;

    /**
     * Gets or sets the status icons template that should be used at the top of each connection request card (in card view mode),
     * the first column of each row (in grid view mode) + the top of the connection request modal.
     */
    statusIconsTemplate?: string | null;
};
