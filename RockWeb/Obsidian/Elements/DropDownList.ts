﻿// <copyright>
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
import { defineComponent, PropType } from '../Vendor/Vue/vue.js';
import { newGuid } from '../Util/Guid.js';
import RockFormField from './RockFormField.js';

export type DropDownListOption = {
    key: string,
    value: string,
    text: string
};

export default defineComponent({
    name: 'DropDownList',
    components: {
        RockFormField
    },
    props: {
        modelValue: {
            type: String as PropType<string>,
            required: true
        },
        options: {
            type: Array as PropType<DropDownListOption[]>,
            required: true
        },
        showBlankItem: {
            type: Boolean as PropType<boolean>,
            default: true
        },
        blankValue: {
            type: String as PropType<string>,
            default: ''
        }
    },
    data: function () {
        return {
            uniqueId: `rock-dropdownlist-${newGuid()}`,
            internalValue: this.blankValue
        };
    },
    methods: {
        syncValue() {
            this.internalValue = this.modelValue;
            const selectedOption = this.options.find(o => o.value === this.internalValue) || null;

            if (!selectedOption) {
                this.internalValue = this.showBlankItem ?
                    this.blankValue :
                    (this.options[0]?.value || this.blankValue);
            }
        }
    },
    watch: {
        modelValue: {
            immediate: true,
            handler() {
                this.syncValue();
            }
        },
        options: {
            immediate: true,
            handler() {
                this.syncValue();
            }
        },
        internalValue() {
            this.$emit('update:modelValue', this.internalValue);
        }
    },
    template: `
<RockFormField
    :modelValue="internalValue"
    formGroupClasses="rock-drop-down-list"
    name="dropdownlist">
    <template #default="{uniqueId, field, errors, disabled}">
        <div class="control-wrapper">
            <select :id="uniqueId" class="form-control" :disabled="disabled" v-bind="field" v-model="internalValue">
                <option v-if="showBlankItem" :value="blankValue"></option>
                <option v-for="o in options" :key="o.key" :value="o.value">{{o.text}}</option>
            </select>
        </div>
    </template>
</RockFormField>`
});