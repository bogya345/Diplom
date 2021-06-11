using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class DepartmentLoad
    {
        [Column("attAcPl_id")]
        public int AttAcPlId { get; set; }
        [Column("fsh_id")]
        public int FshId { get; set; }
        public float? StaffCount { get; set; }
        [Column("fs_id")]
        public int FsId { get; set; }
        [Column("ps_id")]
        public int PsId { get; set; }
        [Column("dep_id")]
        public int? DepId { get; set; }
        [Column("dep_name")]
        [StringLength(100)]
        public string DepName { get; set; }
        [Column("dep_shortname")]
        [StringLength(50)]
        public string DepShortname { get; set; }
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
        [Column("blockRec_id")]
        public long? BlockRecId { get; set; }
        [Column("acPl_id")]
        public int AcPlId { get; set; }
        [Column("dir_id")]
        public int DirId { get; set; }
        [Column("eBr_id")]
        public int? EBrId { get; set; }
        [Column("eForm_id")]
        public int? EFormId { get; set; }
        [Column("startYear")]
        [StringLength(4)]
        public string StartYear { get; set; }
        [Column("eBr_name")]
        [StringLength(100)]
        public string EBrName { get; set; }
        [Column("eBr_shortname")]
        [StringLength(50)]
        public string EBrShortname { get; set; }
        [Column("eForm_name")]
        [StringLength(100)]
        public string EFormName { get; set; }
        [Column("semestrNum")]
        public int? SemestrNum { get; set; }
        [Column("inPlan")]
        public int? InPlan { get; set; }
        [Column("sub_id")]
        public int? SubId { get; set; }
        [Column("sub_name")]
        public string SubName { get; set; }
        [Column("group_id")]
        public int? GroupId { get; set; }
        [Column("group_name")]
        [StringLength(20)]
        public string GroupName { get; set; }
        [Column("subT_id")]
        public int? SubTId { get; set; }
        [Column("subT_name")]
        [StringLength(100)]
        public string SubTName { get; set; }
        [Column("hourValue")]
        public float? HourValue { get; set; }
    }
}
