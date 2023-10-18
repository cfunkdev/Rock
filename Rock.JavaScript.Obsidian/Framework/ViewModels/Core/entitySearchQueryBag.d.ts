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

/**
 * Defines the details about an entity search request that will be
 * executed.
 */
export type EntitySearchQueryBag = {
    /**
     * Gets or sets the expression that will be used to group the results.
     * This is processed after the Rock.ViewModels.Core.EntitySearchQueryBag.Where expression.
     */
    groupBy?: string | null;

    /**
     * Gets or sets a value indicating whether only the number of matching
     * items should be returned.
     */
    isCountOnly: boolean;

    /**
     * Gets or sets the number of items to include in the result set.
     * This is processed after Rock.ViewModels.Core.EntitySearchQueryBag.Offset is processed.
     */
    limit?: number | null;

    /**
     * Gets or sets the number of items to skip before the first item the result set. This
     * is processed after Rock.ViewModels.Core.EntitySearchQueryBag.Sort performs sorting.
     */
    offset?: number | null;

    /**
     * Gets or sets the expression that will be used to define the structure
     * of the the resulting items. This is processed after the Rock.ViewModels.Core.EntitySearchQueryBag.GroupBy
     * expression.
     */
    select?: string | null;

    /**
     * Gets or sets the expression that will be used to define the structure
     * of the the resulting items. This is processed after the Rock.ViewModels.Core.EntitySearchQueryBag.GroupBy
     * expression and instead of the Rock.ViewModels.Core.EntitySearchQueryBag.Select expression.
     */
    selectMany?: string | null;

    /**
     * Gets or sets the expression that will be used to sort the results.
     * This is processed after the Rock.ViewModels.Core.EntitySearchQueryBag.Select expression.
     */
    sort?: string | null;

    /** Gets or sets the expression that will be used to filter the query. */
    where?: string | null;
};
