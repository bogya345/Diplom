using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Groups", Schema = "Import")]
    public partial class Group
    {
        public Group()
        {
            AttachedAcPlans = new HashSet<AttachedAcPlan>();
        }

        [Key]
        [Column("group_id")]
        public int GroupId { get; set; }
        [Column("dir_id")]
        public int? DirId { get; set; }
        [Column("group_name")]
        [StringLength(20)]
        public string GroupName { get; set; }
        public int? YearArrive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateExit { get; set; }
        [Column("acPl_id")]
        public int? AcPlId { get; set; }

        [ForeignKey(nameof(AcPlId))]
        [InverseProperty(nameof(AcPlan.Groups))]
        public virtual AcPlan AcPl { get; set; }
        [ForeignKey(nameof(DirId))]
        [InverseProperty(nameof(Direction.Groups))]
        public virtual Direction Dir { get; set; }
        [InverseProperty(nameof(AttachedAcPlan.Group))]
        public virtual ICollection<AttachedAcPlan> AttachedAcPlans { get; set; }
    }
}
