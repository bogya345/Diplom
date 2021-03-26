using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Employees", Schema = "Import")]
    public partial class Employee
    {
        public Employee()
        {
            EmpDegrees = new HashSet<EmpDegree>();
        }

        [Key]
        [Column("emp_id")]
        public int EmpId { get; set; }
        [Column("itab_n")]
        [StringLength(50)]
        public string ItabN { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Otch { get; set; }
        public bool? SexBit { get; set; }
        [Column("emp_guid")]
        public Guid? EmpGuid { get; set; }
        [Column("emp_login")]
        [StringLength(128)]
        public string EmpLogin { get; set; }

        [InverseProperty(nameof(EmpDegree.Emp))]
        public virtual ICollection<EmpDegree> EmpDegrees { get; set; }
    }
}
