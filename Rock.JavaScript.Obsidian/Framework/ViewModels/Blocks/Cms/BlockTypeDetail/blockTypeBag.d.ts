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
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type BlockTypeBag = {
    /** Gets or sets the category of the BlockType.  Blocks will be grouped by category when displayed to user */
    category?: string | null;

    /** Gets or sets the user defined description of the BlockType. */
    description?: string | null;

    /** Gets or sets the type of the entity. */
    entityType?: ListItemBag | null;

    /** Gets or sets a flag indicating if this BlockType was created by and is a part of the Rock core system/framework. This property is required. */
    isSystem: boolean;

    /** Gets or sets the name of the BlockType. */
    name?: string | null;

    /** Gets or sets relative path to the .Net ASCX UserControl that provides the HTML Markup and code for the BlockType. */
    path?: string | null;

    /** Gets or sets a flag indicating if this Block exists. */
    isBlockExists: boolean;

    /** Gets or sets a flag indicating if BlockType supports adding additional block type attributes at runtime. */
    isDynamicAttributesBlock: boolean;

    /** Gets or sets the name of the fully qualified page referencing Block Type. */
    pages?: string[] | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;
};
