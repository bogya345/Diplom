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
        [Column("educBr_id")]
        public int EducBrId { get; set; }
        [Column("educBr_name")]
        public string EducBrName { get; set; }
        [Column("educBr_shortName")]
        [StringLength(50)]
        public string EducBrShortName { get; set; }
        [Column("educLvl_id")]
        public int? EducLvlId { get; set; }
        [Column("dDate_spec", TypeName = "datetime")]
        public DateTime? DDateSpec { get; set; }
        [Column("spDateExit", TypeName = "datetime")]
        public DateTime? SpDateExit { get; set; }

        [ForeignKey(nameof(EducLvlId))]
        [InverseProperty(nameof(EducLevel.EducBranches))]
        public virtual EducLevel EducLvl { get; set; }
        [InverseProperty(nameof(Direction.EducBr))]
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
