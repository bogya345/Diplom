using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class Subject
    {
        public Subject()
        {
            BlockRecs = new HashSet<BlockRec>();
        }

        [Column("sub_name")]
        public string SubName { get; set; }
        [Key]
        [Column("sub_id")]
        public int SubId { get; set; }
        [Column("acPlDep_id")]
        public int? AcPlDepId { get; set; }

        [ForeignKey(nameof(AcPlDepId))]
        [InverseProperty(nameof(AcPlanDep.Subjects))]
        public virtual AcPlanDep AcPlDep { get; set; }
        [InverseProperty(nameof(BlockRec.Sub))]
        public virtual ICollection<BlockRec> BlockRecs { get; set; }
    }
}
