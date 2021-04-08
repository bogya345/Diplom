using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class DirFgo
    {
        [Column("dir_id")]
        public int? DirId { get; set; }
        [Column("fgos_id")]
        public int? FgosId { get; set; }
        [Column("settedValue")]
        public float? SettedValue { get; set; }
        [Column("unit_id")]
        public int? UnitId { get; set; }

        [ForeignKey(nameof(DirId))]
        public virtual Direction Dir { get; set; }
        [ForeignKey(nameof(FgosId))]
        public virtual FgosRequir Fgos { get; set; }
        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; }
    }
}
