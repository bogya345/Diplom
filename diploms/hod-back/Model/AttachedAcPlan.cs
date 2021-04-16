using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
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
        [Column("fsh_id")]
        public int? FshId { get; set; }

        [ForeignKey(nameof(BlockRecId))]
        [InverseProperty("AttachedAcPlans")]
        public virtual BlockRec BlockRec { get; set; }
        [ForeignKey(nameof(FshId))]
        [InverseProperty(nameof(FactStaffsHistory.AttachedAcPlans))]
        public virtual FactStaffsHistory Fsh { get; set; }
        [ForeignKey(nameof(GroupId))]
        [InverseProperty("AttachedAcPlans")]
        public virtual Group Group { get; set; }
        [ForeignKey(nameof(SubTId))]
        [InverseProperty(nameof(SubjectType.AttachedAcPlans))]
        public virtual SubjectType SubT { get; set; }

    }
}
