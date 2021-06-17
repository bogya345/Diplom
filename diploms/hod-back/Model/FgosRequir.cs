using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class FgosRequir
    {
        public FgosRequir()
        {
            DirFgos = new HashSet<DirFgo>();
        }

        [Key]
        [Column("fgos_id")]
        public int FgosId { get; set; }
        [Column("fgos_num")]
        [StringLength(11)]
        public string FgosNum { get; set; }
        [Column("fgos_content")]
        public string FgosContent { get; set; }
        [Column("fgos_propertyView")]
        public string FgosPropertyView { get; set; }

        [InverseProperty(nameof(DirFgo.Fgos))]
        public virtual ICollection<DirFgo> DirFgos { get; set; }
    }
}
