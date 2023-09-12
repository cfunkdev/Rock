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
    /// FinancialTransactionAlertType View Model
    /// </summary>
    public partial class FinancialTransactionAlertTypeBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the Rock.Model.SystemCommunication that will be sent to any Account Participants.
        /// Account Participants are stored as <see cref="T:Rock.Model.RelatedEntity" /> with <see cref="P:Rock.Model.RelatedEntity.PurposeKey" />
        /// of <see cref="F:Rock.Model.RelatedEntityPurposeKey.FinancialAccountGivingAlert" />.
        /// </summary>
        /// <value>
        /// The account participant system communication identifier.
        /// </value>
        public int? AccountParticipantSystemCommunicationId { get; set; }

        /// <summary>
        /// Gets or sets the alert summary notification group identifier.
        /// </summary>
        /// <value>
        /// The alert summary notification group identifier.
        /// </value>
        public int? AlertSummaryNotificationGroupId { get; set; }

        /// <summary>
        /// Gets or sets the alert type.
        /// </summary>
        /// <value>
        /// The alert type.
        /// </value>
        public int AlertType { get; set; }

        /// <summary>
        /// Gets or sets the amount sensitivity scale.
        /// This determines the point where a transaction amount is considered
        /// significantly larger or smaller than usual.
        /// See notes on <see cref="P:Rock.Model.FinancialTransactionAlertType.AlertType">Alert Type</see> to
        /// see how this value is used for Gratitude vs Follow-Up alert types.
        /// </summary>
        /// <value>
        /// The amount sensitivity scale.
        /// </value>
        public decimal? AmountSensitivityScale { get; set; }

        /// <summary>
        /// Gets or sets the campus identifier.
        /// </summary>
        /// <value>
        /// The campus identifier.
        /// </value>
        public int? CampusId { get; set; }

        /// <summary>
        /// Gets or sets the connection opportunity identifier.
        /// </summary>
        /// <value>
        /// The connection opportunity identifier.
        /// </value>
        public int? ConnectionOpportunityId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [continue if matched].
        /// </summary>
        /// <value>
        ///   true if [continue if matched]; otherwise, false.
        /// </value>
        public bool ContinueIfMatched { get; set; }

        /// <summary>
        /// Gets or sets the data view identifier.
        /// </summary>
        /// <value>
        /// The data view identifier.
        /// </value>
        public int? DataViewId { get; set; }

        /// <summary>
        /// Gets or sets the financial account identifier.
        /// </summary>
        /// <value>
        /// The financial account identifier.
        /// </value>
        public int? FinancialAccountId { get; set; }

        /// <summary>
        /// Gets or sets the frequency sensitivity scale.
        /// This determines the point where a transaction is considered
        /// significantly later or earlier than usual.
        /// See notes on <see cref="P:Rock.Model.FinancialTransactionAlertType.AlertType">Alert Type</see> to
        /// see how this value is used for Gratitude vs Follow-Up alert types.
        /// </summary>
        /// <value>
        /// The frequency sensitivity scale.
        /// </value>
        public decimal? FrequencySensitivityScale { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [include child financial accounts].
        /// </summary>
        /// <value>
        /// true if [include child financial accounts]; otherwise, false.
        /// </value>
        public bool IncludeChildFinancialAccounts { get; set; }

        /// <summary>
        /// Gets or sets the maximum days since last gift.
        /// </summary>
        /// <value>
        /// The maximum days since last gift.
        /// </value>
        public int? MaximumDaysSinceLastGift { get; set; }

        /// <summary>
        /// Gets or sets the maximum gift amount.
        /// </summary>
        /// <value>
        /// The maximum gift amount.
        /// </value>
        public decimal? MaximumGiftAmount { get; set; }

        /// <summary>
        /// Gets or sets the maximum median gift amount.
        /// </summary>
        /// <value>
        /// The maximum median gift amount.
        /// </value>
        public decimal? MaximumMedianGiftAmount { get; set; }

        /// <summary>
        /// Gets or sets the minimum gift amount.
        /// </summary>
        /// <value>
        /// The minimum gift amount.
        /// </value>
        public decimal? MinimumGiftAmount { get; set; }

        /// <summary>
        /// Gets or sets the minimum median gift amount.
        /// </summary>
        /// <value>
        /// The minimum median gift amount.
        /// </value>
        public decimal? MinimumMedianGiftAmount { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the repeat prevention duration (days).
        /// </summary>
        /// <value>
        /// The repeat prevention duration.
        /// </value>
        public int? RepeatPreventionDuration { get; set; }

        /// <summary>
        /// Gets or sets the run days for this alert type.
        /// Null means all days of the week are run days.
        /// </summary>
        /// <value>
        /// The run days.
        /// </value>
        public int? RunDays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [send bus event].
        /// </summary>
        /// <value>
        ///   true if [send bus event]; otherwise, false.
        /// </value>
        public bool SendBusEvent { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.SystemCommunication that will be sent to the Donor (Rock.Model.FinancialTransaction.AuthorizedPersonAlias).
        /// </summary>
        /// <value>
        /// The system communication identifier.
        /// </value>
        public int? SystemCommunicationId { get; set; }

        /// <summary>
        /// Gets or sets the workflow type identifier.
        /// </summary>
        /// <value>
        /// The workflow type identifier.
        /// </value>
        public int? WorkflowTypeId { get; set; }

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