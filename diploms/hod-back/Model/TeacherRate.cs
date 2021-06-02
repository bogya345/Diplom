using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class TeacherRate
    {
        [Column("fsh_id")]
        public int FshId { get; set; }
        public float? StaffCount { get; set; }
        [Column("fs_id")]
        public int FsId { get; set; }
        [Column("workT_id")]
        public int? WorkTId { get; set; }
        [Column("workT_name")]
        [StringLength(100)]
        public string WorkTName { get; set; }
        [Column("workT_shortname")]
        [StringLength(50)]
        public string WorkTShortname { get; set; }
        [Column("applyT_id")]
        public int? ApplyTId { get; set; }
        [Column("ps_id")]
        public int? PsId { get; set; }
        [Column("post_id")]
        public int? PostId { get; set; }
        [Column("dep_id")]
        public int? DepId { get; set; }
        [Column("post_name")]
        [StringLength(100)]
        public string PostName { get; set; }
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
    }
}
