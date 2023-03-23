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

import { ContentCollectionFilterControl } from "@Obsidian/Enums/Cms/contentCollectionFilterControl";
import { ContentCollectionAttributeFilterSettingsBag } from "@Obsidian/ViewModels/Cms/contentCollectionAttributeFilterSettingsBag";
import { ContentCollectionCustomFieldFilterSettingsBag } from "@Obsidian/ViewModels/Cms/contentCollectionCustomFieldFilterSettingsBag";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

/**
 * Defines the settings used by the Content Collection filters as stored
 * in the database.
 */
export type ContentCollectionFilterSettingsBag = {
    /**
     * Gets or sets the attributes that are enabled for filtering
     * and indexing on the content collection.
     */
    attributeFilters?: Record<string, ContentCollectionAttributeFilterSettingsBag> | null;

    /**
     * Gets or sets the attribute values that have been learned. These
     * are used to display the known values in the filter panel.
     */
    attributeValues?: Record<string, ListItemBag[]> | null;

    /** Gets or sets the custom field filters that are enabled for filtering. */
    customFieldFilters?: Record<string, ContentCollectionCustomFieldFilterSettingsBag> | null;

    /**
     * Gets or sets the field values that have been learned. These
     * are used to display the known values in the filter panel.
     */
    fieldValues?: Record<string, ListItemBag[]> | null;

    /** Gets or sets a value indicating whether full text search should be enabled. */
    fullTextSearchEnabled: boolean;

    /**
     * Gets or sets a value indicating whether searching content by year
     * should be enabled.
     */
    yearSearchEnabled: boolean;

    /** Gets or sets the year search filter control. */
    yearSearchFilterControl: ContentCollectionFilterControl;

    /**
     * Gets or sets a value that indicates if multiple selection is
     * used by the year search filter.
     */
    yearSearchFilterIsMultipleSelection: boolean;

    /**
     * Gets or sets the label to use for the filter that allows an
     * individual to search for content by a specific year.
     */
    yearSearchLabel?: string | null;
};
