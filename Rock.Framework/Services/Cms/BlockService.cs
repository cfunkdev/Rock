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
    public partial class BlockService : Rock.Services.Service
    {
        private IBlockRepository _repository;

        public BlockService()
			: this( new EntityBlockRepository() )
        { }

        public BlockService( IBlockRepository BlockRepository )
        {
            _repository = BlockRepository;
        }

        public IQueryable<Rock.Models.Cms.Block> Queryable()
        {
            return _repository.AsQueryable();
        }

        public Rock.Models.Cms.Block GetBlock( int id )
        {
            return _repository.FirstOrDefault( t => t.Id == id );
        }
		
        public IEnumerable<Rock.Models.Cms.Block> GetBlocksByGuid( Guid guid )
        {
            return _repository.Find( t => t.Guid == guid );
        }
		
        public IEnumerable<Rock.Models.Cms.Block> GetBlocksByName( string name )
        {
            return _repository.Find( t => t.Name == name );
        }
		
        public IEnumerable<Rock.Models.Cms.Block> GetBlocksByPath( string path )
        {
            return _repository.Find( t => t.Path == path );
        }
		
        public void AddBlock( Rock.Models.Cms.Block Block )
        {
            if ( Block.Guid == Guid.Empty )
                Block.Guid = Guid.NewGuid();

            _repository.Add( Block );
        }

        public void AttachBlock( Rock.Models.Cms.Block Block )
        {
            _repository.Attach( Block );
        }

		public void DeleteBlock( Rock.Models.Cms.Block Block )
        {
            _repository.Delete( Block );
        }

        public void Save( Rock.Models.Cms.Block Block, int? personId )
        {
            List<Rock.Models.Core.EntityChange> entityChanges = _repository.Save( Block, personId );

			if ( entityChanges != null )
            {
                Rock.Services.Core.EntityChangeService entityChangeService = new Rock.Services.Core.EntityChangeService();

                foreach ( Rock.Models.Core.EntityChange entityChange in entityChanges )
                {
                    entityChange.EntityId = Block.Id;
                    entityChangeService.AddEntityChange ( entityChange );
                    entityChangeService.Save( entityChange, personId );
                }
            }
        }
    }
}
