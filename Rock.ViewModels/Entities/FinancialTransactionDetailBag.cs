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
    /// FinancialTransactionDetail View Model
    /// </summary>
    public partial class FinancialTransactionDetailBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the AccountId of the Rock.Model.FinancialAccount/account that the Rock.Model.FinancialTransactionDetail.Amount of this 
        /// detail line item should be credited towards.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Rock.Model.FinancialAccount/account that is affected by this
        /// transaction detail.
        /// </value>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the transaction detail. This total amount includes any associated fees.
        /// </summary>
        /// <value>
        /// A System.Decimal representing the total amount of the transaction detail.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        /// <value>
        /// The entity id.
        /// </value>
        public int? EntityId { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public int? EntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the fee amount of the transaction detail, which is a subset of the Amount.
        /// </summary>
        /// <value>
        /// A System.Decimal representing the fee amount of the transaction detail.
        /// </value>
        public decimal? FeeAmount { get; set; }

        /// <summary>
        /// Gets or sets the fee coverage amount.
        /// </summary>
        /// <value>
        /// The fee coverage amount.
        /// </value>
        public decimal? FeeCoverageAmount { get; set; }

        /// <summary>
        /// Gets or sets the foreign currency amount.
        /// </summary>
        /// <value>
        /// The foreign currency amount.
        /// </value>
        public decimal? ForeignCurrencyAmount { get; set; }

        /// <summary>
        /// Gets or sets the summary of the transaction detail.
        /// </summary>
        /// <value>
        /// A System.String representing the summary of the transaction detail.
        /// </value>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the TransactionId of the Rock.Model.FinancialTransaction that this 
        /// detail item is a part of.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the TransactionDetailId of the Rock.Model.FinancialTransaction
        /// that this detail item is a part of.
        /// </value>
        public int TransactionId { get; set; }

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
