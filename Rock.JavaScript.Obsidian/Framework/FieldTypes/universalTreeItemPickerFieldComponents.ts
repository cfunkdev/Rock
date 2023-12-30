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
import TreeItemPicker from "@Obsidian/Controls/treeItemPicker.obs";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { TreeItemBag } from "@Obsidian/ViewModels/Utility/treeItemBag";
import { post } from "@Obsidian/Utility/http";
import { updateRefValue, useVModelPassthrough } from "@Obsidian/Utility/component";
import { ITreeItemProvider } from "@Obsidian/Utility/treeItemProviders";
import { asBoolean } from "@Obsidian/Utility/booleanUtils";
import { DataEntryMode } from "@Obsidian/Utility/fieldTypes";

type UniversalTreeItemPickerOptionsBag = {
    securityGrantToken?: string | null;

    context?: string | null;

    parentValue?: string | null;

    expandToValues?: string[] | null;
};

class UniversalTreeItemProvider implements ITreeItemProvider {
    /**
     * The security grant token that will be used to request additional access
     * to the category list.
     */
    public securityGrantToken?: string | null;

    /**
     * Any custom context data to send with the API requests.
     */
    public context?: string | null;

    /**
     * The URL to call in order to retrieve the items.
     */
    public restUrl: string;

    public constructor(restUrl: string) {
        this.restUrl = restUrl;
    }

    /**
     * Gets the child items from the server.
     *
     * @param parentValue The parent item whose children are retrieved.
     *
     * @returns A collection of TreeItem objects as an asynchronous operation.
     */
    private async getItems(parentValue: string | null | undefined, expandToValues: string[] | null): Promise<TreeItemBag[]> {
        if (!this.restUrl) {
            return [];
        }

        const options: Partial<UniversalTreeItemPickerOptionsBag> = {
            parentValue: parentValue,
            expandToValues: expandToValues,
            securityGrantToken: this.securityGrantToken,
            context: this.context
        };

        const response = await post<TreeItemBag[]>(this.restUrl, {}, options);

        if (response.isSuccess && response.data && typeof response.data === "object" && Array.isArray(response.data)) {
            return response.data;
        }
        else {
            console.log("Error", response.errorMessage);
            return [];
        }
    }

    /**
     * @inheritdoc
     */
    async getRootItems(expandToValues: string[]): Promise<TreeItemBag[]> {
        return await this.getItems(null, expandToValues);
    }

    /**
     * @inheritdoc
     */
    async getChildItems(item: TreeItemBag): Promise<TreeItemBag[]> {
        return this.getItems(item.value, null);
    }

    /**
     * @inheritdoc
     */
    canSelectItem(item: TreeItemBag): boolean {
        return (item as Record<string, unknown>).isSelectionDisabled !== true;
    }
}

export const EditComponent = defineComponent({
    name: "UniversalTreeItemPickerField.Edit",

    components: {
        TreeItemPicker
    },

    props: getFieldEditorProps(),

    setup(props, { emit }) {
        const internalValue = ref(getModelValue());
        const isRequired = inject<boolean>("isRequired") ?? false;
        const itemProvider = new UniversalTreeItemProvider(props.configurationValues["rootRestUrl"] ?? "");

        const iconCssClass = computed((): string => {
            return props.configurationValues["iconCssClass"] ?? "";
        });

        const multiple = computed((): boolean => {
            return asBoolean(props.configurationValues["isMultiple"]);
        });

        const rules = computed((): string => {
            return isRequired ? "required" : "";
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
            iconCssClass,
            internalValue,
            isRequired,
            itemProvider,
            multiple,
            rules
        };
    },

    template: `
<TreeItemPicker v-model="internalValue"
                formGroupClasses="universal-tree-item-picker"
                autoExpand
                :iconCssClass="iconCssClass"
                :provider="itemProvider"
                :multiple="multiple"
                :rules="rules" />
`
});

export const FilterComponent = defineComponent({
    name: "UniversalTreeItemPickerField.Filter",

    components: {
        EditComponent
    },

    props: getFieldEditorProps(),

    setup(props, { emit }) {
        const internalValue = useVModelPassthrough(props, "modelValue", emit);
        const dataEntryMode = computed((): DataEntryMode => props.dataEntryMode);

        const configurationValues = computed((): Record<string, string> => {
            const values = {...props.configurationValues};

            // Invert the multiple state for the filter component.
            if (asBoolean(values["isMultiple"])) {
                values["isMultiple"] = "false";
            }
            else {
                values["isMultiple"] = "true";
            }

            return values;
        });

        return {
            configurationValues,
            dataEntryMode,
            internalValue
        };
    },

    template: `
<EditComponent v-model="internalValue" :configurationValues="configurationValues" :dataEntryMode="dataEntryMode" />
`
});
