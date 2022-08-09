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

/** GroupDemographicType View Model */
export type GroupDemographicTypeBag = {
    /** Gets or sets the component entity type identifier. This is an FK of EntityType.Id. */
    componentEntityTypeId: number;

    /** The description of the Group Demographic Type. Previewable. */
    description?: string | null;

    /** The Rock.Model.GroupType identifier of the group this Group Demographic Type is associated with. */
    groupTypeId: number;

    /** Specify if this GroupDemographicType is automated. If true the UI will not allow manual entry. */
    isAutomated: boolean;

    /** How long a component took to get its values in seconds. */
    lastRunDurationSeconds?: number | null;

    /** The name of the Group Demographic Type. Previewable. */
    name?: string | null;

    /** A comma delimited list of GroupTypeRoles IDs */
    roleFilter?: string | null;

    /** Indicates if the component for this Group Demographic Type should be run everytime a person is updated. */
    runOnPersonUpdate: boolean;

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