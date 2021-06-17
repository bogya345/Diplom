using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class Unit
    {
        public Unit()
        {
            DirFgos = new HashSet<DirFgo>();
        }

        [Key]
        [Column("unit_id")]
        public int UnitId { get; set; }
        [Column("unit_name")]
        [StringLength(50)]
        public string UnitName { get; set; }

        [InverseProperty(nameof(DirFgo.Unit))]
        public virtual ICollection<DirFgo> DirFgos { get; set; }
    }
}
