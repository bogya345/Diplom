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
        [StringLength(100)]
        public string FacName { get; set; }
        [Column("fac_shortname")]
        [StringLength(50)]
        public string FacShortname { get; set; }
        [Column("dateExit", TypeName = "datetime")]
        public DateTime? DateExit { get; set; }
        [Column("dep_guid")]
        public Guid? DepGuid { get; set; }

        [InverseProperty(nameof(Direction.Fac))]
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
