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

import { WebFarmMetricBag } from "@Obsidian/ViewModels/Blocks/WebFarm/WebFarmNodeDetail/webFarmMetricBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type WebFarmNodeBag = {
    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the current leadership polling interval seconds. */
    currentLeadershipPollingIntervalSeconds: number;

    /** Gets or sets the human readable last seen. */
    humanReadableLastSeen?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets a flag indicating if this item is active or not. */
    isActive: boolean;

    /** Gets or sets a value indicating whether this instance is current job runner. */
    isCurrentJobRunner: boolean;

    /** Gets or sets a value indicating whether this instance is leader. */
    isLeader: boolean;

    /** Gets or sets a value indicating whether this instance is unresponsive. */
    isUnresponsive: boolean;

    /** Gets or sets the last seen date time. */
    lastSeenDateTime?: string | null;

    /** Gets or sets a Node Name. */
    nodeName?: string | null;

    /** Gets or sets the web farm node metrics. */
    webFarmNodeMetrics?: WebFarmMetricBag[] | null;
};
