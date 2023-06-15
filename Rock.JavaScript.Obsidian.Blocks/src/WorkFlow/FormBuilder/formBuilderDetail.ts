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

import { nextTick } from "vue";
import { computed, defineComponent, ref, watch } from "vue";
import NotificationBox from "@Obsidian/Controls/notificationBox.obs";
import Panel from "@Obsidian/Controls/panel.obs";
import RockButton from "@Obsidian/Controls/rockButton";
import { FieldType } from "@Obsidian/SystemGuids/fieldType";
import { useConfigurationValues, useInvokeBlockAction } from "@Obsidian/Utility/block";
import { FormError } from "@Obsidian/Utility/form";
import { areEqual } from "@Obsidian/Utility/guid";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import CommunicationsTab from "./FormBuilderDetail/communicationsTab.partial";
import FormBuilderTab from "./FormBuilderDetail/formBuilderTab.partial";
import SettingsTab from "./FormBuilderDetail/settingsTab.partial";
import { FormBuilderDetailConfiguration, FormBuilderSettings, FormCommunication, FormTemplateListItem } from "./FormBuilderDetail/types.partial";
import { provideFormSources } from "./FormBuilderDetail/utils.partial";
import { FormCompletionAction, FormGeneral } from "./Shared/types.partial";

export default defineComponent({
    name: "WorkFlow.FormBuilderDetail",

    components: {
        NotificationBox,
        CommunicationsTab,
        FormBuilderTab,
        Panel,
        RockButton,
        SettingsTab
    },

    setup() {
        const config = useConfigurationValues<FormBuilderDetailConfiguration>();

        const invokeBlockAction = useInvokeBlockAction();

        const form = config.form ?? {};

        const isFormDirty = ref(false);

        const selectedTab = ref(0);

        const recipientOptions = ref<ListItemBag[]>([]);

        const communicationsViewModel = ref<FormCommunication>({
            confirmationEmail: form.confirmationEmail ?? {},
            notificationEmail: form.notificationEmail ?? {}
        });

        const generalViewModel = ref<FormGeneral>(form.general ?? {});

        const blockTitle = computed((): string => {
            return generalViewModel.value?.name + " Form" ?? "Workflow Form Builder";
        });

        const completionViewModel = ref<FormCompletionAction>(form.completion ?? {});

        const builderViewModel = ref<FormBuilderSettings>({
            allowPersonEntry: form.allowPersonEntry,
            campusSetFrom: form.campusSetFrom,
            footerContent: form.footerContent,
            headerContent: form.headerContent,
            personEntry: form.personEntry,
            sections: form.sections
        });

        const blockError = ref("");

        const formSubmit = ref(false);
        const communicationsValidationErrors = ref<FormError[]>([]);
        const formBuilderValidationErrors = ref<FormError[]>([]);
        const settingsValidationErrors = ref<FormError[]>([]);

        const isFormBuilderTabSelected = computed((): boolean => selectedTab.value === 0);
        const isCommunicationsTabSelected = computed((): boolean => selectedTab.value === 1);
        const isSettingsTabSelected = computed((): boolean => selectedTab.value === 2);

        const formBuilderContainerStyle = computed((): Record<string, string> => {
            return {
                display: isFormBuilderTabSelected.value ? "flex" : "none"
            };
        });

        const communicationsContainerStyle = computed((): Record<string, string> => {
            return {
                display: isCommunicationsTabSelected.value ? "flex" : "none"
            };
        });

        const settingsContainerStyle = computed((): Record<string, string> => {
            return {
                display: isSettingsTabSelected.value ? "flex" : "none"
            };
        });

        const selectedTemplate = computed((): FormTemplateListItem | null => {
            const matches = config.sources?.formTemplateOptions?.filter(t => areEqual(t.value, form.general?.template));

            return matches && matches.length > 0 ? matches[0] : null;
        });

        const onFormBuilderTabClick = (): void => {
            selectedTab.value = 0;
        };

        const onCommunicationsTabClick = (): void => {
            selectedTab.value = 1;
        };

        const onSettingsTabClick = (): void => {
            selectedTab.value = 2;
        };

        const onSaveClick = async (): Promise<void> => {
            // Trigger the submit for validation purposes and then on the next
            // UI pass turn it back off.
            formSubmit.value = true;
            nextTick(() => formSubmit.value = false);

            if (formBuilderValidationErrors.value.length > 0) {
                onFormBuilderTabClick();
                return;
            }

            if (communicationsValidationErrors.value.length > 0) {
                onCommunicationsTabClick();
                return;
            }

            if (settingsValidationErrors.value.length > 0) {
                onSettingsTabClick();
                return;
            }

            const result = await invokeBlockAction("SaveForm", {
                formGuid: config.formGuid,
                formSettings: form
            });

            if (!result.isSuccess) {
                alert(result.errorMessage ?? "Failed to save.");
            }
            else {
                isFormDirty.value = false;
            }
        };

        /**
         * Updates the recipientOptions value with a new list of recipients.
         * This should be called any time an attribute is changed so that
         * the list can be updated in case that attribute is now one of the
         * possible types.
         */
        const updateRecipientOptions = (): void => {
            const options: ListItemBag[] = [];

            // Include attributes from the main workflow.
            if (config.otherAttributes) {
                for (const attribute of config.otherAttributes) {
                    if (!attribute.guid || !attribute.fieldTypeGuid || !attribute.name) {
                        continue;
                    }

                    if (areEqual(attribute.fieldTypeGuid, FieldType.Person) || areEqual(attribute.fieldTypeGuid, FieldType.Email)) {
                        options.push({
                            value: attribute.guid,
                            text: attribute.name
                        });
                    }
                }
            }

            // If we have any sections defined, then include attributes from
            // the sections that match our criteria.
            if (form.sections) {
                for (const section of form.sections) {
                    if (!section.fields) {
                        continue;
                    }

                    for (const field of section.fields) {
                        if (areEqual(field.fieldTypeGuid, FieldType.Person) || areEqual(field.fieldTypeGuid, FieldType.Email)) {
                            options.push({
                                value: field.guid,
                                text: field.name
                            });
                        }
                    }
                }
            }

            // Sort everything to be alphabetical.
            options.sort((a, b) => {
                if ((a.text ?? "") < (b.text ?? "")) {
                    return -1;
                }
                else if ((a.text ?? "") > (b.text ?? "")) {
                    return 1;
                }
                else {
                    return 0;
                }
            });

            recipientOptions.value = options;
        };

        /**
         * Event handler called before the page unloads. This handler is
         * added whenever the form is dirty and needs to be saved.
         *
         * @param event The event that was raised.
         */
        const onBeforeUnload = (event: BeforeUnloadEvent): void => {
            event.preventDefault();
            event.returnValue = "";
        };

        /**
         * Event handler for when the validation state of the communications tab has changed.
         *
         * @param errors Any errors that were detected on the form.
         */
        const onCommunicationsValidationChanged = (errors: FormError[]): void => {
            communicationsValidationErrors.value = errors;
        };

        /**
         * Event handler for when the validation state of the form builder tab has changed.
         *
         * @param errors Any errors that were detected on the form.
         */
        const onFormBuilderValidationChanged = (errors: FormError[]): void => {
            formBuilderValidationErrors.value = errors;
        };

        /**
         * Event handler for when the validation state of the settings tab has changed.
         *
         * @param errors Any errors that were detected on the form.
         */
        const onSettingsValidationChanged = (errors: FormError[]): void => {
            settingsValidationErrors.value = errors;
        };

        // Watch for changes to our internal values and update the modelValue.
        watch([builderViewModel, communicationsViewModel, generalViewModel, completionViewModel], () => {
            form.allowPersonEntry = builderViewModel.value.allowPersonEntry;
            form.campusSetFrom = builderViewModel.value.campusSetFrom;
            form.footerContent = builderViewModel.value.footerContent;
            form.headerContent = builderViewModel.value.headerContent;
            form.personEntry = builderViewModel.value.personEntry;
            form.sections = builderViewModel.value.sections;

            form.general = generalViewModel.value;
            form.completion = completionViewModel.value;

            form.confirmationEmail = communicationsViewModel.value.confirmationEmail;
            form.notificationEmail = communicationsViewModel.value.notificationEmail;

            updateRecipientOptions();
            isFormDirty.value = true;
        });

        // Watch for changes in the form dirty state and remove/install our
        // handle to prevent accidentally navigating away from the page.
        watch(isFormDirty, () => {
            window.removeEventListener("beforeunload", onBeforeUnload);

            if (isFormDirty.value) {
                window.addEventListener("beforeunload", onBeforeUnload);
            }
        });

        provideFormSources(config.sources ?? {});
        updateRecipientOptions();

        if (!config.formGuid || !config.form) {
            blockError.value = "That form does not exist or it can't be edited.";
        }

        // Set initially selected tab.
        const queryString = new URLSearchParams(window.location.search.toLowerCase());
        if (queryString.has("tab")) {
            const tab = queryString.get("tab");

            if (tab === "communications") {
                selectedTab.value = 1;
            }
            else if (tab === "settings") {
                selectedTab.value = 2;
            }
        }

        return {
            analyticsPageUrl: config.analyticsPageUrl,
            blockError,
            builderViewModel,
            communicationsContainerStyle,
            communicationsValidationErrors,
            communicationsViewModel,
            completionViewModel,
            formBuilderContainerStyle,
            formSubmit,
            isCommunicationsTabSelected,
            isFormBuilderTabSelected,
            isFormDirty,
            isSettingsTabSelected,
            settingsContainerStyle,
            generalViewModel,
            blockTitle,
            submissionsPageUrl: config.submissionsPageUrl,
            onCommunicationsTabClick,
            onCommunicationsValidationChanged,
            onFormBuilderTabClick,
            onFormBuilderValidationChanged,
            onSaveClick,
            onSettingsTabClick,
            onSettingsValidationChanged,
            recipientOptions,
            selectedTemplate
        };
    },

    template: `
<v-style>
    .inline-svg {
        display: inline-flex;
        width: 1.25em;
        height: 1em;
        line-height: 1;
        fill: currentColor;
    }

    .form-builder-detail {
        --zone-border: #ebebeb;
        --zone-configurable-border: #f5faff;
        --zone-configurable-hover-border: #dfe0e1;
        --zone-action-bg: #f5faff;
        --zone-action-border: #dde7f2;
        --zone-action-color: #89a1b9;
        --zone-action-hover-color: #737475;
        --zone-active-color: #c9eaf9;
        --zone-active-action-color: #83bad3;
        --zone-highlight-color: #ee7725;
        --zone-highlight-action-text-color: #e4bda2;
        --flex-col-gutter: 30px;
        --zone-border-radius: 6px;
    }

    .form-builder-detail .zone-body .configurable-zone > .zone-content-container > .zone-content {
        pointer-events: none;
    }

    .form-builder-detail .zone-body > div > .form-group {
        margin-bottom: 0;
    }

    .form-builder-detail .configurable-zone {
        position: relative;
        display: flex;
        margin-bottom: 12px;
        transition: border-color 108ms cubic-bezier(.2, .2, .38, .9);
    }

    .form-builder-detail .configurable-zone.zone-section {
        flex-grow: 1;
    }

    .form-builder-detail .configurable-zone.zone-section > .zone-actions {
        position: relative;
    }

    .form-builder-detail .configurable-zone > .zone-content-container {
        display: flex;
        flex-grow: 1;
        background: #fff;
        border: 2px dotted var(--zone-border);
        border-right: 2px solid var(--zone-action-border);
        border-radius: var(--zone-border-radius) 0 0 var(--zone-border-radius);
    }

    .form-builder-detail .configurable-zone > .zone-content-container > .zone-content {
        flex-grow: 1;
    }

    .form-builder-detail .configurable-zone > .zone-content-container > .zone-content > .zone-body {
        display: flex;
        flex-direction: column;
        min-height: 100%;
        padding: 20px;
    }

    .form-builder-detail .configurable-zone > .zone-actions {
        display: flex;
        flex-direction: column;
        flex-shrink: 0;
        align-items: center;
        justify-content: center;
        width: 40px;
        background-color: var(--zone-action-bg);
        border: 2px solid var(--zone-action-border);
        border-left: 0;
    }

    .form-builder-detail .configurable-zone.active > .zone-content-container {
        border-color: var(--zone-active-color);
    }

    .form-builder-detail .configurable-zone.active > .zone-actions {
        background-color: var(--zone-active-color);
        border-color: var(--zone-active-color);
    }

    .form-builder-detail .configurable-zone.highlight > .zone-content-container {
        border-color: var(--zone-highlight-color);
        border-right-style: dotted;
    }

    .form-builder-detail .form-section {
        display: flex;
        flex: 1 1 auto;
        flex-wrap: wrap;
        align-content: flex-start;
        min-height: 50px;
        margin: 0 calc(-.5 * var(--flex-col-gutter)) -10px;
    }

    .form-builder-detail .form-layout .form-template-item {
        padding: 16px;
        margin: 0 0 12px;
        font-size: 18px;
    }

    .form-builder-detail .form-layout .form-template-item.form-template-item-field {
        flex-basis: calc(100% - var(--flex-col-gutter) - 40px);
        margin: 0 calc(.5 * var(--flex-col-gutter) + 40px) 12px calc(.5 * var(--flex-col-gutter));
    }

    .form-builder-detail .form-section .configurable-zone {
        --zone-border: var(--zone-configurable-border);
    }

    .form-builder-detail .form-section .configurable-zone > .zone-actions {
        border-style: dotted;
        border-radius: 0 var(--zone-border-radius) var(--zone-border-radius) 0;
        opacity: 0;
        transition: opacity 116ms cubic-bezier(.2, .2, .38, .9), transform 116ms cubic-bezier(.2, .2, .38, .9);
        transform: scaleX(0);
        transform-origin: 0% 0%;
    }

    .form-builder-detail .form-section .configurable-zone > .zone-content-container {
        border-right: 2px dotted var(--zone-border);
    }

    .form-builder-detail .form-section .configurable-zone.active,
    .form-builder-detail .form-section .configurable-zone:hover {
        --zone-border: var(--zone-configurable-hover-border);
    }

    .form-builder-detail .form-section .configurable-zone.active > .zone-content-container,
    .form-builder-detail .form-section .configurable-zone:hover > .zone-content-container {
        border-right-color: transparent;
    }

    .form-builder-detail .form-section .configurable-zone.active > .zone-actions,
    .form-builder-detail .form-section .configurable-zone:hover > .zone-actions {
        opacity: 1;
        transform: scaleX(1);
        transform-origin: 0% 0%;
    }

    .form-builder-detail .flex-col {
        margin-right: calc(.5 * var(--flex-col-gutter));
        margin-left: calc(.5 * var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-1 {
        flex-basis: calc(8.3333% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-2 {
        flex-basis: calc(16.6666% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-3 {
        flex-basis: calc(25% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-4 {
        flex-basis: calc(33.3333% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-5 {
        flex-basis: calc(41.6666% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-6 {
        flex-basis: calc(50% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-7 {
        flex-basis: calc(58.3333% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-8 {
        flex-basis: calc(66.6666% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-9 {
        flex-basis: calc(75% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-10 {
        flex-basis: calc(83.3333% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-11 {
        flex-basis: calc(91.6666% - var(--flex-col-gutter));
    }

    .form-builder-detail .flex-col-12 {
        flex-basis: calc(100% - var(--flex-col-gutter));
    }

    .form-builder-grow {
        position: relative;
        display: flex;
        flex-grow: 1;
        overflow: hidden;
    }

    .form-builder-container {
        display: flex;
        flex: 1 1 auto;
        overflow: hidden;
    }

    .form-builder-scroll {
        display: flex;
        flex-direction: column;
        flex-grow: 1;
        overflow-y: auto;
    }

    .form-layout {
        position: relative;
        display: flex;
        flex: 1 1 0;
        flex-direction: column;
        padding: 1rem;
        overflow-y: auto;
    }

    .form-layout-body {
        display: flex;
        flex-direction: column;
        flex-grow: 1;
    }

    .form-sidebar {
        position: relative;
        z-index: 20;
        display: flex;
        flex: 1 0 auto;
        flex-direction: column;
        min-width: 320px;
        max-width: 320px;
        overflow: hidden;
        background-color: ;
        border-right: 1px solid #dfe0e1;
    }

    .form-sidebar .panel-body {
        padding: 12px 16px;
    }

    .form-sidebar .panel-title {
        padding: 0 16px !important;
        font-size: 16px;
    }

    .sidebar-back {
        display: flex;
        align-items: center;
        justify-content: center;
        width: 40px;
        color: #fff;
        cursor: pointer;
        background-color: #484848;
    }

    .sidebar-back:hover {
        background-color: #3d3d3d;
    }

    .sidebar-header {
        position: relative;
        display: flex;
        flex-direction: row;
        align-items: stretch;
        font-size: 14px;
        font-weight: 600;
        border-bottom: 1px solid #dfe0e1;
    }

    .sidebar-header .title {
        display: flex;
        align-items: center;
        padding: 8px;
    }

    .sidebar-header .icon {
        width: 1em;
        height: 1em;
        margin-right: 8px;
        font-size: 1.125rem;
    }

    .sidebar-body {
        position: relative;
        display: flex;
        flex-direction: column;
        overflow-y: auto;
    }

    .sidebar-panels {
        display: flex;
        flex-direction: column;
        flex-grow: 1;
    }

    .sidebar-panels .panel-default {
        margin-bottom: 0;
        border: 0;
        border-top: 1px solid var(--panel-border);
        border-radius: 0;
        box-shadow: none;
    }

    .sidebar-panels > div:nth-child(2) > .panel {
        border-top: 0;
    }

    .sidebar-panels > div:last-child {
        border-bottom: 1px solid var(--panel-border);
    }

    .sidebar-panels .panel-heading {
        background: var(--theme-lightest);
        border-bottom: 0;
        transition: .1s background-color ease-in-out;
    }

    .sidebar-panels .panel-heading > .panel-aside {
        color: #737475;
    }

    .sidebar-panels .panel-heading:hover {
        background: #fcfcfc;
    }

    .sidebar-panels .panel-heading:hover > .panel-aside {
        color: var(--text-color);
    }

    .sidebar-panels .panel-heading:active {
        background: #dfe0e1;
    }

    .form-template-item-list {
        --gutter: 8px;
        display: flex;
        flex-wrap: wrap;
        margin-top: calc(-1 * var(--gutter));
        margin-right: calc(-.5 * var(--gutter));
        margin-left: calc(-.5 * var(--gutter));
    }

    .form-template-item-list .form-template-item {
        flex-shrink: 0;
        width: calc(50% - var(--gutter));
        max-width: 100%;
        margin-top: var(--gutter);
        margin-right: calc(var(--gutter) * .5);
        margin-left: calc(var(--gutter) * .5);
    }

    .zone-action {
        z-index: 10;
        width: 100% !important;
        padding: 6px 4px;
        color: var(--zone-action-color);
        text-align: center;
        cursor: pointer;
    }

    .zone-action:hover {
        color: var(--zone-action-hover-color);
    }

    .configurable-zone.active .zone-action {
        color: var(--zone-active-action-color);
    }

    .zone-action.zone-action-delete:hover {
        color: var(--color-danger);
    }

    .zone-action-move {
        margin-bottom: auto;
        cursor: grab;
    }

    .section-header {
        display: flex;
    }

    .section-header-content {
        flex-grow: 1;
        align-items: center;
    }

    .form-template-item {
        display: flex;
        align-items: center;
        padding: 7px 6px;
        font-size: 14px;
        font-weight: 600;
        cursor: grab;
        background-color: #fff;
        border: 1px solid #e1e1e1;
        border-left-width: 3px;
        border-radius: 3px;
        box-shadow: 0 1px 2px 0 rgba(0, 0, 0, .05);
        transition: all 108ms cubic-bezier(.2, .2, .38, .9);
        transform: scale(1);
    }

    .form-template-item > .fa {
        margin-right: 6px;
    }

    .form-template-item > .icon {
        width: 18px;
        height: 18px;
        margin-right: 3px;
    }

    .form-template-item > .text {
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
    }

    .form-template-item:hover {
        border-color: var(--color-primary);
        box-shadow: 0 1px 3px 0 rgba(0, 0, 0, .1), 0 1px 2px -1px rgba(0, 0, 0, .1);
        transform: scale(1.02);
    }

    .form-template-item.form-template-item-section {
        border-left-color: #009ce3;
    }
</v-style>

<NotificationBox v-if="blockError" alertType="warning">
    {{ blockError }}
</NotificationBox>

<Panel v-else type="block" hasFullscreen :title="blockTitle" titleIconCssClass="fa fa-poll-h">
    <template #default>

        <div ref="bodyElement" class="panel-flex-fill-body styled-scroll">
            <div class="panel-toolbar panel-toolbar-shadow">
                <ul class="nav nav-pills nav-sm">
                    <li role="presentation"><a :href="submissionsPageUrl">Submissions</a></li>
                    <li :class="{ active: isFormBuilderTabSelected }" role="presentation"><a href="#" @click.prevent="onFormBuilderTabClick">Form Builder</a></li>
                    <li :class="{ active: isCommunicationsTabSelected }" role="presentation"><a href="#" @click.prevent="onCommunicationsTabClick">Communications</a></li>
                    <li :class="{ active: isSettingsTabSelected }" role="presentation"><a href="#" @click.prevent="onSettingsTabClick">Settings</a></li>
                    <li role="presentation"><a :href="analyticsPageUrl">Analytics</a></li>
                </ul>

                <RockButton btnType="primary" btnSize="sm" :disabled="!isFormDirty" @click="onSaveClick">Save</RockButton>
            </div>

            <div class="form-builder-container form-builder-grow" :style="formBuilderContainerStyle">
                <FormBuilderTab v-model="builderViewModel"
                    :templateOverrides="selectedTemplate"
                    :submit="formSubmit"
                    @validationChanged="onFormBuilderValidationChanged" />
            </div>

            <div class="communications-container form-builder-grow" :style="communicationsContainerStyle">
                <CommunicationsTab v-model="communicationsViewModel"
                    :recipientOptions="recipientOptions"
                    :templateOverrides="selectedTemplate"
                    :submit="formSubmit"
                    @validationChanged="onCommunicationsValidationChanged" />
            </div>

            <div class="settings-container form-builder-grow" :style="settingsContainerStyle">
                <SettingsTab v-model="generalViewModel"
                    v-model:completion="completionViewModel"
                    :templateOverrides="selectedTemplate"
                    :submit="formSubmit"
                    @validationChanged="onSettingsValidationChanged" />
            </div>
        </div>
    </template>
</Panel>
`
});
