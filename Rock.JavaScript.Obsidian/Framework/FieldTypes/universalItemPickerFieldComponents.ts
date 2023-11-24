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
import { computed, defineComponent, inject, ref, watch } from "vue";
import { getFieldEditorProps } from "./utils";
import CheckBoxList from "@Obsidian/Controls/checkBoxList.obs";
import BaseAsyncPicker from "@Obsidian/Controls/baseAsyncPicker.obs";
import { toNumberOrNull } from "@Obsidian/Utility/numberUtils";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { updateRefValue } from "@Obsidian/Utility/component";
import { asBoolean } from "@Obsidian/Utility/booleanUtils";
import { PickerDisplayStyle } from "@Obsidian/Enums/Controls/pickerDisplayStyle";

export const EditComponent = defineComponent({
    name: "UniversalItemPickerField.Edit",

    components: {
        BaseAsyncPicker
    },

    props: getFieldEditorProps(),

    setup(props, { emit }) {
        const internalValue = ref(getModelValue());
        const isRequired = inject<boolean>("isRequired") ?? false;

        /** The options to choose from in the drop down list */
        const items = computed((): ListItemBag[] => {
            try {
                const providedOptions = JSON.parse(props.configurationValues["items"] ?? "[]") as ListItemBag[];

                if (isRadioButtons && !isRequired) {
                    providedOptions.unshift({
                        text: "None",
                        value: ""
                    });
                }

                return providedOptions;
            }
            catch {
                return [];
            }
        });

        const displayStyle = computed((): PickerDisplayStyle => {
            const mode = toNumberOrNull(props.configurationValues["displayStyle"]) ?? 0;

            if (mode === 1) {
                return PickerDisplayStyle.List;
            }
            else if (mode === 2) {
                return PickerDisplayStyle.Condensed;
            }
            else {
                return PickerDisplayStyle.Auto;
            }
        });

        const enhanceForLongLists = computed((): boolean => {
            return asBoolean(props.configurationValues["enhanceForLongLists"]);
        });

        const columnCount = computed((): number => {
            return toNumberOrNull(props.configurationValues["columnCount"]) ?? 0;
        });

        const isRadioButtons = computed((): boolean => {
            return !asBoolean(props.configurationValues["multiple"]);
        });

        function getModelValue(): ListItemBag | ListItemBag[] | null {
            try {
                return JSON.parse(props.modelValue) as ListItemBag | ListItemBag[];
            }
            catch {
                return null;
            }
        }

        watch(internalValue, () => {
            emit("update:modelValue", JSON.stringify(internalValue.value));
        });

        watch(() => props.modelValue, () => {
            updateRefValue(internalValue, getModelValue());
        });

        return {
            columnCount,
            displayStyle,
            enhanceForLongLists,
            internalValue,
            isRequired,
            items,
        };
    },

    template: `
<BaseAsyncPicker v-model="internalValue"
                 :items="items"
                 :isRequired="isRequired"
                 :enhanceForLongLists="enhanceForLongLists"
                 :columnCount="columnCount"
                 :displayStyle="displayStyle"
                 showBlankItem />
`
});

export const FilterComponent = defineComponent({
    name: "UniversalItemPickerField.Filter",

    components: {
        CheckBoxList
    },

    props: getFieldEditorProps(),

    setup(props, { emit }) {
        const internalValue = ref(props.modelValue.split(",").filter(v => v !== ""));

        const options = computed((): ListItemBag[] => {
            try {
                const providedOptions = JSON.parse(props.configurationValues["items"] ?? "[]") as ListItemBag[];

                return providedOptions;
            }
            catch {
                return [];
            }
        });

        watch(() => props.modelValue, () => {
            updateRefValue(internalValue, props.modelValue.split(",").filter(v => v !== ""));
        });

        watch(internalValue, () => {
            emit("update:modelValue", internalValue.value.join(","));
        });

        return {
            internalValue,
            options
        };
    },

    template: `
<CheckBoxList v-model="internalValue" :items="options" horizontal />
`
});
