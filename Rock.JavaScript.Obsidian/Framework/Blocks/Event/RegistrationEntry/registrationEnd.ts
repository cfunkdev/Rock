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

import { computed, defineComponent, inject, ref, watch } from "vue";
import AttributeValuesContainer from "../../../Controls/attributeValuesContainer";
import RockForm from "../../../Controls/rockForm";
import RockButton from "../../../Elements/rockButton";
import { PublicAttribute } from "../../../ViewModels";
import { RegistrationEntryState } from "../registrationEntry";

export default defineComponent({
    name: "Event.RegistrationEntry.RegistrationEnd",
    components: {
        RockButton,
        AttributeValuesContainer,
        RockForm
    },
    setup(props, { emit }) {
        const registrationEntryState = inject("registrationEntryState") as RegistrationEntryState;

        const attributeValues = ref<Record<string, string>>({});

        for (const a of registrationEntryState.viewModel.registrationAttributesEnd) {
            attributeValues.value[a.key] = (registrationEntryState.registrationFieldValues[a.attributeGuid] as string) || "";
        }

        const showPrevious = computed((): boolean => {
            return registrationEntryState.firstStep === registrationEntryState.steps.intro;
        });

        const attributes = computed((): Record<string, PublicAttribute> => {
            const attrs: Record<string, PublicAttribute> = {};

            for (const a of registrationEntryState.viewModel.registrationAttributesEnd) {
                attrs[a.key] = a;
            }

            return attrs;
        });

        const onPrevious = (): void => {
            emit("previous");
        };

        const onNext = (): void => {
            emit("next");
        };

        watch(attributeValues, () => {
            for (const a of registrationEntryState.viewModel.registrationAttributesEnd) {
                registrationEntryState.registrationFieldValues[a.attributeGuid] = attributeValues.value[a.key];
            }
        });

        return {
            attributes,
            attributeValues,
            onNext,
            onPrevious,
            showPrevious
        };
    },

    template: `
<div class="registrationentry-registration-attributes">
    <RockForm @submit="onNext">
        <AttributeValuesContainer v-model="attributeValues" :attributes="attributes" isEditMode />

        <div class="actions row">
            <div class="col-xs-6">
                <RockButton v-if="showPrevious" btnType="default" @click="onPrevious">
                    Previous
                </RockButton>
            </div>
            <div class="col-xs-6 text-right">
                <RockButton btnType="primary" type="submit">
                    Next
                </RockButton>
            </div>
        </div>
    </RockForm>
</div>`
});
