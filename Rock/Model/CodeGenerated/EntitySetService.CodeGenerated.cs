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
    /// EntitySet Service class
    /// </summary>
    public partial class EntitySetService : Service<EntitySet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySetService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public EntitySetService(RockContext context) : base(context)
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
        public bool CanDelete( EntitySet item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<EntitySet>( Context ).Queryable().Any( a => a.ParentEntitySetId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} contains one or more child {1}.", EntitySet.FriendlyTypeName, EntitySet.FriendlyTypeName.Pluralize().ToLower() );
                return false;
            }
            return true;
        }
    }

    public partial class EntitySet : IHasQueryableAttributes<EntitySet.EntitySetQueryableAttributeValue>
    {
        /// <inheritdoc/>
        public virtual ICollection<EntitySetQueryableAttributeValue> EntityAttributeValues { get; set; } 

        /// <inheritdoc/>
        public class EntitySetQueryableAttributeValue : QueryableAttributeValue
        {
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class EntitySetExtensionMethods
    {
        /// <summary>
        /// Clones this EntitySet object to a new EntitySet object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static EntitySet Clone( this EntitySet source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as EntitySet;
            }
            else
            {
                var target = new EntitySet();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this EntitySet object to a new EntitySet object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static EntitySet CloneWithoutIdentity( this EntitySet source )
        {
            var target = new EntitySet();
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
        /// Copies the properties from another EntitySet object to this EntitySet object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this EntitySet target, EntitySet source )
        {
            target.Id = source.Id;
            target.EntitySetPurposeValueId = source.EntitySetPurposeValueId;
            target.EntityTypeId = source.EntityTypeId;
            target.ExpireDateTime = source.ExpireDateTime;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.Name = source.Name;
            target.Note = source.Note;
            target.Order = source.Order;
            target.ParentEntitySetId = source.ParentEntitySetId;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}
