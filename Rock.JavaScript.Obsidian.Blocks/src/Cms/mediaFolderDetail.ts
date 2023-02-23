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

import { computed, defineComponent, ref } from "vue";
import Alert from "@Obsidian/Controls/alert.obs";
import { EntityType } from "@Obsidian/SystemGuids/entityType";
import DetailBlock from "@Obsidian/Templates/detailBlock";
import { DetailPanelMode } from "@Obsidian/Enums/Controls/detailPanelMode";
import { PanelAction } from "@Obsidian/Types/Controls/panelAction";
import EditPanel from "./MediaFolderDetail/editPanel.partial";
import ViewPanel from "./MediaFolderDetail/viewPanel.partial";
import { getSecurityGrant, provideSecurityGrant, refreshDetailAttributes, useConfigurationValues, useInvokeBlockAction } from "@Obsidian/Utility/block";
import { debounce } from "@Obsidian/Utility/util";
import { NavigationUrlKey } from "./MediaFolderDetail/types";
import { DetailBlockBox } from "@Obsidian/ViewModels/Blocks/detailBlockBox";
import { MediaFolderBag } from "@Obsidian/ViewModels/Blocks/Cms/MediaFolderDetail/mediaFolderBag";
import { MediaFolderDetailOptionsBag } from "@Obsidian/ViewModels/Blocks/Cms/MediaFolderDetail/mediaFolderDetailOptionsBag";

