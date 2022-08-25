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
    /// BenevolenceRequestDocument Service class
    /// </summary>
    public partial class BenevolenceRequestDocumentService : Service<BenevolenceRequestDocument>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenevolenceRequestDocumentService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public BenevolenceRequestDocumentService(RockContext context) : base(context)
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
        public bool CanDelete( BenevolenceRequestDocument item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// BenevolenceRequestDocument View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( BenevolenceRequestDocument ) )]
    public partial class BenevolenceRequestDocumentViewModelHelper : ViewModelHelper<BenevolenceRequestDocument, BenevolenceRequestDocumentBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override BenevolenceRequestDocumentBag CreateViewModel( BenevolenceRequestDocument model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new BenevolenceRequestDocumentBag
            {
                IdKey = model.IdKey,
                BenevolenceRequestId = model.BenevolenceRequestId,
                BinaryFileId = model.BinaryFileId,
                Order = model.Order,
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
    public static partial class BenevolenceRequestDocumentExtensionMethods
    {
        /// <summary>
        /// Clones this BenevolenceRequestDocument object to a new BenevolenceRequestDocument object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static BenevolenceRequestDocument Clone( this BenevolenceRequestDocument source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as BenevolenceRequestDocument;
            }
            else
            {
                var target = new BenevolenceRequestDocument();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this BenevolenceRequestDocument object to a new BenevolenceRequestDocument object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static BenevolenceRequestDocument CloneWithoutIdentity( this BenevolenceRequestDocument source )
        {
            var target = new BenevolenceRequestDocument();
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
        /// Copies the properties from another BenevolenceRequestDocument object to this BenevolenceRequestDocument object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this BenevolenceRequestDocument target, BenevolenceRequestDocument source )
        {
            target.Id = source.Id;
            target.BenevolenceRequestId = source.BenevolenceRequestId;
            target.BinaryFileId = source.BinaryFileId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.Order = source.Order;
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
        public static BenevolenceRequestDocumentBag ToViewModel( this BenevolenceRequestDocument model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new BenevolenceRequestDocumentViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
