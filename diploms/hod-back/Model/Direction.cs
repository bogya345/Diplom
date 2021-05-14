using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Directions", Schema = "Import")]
    public partial class Direction
    {
        public Direction()
        {
            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("dir_id")]
        public int DirId { get; set; }
        [Column("eBr_id")]
        public int? EBrId { get; set; }
        [Column("fac_id")]
        public int? FacId { get; set; }
        public int? YearObuch { get; set; }
        [Column("eForm_id")]
        public int? EFormId { get; set; }
        [Column("kZav_id")]
        public int? KZavId { get; set; }
        public int? MonthObuch { get; set; }
        [Column("is_old")]
        public bool? IsOld { get; set; }
        [Column("acPl_id")]
        public int? AcPlId { get; set; }
        [Column("dep_id")]
        public int? DepId { get; set; }
        [Column("startYear")]
        [StringLength(4)]
        public string StartYear { get; set; }

        [ForeignKey(nameof(AcPlId))]
        [InverseProperty(nameof(AcPlan.Directions))]
        public virtual AcPlan AcPl { get; set; }
        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(Department.Directions))]
        public virtual Department Dep { get; set; }
        [ForeignKey(nameof(EBrId))]
        [InverseProperty(nameof(EducBranch.Directions))]
        public virtual EducBranch EBr { get; set; }
        [ForeignKey(nameof(EFormId))]
        [InverseProperty(nameof(EducForm.Directions))]
        public virtual EducForm EForm { get; set; }
        [ForeignKey(nameof(FacId))]
        [InverseProperty("Directions")]
        public virtual Fac Fac { get; set; }
        [ForeignKey(nameof(KZavId))]
        [InverseProperty(nameof(KatZaved.Directions))]
        public virtual KatZaved KZav { get; set; }
        [InverseProperty(nameof(Group.Dir))]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
