using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("FactStaffHistories", Schema = "Import")]
    public partial class FactStaffHistory
    {
        [Key]
        [Column("fsh_id")]
        public int FshId { get; set; }
        [Column("fs_id")]
        public int? FsId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateBegin { get; set; }
        [StringLength(50)]
        public string StaffCount { get; set; }
        [Column("workType_id")]
        public int? WorkTypeId { get; set; }
        [StringLength(50)]
        public string HourCount { get; set; }
        [StringLength(50)]
        public string CalcStaffCount { get; set; }
        [StringLength(50)]
        public string WorkHoursInWeek { get; set; }
        [StringLength(50)]
        public string HourSalary { get; set; }
        [StringLength(50)]
        public string NormHoursInWeek { get; set; }

        [ForeignKey(nameof(WorkTypeId))]
        [InverseProperty("FactStaffHistories")]
        public virtual WorkType WorkType { get; set; }
    }
}
