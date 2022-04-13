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

using Rock.Attribute;
using Rock.Data;
using Rock.ViewModels;
using Rock.ViewModels.Entities;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// CommunicationRecipient Service class
    /// </summary>
    public partial class CommunicationRecipientService : Service<CommunicationRecipient>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationRecipientService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public CommunicationRecipientService(RockContext context) : base(context)
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
        public bool CanDelete( CommunicationRecipient item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// CommunicationRecipient View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( CommunicationRecipient ) )]
    public partial class CommunicationRecipientViewModelHelper : ViewModelHelper<CommunicationRecipient, CommunicationRecipientBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override CommunicationRecipientBag CreateViewModel( CommunicationRecipient model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new CommunicationRecipientBag
            {
                Id = model.Id,
                Guid = model.Guid,
                AdditionalMergeValuesJson = model.AdditionalMergeValuesJson,
                CommunicationId = model.CommunicationId,
                MediumEntityTypeId = model.MediumEntityTypeId,
                OpenedClient = model.OpenedClient,
                OpenedDateTime = model.OpenedDateTime,
                PersonalDeviceId = model.PersonalDeviceId,
                PersonAliasId = model.PersonAliasId,
                ResponseCode = model.ResponseCode,
                SendDateTime = model.SendDateTime,
                SentMessage = model.SentMessage,
                Status = ( int ) model.Status,
                StatusNote = model.StatusNote,
                TransportEntityTypeName = model.TransportEntityTypeName,
                UniqueMessageId = model.UniqueMessageId,
                CreatedDateTime = model.CreatedDateTime,
                ModifiedDateTime = model.ModifiedDateTime,
                CreatedByPersonAliasId = model.CreatedByPersonAliasId,
                ModifiedByPersonAliasId = model.ModifiedByPersonAliasId,
            };

            AddAttributesToViewModel( model, viewModel, currentPerson, loadAttributes );
            ApplyAdditionalPropertiesAndSecurityToViewModel( model, viewModel, currentPerson, loadAttributes );
            return viewModel;
        }
    }


    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class CommunicationRecipientExtensionMethods
    {
        /// <summary>
        /// Clones this CommunicationRecipient object to a new CommunicationRecipient object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static CommunicationRecipient Clone( this CommunicationRecipient source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as CommunicationRecipient;
            }
            else
            {
                var target = new CommunicationRecipient();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this CommunicationRecipient object to a new CommunicationRecipient object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static CommunicationRecipient CloneWithoutIdentity( this CommunicationRecipient source )
        {
            var target = new CommunicationRecipient();
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
        /// Copies the properties from another CommunicationRecipient object to this CommunicationRecipient object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this CommunicationRecipient target, CommunicationRecipient source )
        {
            target.Id = source.Id;
            target.AdditionalMergeValuesJson = source.AdditionalMergeValuesJson;
            target.CommunicationId = source.CommunicationId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.MediumEntityTypeId = source.MediumEntityTypeId;
            target.OpenedClient = source.OpenedClient;
            target.OpenedDateTime = source.OpenedDateTime;
            target.PersonalDeviceId = source.PersonalDeviceId;
            target.PersonAliasId = source.PersonAliasId;
            target.ResponseCode = source.ResponseCode;
            target.SendDateTime = source.SendDateTime;
            target.SentMessage = source.SentMessage;
            target.Status = source.Status;
            target.StatusNote = source.StatusNote;
            target.TransportEntityTypeName = source.TransportEntityTypeName;
            target.UniqueMessageId = source.UniqueMessageId;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }

        /// <summary>
        /// Creates a view model from this entity
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson" >The currentPerson.</param>
        /// <param name="loadAttributes" >Load attributes?</param>
        public static CommunicationRecipientBag ToViewModel( this CommunicationRecipient model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new CommunicationRecipientViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
