//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
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

import { IEntity } from "../entity";

export type RegistrationTemplate = IEntity & {
    addPersonNote?: boolean;
    allowExternalRegistrationUpdates?: boolean;
    allowMultipleRegistrants?: boolean;
    batchNamePrefix?: string | null;
    categoryId?: number | null;
    confirmationEmailTemplate?: string | null;
    confirmationFromEmail?: string | null;
    confirmationFromName?: string | null;
    confirmationSubject?: string | null;
    cost?: number;
    defaultPayment?: number | null;
    description?: string | null;
    discountCodeTerm?: string | null;
    feeTerm?: string | null;
    financialGatewayId?: number | null;
    groupMemberRoleId?: number | null;
    groupMemberStatus?: number;
    groupTypeId?: number | null;
    idKey?: string | null;
    isActive?: boolean;
    isRegistrationMeteringEnabled?: boolean;
    loginRequired?: boolean;
    maxRegistrants?: number | null;
    minimumInitialPayment?: number | null;
    name?: string | null;
    notify?: number;
    paymentReminderEmailTemplate?: string | null;
    paymentReminderFromEmail?: string | null;
    paymentReminderFromName?: string | null;
    paymentReminderSubject?: string | null;
    paymentReminderTimeSpan?: number | null;
    pluralRegistrantTerm?: string | null;
    registrantsSameFamily?: number;
    registrantTerm?: string | null;
    registrantWorkflowTypeId?: number | null;
    registrarOption?: number;
    registrationAttributeTitleEnd?: string | null;
    registrationAttributeTitleStart?: string | null;
    registrationInstructions?: string | null;
    registrationTerm?: string | null;
    registrationWorkflowTypeId?: number | null;
    reminderEmailTemplate?: string | null;
    reminderFromEmail?: string | null;
    reminderFromName?: string | null;
    reminderSubject?: string | null;
    requestEntryName?: string | null;
    requiredSignatureDocumentTemplateId?: number | null;
    setCostOnInstance?: boolean | null;
    showCurrentFamilyMembers?: boolean;
    signatureDocumentAction?: number;
    successText?: string | null;
    successTitle?: string | null;
    waitListEnabled?: boolean;
    waitListTransitionEmailTemplate?: string | null;
    waitListTransitionFromEmail?: string | null;
    waitListTransitionFromName?: string | null;
    waitListTransitionSubject?: string | null;
    createdDateTime?: string | null;
    modifiedDateTime?: string | null;
    createdByPersonAliasId?: number | null;
    modifiedByPersonAliasId?: number | null;
};
