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
 * Defines a custom field that will be used to store custom data in the
 * index for an item.
 */
export type ContentCollectionCustomFieldBag = {
    /**
     * Gets or sets a value indicating whether the value will be treated
     * as a multi-value field. When enabled the final value will be split
     * by comma and turned into multiple values.
     */
    isMultiple: boolean;

    /** Gets or sets the key used in the item index. */
    key?: string | null;

    /** Gets or sets the lava template to use when generating custom content. */
    template?: string | null;

    /** Gets or sets the friendly display title. */
    title?: string | null;
};
