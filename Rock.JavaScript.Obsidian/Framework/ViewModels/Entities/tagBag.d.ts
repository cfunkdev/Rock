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

/** Tag View Model */
export type TagBag = {
    /** Gets or sets the background color of each tag */
    backgroundColor?: string | null;

    /** Gets or sets the category identifier. */
    categoryId?: number | null;

    /** Gets or sets the description. */
    description?: string | null;

    /** Gets or sets the EntityTypeId of the Rock.Model.EntityType containing the entities that can use this Tag. This property is required. */
    entityTypeId?: number | null;

    /**
     * Gets or sets the name of the column/property that contains the value that can narrow the scope of entities that can receive this Tag. Entities where this
     * column contains the Rock.Model.Tag.EntityTypeQualifierValue will be eligible to have this Tag. This property must be used in conjunction with the Rock.Model.Tag.EntityTypeQualifierValue
     * property. If all entities of the specified Rock.Model.EntityType are eligible to use this Tag, this property will be null.
     */
    entityTypeQualifierColumn?: string | null;

    /**
     * Gets or sets the value in the Rock.Model.Tag.EntityTypeQualifierColumn that narrows the scope of entities that can receive this Tag. Entities that contain this value
     * in the Rock.Model.Tag.EntityTypeQualifierColumn are eligible to use this Tag. This property must be used in conjunction with the Rock.Model.Tag.EntityTypeQualifierColumn property.
     */
    entityTypeQualifierValue?: string | null;

    /** Gets or sets the icon CSS class. */
    iconCssClass?: string | null;

    /** Gets or sets a value indicating whether this instance is active. */
    isActive: boolean;

    /** Gets or sets a flag indicating if this Tag is part of the Rock core system/framework. */
    isSystem: boolean;

    /** Gets or sets the Name of the Tag. This property is required. */
    name?: string | null;

    /**
     * Gets or sets the display order of the tag. the lower the number, the higher display priority that the Tag has.  For example the Tags with the lower Order could be displayed higher on the Tag list.
     * This property is required.
     */
    order: number;

    /** Gets or sets the owner person alias identifier. */
    ownerPersonAliasId?: number | null;

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
