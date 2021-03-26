using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("EducLevels", Schema = "Import")]
    public partial class EducLevel
    {
        public EducLevel()
        {
            EducBranches = new HashSet<EducBranch>();
        }

        [Key]
        [Column("educLvl_id")]
        public int EducLvlId { get; set; }
        [Column("educLvl_name")]
        [StringLength(100)]
        public string EducLvlName { get; set; }
        [Column("educLvl_shortName")]
        [StringLength(100)]
        public string EducLvlShortName { get; set; }

        [InverseProperty(nameof(EducBranch.EducLvl))]
        public virtual ICollection<EducBranch> EducBranches { get; set; }
    }
}
