using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("ListSpecialities", Schema = "Import")]
    public partial class ListSpeciality
    {
        public ListSpeciality()
        {
            EmpDegrees = new HashSet<EmpDegree>();
        }

        [Key]
        [Column("listSpec_id")]
        public int ListSpecId { get; set; }
        [Column("listSpec_code")]
        [StringLength(10)]
        public string ListSpecCode { get; set; }
        [Column("listSpec_name")]
        public string ListSpecName { get; set; }

        [InverseProperty(nameof(EmpDegree.ListSpec))]
        public virtual ICollection<EmpDegree> EmpDegrees { get; set; }
    }
}
