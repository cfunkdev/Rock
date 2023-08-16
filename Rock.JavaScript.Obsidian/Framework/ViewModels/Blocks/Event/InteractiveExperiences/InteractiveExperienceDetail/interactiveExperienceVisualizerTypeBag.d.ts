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

/**
 * Identifies a single visualizer type that can be used to configure
 * visualizers for an action by the individual.
 */
export type InteractiveExperienceVisualizerTypeBag = {
    /** Gets or sets the attributes that are available on this visualizer type. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the category for this item. */
    category?: string | null;

    /** Gets or sets the default attribute values. */
    defaultAttributeValues?: Record<string, string> | null;

    /** Gets or sets disabled for this item. */
    disabled?: boolean | null;

    /** Gets or sets the text. */
    text?: string | null;

    /** Gets or sets the value. */
    value?: string | null;
};
