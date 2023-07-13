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

import { ConnectionRequestBoardSortPropertyBag } from "@Obsidian/ViewModels/Blocks/Connection/ConnectionRequestBoard/connectionRequestBoardSortPropertyBag";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

/** A bag that contains filter options information for the connection request board. */
export type ConnectionRequestBoardFilterOptionsBag = {
    /** Gets or sets the campuses that can be used to filter connection requests. */
    campuses?: ListItemBag[] | null;

    /** Gets or sets the connection activity types that can be used to filter connection requests. */
    connectionActivityTypes?: ListItemBag[] | null;

    /** Gets or sets the connection states that can be used to filter connection requests. */
    connectionStates?: ListItemBag[] | null;

    /** Gets or sets the connection statuses that can be used to filter connection requests. */
    connectionStatuses?: ListItemBag[] | null;

    /** Gets or sets the "connector" people that can be used to filter connection requests. */
    connectors?: ListItemBag[] | null;

    /** Gets or sets the properties that can be used to sort connection requests. */
    sortProperties?: ConnectionRequestBoardSortPropertyBag[] | null;
};
