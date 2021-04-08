using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    [Table("EmpDegrees", Schema = "Import")]
    public partial class EmpDegree
    {
        [Column("eDoc_id")]
        public int? EDocId { get; set; }
        [Column("deg_date", TypeName = "datetime")]
        public DateTime? DegDate { get; set; }
        [StringLength(100)]
        public string DissertCouncil { get; set; }
        [Column("diplWhere")]
        [StringLength(100)]
        public string DiplWhere { get; set; }
        [Column("deg_id")]
        public int? DegId { get; set; }
        [Column("sciT_id")]
        public int? SciTId { get; set; }
        [Column("listSpec_id")]
        public int? ListSpecId { get; set; }

        [ForeignKey(nameof(DegId))]
        public virtual Degree Deg { get; set; }
        [ForeignKey(nameof(EDocId))]
        public virtual EducDoc EDoc { get; set; }
        [ForeignKey(nameof(ListSpecId))]
        public virtual ListSpeciality ListSpec { get; set; }
        [ForeignKey(nameof(SciTId))]
        public virtual ScienceType SciT { get; set; }
    }
}
