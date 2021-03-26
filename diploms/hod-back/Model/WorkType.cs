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
            FactStaffHistories = new HashSet<FactStaffHistory>();
        }

        [Key]
        [Column("workType_id")]
        public int WorkTypeId { get; set; }
        [Column("workType_name")]
        [StringLength(50)]
        public string WorkTypeName { get; set; }
        [Column("workType_shortName")]
        [StringLength(50)]
        public string WorkTypeShortName { get; set; }

        [InverseProperty(nameof(FactStaffHistory.WorkType))]
        public virtual ICollection<FactStaffHistory> FactStaffHistories { get; set; }
    }
}
