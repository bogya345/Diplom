using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("DepartmentTypes", Schema = "Import")]
    public partial class DepartmentType
    {
        public DepartmentType()
        {
            Departments = new HashSet<Department>();
        }

        [Key]
        [Column("depType_id")]
        public int DepTypeId { get; set; }
        [Column("depType_name")]
        [StringLength(20)]
        public string DepTypeName { get; set; }

        [InverseProperty(nameof(Department.DepT))]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
