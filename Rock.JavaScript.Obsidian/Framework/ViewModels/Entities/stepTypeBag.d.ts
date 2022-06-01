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

/** StepType View Model */
export type StepTypeBag = {
    /** Gets or sets a flag indicating if this item can be edited by a person. */
    allowManualEditing: boolean;

    /** Gets or sets a flag indicating if this step type allows multiple step records per person. */
    allowMultiple: boolean;

    /**
     * Gets or sets the Id of the Rock.Model.DataView associated with this step type. The data view reveals the people that are allowed to be
     * considered for this step type.
     */
    audienceDataViewId?: number | null;

    /**
     * Gets or sets the Id of the Rock.Model.DataView associated with this step type. The data view reveals the people that should be considered
     * as having completed this step.
     */
    autoCompleteDataViewId?: number | null;

    /** Gets or sets the lava template used to render custom card details. */
    cardLavaTemplate?: string | null;

    /** Gets or sets a description of the step type. */
    description?: string | null;

    /** Gets or sets a flag indicating if this step type happens over time (like being in a group) or is it achievement based (like attended a class). */
    hasEndDate: boolean;

    /** Gets or sets the highlight color for badges and cards. */
    highlightColor?: string | null;

    /** Gets or sets the icon CSS class. */
    iconCssClass?: string | null;

    /** Gets or sets a flag indicating if this item is active or not. */
    isActive: boolean;

    /** Gets or sets a value indicating whether this step requires a date. */
    isDateRequired: boolean;

    /** Gets or sets the name used to describe the merge template (e.g. Certificate). */
    mergeTemplateDescriptor?: string | null;

    /**
     * Gets or sets the Id of the Rock.Model.MergeTemplate associated with this step type. This template can represent things like
     * certificates or letters.
     */
    mergeTemplateId?: number | null;

    /** Gets or sets the name of the step type. This property is required. */
    name?: string | null;

    /** Gets or sets the order. */
    order: number;

    /** Gets or sets a flag indicating if the number of occurrences should be shown on the badge. */
    showCountOnBadge: boolean;

    /** Gets or sets the Id of the Rock.Model.StepProgram to which this step type belongs. This property is required. */
    stepProgramId: number;

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
