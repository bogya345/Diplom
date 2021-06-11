using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class AttachedAcPlan
    {
        [Key]
        [Column("attAcPl_id")]
        public int AttAcPlId { get; set; }
        [Column("blockRec_id")]
        public long? BlockRecId { get; set; }
        [Column("group_id")]
        public int? GroupId { get; set; }
        [Column("subT_id")]
        public int? SubTId { get; set; }
        [Column("hourValue")]
        public float? HourValue { get; set; }
        [Column("fsh_id1")]
        public int? FshId1 { get; set; }
        [Column("fsh_id2")]
        public int? FshId2 { get; set; }

        [ForeignKey(nameof(BlockRecId))]
        [InverseProperty("AttachedAcPlans")]
        public virtual BlockRec BlockRec { get; set; }
        [ForeignKey(nameof(FshId1))]
        [InverseProperty(nameof(FactStaffsHistory.AttachedAcPlanFshId1Navigations))]
        public virtual FactStaffsHistory FshId1Navigation { get; set; }
        [ForeignKey(nameof(FshId2))]
        [InverseProperty(nameof(FactStaffsHistory.AttachedAcPlanFshId2Navigations))]
        public virtual FactStaffsHistory FshId2Navigation { get; set; }
        [ForeignKey(nameof(GroupId))]
        [InverseProperty("AttachedAcPlans")]
        public virtual Group Group { get; set; }
        [ForeignKey(nameof(SubTId))]
        [InverseProperty(nameof(SubjectType.AttachedAcPlans))]
        public virtual SubjectType SubT { get; set; }
    }
}
