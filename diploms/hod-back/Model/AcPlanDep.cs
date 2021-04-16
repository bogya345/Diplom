using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class AcPlanDep
    {
        public AcPlanDep()
        {
            Subjects = new HashSet<Subject>();
        }

        [Key]
        [Column("acPlDep_id")]
        public int AcPlDepId { get; set; }
        [Column("acPlDep_name")]
        public string AcPlDepName { get; set; }
        [Column("dep_id")]
        public int? DepId { get; set; }

        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(Department.AcPlanDeps))]
        public virtual Department Dep { get; set; }
        [InverseProperty(nameof(Subject.AcPlDep))]
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
