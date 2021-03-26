using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    [Table("EmpEducDocs", Schema = "Import")]
    public partial class EmpEducDoc
    {
        [Column("educDoc_id")]
        public int? EducDocId { get; set; }
        [Column("emp_id")]
        public int? EmpId { get; set; }

        [ForeignKey(nameof(EducDocId))]
        public virtual EducDoc EducDoc { get; set; }
        [ForeignKey(nameof(EmpId))]
        public virtual Employee Emp { get; set; }
    }
}
