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
        [Column("eDoc_id")]
        public int? EDocId { get; set; }
        [Column("emp_id")]
        public int? EmpId { get; set; }

        [ForeignKey(nameof(EDocId))]
        public virtual EducDoc EDoc { get; set; }
        [ForeignKey(nameof(EmpId))]
        public virtual Employee Emp { get; set; }
    }
}
