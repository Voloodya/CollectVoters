using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CollectVoters.Models
{
    [Table("district")]
    public partial class District
    {
        public District()
        {
            Friends = new HashSet<Friend>();
        }

        [Key]
        [Column("Id_District")]
        public int IdDistrict { get; set; }
        [Column(TypeName = "varchar(256)")]
        public string Name { get; set; }

        [InverseProperty("District")]
        public virtual ICollection<Friend> Friends { get; set; }
    }
}