export default defineComponent({
    name: "Cms.MediaFolderDetail",

    components: {
        Alert,
        EditPanel,
        DetailBlock,
        ViewPanel
    },

    setup() {
        const config = useConfigurationValues<DetailBlockBox<MediaFolderBag, MediaFolderDetailOptionsBag>>();
        const invokeBlockAction = useInvokeBlockAction();
        const securityGrant = getSecurityGrant(config.securityGrantToken);

        // #region Values

        const blockError = ref("");
        const errorMessage = ref("");

        const mediaFolderViewBag = ref(config.entity);
        const mediaFolderEditBag = ref<MediaFolderBag | null>(null);

        const panelMode = ref<DetailPanelMode>(DetailPanelMode.View);

        // The properties that are being edited in the UI. This is used to
        // inform the server which incoming values have valid data in them.
        const validProperties = [
            "attributeValues",
            "contentChannel",
            "contentChannelAttribute",
            "description",
            "isContentChannelSyncEnabled",
            "isPublic",
            "name",
            "workflowType",
            "contentChannelItemStatus"
        ];

        const refreshAttributesDebounce = debounce(() => refreshDetailAttributes(mediaFolderEditBag, validProperties, invokeBlockAction), undefined, true);

        // #endregion

        // #region Computed Values

        /**
         * The entity name to display in the block panel.
         */
        const panelName = computed((): string => {
            return mediaFolderViewBag.value?.name ?? "";
        });

        /**
         * The identifier key value for this entity.
         */
        const entityKey = computed((): string => {
            return mediaFolderViewBag.value?.idKey ?? "";
        });

        /**
         * Additional labels to display in the block panel.
         */
        const blockLabels = computed((): PanelAction[] | null => {
            const labels: PanelAction[] = [];

            if (panelMode.value !== DetailPanelMode.View) {
                return null;
            }

            if (mediaFolderViewBag.value?.isContentChannelSyncEnabled) {
                labels.push({
                    iconCssClass: "fa fa-exchange",
                    type: "info"
                });
            }

            return labels;
        });

        const isEditable = computed((): boolean => {
            return config.isEditable === true;
        });

        const options = computed((): MediaFolderDetailOptionsBag => {
            return config.options ?? {};
        });

        // #endregion

        // #region Functions

        // #endregion

        // #region Event Handlers

        /**
         * Event handler for the Cancel button being clicked while in Edit mode.
         * Handles redirect to parent page if creating a new entity.
         *
         * @returns true if the panel should leave edit mode; false if it should stay in edit mode; or a string containing a redirect URL.
         */
        const onCancelEdit = async (): Promise<boolean | string> => {
            if (!mediaFolderEditBag.value?.idKey) {
                if (config.navigationUrls?.[NavigationUrlKey.ParentPage]) {
                    return config.navigationUrls[NavigationUrlKey.ParentPage];
                }

                return false;
            }

            return true;
        };

        /**
         * Event handler for the Delete button being clicked. Sends the
         * delete request to the server and then redirects to the target page.
         *
         * @returns false if it should stay on the page; or a string containing a redirect URL.
         */
        const onDelete = async (): Promise<false | string> => {
            errorMessage.value = "";

            const result = await invokeBlockAction<string>("Delete", {
                key: mediaFolderViewBag.value?.idKey
            });

            if (result.isSuccess && result.data) {
                return result.data;
            }
            else {
                errorMessage.value = result.errorMessage ?? "Unknown error while trying to delete media folder.";

                return false;
            }
        };

        /**
         * Event handler for the Edit button being clicked. Request the edit
         * details from the server and then enter edit mode.
         *
         * @returns true if the panel should enter edit mode; otherwise false.
         */
        const onEdit = async (): Promise<boolean> => {
            const result = await invokeBlockAction<DetailBlockBox<MediaFolderBag, MediaFolderDetailOptionsBag>>("Edit", {
                key: mediaFolderViewBag.value?.idKey
            });

            if (result.isSuccess && result.data && result.data.entity) {
                mediaFolderEditBag.value = result.data.entity;

                return true;
            }
            else {
                return false;
            }
        };

        /**
         * Event handler for when a value has changed that has an associated
         * C# property name. This is used to detect changes to values that
         * might cause qualified attributes to either show up or not show up.
         *
         * @param propertyName The name of the C# property that was changed.
         */
        const onPropertyChanged = (propertyName: string): void => {
            // If we don't have any qualified attribute properties or this property
            // is not one of them then do nothing.
            if (!config.qualifiedAttributeProperties || !config.qualifiedAttributeProperties.some(n => n.toLowerCase() === propertyName.toLowerCase())) {
                return;
            }

            refreshAttributesDebounce();
        };

        /**
         * Event handler for the panel's Save event. Send the data to the server
         * to be saved and then leave edit mode or redirect to target page.
         *
         * @returns true if the panel should leave edit mode; false if it should stay in edit mode; or a string containing a redirect URL.
         */
        const onSave = async (): Promise<boolean | string> => {
            errorMessage.value = "";

            const data: DetailBlockBox<MediaFolderBag, MediaFolderDetailOptionsBag> = {
                entity: mediaFolderEditBag.value,
                isEditable: true,
                validProperties: validProperties
            };

            const result = await invokeBlockAction<MediaFolderBag | string>("Save", {
                box: data
            });

            if (result.isSuccess && result.data) {
                if (result.statusCode === 200 && typeof result.data === "object") {
                    mediaFolderViewBag.value = result.data;

                    return true;
                }
                else if (result.statusCode === 201 && typeof result.data === "string") {
                    return result.data;
                }
            }

            errorMessage.value = result.errorMessage ?? "Unknown error while trying to save media folder.";

            return false;
        };

        // #endregion

        provideSecurityGrant(securityGrant);

        // Handle any initial error conditions or the need to go into edit mode.
        if (config.errorMessage) {
            blockError.value = config.errorMessage;
        }
        else if (!config.entity) {
            blockError.value = "The specified media folder could not be viewed.";
        }
        else if (!config.entity.idKey) {
            mediaFolderEditBag.value = config.entity;
            panelMode.value = DetailPanelMode.Add;
        }

        return {
            mediaFolderViewBag,
            mediaFolderEditBag,
            blockError,
            blockLabels,
            entityKey,
            entityTypeGuid: EntityType.MediaFolder,
            errorMessage,
            isEditable,
            onCancelEdit,
            onDelete,
            onEdit,
            onPropertyChanged,
            onSave,
            options,
            panelMode,
            panelName
        };
    },

    template: `
<Alert v-if="blockError" alertType="warning" v-text="blockError" />

<Alert v-if="errorMessage" alertType="danger" v-text="errorMessage" />

<DetailBlock v-if="!blockError"
    v-model:mode="panelMode"
    :name="panelName"
    :labels="blockLabels"
    :entityKey="entityKey"
    :entityTypeGuid="entityTypeGuid"
    entityTypeName="MediaFolder"
    :isAuditHidden="false"
    :isBadgesVisible="false"
    :isDeleteVisible="isEditable"
    :isEditVisible="isEditable"
    :isFollowVisible="true"
    :isSecurityHidden="false"
    @cancelEdit="onCancelEdit"
    @delete="onDelete"
    @edit="onEdit"
    @save="onSave">
    <template #view>
        <ViewPanel :modelValue="mediaFolderViewBag" :options="options" />
    </template>

    <template #edit>
        <EditPanel v-model="mediaFolderEditBag" :options="options" @propertyChanged="onPropertyChanged" />
    </template>
</DetailBlock>
`
});
