using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("DepTypes", Schema = "Import")]
    public partial class DepType
    {
        public DepType()
        {
            Departments = new HashSet<Department>();
        }

        [Key]
        [Column("depT_id")]
        public int DepTId { get; set; }
        [Column("depT_name")]
        [StringLength(100)]
        public string DepTName { get; set; }

        [InverseProperty(nameof(Department.DepT))]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
