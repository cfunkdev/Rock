﻿//------------------------------------------------------------------------------
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
    /// InteractionSessionLocation Service class
    /// </summary>
    public partial class InteractionSessionLocationService : Service<InteractionSessionLocation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionSessionLocationService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public InteractionSessionLocationService(RockContext context) : base(context)
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
        public bool CanDelete( InteractionSessionLocation item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// InteractionSessionLocation View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( InteractionSessionLocation ) )]
    public partial class InteractionSessionLocationViewModelHelper : ViewModelHelper<InteractionSessionLocation, InteractionSessionLocationBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override InteractionSessionLocationBag CreateViewModel( InteractionSessionLocation model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new InteractionSessionLocationBag
            {
                Id = model.Id,
                Guid = model.Guid,
                CountryCode = model.CountryCode,
                CountryValueId = model.CountryValueId,
                GeoPoint = model.GeoPoint,
                IpAddress = model.IpAddress,
                ISP = model.ISP,
                Location = model.Location,
                LookupDateTime = model.LookupDateTime,
                PostalCode = model.PostalCode,
                RegionCode = model.RegionCode,
                RegionValueId = model.RegionValueId,
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
    public static partial class InteractionSessionLocationExtensionMethods
    {
        /// <summary>
        /// Clones this InteractionSessionLocation object to a new InteractionSessionLocation object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static InteractionSessionLocation Clone( this InteractionSessionLocation source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as InteractionSessionLocation;
            }
            else
            {
                var target = new InteractionSessionLocation();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this InteractionSessionLocation object to a new InteractionSessionLocation object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static InteractionSessionLocation CloneWithoutIdentity( this InteractionSessionLocation source )
        {
            var target = new InteractionSessionLocation();
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
        /// Copies the properties from another InteractionSessionLocation object to this InteractionSessionLocation object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this InteractionSessionLocation target, InteractionSessionLocation source )
        {
            target.Id = source.Id;
            target.CountryCode = source.CountryCode;
            target.CountryValueId = source.CountryValueId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.GeoPoint = source.GeoPoint;
            target.IpAddress = source.IpAddress;
            target.ISP = source.ISP;
            target.Location = source.Location;
            target.LookupDateTime = source.LookupDateTime;
            target.PostalCode = source.PostalCode;
            target.RegionCode = source.RegionCode;
            target.RegionValueId = source.RegionValueId;
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
        public static InteractionSessionLocationBag ToViewModel( this InteractionSessionLocation model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new InteractionSessionLocationViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}
