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
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Rock.Models;

namespace Rock.Models.Groups
{
    [Table( "groupsGroupType" )]
    public partial class GroupType : ModelWithAttributes, IAuditable
    {
		[DataMember]
		public Guid Guid { get; set; }
		
		[DataMember]
		public bool System { get; set; }
		
		[MaxLength( 100 )]
		[DataMember]
		public string Name { get; set; }
		
		[DataMember]
		public string Description { get; set; }
		
		[DataMember]
		public int DefaultGroupRoleId { get; set; }
		
		[DataMember]
		public DateTime? CreatedDateTime { get; set; }
		
		[DataMember]
		public DateTime? ModifiedDateTime { get; set; }
		
		[DataMember]
		public int? CreatedByPersonId { get; set; }
		
		[DataMember]
		public int? ModifiedByPersonId { get; set; }
		
		[NotMapped]
		public override string AuthEntity { get { return "Groups.GroupType"; } }

		public virtual ICollection<Group> Groups { get; set; }

		public virtual ICollection<GroupType> ChildGroupTypes { get; set; }

		public virtual ICollection<GroupType> ParentGroupTypes { get; set; }

		public virtual ICollection<GroupRole> GroupRoles { get; set; }

		public virtual Crm.Person CreatedByPerson { get; set; }

		public virtual Crm.Person ModifiedByPerson { get; set; }

		public virtual GroupRole DefaultGroupRole { get; set; }
    }

    public partial class GroupTypeConfiguration : EntityTypeConfiguration<GroupType>
    {
        public GroupTypeConfiguration()
        {
			this.HasMany( p => p.ChildGroupTypes ).WithMany( c => c.ParentGroupTypes ).Map( m => { m.MapLeftKey("ChildGroupTypeId"); m.MapRightKey("ParentGroupTypeId"); m.ToTable("groupsGroupTypeAssociation" ); } );
			this.HasOptional( p => p.CreatedByPerson ).WithMany().HasForeignKey( p => p.CreatedByPersonId );
			this.HasOptional( p => p.ModifiedByPerson ).WithMany().HasForeignKey( p => p.ModifiedByPersonId );
			this.HasRequired( p => p.DefaultGroupRole ).WithMany().HasForeignKey( p => p.DefaultGroupRoleId );
		}
    }
}
