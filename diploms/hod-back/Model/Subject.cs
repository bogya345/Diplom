using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class Subject
    {
        public Subject()
        {
            BlockRecs = new HashSet<BlockRec>();
        }

        [Key]
        [Column("sub_id")]
        public int SubId { get; set; }
        [Column("sub_name")]
        [StringLength(100)]
        public string SubName { get; set; }

        [InverseProperty(nameof(BlockRec.Sub))]
        public virtual ICollection<BlockRec> BlockRecs { get; set; }
    }
}
