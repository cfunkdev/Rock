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

import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

/** RegistrationTemplate View Model */
export type RegistrationTemplateBag = {
    /** Gets or sets the AddPersonNote. */
    addPersonNote: boolean;

    /** Gets or sets the AllowExternalRegistrationUpdates. */
    allowExternalRegistrationUpdates: boolean;

    /** Gets or sets the AllowMultipleRegistrants. */
    allowMultipleRegistrants: boolean;

    /** Gets or sets the BatchNamePrefix. */
    batchNamePrefix?: string | null;

    /** Gets or sets the CategoryId. */
    categoryId?: number | null;

    /** Gets or sets the ConfirmationEmailTemplate. */
    confirmationEmailTemplate?: string | null;

    /** Gets or sets the ConfirmationFromEmail. */
    confirmationFromEmail?: string | null;

    /** Gets or sets the ConfirmationFromName. */
    confirmationFromName?: string | null;

    /** Gets or sets the ConfirmationSubject. */
    confirmationSubject?: string | null;

    /** Gets or sets the Cost. */
    cost?: number;

    /** Gets or sets the DefaultPayment. */
    defaultPayment?: number | null;

    /** Gets or sets the Description. */
    description?: string | null;

    /** Gets or sets the DiscountCodeTerm. */
    discountCodeTerm?: string | null;

    /** Gets or sets the FeeTerm. */
    feeTerm?: string | null;

    /** Gets or sets the FinancialGatewayId. */
    financialGatewayId?: number | null;

    /** Gets or sets the GroupMemberRoleId. */
    groupMemberRoleId?: number | null;

    /** Gets or sets the GroupMemberStatus. */
    groupMemberStatus: number;

    /** Gets or sets the GroupTypeId. */
    groupTypeId?: number | null;

    /** Gets or sets the IsActive. */
    isActive: boolean;

    /** Gets or sets the IsRegistrationMeteringEnabled. */
    isRegistrationMeteringEnabled: boolean;

    /** Gets or sets the LoginRequired. */
    loginRequired: boolean;

    /** Gets or sets the MaxRegistrants. */
    maxRegistrants?: number | null;

    /** Gets or sets the MinimumInitialPayment. */
    minimumInitialPayment?: number | null;

    /** Gets or sets the Name. */
    name?: string | null;

    /** Gets or sets the Notify. */
    notify: number;

    /** Gets or sets the PaymentReminderEmailTemplate. */
    paymentReminderEmailTemplate?: string | null;

    /** Gets or sets the PaymentReminderFromEmail. */
    paymentReminderFromEmail?: string | null;

    /** Gets or sets the PaymentReminderFromName. */
    paymentReminderFromName?: string | null;

    /** Gets or sets the PaymentReminderSubject. */
    paymentReminderSubject?: string | null;

    /** Gets or sets the PaymentReminderTimeSpan. */
    paymentReminderTimeSpan?: number | null;

    /** Gets or sets the RegistrantsSameFamily. */
    registrantsSameFamily: number;

    /** Gets or sets the RegistrantTerm. */
    registrantTerm?: string | null;

    /** Gets or sets the RegistrantWorkflowTypeId. */
    registrantWorkflowTypeId?: number | null;

    /** Gets or sets the RegistrarOption. */
    registrarOption: number;

    /** Gets or sets the RegistrationAttributeTitleEnd. */
    registrationAttributeTitleEnd?: string | null;

    /** Gets or sets the RegistrationAttributeTitleStart. */
    registrationAttributeTitleStart?: string | null;

    /** Gets or sets the RegistrationInstructions. */
    registrationInstructions?: string | null;

    /** Gets or sets the RegistrationTerm. */
    registrationTerm?: string | null;

    /** Gets or sets the RegistrationWorkflowTypeId. */
    registrationWorkflowTypeId?: number | null;

    /** Gets or sets the ReminderEmailTemplate. */
    reminderEmailTemplate?: string | null;

    /** Gets or sets the ReminderFromEmail. */
    reminderFromEmail?: string | null;

    /** Gets or sets the ReminderFromName. */
    reminderFromName?: string | null;

    /** Gets or sets the ReminderSubject. */
    reminderSubject?: string | null;

    /** Gets or sets the RequestEntryName. */
    requestEntryName?: string | null;

    /** Gets or sets the RequiredSignatureDocumentTemplateId. */
    requiredSignatureDocumentTemplateId?: number | null;

    /** Gets or sets the SetCostOnInstance. */
    setCostOnInstance?: boolean | null;

    /** Gets or sets the ShowCurrentFamilyMembers. */
    showCurrentFamilyMembers: boolean;

    /** Gets or sets the SignatureDocumentAction. */
    signatureDocumentAction: number;

    /** Gets or sets the SuccessText. */
    successText?: string | null;

    /** Gets or sets the SuccessTitle. */
    successTitle?: string | null;

    /** Gets or sets the WaitListEnabled. */
    waitListEnabled: boolean;

    /** Gets or sets the WaitListTransitionEmailTemplate. */
    waitListTransitionEmailTemplate?: string | null;

    /** Gets or sets the WaitListTransitionFromEmail. */
    waitListTransitionFromEmail?: string | null;

    /** Gets or sets the WaitListTransitionFromName. */
    waitListTransitionFromName?: string | null;

    /** Gets or sets the WaitListTransitionSubject. */
    waitListTransitionSubject?: string | null;

    /** Gets or sets the CreatedDateTime. */
    createdDateTime?: string | null;

    /** Gets or sets the ModifiedDateTime. */
    modifiedDateTime?: string | null;

    /** Gets or sets the CreatedByPersonAliasId. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the ModifiedByPersonAliasId. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the plural registrant term. */
    pluralRegistrantTerm?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;
};
