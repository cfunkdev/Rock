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

export type MediaElement = IEntity & {
    attributeValues?: Record<string, unknown>;
    description?: string | null;
    durationSeconds?: number | null;
    fileDataJson?: string | null;
    mediaFolderId?: number;
    metricData?: string | null;
    name?: string | null;
    sourceCreatedDateTime?: string | null;
    sourceData?: string | null;
    sourceKey?: string | null;
    sourceModifiedDateTime?: string | null;
    thumbnailDataJson?: string | null;
    createdDateTime?: string | null;
    modifiedDateTime?: string | null;
    createdByPersonAliasId?: number | null;
    modifiedByPersonAliasId?: number | null;
};
