using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("EducBranches", Schema = "Import")]
    public partial class EducBranch
    {
        public EducBranch()
        {
            Directions = new HashSet<Direction>();
        }

        [Key]
        [Column("eBr_id")]
        public int EBrId { get; set; }
        [Column("eBr_name")]
        [StringLength(100)]
        public string EBrName { get; set; }
        [Column("eBr_shortname")]
        [StringLength(50)]
        public string EBrShortname { get; set; }
        [Column("eBr_code")]
        [StringLength(10)]
        public string EBrCode { get; set; }
        [Column("eLvl_id")]
        public int? ELvlId { get; set; }

        [ForeignKey(nameof(ELvlId))]
        [InverseProperty(nameof(EducLevel.EducBranches))]
        public virtual EducLevel ELvl { get; set; }
        [InverseProperty(nameof(Direction.EBr))]
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
