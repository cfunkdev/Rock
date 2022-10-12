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

import { SearchOrder } from "@Obsidian/Enums/Blocks/Cms/ContentCollectionView/searchOrder";
import { Guid } from "@Obsidian/Types";

/**
 * Defines a query against the content collection for the Content Collection
 * View block.
 */
export type SearchQueryBag = {
    /** Gets or sets the text to use when searching for content. */
    text?: string | null;

    /**
     * Gets or sets the source unique identifier to load results for. This
     * is used by the show more feature.
     */
    sourceGuid?: Guid | null;

    /**
     * Gets or sets the offset to start loading results for. This is used
     * by the show more feature.
     */
    offset?: number | null;

    /** Gets or sets the filter values to use when searching for results. */
    filters?: Record<string, string> | null;

    /** Gets or sets the order to sort results into. */
    order?: SearchOrder | null;
};
