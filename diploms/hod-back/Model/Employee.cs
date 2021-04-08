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
            FactStaffs = new HashSet<FactStaff>();
        }

        [Key]
        [Column("emp_id")]
        public int EmpId { get; set; }
        [Column("emp_guid")]
        public Guid? EmpGuid { get; set; }
        [Column("itab_n")]
        [StringLength(50)]
        public string ItabN { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [Column("FIrstName")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string MiddleName { get; set; }

        [InverseProperty(nameof(FactStaff.Emp))]
        public virtual ICollection<FactStaff> FactStaffs { get; set; }
    }
}
