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

/** The additional configuration options for the Group Type Detail block. */
export type CheckinTypeDetailOptionsBag = {
    /** Gets or sets the achievement type options. */
    achievementTypeOptions?: ListItemBag[] | null;

    /** Gets or sets the display options. */
    displayOptions?: ListItemBag[] | null;

    /** Gets or sets the family attribute options. */
    familyAttributeOptions?: ListItemBag[] | null;

    /** Gets or sets a value indicating whether [hide panel]. */
    hidePanel: boolean;

    /** Gets or sets the name search defined value. */
    nameSearch?: ListItemBag | null;

    /** Gets or sets the registration attribute options. */
    personAttributeOptions?: ListItemBag[] | null;

    /** Gets or sets the relationship type options. */
    relationshipTypeOptions?: ListItemBag[] | null;

    /** Gets or sets the search type options. */
    searchTypeOptions?: ListItemBag[] | null;

    /** Gets or sets the template display options. */
    templateDisplayOptions?: ListItemBag[] | null;
};
