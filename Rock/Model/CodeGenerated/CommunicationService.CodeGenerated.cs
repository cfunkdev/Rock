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
using System.Collections.Generic;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Communication Service class
    /// </summary>
    public partial class CommunicationService : Service<Communication>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public CommunicationService(RockContext context) : base(context)
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
        public bool CanDelete( Communication item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<CommunicationResponse>( Context ).Queryable().Any( a => a.RelatedCommunicationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Communication.FriendlyTypeName, CommunicationResponse.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    public partial class Communication : IHasQueryableAttributes<Communication.CommunicationQueryableAttributeValue>
    {
        /// <inheritdoc/>
        public virtual ICollection<CommunicationQueryableAttributeValue> EntityAttributeValues { get; set; } 

        /// <inheritdoc/>
        public class CommunicationQueryableAttributeValue : QueryableAttributeValue
        {
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class CommunicationExtensionMethods
    {
        /// <summary>
        /// Clones this Communication object to a new Communication object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static Communication Clone( this Communication source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as Communication;
            }
            else
            {
                var target = new Communication();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this Communication object to a new Communication object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Communication CloneWithoutIdentity( this Communication source )
        {
            var target = new Communication();
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
        /// Copies the properties from another Communication object to this Communication object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this Communication target, Communication source )
        {
            target.Id = source.Id;
            target.AdditionalMergeFieldsJson = source.AdditionalMergeFieldsJson;
            target.BCCEmails = source.BCCEmails;
            target.CCEmails = source.CCEmails;
            target.CommunicationTemplateId = source.CommunicationTemplateId;
            target.CommunicationType = source.CommunicationType;
            target.EnabledLavaCommands = source.EnabledLavaCommands;
            target.ExcludeDuplicateRecipientAddress = source.ExcludeDuplicateRecipientAddress;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.FromEmail = source.FromEmail;
            target.FromName = source.FromName;
            target.FutureSendDateTime = source.FutureSendDateTime;
            target.IsBulkCommunication = source.IsBulkCommunication;
            target.ListGroupId = source.ListGroupId;
            target.Message = source.Message;
            target.MessageMetaData = source.MessageMetaData;
            target.Name = source.Name;
            target.PushData = source.PushData;
            target.PushImageBinaryFileId = source.PushImageBinaryFileId;
            target.PushMessage = source.PushMessage;
            target.PushOpenAction = source.PushOpenAction;
            target.PushOpenMessage = source.PushOpenMessage;
            target.PushSound = source.PushSound;
            target.PushTitle = source.PushTitle;
            target.ReplyToEmail = source.ReplyToEmail;
            target.ReviewedDateTime = source.ReviewedDateTime;
            target.ReviewerNote = source.ReviewerNote;
            target.ReviewerPersonAliasId = source.ReviewerPersonAliasId;
            target.SegmentCriteria = source.SegmentCriteria;
            target.Segments = source.Segments;
            target.SendDateTime = source.SendDateTime;
            target.SenderPersonAliasId = source.SenderPersonAliasId;
            #pragma warning disable 612, 618
            target.SMSFromDefinedValueId = source.SMSFromDefinedValueId;
            #pragma warning restore 612, 618
            target.SmsFromSystemPhoneNumberId = source.SmsFromSystemPhoneNumberId;
            target.SMSMessage = source.SMSMessage;
            target.Status = source.Status;
            target.Subject = source.Subject;
            target.SystemCommunicationId = source.SystemCommunicationId;
            target.UrlReferrer = source.UrlReferrer;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}
