using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("ApplyTypes", Schema = "Import")]
    public partial class ApplyType
    {
        public ApplyType()
        {
            FactStaffs = new HashSet<FactStaff>();
        }

        [Key]
        [Column("applyT_id")]
        public int ApplyTId { get; set; }
        [Column("applyT_name")]
        [StringLength(100)]
        public string ApplyTName { get; set; }

        [InverseProperty(nameof(FactStaff.ApplyT))]
        public virtual ICollection<FactStaff> FactStaffs { get; set; }
    }
}
