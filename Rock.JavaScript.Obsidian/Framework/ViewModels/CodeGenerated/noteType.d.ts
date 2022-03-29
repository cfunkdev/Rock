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

export type NoteType = IEntity & {
    allowsAttachments?: boolean;
    allowsReplies?: boolean;
    allowsWatching?: boolean;
    approvalUrlTemplate?: string | null;
    attributeValues?: Record<string, unknown>;
    autoWatchAuthors?: boolean;
    backgroundColor?: string | null;
    binaryFileTypeId?: number | null;
    borderColor?: string | null;
    entityTypeId?: number;
    entityTypeQualifierColumn?: string | null;
    entityTypeQualifierValue?: string | null;
    fontColor?: string | null;
    iconCssClass?: string | null;
    isSystem?: boolean;
    maxReplyDepth?: number | null;
    name?: string | null;
    order?: number;
    requiresApprovals?: boolean;
    sendApprovalNotifications?: boolean;
    userSelectable?: boolean;
    createdDateTime?: string | null;
    modifiedDateTime?: string | null;
    createdByPersonAliasId?: number | null;
    modifiedByPersonAliasId?: number | null;
};
