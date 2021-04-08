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
        [Column("fs_id")]
        public int? FsId { get; set; }
        [Column("ps_id")]
        public int? PsId { get; set; }

        [ForeignKey(nameof(FsId))]
        public virtual FactStaff Fs { get; set; }
        [ForeignKey(nameof(PsId))]
        public virtual PlanStaff Ps { get; set; }
    }
}
