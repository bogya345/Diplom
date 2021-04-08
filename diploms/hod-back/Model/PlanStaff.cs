using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("PlanStaffs", Schema = "Import")]
    public partial class PlanStaff
    {
        public PlanStaff()
        {
            FactStaffs = new HashSet<FactStaff>();
        }

        [Key]
        [Column("ps_id")]
        public int PsId { get; set; }
        [Column("dep_id")]
        public int? DepId { get; set; }
        [Column("post_id")]
        public int? PostId { get; set; }

        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(Department.PlanStaffs))]
        public virtual Department Dep { get; set; }
        [ForeignKey(nameof(PostId))]
        [InverseProperty("PlanStaffs")]
        public virtual Post Post { get; set; }
        [InverseProperty(nameof(FactStaff.Ps))]
        public virtual ICollection<FactStaff> FactStaffs { get; set; }
    }
}
