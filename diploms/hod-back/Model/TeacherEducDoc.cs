using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class TeacherEducDoc
    {
        [Column("emp_id")]
        public int EmpId { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [Column("FIrstName")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(302)]
        public string FullName { get; set; }
        [Column("eDoc_id")]
        public int? EDocId { get; set; }
        [Column("eDocT_id")]
        public int? EDocTId { get; set; }
        [Column("eDocT_name")]
        [StringLength(100)]
        public string EDocTName { get; set; }
        [Column("deg_id")]
        public int? DegId { get; set; }
        [Column("deg_shortname")]
        [StringLength(50)]
        public string DegShortname { get; set; }
        [Column("dep_name")]
        [StringLength(100)]
        public string DepName { get; set; }
        [Column("rank_id")]
        public int? RankId { get; set; }
        [Column("rankWhere")]
        [StringLength(100)]
        public string RankWhere { get; set; }
        [Column("isAcademicRank")]
        public bool? IsAcademicRank { get; set; }
        [Column("rank_name")]
        [StringLength(100)]
        public string RankName { get; set; }
    }
}
