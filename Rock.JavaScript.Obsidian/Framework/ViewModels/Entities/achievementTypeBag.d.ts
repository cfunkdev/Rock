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
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

/** AchievementType View Model */
export type AchievementTypeBag = {
    /** Gets or sets the AchievementFailureWorkflowTypeId. */
    achievementFailureWorkflowTypeId?: number | null;

    /** Gets or sets the AchievementIconCssClass. */
    achievementIconCssClass?: string | null;

    /** Gets or sets the AchievementStartWorkflowTypeId. */
    achievementStartWorkflowTypeId?: number | null;

    /** Gets or sets the AchievementStepStatusId. */
    achievementStepStatusId?: number | null;

    /** Gets or sets the AchievementStepTypeId. */
    achievementStepTypeId?: number | null;

    /** Gets or sets the AchievementSuccessWorkflowTypeId. */
    achievementSuccessWorkflowTypeId?: number | null;

    /** Gets or sets the AchieverEntityTypeId. */
    achieverEntityTypeId: number;

    /** Gets or sets the AllowOverAchievement. */
    allowOverAchievement: boolean;

    /** Gets or sets the AlternateImageBinaryFileId. */
    alternateImageBinaryFileId?: number | null;

    /** Gets or sets the BadgeLavaTemplate. */
    badgeLavaTemplate?: string | null;

    /** Gets or sets the CategoryId. */
    categoryId?: number | null;

    /** Gets or sets the ComponentConfigJson. */
    componentConfigJson?: string | null;

    /** Gets or sets the ComponentEntityTypeId. */
    componentEntityTypeId: number;

    /** Gets or sets the CustomSummaryLavaTemplate. */
    customSummaryLavaTemplate?: string | null;

    /** Gets or sets the Description. */
    description?: string | null;

    /** Gets or sets the HighlightColor. */
    highlightColor?: string | null;

    /** Gets or sets the ImageBinaryFileId. */
    imageBinaryFileId?: number | null;

    /** Gets or sets the IsActive. */
    isActive: boolean;

    /** Gets or sets the IsPublic. */
    isPublic: boolean;

    /** Gets or sets the MaxAccomplishmentsAllowed. */
    maxAccomplishmentsAllowed?: number | null;

    /** Gets or sets the Name. */
    name?: string | null;

    /** Gets or sets the ResultsLavaTemplate. */
    resultsLavaTemplate?: string | null;

    /** Gets or sets the SourceEntityTypeId. */
    sourceEntityTypeId?: number | null;

    /** Gets or sets the CreatedDateTime. */
    createdDateTime?: string | null;

    /** Gets or sets the ModifiedDateTime. */
    modifiedDateTime?: string | null;

    /** Gets or sets the CreatedByPersonAliasId. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the ModifiedByPersonAliasId. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the Id. */
    id: number;

    /** Gets or sets the Guid. */
    guid?: Guid | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;
};
