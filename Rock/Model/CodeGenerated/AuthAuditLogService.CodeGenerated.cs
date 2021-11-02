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
using Rock.ViewModel;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// AuthAuditLog Service class
    /// </summary>
    public partial class AuthAuditLogService : Service<AuthAuditLog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthAuditLogService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public AuthAuditLogService(RockContext context) : base(context)
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
        public bool CanDelete( AuthAuditLog item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class AuthAuditLogExtensionMethods
    {
        /// <summary>
        /// Clones this AuthAuditLog object to a new AuthAuditLog object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static AuthAuditLog Clone( this AuthAuditLog source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as AuthAuditLog;
            }
            else
            {
                var target = new AuthAuditLog();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this AuthAuditLog object to a new AuthAuditLog object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static AuthAuditLog CloneWithoutIdentity( this AuthAuditLog source )
        {
            var target = new AuthAuditLog();
            target.CopyPropertiesFrom( source );

            target.Id = 0;
            target.Guid = Guid.NewGuid();
            target.ForeignKey = null;
            target.ForeignId = null;
            target.ForeignGuid = null;

            return target;
        }

        /// <summary>
        /// Copies the properties from another AuthAuditLog object to this AuthAuditLog object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this AuthAuditLog target, AuthAuditLog source )
        {
            target.Id = source.Id;
            target.Action = source.Action;
            target.ChangeByPersonAliasId = source.ChangeByPersonAliasId;
            target.ChangeDateTime = source.ChangeDateTime;
            target.ChangeType = source.ChangeType;
            target.EntityId = source.EntityId;
            target.EntityTypeId = source.EntityTypeId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.GroupId = source.GroupId;
            target.PersonAliasId = source.PersonAliasId;
            target.PostAllowOrDeny = source.PostAllowOrDeny;
            target.PostOrder = source.PostOrder;
            target.PreAllowOrDeny = source.PreAllowOrDeny;
            target.PreOrder = source.PreOrder;
            target.SpecialRole = source.SpecialRole;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }

    }

}
