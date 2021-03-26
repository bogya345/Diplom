using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class AcademicPlan
    {
        public AcademicPlan()
        {
            BlockRecs = new HashSet<BlockRec>();
        }

        [Key]
        [Column("acPlan_id")]
        public int AcPlanId { get; set; }
        [Column("direct_id")]
        public int? DirectId { get; set; }
        [Column("group_id")]
        public int? GroupId { get; set; }
        [Column("executionProgresss")]
        public int? ExecutionProgresss { get; set; }

        [ForeignKey(nameof(DirectId))]
        [InverseProperty(nameof(Direction.AcademicPlans))]
        public virtual Direction Direct { get; set; }
        [ForeignKey(nameof(GroupId))]
        [InverseProperty("AcademicPlans")]
        public virtual Group Group { get; set; }
        [InverseProperty(nameof(BlockRec.AcPlan))]
        public virtual ICollection<BlockRec> BlockRecs { get; set; }
    }
}
