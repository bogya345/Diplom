using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("FactStaffsHistory", Schema = "Import")]
    public partial class FactStaffsHistory
    {
        public FactStaffsHistory()
        {
            AttachedAcPlanFshId1Navigations = new HashSet<AttachedAcPlan>();
            AttachedAcPlanFshId2Navigations = new HashSet<AttachedAcPlan>();
        }

        [Key]
        [Column("fsh_id")]
        public int FshId { get; set; }
        [Column("fs_id")]
        public int? FsId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateBegin { get; set; }
        public float? StaffCount { get; set; }
        [Column("workT_id")]
        public int? WorkTId { get; set; }

        [ForeignKey(nameof(FsId))]
        [InverseProperty(nameof(FactStaff.FactStaffsHistories))]
        public virtual FactStaff Fs { get; set; }
        [ForeignKey(nameof(WorkTId))]
        [InverseProperty(nameof(WorkType.FactStaffsHistories))]
        public virtual WorkType WorkT { get; set; }
        [InverseProperty(nameof(AttachedAcPlan.FshId1Navigation))]
        public virtual ICollection<AttachedAcPlan> AttachedAcPlanFshId1Navigations { get; set; }
        [InverseProperty(nameof(AttachedAcPlan.FshId2Navigation))]
        public virtual ICollection<AttachedAcPlan> AttachedAcPlanFshId2Navigations { get; set; }
    }
}
