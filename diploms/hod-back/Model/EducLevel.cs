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
        [Column("eLvl_id")]
        public int ELvlId { get; set; }
        [Column("eLvl_name")]
        [StringLength(100)]
        public string ELvlName { get; set; }
        [Column("eLvl_shortname")]
        [StringLength(50)]
        public string ELvlShortname { get; set; }

        [InverseProperty(nameof(EducBranch.ELvl))]
        public virtual ICollection<EducBranch> EducBranches { get; set; }
    }
}
