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
    /// FinancialPersonSavedAccount View Model
    /// </summary>
    public partial class FinancialPersonSavedAccountBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the Rock.Model.FinancialGateway identifier.
        /// </summary>
        /// <value>
        /// The gateway identifier.
        /// </value>
        public int? FinancialGatewayId { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.FinancialPaymentDetail identifier.
        /// </summary>
        /// <value>
        /// The financial payment detail identifier.
        /// </value>
        public int? FinancialPaymentDetailId { get; set; }

        /// <summary>
        /// Gets or sets the Gateway Person Identifier.
        /// This would indicate id the customer vault information on the gateway (for gateways that have customer vaults (NMI and MyWell) )
        /// </summary>
        /// <value>
        /// A System.String representing the Gateway Person Identifier of the account.
        /// </value>
        public string GatewayPersonIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public int? GroupId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this saved account is the default payment option for the given person.
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if this saved account is the default payment option for the given person, otherwise is false.
        /// </value>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this saved account was created by and is a part of the Rock core system/framework.
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if this saved account is part of the Rock core system/framework, otherwise is false.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the name of the saved account. This property is required.
        /// </summary>
        /// <value>
        /// A System.String representing the name of the account.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.PersonAlias identifier.
        /// </summary>
        /// <value>
        /// The person alias identifier.
        /// </value>
        public int? PersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the foreign currency code value identifier.
        /// </summary>
        /// <value>
        /// The foreign currency code value identifier.
        /// </value>
        public int? PreferredForeignCurrencyCodeValueId { get; set; }

        /// <summary>
        /// Gets or sets a reference identifier needed by the payment provider to use as a payment token.
        /// For gateways that have a concept of a customer vault (NMI and MyWell), this would be the customer vault id Rock.Model.FinancialPersonSavedAccount.GatewayPersonIdentifier
        /// For gateways that use a source transaction for payment info (PayFlowPro), this would be the Rock.Model.FinancialPersonSavedAccount.TransactionCode
        /// </summary>
        /// <value>
        /// A System.String reference identifier needed by the payment provider to use as a payment token (customer vault id).
        /// </value>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the transaction code that was used as the "source transaction", and is used by some gateways (PayFlowPro) to lookup the payment info.
        /// For gateways that have the concept of a Customer Vault (NMI and MyWell), Rock.Model.FinancialPersonSavedAccount.GatewayPersonIdentifier is what would be used.
        /// </summary>
        /// <value>
        /// A System.String representing the transaction code of the transaction.
        /// </value>
        public string TransactionCode { get; set; }

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
