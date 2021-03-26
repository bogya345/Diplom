using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    [Table("EmpRanks", Schema = "Import")]
    public partial class EmpRank
    {
        [Column("educDoc_id")]
        public int? EducDocId { get; set; }
        [Column("emp_id")]
        public int? EmpId { get; set; }
        [Column("rank_id")]
        public int? RankId { get; set; }
        [Column("rankWhere")]
        [StringLength(200)]
        public string RankWhere { get; set; }

        [ForeignKey(nameof(RankId))]
        public virtual Rank Rank { get; set; }
    }
}
