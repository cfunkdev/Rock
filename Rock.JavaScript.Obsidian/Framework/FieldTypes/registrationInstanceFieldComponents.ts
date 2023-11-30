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

import { computed, defineComponent, ref, watch } from "vue";
import { getFieldConfigurationProps, getFieldEditorProps } from "./utils";
import RegistrationInstancePicker from "@Obsidian/Controls/registrationInstancePicker.obs";
import RegistrationTemplatePicker from "@Obsidian/Controls/registrationTemplatePicker.obs";
import { ConfigurationValueKey } from "./registrationInstanceField.partial";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

export const EditComponent = defineComponent({
    name: "RegistrationInstanceField.Edit",

    components: {
        RegistrationInstancePicker,
    },

    props: getFieldEditorProps(),

    setup(props, { emit }) {
        // The internal value used by the text editor.
        const internalValue = ref<ListItemBag>({});

        // Get the selected registration template guid.
        const registrationTemplateGuid = computed((): string | null | undefined => {
            const registrationTemplate = JSON.parse(props.configurationValues[ConfigurationValueKey.RegistrationTemplate] || "{}") as ListItemBag;
            return registrationTemplate?.value;
        });

        // Watch for changes from the parent component and update the text editor.
        watch(() => props.modelValue, () => {
            internalValue.value = JSON.parse(props.modelValue || "{}");
        }, {
            immediate: true
        });

        // Watch for changes from the text editor and update the parent component.
        watch(internalValue, () => {
            emit("update:modelValue", JSON.stringify(internalValue.value));
        });

        return {
            internalValue,
            registrationTemplateGuid
        };
    },

    template: `
    <RegistrationInstancePicker v-model="internalValue" :registrationTemplateGuid="registrationTemplateGuid" />
`
});

export const ConfigurationComponent = defineComponent({
    name: "RegistrationInstanceField.Configuration",

    components: {
        RegistrationTemplatePicker
    },

    props: getFieldConfigurationProps(),

    emits: ["update:modelValue", "updateConfiguration", "updateConfigurationValue"],

    setup(props, { emit }) {
        // Define the properties that will hold the current selections.
        const registrationTemplate = ref<ListItemBag>({});

        /**
         * Update the modelValue property if any value of the dictionary has
         * actually changed. This helps prevent unwanted postbacks if the value
         * didn't really change - which can happen if multiple values get updated
         * at the same time.
         *
         * @returns true if a new modelValue was emitted to the parent component.
         */
        const maybeUpdateModelValue = (): boolean => {
            const newValue: Record<string, string> = {};

            // Construct the new value that will be emitted if it is different
            // than the current value.
            newValue[ConfigurationValueKey.RegistrationTemplate] = JSON.stringify(registrationTemplate.value) ?? "";

            // Compare the new value and the old value.
            const anyValueChanged = newValue[ConfigurationValueKey.RegistrationTemplate] !== props.modelValue[ConfigurationValueKey.RegistrationTemplate];

            // If any value changed then emit the new model value.
            if (anyValueChanged) {
                emit("update:modelValue", newValue);
                return true;
            }
            else {
                return false;
            }
        };

        /**
         * Emits the updateConfigurationValue if the value has actually changed.
         *
         * @param key The key that was possibly modified.
         * @param value The new value.
         */
        const maybeUpdateConfiguration = (key: string, value: string): void => {
            if (maybeUpdateModelValue()) {
                emit("updateConfigurationValue", key, value);
            }
        };

        // Watch for changes coming in from the parent component and update our
        // data to match the new information.
        watch(() => [props.modelValue, props.configurationProperties], () => {
            registrationTemplate.value  = JSON.parse(props.modelValue[ConfigurationValueKey.RegistrationTemplate] || "{}") as ListItemBag;
        }, {
            immediate: true
        });

        // Watch for changes in properties that only require a local UI update.
        watch(registrationTemplate, () => maybeUpdateConfiguration(ConfigurationValueKey.RegistrationTemplate, JSON.stringify(registrationTemplate.value)));

        return {
            registrationTemplate,
        };
    },

    template: `
    <RegistrationTemplatePicker label="Registration Template" v-model="registrationTemplate" />
`
});
