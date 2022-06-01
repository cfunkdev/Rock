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
using System.Linq;

using Rock.ViewModels.Utility;

namespace Rock.ViewModels.Entities
{
    /// <summary>
    /// FinancialTransaction View Model
    /// </summary>
    public partial class FinancialTransactionBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the authorized person identifier.
        /// </summary>
        /// <value>
        /// The authorized person identifier.
        /// </value>
        public int? AuthorizedPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets BatchId of the Rock.Model.FinancialBatch that contains this transaction.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the BatchId of the Rock.Model.FinancialBatch that contains the transaction.
        /// </value>
        public int? BatchId { get; set; }

        /// <summary>
        /// Gets or sets an encrypted version of a scanned check's raw track of the MICR data.
        /// Note that different scanning hardware might use different special characters for fields such as Transit and On-US.
        /// Also, encryption of the same values results in different encrypted data, so this field can't be used for check matching
        /// </summary>
        /// <value>
        /// The check micr encrypted.
        /// A System.String representing an encrypted version of a scanned check's MICR track data
        /// </value>
        public string CheckMicrEncrypted { get; set; }

        /// <summary>
        /// One Way Encryption (SHA1 Hash) of Raw Track of the MICR read. The same raw MICR will result in the same hash.
        /// Enables detection of duplicate scanned checks
        /// Note: duplicate detection requires that the duplicate check was scanned using the same scanner type (Ranger vs Magtek)
        /// </summary>
        /// <value>
        /// The check micr hash.
        /// </value>
        public string CheckMicrHash { get; set; }

        /// <summary>
        /// Gets or sets an encrypted version of a scanned check's parsed MICR in the format {routingnumber}_{accountnumber}_{checknumber}
        /// </summary>
        /// <value>
        /// The check micr encrypted.
        /// A System.String representing an encrypted version of a scanned check's parsed MICR data in the format {routingnumber}_{accountnumber}_{checknumber}
        /// </value>
        public string CheckMicrParts { get; set; }

        /// <summary>
        /// Gets or sets the gateway identifier.
        /// </summary>
        /// <value>
        /// The gateway identifier.
        /// </value>
        public int? FinancialGatewayId { get; set; }

        /// <summary>
        /// Gets or sets the financial payment detail identifier.
        /// </summary>
        /// <value>
        /// The financial payment detail identifier.
        /// </value>
        public int? FinancialPaymentDetailId { get; set; }

        /// <summary>
        /// Gets or sets the foreign currency code value identifier.
        /// </summary>
        /// <value>
        /// The foreign currency code value identifier.
        /// </value>
        public int? ForeignCurrencyCodeValueId { get; set; }

        /// <summary>
        /// Gets or sets date and time that the transaction should be processed after. This is the local server time.
        /// </summary>
        public DateTime? FutureProcessingDateTime { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the transaction has been reconciled or not.
        /// </summary>
        /// <value>
        /// The is settled.
        /// </value>
        public bool? IsReconciled { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the transaction has been settled by the processor/gateway.
        /// </summary>
        /// <value>
        /// The is settled.
        /// </value>
        public bool? IsSettled { get; set; }

        /// <summary>
        /// Gets or sets the micr status (if this Transaction is from a scanned check)
        /// Fail means that the check scanner detected a bad MICR read, but the user choose to Upload it anyway
        /// </summary>
        /// <value>
        /// The micr status.
        /// </value>
        public int? MICRStatus { get; set; }

        /// <summary>
        /// Gets or sets the non cash asset type Rock.Model.DefinedValue identifier.
        /// </summary>
        /// <value>
        /// The non cash asset type value identifier.
        /// </value>
        public int? NonCashAssetTypeValueId { get; set; }

        /// <summary>
        /// Gets or sets the PersonAliasId of the Rock.Model.PersonAlias who processed the transaction. For example, if the transaction is
        /// from a scanned check, the ProcessedByPersonAlias is the person who matched (or started to match) the check to the person who wrote the check.
        /// </summary>
        /// <value>
        /// The processed by person alias identifier.
        /// </value>
        public int? ProcessedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the processed date time. For example, if the transaction is from a scanned check, the ProcessedDateTime is when the transaction
        /// was matched (or started to match) to the person who wrote the check.
        /// </summary>
        /// <value>
        /// The processed date time.
        /// </value>
        public DateTime? ProcessedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the ScheduledTransactionId of the Rock.Model.FinancialScheduledTransaction that triggered
        /// this transaction. If this was an ad-hoc/on demand transaction, this property will be null.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the ScheduledTransactionId of the Rock.Model.FinancialScheduledTransaction
        /// </value>
        public int? ScheduledTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the date that the transaction was settled by the processor/gateway.
        /// </summary>
        /// <value>
        /// The settled date.
        /// </value>
        public DateTime? SettledDate { get; set; }

        /// <summary>
        /// The group/batch identifier used by the processor/gateway when the transaction has been settled.
        /// </summary>
        /// <value>
        /// The settled group identifier.
        /// </value>
        public string SettledGroupId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show the transaction as anonymous when displayed publicly, for example on a list of fundraising contributors
        /// </summary>
        /// <value>
        ///   true if [show as anonymous]; otherwise, false.
        /// </value>
        public bool ShowAsAnonymous { get; set; }

        /// <summary>
        /// Gets or sets the DefinedValueId of the source type Rock.Model.DefinedValue for this transaction. Representing the source (method) of this transaction.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the DefinedValueId of the source type Rock.Model.DefinedValue for this transaction.
        /// </value>
        public int? SourceTypeValueId { get; set; }

        /// <summary>
        /// Gets the status of the transaction provided by the payment gateway (i.e. Pending, Complete, Failed)
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>
        /// The status message.
        /// </value>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets a summary of the transaction. This would store any comments made.
        /// </summary>
        /// <value>
        /// A System.String representing a summary of the transaction.
        /// </value>
        public string Summary { get; set; }

        /// <summary>
        /// Gets Sunday date.
        /// </summary>
        /// <value>
        /// The Sunday date.
        /// </value>
        public DateTime? SundayDate { get; set; }

        /// <summary>
        /// For Credit Card transactions, this is the response code that the gateway returns.
        /// For Scanned Checks, this is the check number.
        /// </summary>
        /// <value>
        /// A System.String representing the transaction code of the transaction.
        /// </value>
        public string TransactionCode { get; set; }

        /// <summary>
        /// Gets or sets date and time that the transaction occurred. This is the local server time.
        /// </summary>
        /// <value>
        /// A System.DateTime representing the time that the transaction occurred. This is the local server time.
        /// </value>
        public DateTime? TransactionDateTime { get; set; }

        /// <summary>
        /// Gets or sets the DefinedValueId of the TransactionType Rock.Model.DefinedValue indicating
        /// the type of the transaction.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the DefinedValueId of the TransactionType Rock.Model.DefinedValue for this transaction.
        /// </value>
        public int TransactionTypeValueId { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the created by person alias identifier.
        /// </summary>
        /// <value>
        /// The created by person alias identifier.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the modified by person alias identifier.
        /// </summary>
        /// <value>
        /// The modified by person alias identifier.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

    }
}
