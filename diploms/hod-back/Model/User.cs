using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    [Table("Users", Schema = "Auth")]
    public partial class User
    {
        [Column("user_login")]
        [StringLength(100)]
        public string UserLogin { get; set; }
        [Column("user_password")]
        [StringLength(100)]
        public string UserPassword { get; set; }
        [Column("fsh_id")]
        public int? FshId { get; set; }
        [Column("role_id")]
        public int? RoleId { get; set; }

        [ForeignKey(nameof(FshId))]
        public virtual FactStaffHistory Fsh { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
    }
}
