using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Degrees", Schema = "Import")]
    public partial class Degree
    {
        public Degree()
        {
            EmpDegrees = new HashSet<EmpDegree>();
        }

        [Key]
        [Column("deg_id")]
        public int DegId { get; set; }
        [Column("deg_name")]
        [StringLength(100)]
        public string DegName { get; set; }
        [Column("deg_shortName")]
        [StringLength(50)]
        public string DegShortName { get; set; }
        [Column("deg_abbrev")]
        [StringLength(50)]
        public string DegAbbrev { get; set; }
        [Column("deg_order")]
        public int? DegOrder { get; set; }

        [InverseProperty(nameof(EmpDegree.Deg))]
        public virtual ICollection<EmpDegree> EmpDegrees { get; set; }
    }
}
