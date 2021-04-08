using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Degrees", Schema = "Import")]
    public partial class Degree
    {
        [Key]
        [Column("deg_id")]
        public int DegId { get; set; }
        [Column("dep_name")]
        [StringLength(100)]
        public string DepName { get; set; }
        [Column("deg_shortname")]
        [StringLength(50)]
        public string DegShortname { get; set; }
        [Column("deg_Abbrev")]
        [StringLength(50)]
        public string DegAbbrev { get; set; }
    }
}
