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

import { NcoaProcessPersonAddressBag } from "@Obsidian/ViewModels/Blocks/Communication/NcoaProcess/ncoaProcessPersonAddressBag";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

export type NcoaProcessBag = {
    /** Gets or sets the addresses that will be exported into the file used in the NCOA process. */
    addresses?: Record<number, NcoaProcessPersonAddressBag> | null;

    /** Gets or sets the Id of the Inactive Record Reason to use when inactivating people due to moving beyond the configured number of miles. */
    inactiveReason?: ListItemBag | null;

    /** Gets or sets the boolean determining if a move in the 19-48 month catagory should be marked as a previous address. */
    mark48MonthAsPrevious: boolean;

    /** Gets or sets the boolean determining invalid addresses should be marked as previous addresses. */
    markInvalidAsPrevious: boolean;

    /** Gets or sets the minimum move distance to use when determining inactivating people. */
    minMoveDistance: number;

    /** Gets or sets the reference to the uploaded file. */
    ncoaFileUploadReference?: ListItemBag | null;

    /** Gets or sets the success message. */
    successMessage?: string | null;
};
