using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class TeacherInfo
    {
        [Column("fsh_id")]
        public int FshId { get; set; }
        [Column("emp_id")]
        public int? EmpId { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string Otch { get; set; }
        [Column("educDOc_rank")]
        public int? EducDocRank { get; set; }
        [Column("rank_name")]
        [StringLength(100)]
        public string RankName { get; set; }
        [Column("educDoc_degree")]
        public int? EducDocDegree { get; set; }
        [Column("deg_name")]
        [StringLength(100)]
        public string DegName { get; set; }
    }
}
