using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Ranks", Schema = "Import")]
    public partial class Rank
    {
        [Key]
        [Column("rank_id")]
        public int RankId { get; set; }
        [Column("rank_name")]
        [StringLength(100)]
        public string RankName { get; set; }
        [Column("isAcademicRank")]
        public bool? IsAcademicRank { get; set; }
    }
}
