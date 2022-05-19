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

/** DefinedValue View Model */
export type DefinedValueBag = {
    /** Gets or sets the category identifier. This property is ignored if DefinedType.CategorizedValuesEnabled is disabled. */
    categoryId?: number | null;

    /** Gets or sets the DefinedTypeId of the Rock.Model.DefinedType that this DefinedValue belongs to. This property is required. */
    definedTypeId: number;

    /** Gets or sets the Description of the DefinedValue. */
    description?: string | null;

    /** Gets or sets a value indicating whether this DefinedValue is active. */
    isActive: boolean;

    /** Gets or sets a flag indicating if this DefinedValue is part of the Rock core system/framework. this property is required. */
    isSystem: boolean;

    /** Gets or sets the sort and display order of the DefinedValue.  This is an ascending order, so the lower the value the higher the sort priority. */
    order: number;

    /** Gets or sets the Value of the DefinedValue. This property is required. */
    value?: string | null;

    /** Gets or sets the created date time. */
    createdDateTime?: string | null;

    /** Gets or sets the modified date time. */
    modifiedDateTime?: string | null;

    /** Gets or sets the created by person alias identifier. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the modified by person alias identifier. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;
};
