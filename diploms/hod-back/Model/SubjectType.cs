using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class SubjectType
    {
        public SubjectType()
        {
            AttachedAcPlans = new HashSet<AttachedAcPlan>();
        }

        [Key]
        [Column("subT_id")]
        public int SubTId { get; set; }
        [Column("subT_name")]
        [StringLength(100)]
        public string SubTName { get; set; }
        [Column("subT_nameInPlan")]
        [StringLength(30)]
        public string SubTNameInPlan { get; set; }

        [InverseProperty(nameof(AttachedAcPlan.SubT))]
        public virtual ICollection<AttachedAcPlan> AttachedAcPlans { get; set; }
    }
}
