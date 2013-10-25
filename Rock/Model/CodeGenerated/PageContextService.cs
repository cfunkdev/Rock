//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// PageContext Service class
    /// </summary>
    public partial class PageContextService : Service<PageContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageContextService"/> class
        /// </summary>
        public PageContextService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageContextService"/> class
        /// </summary>
        /// <param name="repository">The repository.</param>
        public PageContextService(IRepository<PageContext> repository) : base(repository)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageContextService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public PageContextService(RockContext context) : base(context)
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
        public bool CanDelete( PageContext item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class PageContextExtensionMethods
    {
        /// <summary>
        /// Clones this PageContext object to a new PageContext object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static PageContext Clone( this PageContext source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as PageContext;
            }
            else
            {
                var target = new PageContext();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another PageContext object to this PageContext object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this PageContext target, PageContext source )
        {
            target.IsSystem = source.IsSystem;
            target.PageId = source.PageId;
            target.Entity = source.Entity;
            target.IdParameter = source.IdParameter;
            target.CreatedDateTime = source.CreatedDateTime;
            target.Id = source.Id;
            target.Guid = source.Guid;

        }
    }
}
