using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    [Table("Direction_fgos")]
    public partial class DirectionFgo
    {
        [Column("direct_id")]
        public int? DirectId { get; set; }
        [Column("fgos_id")]
        public int? FgosId { get; set; }
        [Column("settedValue")]
        public float? SettedValue { get; set; }
        [Column("unit_id")]
        public int? UnitId { get; set; }

        [ForeignKey(nameof(DirectId))]
        public virtual Direction Direct { get; set; }
        [ForeignKey(nameof(FgosId))]
        public virtual FgosRequir Fgos { get; set; }
        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; }
    }
}
