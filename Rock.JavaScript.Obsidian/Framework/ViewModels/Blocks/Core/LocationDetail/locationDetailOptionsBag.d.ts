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

import { Guid } from "@Obsidian/Types";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

/** Contains extra configuration details for the block. */
export type LocationDetailOptionsBag = {
    /** Gets or sets a value indicating whether current user has Administrate authorizartion */
    canAdministrate: boolean;

    /** Gets or sets a value indicating whether a parent Id was passed in the URL indicating the block is in TreeView. */
    hasParentLocationId: boolean;

    /** Gets or sets a value indicating whether the a PersonId was passed as a URL parameter */
    hasPersonId: boolean;

    /** Gets or sets the map style unique identifier. */
    mapStyleGuid?: Guid | null;

    /** Gets or sets the panel title. */
    panelTitle?: string | null;

    /** Gets or sets the printer device options. */
    printerDeviceOptions?: ListItemBag[] | null;
};
