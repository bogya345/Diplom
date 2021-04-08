using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("FactStaffs", Schema = "Import")]
    public partial class FactStaff
    {
        public FactStaff()
        {
            FactStaffsHistories = new HashSet<FactStaffsHistory>();
        }

        [Key]
        [Column("fs_id")]
        public int FsId { get; set; }
        [Column("ps_id")]
        public int? PsId { get; set; }
        [Column("emp_id")]
        public int? EmpId { get; set; }
        [Column("workT_id")]
        public int? WorkTId { get; set; }

        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.FactStaffs))]
        public virtual Employee Emp { get; set; }
        [ForeignKey(nameof(PsId))]
        [InverseProperty(nameof(PlanStaff.FactStaffs))]
        public virtual PlanStaff Ps { get; set; }
        [ForeignKey(nameof(WorkTId))]
        [InverseProperty(nameof(WorkType.FactStaffs))]
        public virtual WorkType WorkT { get; set; }
        [InverseProperty(nameof(FactStaffsHistory.Fs))]
        public virtual ICollection<FactStaffsHistory> FactStaffsHistories { get; set; }
    }
}
