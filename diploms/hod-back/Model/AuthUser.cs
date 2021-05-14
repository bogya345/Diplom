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
        [Column("fs_id")]
        public int FsId { get; set; }
        [Column("ps_id")]
        public int PsId { get; set; }
        [Column("dep_id")]
        public int DepId { get; set; }
        [Column("dep_shortname")]
        [StringLength(50)]
        public string DepShortname { get; set; }
        [Column("id_role_actual")]
        public int? IdRoleActual { get; set; }
        [Column("name_role_actual")]
        [StringLength(100)]
        public string NameRoleActual { get; set; }
    }
}
