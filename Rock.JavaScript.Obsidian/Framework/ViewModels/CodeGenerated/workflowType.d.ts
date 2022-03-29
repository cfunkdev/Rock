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

import { IEntity } from "../entity";

export type WorkflowType = IEntity & {
    attributeValues?: Record<string, unknown>;
    categoryId?: number | null;
    completedWorkflowRetentionPeriod?: number | null;
    description?: string | null;
    formBuilderSettingsJson?: string | null;
    formBuilderTemplateId?: number | null;
    formEndDateTime?: string | null;
    formStartDateTime?: string | null;
    iconCssClass?: string | null;
    isActive?: boolean | null;
    isFormBuilder?: boolean;
    isLoginRequired?: boolean;
    isPersisted?: boolean;
    isSystem?: boolean;
    loggingLevel?: number;
    logRetentionPeriod?: number | null;
    maxWorkflowAgeDays?: number | null;
    name?: string | null;
    noActionMessage?: string | null;
    order?: number;
    processingIntervalSeconds?: number | null;
    summaryViewText?: string | null;
    workflowExpireDateTime?: string | null;
    workflowIdPrefix?: string | null;
    workTerm?: string | null;
    createdDateTime?: string | null;
    modifiedDateTime?: string | null;
    createdByPersonAliasId?: number | null;
    modifiedByPersonAliasId?: number | null;
};
