using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("kat_zaved", Schema = "Import")]
    public partial class KatZaved
    {
        public KatZaved()
        {
            Directions = new HashSet<Direction>();
        }

        [Key]
        [Column("katZaved_id")]
        public int KatZavedId { get; set; }
        [Column("katZaved_name")]
        [StringLength(100)]
        public string KatZavedName { get; set; }
        [Column("katZaved_printName")]
        [StringLength(100)]
        public string KatZavedPrintName { get; set; }
        [Column("katZaved_abjective")]
        [StringLength(100)]
        public string KatZavedAbjective { get; set; }

        [InverseProperty(nameof(Direction.KatZaved))]
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
