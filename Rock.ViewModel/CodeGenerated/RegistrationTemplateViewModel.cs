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

using System;

namespace Rock.ViewModel
{
    /// <summary>
    /// RegistrationTemplate View Model
    /// </summary>
    [ViewModelOf( typeof( Rock.Model.RegistrationTemplate ) )]
    public partial class RegistrationTemplateViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the AddPersonNote.
        /// </summary>
        /// <value>
        /// The AddPersonNote.
        /// </value>
        public bool AddPersonNote { get; set; }

        /// <summary>
        /// Gets or sets the AllowExternalRegistrationUpdates.
        /// </summary>
        /// <value>
        /// The AllowExternalRegistrationUpdates.
        /// </value>
        public bool AllowExternalRegistrationUpdates { get; set; }

        /// <summary>
        /// Gets or sets the AllowGroupPlacement.
        /// </summary>
        /// <value>
        /// The AllowGroupPlacement.
        /// </value>
        public bool AllowGroupPlacement { get; set; }

        /// <summary>
        /// Gets or sets the AllowMultipleRegistrants.
        /// </summary>
        /// <value>
        /// The AllowMultipleRegistrants.
        /// </value>
        public bool AllowMultipleRegistrants { get; set; }

        /// <summary>
        /// Gets or sets the BatchNamePrefix.
        /// </summary>
        /// <value>
        /// The BatchNamePrefix.
        /// </value>
        public string BatchNamePrefix { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId.
        /// </summary>
        /// <value>
        /// The CategoryId.
        /// </value>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmationEmailTemplate.
        /// </summary>
        /// <value>
        /// The ConfirmationEmailTemplate.
        /// </value>
        public string ConfirmationEmailTemplate { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmationFromEmail.
        /// </summary>
        /// <value>
        /// The ConfirmationFromEmail.
        /// </value>
        public string ConfirmationFromEmail { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmationFromName.
        /// </summary>
        /// <value>
        /// The ConfirmationFromName.
        /// </value>
        public string ConfirmationFromName { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmationSubject.
        /// </summary>
        /// <value>
        /// The ConfirmationSubject.
        /// </value>
        public string ConfirmationSubject { get; set; }

        /// <summary>
        /// Gets or sets the Cost.
        /// </summary>
        /// <value>
        /// The Cost.
        /// </value>
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets the DefaultPayment.
        /// </summary>
        /// <value>
        /// The DefaultPayment.
        /// </value>
        public decimal? DefaultPayment { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the DiscountCodeTerm.
        /// </summary>
        /// <value>
        /// The DiscountCodeTerm.
        /// </value>
        public string DiscountCodeTerm { get; set; }

        /// <summary>
        /// Gets or sets the FeeTerm.
        /// </summary>
        /// <value>
        /// The FeeTerm.
        /// </value>
        public string FeeTerm { get; set; }

        /// <summary>
        /// Gets or sets the FinancialGatewayId.
        /// </summary>
        /// <value>
        /// The FinancialGatewayId.
        /// </value>
        public int? FinancialGatewayId { get; set; }

        /// <summary>
        /// Gets or sets the GroupMemberRoleId.
        /// </summary>
        /// <value>
        /// The GroupMemberRoleId.
        /// </value>
        public int? GroupMemberRoleId { get; set; }

        /// <summary>
        /// Gets or sets the GroupMemberStatus.
        /// </summary>
        /// <value>
        /// The GroupMemberStatus.
        /// </value>
        public int GroupMemberStatus { get; set; }

        /// <summary>
        /// Gets or sets the GroupTypeId.
        /// </summary>
        /// <value>
        /// The GroupTypeId.
        /// </value>
        public int? GroupTypeId { get; set; }

        /// <summary>
        /// Gets or sets the IsActive.
        /// </summary>
        /// <value>
        /// The IsActive.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the LoginRequired.
        /// </summary>
        /// <value>
        /// The LoginRequired.
        /// </value>
        public bool LoginRequired { get; set; }

        /// <summary>
        /// Gets or sets the MaxRegistrants.
        /// </summary>
        /// <value>
        /// The MaxRegistrants.
        /// </value>
        public int? MaxRegistrants { get; set; }

        /// <summary>
        /// Gets or sets the MinimumInitialPayment.
        /// </summary>
        /// <value>
        /// The MinimumInitialPayment.
        /// </value>
        public decimal? MinimumInitialPayment { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Notify.
        /// </summary>
        /// <value>
        /// The Notify.
        /// </value>
        public int Notify { get; set; }

        /// <summary>
        /// Gets or sets the PaymentRedirectVendor.
        /// </summary>
        /// <value>
        /// The PaymentRedirectVendor.
        /// </value>
        public int? PaymentRedirectVendor { get; set; }

        /// <summary>
        /// Gets or sets the PaymentReminderEmailTemplate.
        /// </summary>
        /// <value>
        /// The PaymentReminderEmailTemplate.
        /// </value>
        public string PaymentReminderEmailTemplate { get; set; }

        /// <summary>
        /// Gets or sets the PaymentReminderFromEmail.
        /// </summary>
        /// <value>
        /// The PaymentReminderFromEmail.
        /// </value>
        public string PaymentReminderFromEmail { get; set; }

        /// <summary>
        /// Gets or sets the PaymentReminderFromName.
        /// </summary>
        /// <value>
        /// The PaymentReminderFromName.
        /// </value>
        public string PaymentReminderFromName { get; set; }

        /// <summary>
        /// Gets or sets the PaymentReminderSubject.
        /// </summary>
        /// <value>
        /// The PaymentReminderSubject.
        /// </value>
        public string PaymentReminderSubject { get; set; }

        /// <summary>
        /// Gets or sets the PaymentReminderTimeSpan.
        /// </summary>
        /// <value>
        /// The PaymentReminderTimeSpan.
        /// </value>
        public int? PaymentReminderTimeSpan { get; set; }

        /// <summary>
        /// Gets or sets the RegistrantsSameFamily.
        /// </summary>
        /// <value>
        /// The RegistrantsSameFamily.
        /// </value>
        public int RegistrantsSameFamily { get; set; }

        /// <summary>
        /// Gets or sets the RegistrantTerm.
        /// </summary>
        /// <value>
        /// The RegistrantTerm.
        /// </value>
        public string RegistrantTerm { get; set; }

        /// <summary>
        /// Gets or sets the RegistrarOption.
        /// </summary>
        /// <value>
        /// The RegistrarOption.
        /// </value>
        public int RegistrarOption { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationAttributeTitleEnd.
        /// </summary>
        /// <value>
        /// The RegistrationAttributeTitleEnd.
        /// </value>
        public string RegistrationAttributeTitleEnd { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationAttributeTitleStart.
        /// </summary>
        /// <value>
        /// The RegistrationAttributeTitleStart.
        /// </value>
        public string RegistrationAttributeTitleStart { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationInstructions.
        /// </summary>
        /// <value>
        /// The RegistrationInstructions.
        /// </value>
        public string RegistrationInstructions { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationTerm.
        /// </summary>
        /// <value>
        /// The RegistrationTerm.
        /// </value>
        public string RegistrationTerm { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationWorkflowTypeId.
        /// </summary>
        /// <value>
        /// The RegistrationWorkflowTypeId.
        /// </value>
        public int? RegistrationWorkflowTypeId { get; set; }

        /// <summary>
        /// Gets or sets the ReminderEmailTemplate.
        /// </summary>
        /// <value>
        /// The ReminderEmailTemplate.
        /// </value>
        public string ReminderEmailTemplate { get; set; }

        /// <summary>
        /// Gets or sets the ReminderFromEmail.
        /// </summary>
        /// <value>
        /// The ReminderFromEmail.
        /// </value>
        public string ReminderFromEmail { get; set; }

        /// <summary>
        /// Gets or sets the ReminderFromName.
        /// </summary>
        /// <value>
        /// The ReminderFromName.
        /// </value>
        public string ReminderFromName { get; set; }

        /// <summary>
        /// Gets or sets the ReminderSubject.
        /// </summary>
        /// <value>
        /// The ReminderSubject.
        /// </value>
        public string ReminderSubject { get; set; }

        /// <summary>
        /// Gets or sets the RequestEntryName.
        /// </summary>
        /// <value>
        /// The RequestEntryName.
        /// </value>
        public string RequestEntryName { get; set; }

        /// <summary>
        /// Gets or sets the RequiredSignatureDocumentTemplateId.
        /// </summary>
        /// <value>
        /// The RequiredSignatureDocumentTemplateId.
        /// </value>
        public int? RequiredSignatureDocumentTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the SetCostOnInstance.
        /// </summary>
        /// <value>
        /// The SetCostOnInstance.
        /// </value>
        public bool? SetCostOnInstance { get; set; }

        /// <summary>
        /// Gets or sets the ShowCurrentFamilyMembers.
        /// </summary>
        /// <value>
        /// The ShowCurrentFamilyMembers.
        /// </value>
        public bool ShowCurrentFamilyMembers { get; set; }

        /// <summary>
        /// Gets or sets the SignatureDocumentAction.
        /// </summary>
        /// <value>
        /// The SignatureDocumentAction.
        /// </value>
        public int SignatureDocumentAction { get; set; }

        /// <summary>
        /// Gets or sets the SuccessText.
        /// </summary>
        /// <value>
        /// The SuccessText.
        /// </value>
        public string SuccessText { get; set; }

        /// <summary>
        /// Gets or sets the SuccessTitle.
        /// </summary>
        /// <value>
        /// The SuccessTitle.
        /// </value>
        public string SuccessTitle { get; set; }

        /// <summary>
        /// Gets or sets the WaitListEnabled.
        /// </summary>
        /// <value>
        /// The WaitListEnabled.
        /// </value>
        public bool WaitListEnabled { get; set; }

        /// <summary>
        /// Gets or sets the WaitListTransitionEmailTemplate.
        /// </summary>
        /// <value>
        /// The WaitListTransitionEmailTemplate.
        /// </value>
        public string WaitListTransitionEmailTemplate { get; set; }

        /// <summary>
        /// Gets or sets the WaitListTransitionFromEmail.
        /// </summary>
        /// <value>
        /// The WaitListTransitionFromEmail.
        /// </value>
        public string WaitListTransitionFromEmail { get; set; }

        /// <summary>
        /// Gets or sets the WaitListTransitionFromName.
        /// </summary>
        /// <value>
        /// The WaitListTransitionFromName.
        /// </value>
        public string WaitListTransitionFromName { get; set; }

        /// <summary>
        /// Gets or sets the WaitListTransitionSubject.
        /// </summary>
        /// <value>
        /// The WaitListTransitionSubject.
        /// </value>
        public string WaitListTransitionSubject { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDateTime.
        /// </summary>
        /// <value>
        /// The CreatedDateTime.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedDateTime.
        /// </summary>
        /// <value>
        /// The ModifiedDateTime.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the CreatedByPersonAliasId.
        /// </summary>
        /// <value>
        /// The CreatedByPersonAliasId.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedByPersonAliasId.
        /// </summary>
        /// <value>
        /// The ModifiedByPersonAliasId.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

    }
}