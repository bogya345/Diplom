using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Facs", Schema = "Import")]
    public partial class Fac
    {
        public Fac()
        {
            Directions = new HashSet<Direction>();
        }

        [Key]
        [Column("fac_id")]
        public int FacId { get; set; }
        [Column("fac_name")]
        public string FacName { get; set; }
        [Column("fac_shortname")]
        [StringLength(100)]
        public string FacShortname { get; set; }
        [Column("fDateExit", TypeName = "datetime")]
        public DateTime? FDateExit { get; set; }
        [Column("dep_guid")]
        public Guid? DepGuid { get; set; }

        [ForeignKey(nameof(DepGuid))]
        [InverseProperty(nameof(Department.Facs))]
        public virtual Department DepGu { get; set; }
        [InverseProperty(nameof(Direction.Fac))]
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
