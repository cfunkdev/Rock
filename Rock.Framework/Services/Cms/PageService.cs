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
    public partial class PageService : Rock.Services.Service
    {
        private IPageRepository _repository;

        public PageService()
			: this( new EntityPageRepository() )
        { }

        public PageService( IPageRepository PageRepository )
        {
            _repository = PageRepository;
        }

        public IQueryable<Rock.Models.Cms.Page> Queryable()
        {
            return _repository.AsQueryable();
        }

        public Rock.Models.Cms.Page GetPage( int id )
        {
            return _repository.FirstOrDefault( t => t.Id == id );
        }
		
        public IEnumerable<Rock.Models.Cms.Page> GetPagesByGuid( Guid guid )
        {
            return _repository.Find( t => t.Guid == guid );
        }
		
        public IEnumerable<Rock.Models.Cms.Page> GetPagesByParentPageId( int? parentPageId )
        {
            return _repository.Find( t => t.ParentPageId == parentPageId );
        }
		
        public void AddPage( Rock.Models.Cms.Page Page )
        {
            if ( Page.Guid == Guid.Empty )
                Page.Guid = Guid.NewGuid();

            _repository.Add( Page );
        }

        public void AttachPage( Rock.Models.Cms.Page Page )
        {
            _repository.Attach( Page );
        }

		public void DeletePage( Rock.Models.Cms.Page Page )
        {
            _repository.Delete( Page );
        }

        public void Save( Rock.Models.Cms.Page Page, int? personId )
        {
            List<Rock.Models.Core.EntityChange> entityChanges = _repository.Save( Page, personId );

			if ( entityChanges != null )
            {
                Rock.Services.Core.EntityChangeService entityChangeService = new Rock.Services.Core.EntityChangeService();

                foreach ( Rock.Models.Core.EntityChange entityChange in entityChanges )
                {
                    entityChange.EntityId = Page.Id;
                    entityChangeService.AddEntityChange ( entityChange );
                    entityChangeService.Save( entityChange, personId );
                }
            }
        }
    }
}
