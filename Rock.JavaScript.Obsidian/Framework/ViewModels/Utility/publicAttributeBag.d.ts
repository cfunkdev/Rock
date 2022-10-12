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
import { PublicAttributeCategoryBag } from "@Obsidian/ViewModels/Utility/publicAttributeCategoryBag";

/**
 * A slimmed down version of an attribute that includes enough detail to
 * view and edit a value, but not enough to edit the attribute itself.
 */
export type PublicAttributeBag = {
    /** Gets or sets the field type unique identifier. */
    fieldTypeGuid?: Guid | null;

    /** Gets or sets the attribute unique identifier. */
    attributeGuid?: Guid | null;

    /** Gets or sets the name of the attribute. */
    name?: string | null;

    /** Gets or sets the key that identifies the attribute on the entity. */
    key?: string | null;

    /** Gets or sets the description. */
    description?: string | null;

    /** Gets or sets a value indicating whether this attribute value is required. */
    isRequired: boolean;

    /** Gets or sets the order. */
    order: number;

    /** Gets or sets the categories. */
    categories?: PublicAttributeCategoryBag[] | null;

    /** Gets or sets the configuration values. */
    configurationValues?: Record<string, string> | null;
};
