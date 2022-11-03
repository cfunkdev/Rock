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

/** InteractionComponent View Model */
export type InteractionComponentBag = {
    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the channel custom 1. */
    channelCustom1?: string | null;

    /** Gets or sets the channel custom 2. */
    channelCustom2?: string | null;

    /** Gets or sets the channel custom indexed 1. */
    channelCustomIndexed1?: string | null;

    /** Gets or sets the interaction component data. */
    componentData?: string | null;

    /** Gets or sets the component summary. */
    componentSummary?: string | null;

    /** Gets or sets the created by person alias identifier. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the created date time. */
    createdDateTime?: string | null;

    /**
     * Gets or sets the Id of the entity that this interaction component is related to (determined by Rock.Model.InteractionChannel.ComponentEntityTypeId )
     * 
     * 
     *     <term>Page Views</term>
     *     <description><see cref="T:Rock.Model.Page" /> Id</description>
     * 
     *     <term>Communication Recipient Activity</term>
     *     <description><see cref="T:Rock.Model.Communication" /> Id</description>
     * 
     *     <term>Content Channel Activity</term>
     *     <description><see cref="T:Rock.Model.ContentChannel" /> Id</description>
     * 
     *     <term>System Events, like Workflow Form Entry</term>
     *     <description>Depends on <see cref="T:Rock.Model.ContentChannelType"></see></description>
     */
    entityId?: number | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the Id of the Rock.Model.InteractionChannel channel that is associated with this Component. */
    interactionChannelId: number;

    /** Gets or sets the modified by person alias identifier. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the modified date time. */
    modifiedDateTime?: string | null;

    /** Gets or sets the interaction component name. */
    name?: string | null;
};
