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
import { FilterOptionsBag } from "@Obsidian/ViewModels/Blocks/Cms/ContentCollectionView/filterOptionsBag";

/**
 * The settings that will be edited in the custom settings panel for the
 * Content Collection View block.
 */
export type CustomSettingsBag = {
    /** Gets or sets the content collection that is currently selected. */
    contentCollection?: Guid | null;

    /**
     * Gets or sets a value indicating whether the filters panel
     * should be visible.
     */
    showFiltersPanel: boolean;

    /**
     * Gets or sets a value indicating whether the full text search
     * panel should be visible.
     */
    showFullTextSearch: boolean;

    /**
     * Gets or sets a value indicating whether the sorting control
     * should be shown.
     */
    showSort: boolean;

    /**
     * Gets or sets the number of results to return per source. If grouping
     * is not enabled then this controls the total number of results.
     */
    numberOfResults?: number | null;

    /**
     * Gets or sets a value indicating whether to perform an initial
     * search if no query string parameters are provided. If query string
     * parameters are provided then search will always be performed on load.
     */
    searchOnLoad: boolean;

    /**
     * Gets or sets a value indicating whether results should be grouped
     * by source.
     */
    groupResultsBySource: boolean;

    /**
     * Gets or sets a value indicating which sort orders are available to
     * be used by the individual
     */
    enabledSortOrders?: string[] | null;

    /** Gets or sets the trending term to use when displaying the sort option. */
    trendingTerm?: string | null;

    /** Gets or sets the filters that are configured. */
    filters?: FilterOptionsBag[] | null;

    /**
     * Gets or sets the template that will be used to render the search
     * results container. It must have a div with result-items class
     * and an optional element with show-more class to act as a show more
     * button.
     */
    resultsTemplate?: string | null;

    /**
     * Gets or sets the template that will be used to render each individual
     * search result item.
     */
    itemTemplate?: string | null;

    /**
     * Gets or sets the template that will be used to render the content
     * to display in the search results area before a search happens.
     */
    preSearchTemplate?: string | null;

    /**
     * Gets or sets a value indicating whether results with matching
     * personalization segments should be boosted.
     */
    boostMatchingSegments: boolean;

    /**
     * Gets or sets a value indicating whether results with matching
     * request segments should be boosted.
     */
    boostMatchingRequestFilters: boolean;

    /** Gets or sets the segment boost amount. */
    segmentBoostAmount?: number | null;

    /** Gets or sets the request filter boost amount. */
    requestFilterBoostAmount?: number | null;
};
