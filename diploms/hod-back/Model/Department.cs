using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Departments", Schema = "Import")]
    public partial class Department
    {
        public Department()
        {
            Facs = new HashSet<Fac>();
        }

        [Key]
        [Column("dep_guid")]
        public Guid DepGuid { get; set; }
        [Column("dep_name")]
        public string DepName { get; set; }
        [Column("dep_shortname")]
        [StringLength(200)]
        public string DepShortname { get; set; }
        [Column("depType_id")]
        public int? DepTypeId { get; set; }
        [Column("dateExit", TypeName = "date")]
        public DateTime? DateExit { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateCreate { get; set; }
        [Column("role_id")]
        public int? RoleId { get; set; }

        [ForeignKey(nameof(DepTypeId))]
        [InverseProperty(nameof(DepartmentType.Departments))]
        public virtual DepartmentType DepType { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Departments")]
        public virtual Role Role { get; set; }
        [InverseProperty(nameof(Fac.DepGu))]
        public virtual ICollection<Fac> Facs { get; set; }
    }
}
