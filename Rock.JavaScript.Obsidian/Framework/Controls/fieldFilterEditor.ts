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

import { defineComponent, PropType, ref, TransitionGroup, watch } from "vue";
import DropDownList from "./dropDownList";
import { FilterExpressionType } from "@Obsidian/Core/Reporting/filterExpressionType";
import { areEqual, newGuid } from "@Obsidian/Utility/guid";
import { updateRefValue } from "@Obsidian/Utility/component";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { FieldFilterGroupBag } from "@Obsidian/ViewModels/Reporting/fieldFilterGroupBag";
import { FieldFilterRuleBag } from "@Obsidian/ViewModels/Reporting/fieldFilterRuleBag";
import { FieldFilterSourceBag } from "@Obsidian/ViewModels/Reporting/fieldFilterSourceBag";
import { FieldFilterRuleRow } from "./fieldFilterRuleRow";

type ShowHide = "Show" | "Hide";
type AllAny = "All" | "Any";

// Maps for converting between `FilterExpressionType` and `ShowHide`/`AllAny`
const filterExpressionTypeMap: Record<ShowHide, Record<AllAny, FilterExpressionType>> = {
    Show: {
        All: FilterExpressionType.GroupAll,
        Any: FilterExpressionType.GroupAny
    },
    Hide: {
        All: FilterExpressionType.GroupAllFalse,
        Any: FilterExpressionType.GroupAnyFalse
    }
};

const filterExpressionToShowHideMap: ShowHide[] = ["Show", "Show", "Hide", "Hide"]; // Use FilterExpressionType - 1 as index
const filterExpressionToAllAnyMap: AllAny[] = ["All", "Any", "All", "Any"]; // Use FilterExpressionType - 1 as index

const showHideOptions: ListItemBag[] = [
    { text: "Show", value: "Show" },
    { text: "Hide", value: "Hide" }
];

const allAnyOptions: ListItemBag[] = [
    { text: "All", value: "All" },
    { text: "Any", value: "Any" }
];

export default defineComponent({
    name: "FieldVisibilityRulesEditor",

    components: {
        TransitionGroup,
        DropDownList,
        FieldFilterRuleRow
    },

    props: {
        modelValue: {
            type: Object as PropType<FieldFilterGroupBag>,
            required: true
        },
        sources: {
            type: Array as PropType<FieldFilterSourceBag[]>,
            required: true
        },
        title: {
            type: String as PropType<string>,
            default: ""
        },
        allowNestedGroups: {
            type: Boolean as PropType<boolean>,
            default: false
        }
    },

    emits: ["update:modelValue"],

    setup(props, { emit }) {
        const showHide = ref(filterExpressionToShowHideMap[props.modelValue.expressionType - 1]);
        const allAny = ref(filterExpressionToAllAnyMap[props.modelValue.expressionType - 1]);
        const rules = ref(props.modelValue.rules ?? []);

        // We currently don't support nested groups, so fire a warning if anyone tries to use them
        watch(() => props.allowNestedGroups, () => {
            if (props.allowNestedGroups === true) {
                console.warn("Nested Filter Groups are not supported yet. Please set `allowNestedGroups` to `false`.");
            }
        });

        /**
         * Event handler for when the add rule button is clicked. Insert a new
         * rule with default values into the list of rules.
         */
        function onAddRuleClick(): void {
            rules.value = [
                ...rules.value,
                {
                    guid: newGuid(),
                    comparisonType: 0,
                    value: "",
                    sourceType: 0,
                    attributeGuid: props.sources[0].attribute?.attributeGuid
                }
            ];
        }

        /**
         * Event handler for when a single rule has been updated. Replace the
         * rule in our array with the new rule.
         *
         * @param rule The new rule information.
         */
        const onUpdateRule = (rule: FieldFilterRuleBag): void => {
            const newRules = [...rules.value];
            const ruleIndex = newRules.findIndex(r => areEqual(r.guid, rule.guid));

            if (ruleIndex !== -1) {
                newRules.splice(ruleIndex, 1, rule);

                rules.value = newRules;
            }
        };

        /**
         * Event handler for when a rule has requested that it be removed from
         * the list of rules.
         *
         * @param rule The rule to be removed.
         */
        function onRemoveRule(rule: FieldFilterRuleBag): void {
            rules.value = (rules.value || []).filter((val: FieldFilterRuleBag) => !areEqual(val.guid, rule.guid));
        }

        // Watch for changes to the model value and update our internal values.
        watch(() => props.modelValue, () => {
            showHide.value = filterExpressionToShowHideMap[props.modelValue.expressionType - 1];
            allAny.value = filterExpressionToAllAnyMap[props.modelValue.expressionType - 1];
            updateRefValue(rules, props.modelValue.rules ?? []);
        });

        // Watch for changes to our internal values and update the model value.
        watch([showHide, allAny, rules], () => {
            const newValue: FieldFilterGroupBag = {
                ...props.modelValue,
                expressionType: filterExpressionTypeMap[showHide.value][allAny.value],
                rules: rules.value
            };

            emit("update:modelValue", newValue);
        });

        return {
            allAny,
            allAnyOptions,
            onAddRuleClick,
            onRemoveRule,
            onUpdateRule,
            rules,
            showHide,
            showHideOptions
        };
    },

    template: `
<div class="filtervisibilityrules-container">
    <div class="filtervisibilityrules-rulesheader">
        <div class="filtervisibilityrules-type form-inline form-inline-all">
            <DropDownList v-model="showHide" :items="showHideOptions" :show-blank-item="false" formControlClasses="input-width-sm margin-r-sm" />
            <div class="form-control-static margin-r-sm">
                <span class="filtervisibilityrules-fieldname">{{ title }}</span><span class="filtervisibilityrules-if"> if</span>
            </div>
            <DropDownList v-model="allAny" :items="allAnyOptions" :show-blank-item="false" formControlClasses="input-width-sm margin-r-sm" />
            <span class="form-control-static">of the following match:</span>
        </div>
    </div>

    <div class="filtervisibilityrules-ruleslist ">
        <FieldFilterRuleRow v-for="rule in rules" :key="rule.guid" :modelValue="rule" :sources="sources" @update:modelValue="onUpdateRule" @removeRule="onRemoveRule" />
    </div>

    <div class="filter-actions">
        <button class="btn btn-xs btn-action add-action" @click.prevent="onAddRuleClick"><i class="fa fa-filter"></i> Add Criteria</button>
    </div>
</div>
`
});
