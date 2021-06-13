using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class DirRequir
    {
        [Column("dep_id")]
        public int? DepId { get; set; }
        [Column("dir_id")]
        public int DirId { get; set; }
        [Column("startYear")]
        [StringLength(4)]
        public string StartYear { get; set; }
        [Column("eBr_name")]
        [StringLength(100)]
        public string EBrName { get; set; }
        [Column("acPl_id")]
        public int? AcPlId { get; set; }
        [Column("fgos_num")]
        [StringLength(11)]
        public string FgosNum { get; set; }
        [Column("settedValue")]
        public float? SettedValue { get; set; }
        [Column("unit_name")]
        [StringLength(50)]
        public string UnitName { get; set; }
        [Column("fgos_content")]
        public string FgosContent { get; set; }
        [Column("fgos_propertyView")]
        public string FgosPropertyView { get; set; }
    }
}
