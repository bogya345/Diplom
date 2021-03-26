using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("EmpDegrees", Schema = "Import")]
    public partial class EmpDegree
    {
        [Key]
        [Column("educDoc_id")]
        public int EducDocId { get; set; }
        [Column("empDeg_date", TypeName = "datetime")]
        public DateTime? EmpDegDate { get; set; }
        [Column("dissertCouncil")]
        [StringLength(200)]
        public string DissertCouncil { get; set; }
        [Column("diplWhere")]
        [StringLength(200)]
        public string DiplWhere { get; set; }
        [Column("deg_id")]
        public int? DegId { get; set; }
        [Column("sciType_id")]
        public int? SciTypeId { get; set; }
        [Column("emp_id")]
        public int? EmpId { get; set; }
        [Column("listSpec_id")]
        public int? ListSpecId { get; set; }

        [ForeignKey(nameof(DegId))]
        [InverseProperty(nameof(Degree.EmpDegrees))]
        public virtual Degree Deg { get; set; }
        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.EmpDegrees))]
        public virtual Employee Emp { get; set; }
        [ForeignKey(nameof(ListSpecId))]
        [InverseProperty(nameof(ListSpeciality.EmpDegrees))]
        public virtual ListSpeciality ListSpec { get; set; }
        [ForeignKey(nameof(SciTypeId))]
        [InverseProperty(nameof(ScienceType.EmpDegrees))]
        public virtual ScienceType SciType { get; set; }
    }
}
