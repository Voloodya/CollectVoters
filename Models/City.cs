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
    [Table("city")]
    public partial class City
    {
        public City()
        {
            Friends = new HashSet<Friend>();
        }

        [Key]
        [Column("Id_City")]
        public int IdCity { get; set; }
        [DisplayName("Насел. п-т")]
        [Column(TypeName = "varchar(256)")]
        public string Name { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<Friend> Friends { get; set; }
    }
}
