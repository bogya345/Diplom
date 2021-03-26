using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Roles", Schema = "Auth")]
    public partial class Role
    {
        public Role()
        {
            Departments = new HashSet<Department>();
        }

        [Key]
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("role_name")]
        [StringLength(100)]
        public string RoleName { get; set; }

        [InverseProperty(nameof(Department.Role))]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
