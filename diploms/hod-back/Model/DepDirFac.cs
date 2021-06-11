using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class DepDirFac
    {
        [Column("dep_id")]
        public int DepId { get; set; }
        [Column("dep_guid")]
        public Guid? DepGuid { get; set; }
        [Column("dep_name")]
        [StringLength(100)]
        public string DepName { get; set; }
        [Column("fac_id")]
        public int? FacId { get; set; }
        [Column("fac_name")]
        [StringLength(100)]
        public string FacName { get; set; }
        [Column("dir_id")]
        public int? DirId { get; set; }
        [Column("acPl_id")]
        public int? AcPlId { get; set; }
        [Column("startYear")]
        [StringLength(4)]
        public string StartYear { get; set; }
        [Column("eBr_name")]
        [StringLength(100)]
        public string EBrName { get; set; }
    }
}
