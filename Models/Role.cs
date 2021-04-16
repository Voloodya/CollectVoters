using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CollectVoters.Models
{
    [Table("role")]
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }
        [DisplayName("Роль")]
        [Key]
        [Column("Id_Role")]
        public int IdRole { get; set; }
        [DisplayName("Роль")]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<User> User { get; set; }
    }
}
