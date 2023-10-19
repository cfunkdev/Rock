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

import { BenevolenceWorkflowBag } from "@Obsidian/ViewModels/Blocks/Finance/BenevolenceTypeDetail/benevolenceWorkflowBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type BenevolenceTypeBag = {
    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets a value indicating whether the user has administrative rights with this entity. */
    canAdminstrate: boolean;

    /** Gets or sets the Rock.Model.BenevolenceType.Description value on the Rock.Model.BenevolenceType. This property is required. */
    description?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the Rock.Model.BenevolenceType.IsActive value on the Rock.Model.BenevolenceType. This property is required. */
    isActive: boolean;

    /** Gets or sets the maximum number of documents. */
    maximumNumberOfDocuments?: number | null;

    /** Gets or sets the Rock.Model.BenevolenceType.Name value on the Rock.Model.BenevolenceType. This property is required. */
    name?: string | null;

    /** Gets or sets the Rock.Model.BenevolenceType.RequestLavaTemplate value on the Rock.Model.BenevolenceType. This property is required. */
    requestLavaTemplate?: string | null;

    /** Gets or sets a value indicating whether [show financial results]. */
    showFinancialResults: boolean;

    /** Gets or sets the workflows. */
    workflows?: BenevolenceWorkflowBag[] | null;
};
