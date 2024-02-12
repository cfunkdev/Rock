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

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// FinancialScheduledTransaction Service class
    /// </summary>
    public partial class FinancialScheduledTransactionService : Service<FinancialScheduledTransaction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialScheduledTransactionService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public FinancialScheduledTransactionService(RockContext context) : base(context)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( FinancialScheduledTransaction item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<FinancialTransaction>( Context ).Queryable().Any( a => a.ScheduledTransactionId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", FinancialScheduledTransaction.FriendlyTypeName, FinancialTransaction.FriendlyTypeName );
                return false;
            }

            if ( new Service<Registration>( Context ).Queryable().Any( a => a.PaymentPlanFinancialScheduledTransactionId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", FinancialScheduledTransaction.FriendlyTypeName, Registration.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class FinancialScheduledTransactionExtensionMethods
    {
        /// <summary>
        /// Clones this FinancialScheduledTransaction object to a new FinancialScheduledTransaction object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static FinancialScheduledTransaction Clone( this FinancialScheduledTransaction source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as FinancialScheduledTransaction;
            }
            else
            {
                var target = new FinancialScheduledTransaction();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this FinancialScheduledTransaction object to a new FinancialScheduledTransaction object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static FinancialScheduledTransaction CloneWithoutIdentity( this FinancialScheduledTransaction source )
        {
            var target = new FinancialScheduledTransaction();
            target.CopyPropertiesFrom( source );

            target.Id = 0;
            target.Guid = Guid.NewGuid();
            target.ForeignKey = null;
            target.ForeignId = null;
            target.ForeignGuid = null;
            target.CreatedByPersonAliasId = null;
            target.CreatedDateTime = RockDateTime.Now;
            target.ModifiedByPersonAliasId = null;
            target.ModifiedDateTime = RockDateTime.Now;

            return target;
        }

        /// <summary>
        /// Copies the properties from another FinancialScheduledTransaction object to this FinancialScheduledTransaction object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this FinancialScheduledTransaction target, FinancialScheduledTransaction source )
        {
            target.Id = source.Id;
            target.AuthorizedPersonAliasId = source.AuthorizedPersonAliasId;
            target.CardReminderDate = source.CardReminderDate;
            target.EndDate = source.EndDate;
            target.FinancialGatewayId = source.FinancialGatewayId;
            target.FinancialPaymentDetailId = source.FinancialPaymentDetailId;
            target.ForeignCurrencyCodeValueId = source.ForeignCurrencyCodeValueId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.GatewayScheduleId = source.GatewayScheduleId;
            target.InactivateDateTime = source.InactivateDateTime;
            target.IsActive = source.IsActive;
            target.LastRemindedDate = source.LastRemindedDate;
            target.LastStatusUpdateDateTime = source.LastStatusUpdateDateTime;
            target.NextPaymentDate = source.NextPaymentDate;
            target.NumberOfPayments = source.NumberOfPayments;
            target.PreviousGatewayScheduleIdsJson = source.PreviousGatewayScheduleIdsJson;
            target.SourceTypeValueId = source.SourceTypeValueId;
            target.StartDate = source.StartDate;
            target.Status = source.Status;
            target.StatusMessage = source.StatusMessage;
            target.Summary = source.Summary;
            target.TransactionCode = source.TransactionCode;
            target.TransactionFrequencyValueId = source.TransactionFrequencyValueId;
            target.TransactionTypeValueId = source.TransactionTypeValueId;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}
