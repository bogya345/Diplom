using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class AcPlan
    {
        public AcPlan()
        {
            BlockRecs = new HashSet<BlockRec>();
            Directions = new HashSet<Direction>();
            Groups = new HashSet<Group>();
        }

        [Column("document")]
        public byte[] Document { get; set; }
        [Key]
        [Column("acPl_id")]
        public int AcPlId { get; set; }

        [InverseProperty(nameof(BlockRec.AcPl))]
        public virtual ICollection<BlockRec> BlockRecs { get; set; }
        [InverseProperty(nameof(Direction.AcPl))]
        public virtual ICollection<Direction> Directions { get; set; }
        [InverseProperty(nameof(Group.AcPl))]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
