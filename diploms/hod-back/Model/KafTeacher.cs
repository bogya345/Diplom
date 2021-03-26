using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("KafTeachers", Schema = "Import")]
    public partial class KafTeacher
    {
        public KafTeacher()
        {
            TeacherLoads = new HashSet<TeacherLoad>();
        }

        [Column("emp_id")]
        public int? EmpId { get; set; }
        [Key]
        [Column("fsh_id")]
        public int FshId { get; set; }
        [Column("post_guid")]
        public Guid? PostGuid { get; set; }
        [Column("dep_guid")]
        public Guid? DepGuid { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateBegin { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateEnd { get; set; }
        [Column(TypeName = "numeric(6, 3)")]
        public decimal? StaffCount { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? HourCount { get; set; }
        [StringLength(100)]
        public string Login { get; set; }
        [Column("PPSStuff")]
        public double? Ppsstuff { get; set; }
        public double? HourlyLoad { get; set; }

        [InverseProperty(nameof(TeacherLoad.Fsh))]
        public virtual ICollection<TeacherLoad> TeacherLoads { get; set; }
    }
}
