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

import { computed, defineComponent, nextTick } from "vue";
import Alert from "@Obsidian/Controls/alert";
import EntityTagList from "@Obsidian/Controls/entityTagList";
import { EntityType } from "@Obsidian/SystemGuids";
import { BadgesConfigurationBox } from "@Obsidian/ViewModels/Blocks/CRM/PersonDetail/Badges/badgesConfigurationBox";
import { useConfigurationValues } from "@Obsidian/Utility/block";
import { ControlLazyMode } from "@Obsidian/Types/Controls/controlLazyMode";

export default defineComponent({
    name: "CRM.PersonDetail.Badges",

    components: {
        Alert,
        EntityTagList
    },

    setup() {
        const config = useConfigurationValues<BadgesConfigurationBox>();

        // #region Values

        // #endregion

        // #region Computed Values

        const topLeftBadges = computed((): string => {
            return config.topLeftBadges?.map(b => b.html ?? "").join("") ?? "";
        });

        const topMiddleBadges = computed((): string => {
            return config.topMiddleBadges?.map(b => b.html ?? "").join("") ?? "";
        });

        const topRightBadges = computed((): string => {
            return config.topRightBadges?.map(b => b.html ?? "").join("") ?? "";
        });

        const bottomLeftBadges = computed((): string => {
            return config.bottomLeftBadges?.map(b => b.html ?? "").join("") ?? "";
        });

        const bottomRightBadges = computed((): string => {
            return config.bottomRightBadges?.map(b => b.html ?? "").join("") ?? "";
        });

        // #endregion

        // #region Functions

        // #endregion

        // #region Event Handlers

        // #endregion

        const script = [...config.topLeftBadges ?? [],
            ...config.topMiddleBadges ?? [],
            ...config.topRightBadges ?? [],
            ...config.bottomLeftBadges ?? [],
            ...config.bottomRightBadges ?? []]
            .map(b => b.javaScript ?? "").join("");

        if (script !== "") {
            // Add the script on the next tick to ensure the HTML has been rendered.
            nextTick(() => {
                const scriptNode = document.createElement("script");
                scriptNode.type = "text/javascript";
                scriptNode.innerText = script;
                document.body.appendChild(scriptNode);
            });
        }

        return {
            bottomLeftBadges,
            bottomRightBadges,
            entityKey: config.personKey,
            entityTypeGuid: EntityType.Person,
            lazyMode: ControlLazyMode.Eager,
            topLeftBadges,
            topMiddleBadges,
            topRightBadges
        };
    },

    template: `
<div class="card card-badges">           
    <div class="card-badge-top">
        <div class="rockbadge-container" v-html="topLeftBadges"></div>

        <div class="rockbadge-container" v-html="topMiddleBadges"></div>

        <div class="rockbadge-container" v-html="topRightBadges"></div>
    </div>

    <div class="card-badge-bottom">
        <div class="rockbadge-container" v-html="bottomLeftBadges"></div>

        <div class="rockbadge-container">
            <EntityTagList :entityTypeGuid="entityTypeGuid"
                :entityKey="entityKey"
                :lazyMode="lazyMode" />
         </div> 

        <div class="rockbadge-container" v-html="bottomRightBadges"></div> 
   </div>
</div>
`
});
