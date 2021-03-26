using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class AuthUser
    {
        [Column("user_login")]
        [StringLength(100)]
        public string UserLogin { get; set; }
        [Column("user_password")]
        [StringLength(100)]
        public string UserPassword { get; set; }
        [Column("role_id")]
        public int? RoleId { get; set; }
        [Column("dep_guid")]
        public Guid? DepGuid { get; set; }
    }
}
