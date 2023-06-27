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

export type LavaShortcodeBag = {
    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /**
     * Gets or sets the collection of Categories that this Rock.Model.LavaShortcode is associated with.
     * NOTE: Since changes to Categories isn't tracked by ChangeTracker, set the ModifiedDateTime if Categories are modified.
     */
    categories?: ListItemBag[] | null;

    /** Gets or sets the Description of the Lava Shortcode. */
    description?: string | null;

    /** Gets or sets the documentation. This serves as the technical description of the internals of the shortcode. */
    documentation?: string | null;

    /** Gets or sets the enabled commands. */
    enabledCommands?: ListItemBag[] | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets a value indicating whether this instance is active. */
    isActive: boolean;

    /** Gets or sets a value indicating whether this instance is system. */
    isSystem: boolean;

    /** Gets or sets the token. */
    markup?: string | null;

    /** Gets or sets the public name of the shortcode. */
    name?: string | null;

    /** Gets or sets the parameters. */
    parameters?: ListItemBag[] | null;

    /** Gets or sets the name of the tag. */
    tagName?: string | null;

    /** Gets or sets the type of the tag (inline or block). A tag type of block requires an end tag. */
    tagType?: string | null;
};
