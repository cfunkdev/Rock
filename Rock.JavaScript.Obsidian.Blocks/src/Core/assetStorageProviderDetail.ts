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
import Alert from "@Obsidian/Controls/alert";
import { EntityType } from "@Obsidian/SystemGuids";
import DetailBlock from "@Obsidian/Templates/detailBlock";
import { DetailPanelMode } from "@Obsidian/Types/Controls/detailPanelMode";
import { PanelAction } from "@Obsidian/Types/Controls/panelAction";
import EditPanel from "./AssetStorageProviderDetail/editPanel.partial";
import ViewPanel from "./AssetStorageProviderDetail/viewPanel.partial";
import { getSecurityGrant, provideSecurityGrant, refreshDetailAttributes, useConfigurationValues, useInvokeBlockAction } from "@Obsidian/Utility/block";
import { debounce } from "@Obsidian/Utility/util";
import { NavigationUrlKey } from "./AssetStorageProviderDetail/types";
import { DetailBlockBox } from "@Obsidian/ViewModels/Blocks/detailBlockBox";
import { AssetStorageProviderBag } from "@Obsidian/ViewModels/Blocks/Core/AssetStorageProviderDetail/assetStorageProviderBag";
import { AssetStorageProviderDetailOptionsBag } from "@Obsidian/ViewModels/Blocks/Core/AssetStorageProviderDetail/assetStorageProviderDetailOptionsBag";

export default defineComponent({
    name: "Core.AssetStorageProviderDetail",

    components: {
        Alert,
        EditPanel,
        DetailBlock,
        ViewPanel
    },

    setup() {
        const config = useConfigurationValues<DetailBlockBox<AssetStorageProviderBag, AssetStorageProviderDetailOptionsBag>>();
        const invokeBlockAction = useInvokeBlockAction();
        const securityGrant = getSecurityGrant(config.securityGrantToken);

        // #region Values

        const blockError = ref("");
        const errorMessage = ref("");

        const assetStorageProviderViewBag = ref(config.entity);
        const assetStorageProviderEditBag = ref<AssetStorageProviderBag | null>(null);

        const panelMode = ref(DetailPanelMode.View);

        // The properties that are being edited in the UI. This is used to
        // inform the server which incoming values have valid data in them.
        const validProperties = [
            "attributeValues",
            "description",
            "entityType",
            "entityTypeId",
            "isActive",
            "name"
        ];

        const refreshAttributesDebounce = debounce(() => refreshDetailAttributes(assetStorageProviderEditBag, validProperties, invokeBlockAction), undefined, true);

        // #endregion

        // #region Computed Values

        /**
         * The entity name to display in the block panel.
         */
        const panelName = computed((): string => {
            return assetStorageProviderViewBag.value?.name ?? "";
        });

        /**
         * The identifier key value for this entity.
         */
        const entityKey = computed((): string => {
            return assetStorageProviderViewBag.value?.idKey ?? "";
        });

        /**
         * Additional labels to display in the block panel.
         */
        const blockLabels = computed((): PanelAction[] | null => {
            const labels: PanelAction[] = [];

            if (panelMode.value !== DetailPanelMode.View) {
                return null;
            }

            if (assetStorageProviderViewBag.value?.isActive === true) {
                labels.push({
                    iconCssClass: "fa fa-lightbulb",
                    title: "Active",
                    type: "success"
                });
            }
            else {
                labels.push({
                    iconCssClass: "far fa-lightbulb",
                    title: "Inactive",
                    type: "danger"
                });
            }

            return labels;
        });

        const isEditable = computed((): boolean => {
            return config.isEditable === true;
        });

        const options = computed((): AssetStorageProviderDetailOptionsBag => {
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
         * @returns true if the panel should leave edit mode; otherwise false.
         */
        const onCancelEdit = async (): Promise<boolean | string> => {
            if (!assetStorageProviderEditBag.value?.idKey) {
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
         */
        const onDelete = async (): Promise<false | string> => {
            errorMessage.value = "";

            const result = await invokeBlockAction<string>("Delete", {
                key: assetStorageProviderViewBag.value?.idKey
            });

            if (result.isSuccess && result.data) {
                return result.data;
            }
            else {
                errorMessage.value = result.errorMessage ?? "Unknown error while trying to delete asset storage provider.";
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
            const result = await invokeBlockAction<DetailBlockBox<AssetStorageProviderBag, AssetStorageProviderDetailOptionsBag>>("Edit", {
                key: assetStorageProviderViewBag.value?.idKey
            });

            if (result.isSuccess && result.data && result.data.entity) {
                assetStorageProviderEditBag.value = result.data.entity;

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
         * @returns true if the panel should leave edit mode; otherwise false.
         */
        const onSave = async (): Promise<boolean | string> => {
            errorMessage.value = "";

            const data: DetailBlockBox<AssetStorageProviderBag, AssetStorageProviderDetailOptionsBag> = {
                entity: assetStorageProviderEditBag.value,
                isEditable: true,
                validProperties: validProperties
            };

            const result = await invokeBlockAction<AssetStorageProviderBag | string>("Save", {
                box: data
            });

            if (result.isSuccess && config.navigationUrls?.[NavigationUrlKey.ParentPage]) {
                return config.navigationUrls[NavigationUrlKey.ParentPage];
            }

            errorMessage.value = result.errorMessage ?? "Unknown error while trying to save asset storage provider.";

            return false;
        };

        // #endregion

        provideSecurityGrant(securityGrant);

        // Handle any initial error conditions or the need to go into edit mode.
        if (config.errorMessage) {
            blockError.value = config.errorMessage;
        }
        else if (!config.entity) {
            blockError.value = "The specified asset storage provider could not be viewed.";
        }
        else if (!config.entity.idKey) {
            assetStorageProviderEditBag.value = config.entity;
            panelMode.value = DetailPanelMode.Add;
        }

        return {
            assetStorageProviderViewBag,
            assetStorageProviderEditBag,
            blockError,
            blockLabels,
            entityKey,
            entityTypeGuid: EntityType.AssetStorageProvider,
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
    entityTypeName="Asset Storage Provider"
    :isAuditHidden="false"
    :isBadgesVisible="true"
    :isDeleteVisible="isEditable"
    :isEditVisible="isEditable"
    :isFollowVisible="true"
    :isSecurityHidden="false"
    @cancelEdit="onCancelEdit"
    @delete="onDelete"
    @edit="onEdit"
    @save="onSave">
    <template #view>
        <ViewPanel :modelValue="assetStorageProviderViewBag" :options="options" />
    </template>

    <template #edit>
        <EditPanel v-model="assetStorageProviderEditBag" :options="options" @propertyChanged="onPropertyChanged" />
    </template>
</DetailBlock>
`
});
