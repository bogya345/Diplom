using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class DirGroup
    {
        [Column("dep_id")]
        public int? DepId { get; set; }
        [Column("dir_id")]
        public int DirId { get; set; }
        [Column("acPl_id")]
        public int? AcPlId { get; set; }
        [Column("group_id")]
        public int GroupId { get; set; }
        [Column("group_name")]
        [StringLength(20)]
        public string GroupName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateExit { get; set; }
    }
}
