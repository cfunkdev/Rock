//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rock.Models.Cms;
using Rock.Repository.Cms;

namespace Rock.Services.Cms
{
    public partial class BlogCategoryService : Rock.Services.Service
    {
        private IBlogCategoryRepository _repository;

        public BlogCategoryService()
			: this( new EntityBlogCategoryRepository() )
        { }

        public BlogCategoryService( IBlogCategoryRepository BlogCategoryRepository )
        {
            _repository = BlogCategoryRepository;
        }

        public IQueryable<Rock.Models.Cms.BlogCategory> Queryable()
        {
            return _repository.AsQueryable();
        }

        public Rock.Models.Cms.BlogCategory GetBlogCategory( int id )
        {
            return _repository.FirstOrDefault( t => t.Id == id );
        }
		
        public void AddBlogCategory( Rock.Models.Cms.BlogCategory BlogCategory )
        {
            if ( BlogCategory.Guid == Guid.Empty )
                BlogCategory.Guid = Guid.NewGuid();

            _repository.Add( BlogCategory );
        }

        public void AttachBlogCategory( Rock.Models.Cms.BlogCategory BlogCategory )
        {
            _repository.Attach( BlogCategory );
        }

		public void DeleteBlogCategory( Rock.Models.Cms.BlogCategory BlogCategory )
        {
            _repository.Delete( BlogCategory );
        }

        public void Save( Rock.Models.Cms.BlogCategory BlogCategory, int? personId )
        {
            List<Rock.Models.Core.EntityChange> entityChanges = _repository.Save( BlogCategory, personId );

			if ( entityChanges != null )
            {
                Rock.Services.Core.EntityChangeService entityChangeService = new Rock.Services.Core.EntityChangeService();

                foreach ( Rock.Models.Core.EntityChange entityChange in entityChanges )
                {
                    entityChange.EntityId = BlogCategory.Id;
                    entityChangeService.AddEntityChange ( entityChange );
                    entityChangeService.Save( entityChange, personId );
                }
            }
        }
    }
}
