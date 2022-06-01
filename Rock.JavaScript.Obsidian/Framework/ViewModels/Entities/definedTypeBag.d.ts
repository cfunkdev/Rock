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

/** DefinedType View Model */
export type DefinedTypeBag = {
    /** Gets or sets a flag indicating if the Defined Values associated with this Defined Type can be grouped into categories. */
    categorizedValuesEnabled?: boolean | null;

    /** Gets or sets the category identifier. */
    categoryId?: number | null;

    /** Gets or sets a user defined description of the DefinedType. */
    description?: string | null;

    /** Gets or sets a value indicating whether the DefinedValues for this DefinedType should allow security settings. */
    enableSecurityOnValues: boolean;

    /**
     * Gets or sets the FieldTypeId of the Rock.Model.FieldType that is used to set/select, and at times display the DefinedValues that are associated with
     * NOTE: Currently, Text is the only supported fieldType for DefinedTypes.
     * this DefinedType. 
     */
    fieldTypeId?: number | null;

    /** Gets or sets the help text for the defined type. */
    helpText?: string | null;

    /** Gets or sets a value indicating whether this Defined Type is active. */
    isActive: boolean;

    /** Gets or sets a flag indicating if this DefinedType is part of the Rock core system/framework. This property is required. */
    isSystem: boolean;

    /** Gets or sets the Name of the DefinedType. */
    name?: string | null;

    /** Gets or sets the display order of this DefinedType.  The lower the number the higher the display priority.  This property is required. */
    order: number;

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
