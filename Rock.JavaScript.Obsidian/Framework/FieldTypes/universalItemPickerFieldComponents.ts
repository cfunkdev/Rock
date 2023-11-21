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
import { getFieldConfigurationProps, getFieldEditorProps } from "./utils";
import CheckBoxList from "@Obsidian/Controls/checkBoxList.obs";
import BaseAsyncPicker from "@Obsidian/Controls/baseAsyncPicker.obs";
import DropDownList from "@Obsidian/Controls/dropDownList.obs";
import NumberBox from "@Obsidian/Controls/numberBox.obs";
import RadioButtonList from "@Obsidian/Controls/radioButtonList.obs";
import TextBox from "@Obsidian/Controls/textBox.obs";
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

const controlTypeOptions: ListItemBag[] = [
    {
        value: "ddl",
        text: "Drop Down List"
    },
    {
        value: "ddl_enhanced",
        text: "Drop Down List (Enhanced for Long Lists)"
    },
    {
        value: "rb",
        text: "Radio Buttons"
    }
];

// export const ConfigurationComponent = defineComponent({
//     name: "UniversalItemPickerField.Configuration",

//     components: {
//         DropDownList,
//         TextBox,
//         NumberBox
//     },

//     props: getFieldConfigurationProps(),

//     emits: [
//         "update:modelValue",
//         "updateConfiguration",
//         "updateConfigurationValue"
//     ],

//     setup(props, { emit }) {
//         // Define the properties that will hold the current selections.
//         const rawValues = ref("");
//         const internalRawValues = ref("");
//         const controlType = ref("");
//         const repeatColumns = ref<number | null>(null);

//         const isRadioList = computed((): boolean => {
//             return controlType.value === "rb";
//         });

//         const onBlur = (): void => {
//             internalRawValues.value = rawValues.value;
//         };

//         /**
//          * Update the modelValue property if any value of the dictionary has
//          * actually changed. This helps prevent unwanted postbacks if the value
//          * didn't really change - which can happen if multiple values get updated
//          * at the same time.
//          *
//          * @returns true if a new modelValue was emitted to the parent component.
//          */
//         const maybeUpdateModelValue = (): boolean => {
//             const newValue: Record<string, string> = { ...props.modelValue };

//             // Construct the new value that will be emitted if it is different
//             // than the current value.
//             newValue[ConfigurationValueKey.CustomValues] = internalRawValues.value ?? "";
//             newValue[ConfigurationValueKey.FieldType] = controlType.value ?? "";
//             newValue[ConfigurationValueKey.RepeatColumns] = repeatColumns.value?.toString() ?? "";

//             // Compare the new value and the old value.
//             const anyValueChanged = newValue[ConfigurationValueKey.CustomValues] !== (props.modelValue[ConfigurationValueKey.CustomValues] ?? "")
//                 || newValue[ConfigurationValueKey.FieldType] !== (props.modelValue[ConfigurationValueKey.FieldType] ?? "")
//                 || newValue[ConfigurationValueKey.RepeatColumns] !== (props.modelValue[ConfigurationValueKey.RepeatColumns] ?? "");

//             // If any value changed then emit the new model value.
//             if (anyValueChanged) {
//                 emit("update:modelValue", newValue);
//                 return true;
//             }
//             else {
//                 return false;
//             }
//         };

//         /**
//          * Emits the updateConfigurationValue if the value has actually changed.
//          *
//          * @param key The key that was possibly modified.
//          * @param value The new value.
//          */
//         const maybeUpdateConfiguration = (key: string, value: string): void => {
//             if (maybeUpdateModelValue()) {
//                 emit("updateConfigurationValue", key, value);
//             }
//         };

//         // Watch for changes coming in from the parent component and update our
//         // data to match the new information.
//         watch(() => [props.modelValue, props.configurationProperties], () => {
//             rawValues.value = props.modelValue[ConfigurationValueKey.CustomValues] ?? "";
//             internalRawValues.value = rawValues.value;
//             controlType.value = props.modelValue[ConfigurationValueKey.FieldType] ?? "ddl";
//             repeatColumns.value = toNumberOrNull(props.modelValue[ConfigurationValueKey.RepeatColumns]);
//         }, {
//             immediate: true
//         });

//         // Watch for changes in properties that require new configuration
//         // properties to be retrieved from the server.
//         watch([internalRawValues], () => {
//             if (maybeUpdateModelValue()) {
//                 emit("updateConfiguration");
//             }
//         });

//         // Watch for changes in properties that only require a local UI update.
//         watch(controlType, () => maybeUpdateConfiguration(ConfigurationValueKey.FieldType, controlType.value ?? "ddl"));
//         watch(repeatColumns, () => maybeUpdateConfiguration(ConfigurationValueKey.RepeatColumns, repeatColumns.value?.toString() ?? ""));

//         return {
//             controlType,
//             controlTypeOptions,
//             isRadioList,
//             onBlur,
//             rawValues,
//             repeatColumns
//         };
//     },

//     template: `
// <div>
//     <TextBox v-model="rawValues"
//         label="Values"
//         help="The source of the values to display in a list.  Format is either 'value1,value2,value3,...', 'value1^text1,value2^text2,value3^text3,...', or a SQL Select statement that returns a result set with a 'Value' and 'Text' column <span class='tip tip-lava'></span>."
//         textMode="multiline"
//         @blur="onBlur" />

//     <DropDownList v-model="controlType"
//         label="Control Type"
//         help="The type of control to use for selecting a single value from the list."
//         :items="controlTypeOptions"
//         :showBlankItem="false" />

//     <NumberBox v-if="isRadioList"
//         v-model="repeatColumns"
//         label="Columns"
//         help="Select how many columns the list should use before going to the next row. If blank or 0 then 4 columns will be displayed. There is no enforced upper limit however the block this control is used in might add contraints due to available space." />
// </div>
// `
// });
