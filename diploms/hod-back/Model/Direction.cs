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
            AcademicPlans = new HashSet<AcademicPlan>();
            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("direct_id")]
        public int DirectId { get; set; }
        [Column("educBr_id")]
        public int? EducBrId { get; set; }
        [Column("fac_id")]
        public int? FacId { get; set; }
        public int? YearObuch { get; set; }
        [Column("educForm_id")]
        public int? EducFormId { get; set; }
        [Column("katZaved_id")]
        public int? KatZavedId { get; set; }
        public int? MonthObuch { get; set; }
        [Column("is_short")]
        public bool? IsShort { get; set; }
        [Column("is_old")]
        public bool? IsOld { get; set; }

        [ForeignKey(nameof(EducBrId))]
        [InverseProperty(nameof(EducBranch.Directions))]
        public virtual EducBranch EducBr { get; set; }
        [ForeignKey(nameof(EducFormId))]
        [InverseProperty("Directions")]
        public virtual EducForm EducForm { get; set; }
        [ForeignKey(nameof(FacId))]
        [InverseProperty("Directions")]
        public virtual Fac Fac { get; set; }
        [ForeignKey(nameof(KatZavedId))]
        [InverseProperty("Directions")]
        public virtual KatZaved KatZaved { get; set; }
        [InverseProperty(nameof(AcademicPlan.Direct))]
        public virtual ICollection<AcademicPlan> AcademicPlans { get; set; }
        [InverseProperty(nameof(Group.Direct))]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
