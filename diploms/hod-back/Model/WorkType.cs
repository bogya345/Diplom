using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("WorkTypes", Schema = "Import")]
    public partial class WorkType
    {
        public WorkType()
        {
            FactStaffs = new HashSet<FactStaff>();
            FactStaffsHistories = new HashSet<FactStaffsHistory>();
        }

        [Key]
        [Column("workT_id")]
        public int WorkTId { get; set; }
        [Column("workT_name")]
        [StringLength(100)]
        public string WorkTName { get; set; }
        [Column("workT_shortname")]
        [StringLength(50)]
        public string WorkTShortname { get; set; }

        [InverseProperty(nameof(FactStaff.WorkT))]
        public virtual ICollection<FactStaff> FactStaffs { get; set; }
        [InverseProperty(nameof(FactStaffsHistory.WorkT))]
        public virtual ICollection<FactStaffsHistory> FactStaffsHistories { get; set; }
    }
}
