using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("ScienceTypes", Schema = "Import")]
    public partial class ScienceType
    {
        [Key]
        [Column("sciT_id")]
        public int SciTId { get; set; }
        [Column("sciT_name")]
        [StringLength(100)]
        public string SciTName { get; set; }
        [Column("sciT_abbrev")]
        [StringLength(50)]
        public string SciTAbbrev { get; set; }
        [Column("sciT_shortname")]
        [StringLength(50)]
        public string SciTShortname { get; set; }
    }
}
