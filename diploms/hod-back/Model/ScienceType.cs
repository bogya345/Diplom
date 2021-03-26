using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("ScienceTypes", Schema = "Import")]
    public partial class ScienceType
    {
        public ScienceType()
        {
            EmpDegrees = new HashSet<EmpDegree>();
        }

        [Key]
        [Column("sciType_id")]
        public int SciTypeId { get; set; }
        [Column("sciType_name")]
        [StringLength(200)]
        public string SciTypeName { get; set; }
        [Column("sciType_abbrev")]
        [StringLength(50)]
        public string SciTypeAbbrev { get; set; }
        [Column("sciType_shortName")]
        [StringLength(50)]
        public string SciTypeShortName { get; set; }

        [InverseProperty(nameof(EmpDegree.SciType))]
        public virtual ICollection<EmpDegree> EmpDegrees { get; set; }
    }
}
