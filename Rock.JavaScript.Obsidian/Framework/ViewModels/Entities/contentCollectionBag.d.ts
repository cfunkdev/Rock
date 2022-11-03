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

/** ContentCollection View Model */
export type ContentCollectionBag = {
    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the collection key. */
    collectionKey?: string | null;

    /** Gets or sets the created by person alias identifier. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the created date time. */
    createdDateTime?: string | null;

    /** Gets or sets the description. */
    description?: string | null;

    /**
     * Gets or sets a value indicating whether personalization request
     * filters should be enabled.
     */
    enableRequestFilters: boolean;

    /**
     * Gets or sets a value indicating whether personalization segments
     * should be enabled.
     */
    enableSegments: boolean;

    /** Gets or sets the filter settings. */
    filterSettings?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the last index date time. */
    lastIndexDateTime?: string | null;

    /** Gets or sets the last index item count. */
    lastIndexItemCount?: number | null;

    /** Gets or sets the modified by person alias identifier. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the modified date time. */
    modifiedDateTime?: string | null;

    /** Gets or sets the name of the Rock.Model.ContentCollection. */
    name?: string | null;

    /**
     * Gets or sets a value indicating whether trending is enabled for this
     * content collection.
     */
    trendingEnabled: boolean;

    /**
     * Gets or sets the trending gravity to apply more weight to items that
     * are newer.
     */
    trendingGravity: number;

    /** Gets or sets the trending max items. */
    trendingMaxItems: number;

    /** Gets or sets the trending window day. */
    trendingWindowDay: number;
};
