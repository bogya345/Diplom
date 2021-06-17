using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
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
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey(nameof(DirId))]
        [InverseProperty(nameof(Direction.DirFgos))]
        public virtual Direction Dir { get; set; }
        [ForeignKey(nameof(FgosId))]
        [InverseProperty(nameof(FgosRequir.DirFgos))]
        public virtual FgosRequir Fgos { get; set; }
        [ForeignKey(nameof(UnitId))]
        [InverseProperty("DirFgos")]
        public virtual Unit Unit { get; set; }
    }
}
