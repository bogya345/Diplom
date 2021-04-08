using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class BlockNum
    {
        public BlockNum()
        {
            BlockRecs = new HashSet<BlockRec>();
        }

        [Column("blockNum_name")]
        [StringLength(100)]
        public string BlockNumName { get; set; }
        [Key]
        [Column("blockNum_id")]
        public int BlockNumId { get; set; }

        [InverseProperty(nameof(BlockRec.BlockNum))]
        public virtual ICollection<BlockRec> BlockRecs { get; set; }
    }
}
