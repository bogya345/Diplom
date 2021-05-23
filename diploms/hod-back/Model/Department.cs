using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Departments", Schema = "Import")]
    public partial class Department
    {
        public Department()
        {
            AcPlanDeps = new HashSet<AcPlanDep>();
            Directions = new HashSet<Direction>();
            PlanStaffs = new HashSet<PlanStaff>();
        }

        [Key]
        [Column("dep_id")]
        public int DepId { get; set; }
        [Column("dep_guid")]
        public Guid? DepGuid { get; set; }
        [Column("dep_name")]
        [StringLength(100)]
        public string DepName { get; set; }
        [Column("dep_shortname")]
        [StringLength(50)]
        public string DepShortname { get; set; }
        [Column("depT_id")]
        public int? DepTId { get; set; }
        [Column("dateCreate", TypeName = "date")]
        public DateTime? DateCreate { get; set; }
        [Column("dateExit", TypeName = "date")]
        public DateTime? DateExit { get; set; }
        [Column("role_id")]
        public int? RoleId { get; set; }

        [ForeignKey(nameof(DepTId))]
        [InverseProperty(nameof(DepType.Departments))]
        public virtual DepType DepT { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Departments")]
        public virtual Role Role { get; set; }
        [InverseProperty(nameof(AcPlanDep.Dep))]
        public virtual ICollection<AcPlanDep> AcPlanDeps { get; set; }
        [InverseProperty(nameof(Direction.Dep))]
        public virtual ICollection<Direction> Directions { get; set; }
        [InverseProperty(nameof(PlanStaff.Dep))]
        public virtual ICollection<PlanStaff> PlanStaffs { get; set; }
    }
}
