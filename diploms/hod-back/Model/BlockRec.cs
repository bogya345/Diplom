using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class BlockRec
    {
        public BlockRec()
        {
            AttachedAcPlans = new HashSet<AttachedAcPlan>();
        }

        [Key]
        [Column("blockRec_id")]
        public long BlockRecId { get; set; }
        [Column("acPl_id")]
        public int? AcPlId { get; set; }
        [Column("semestrNum")]
        public int? SemestrNum { get; set; }
        [Column("inPlan")]
        public int? InPlan { get; set; }
        [Column("sub_id")]
        public int? SubId { get; set; }
        [Column("blockNum_id")]
        public int? BlockNumId { get; set; }
        [Column("ze")]
        public float? Ze { get; set; }
        [Column("total")]
        public float? Total { get; set; }
        [Column("les")]
        public float? Les { get; set; }
        [Column("lab")]
        public float? Lab { get; set; }
        [Column("pr")]
        public float? Pr { get; set; }
        [Column("iz")]
        public float? Iz { get; set; }
        [Column("ak")]
        public float? Ak { get; set; }
        [Column("kpr")]
        public float? Kpr { get; set; }
        [Column("sr")]
        public float? Sr { get; set; }
        [Column("controll")]
        public float? Controll { get; set; }

        [ForeignKey(nameof(AcPlId))]
        [InverseProperty(nameof(AcPlan.BlockRecs))]
        public virtual AcPlan AcPl { get; set; }
        [ForeignKey(nameof(BlockNumId))]
        [InverseProperty("BlockRecs")]
        public virtual BlockNum BlockNum { get; set; }
        [ForeignKey(nameof(SubId))]
        [InverseProperty(nameof(Subject.BlockRecs))]
        public virtual Subject Sub { get; set; }
        [InverseProperty(nameof(AttachedAcPlan.BlockRec))]
        public virtual ICollection<AttachedAcPlan> AttachedAcPlans { get; set; }
    }
}
