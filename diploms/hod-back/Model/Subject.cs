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

        [Column("sub_name")]
        public string SubName { get; set; }
        [Column("dep_id")]
        public int? DepId { get; set; }
        [Key]
        [Column("sub_id")]
        public int SubId { get; set; }

        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(Department.Subjects))]
        public virtual Department Dep { get; set; }
        [InverseProperty(nameof(BlockRec.Sub))]
        public virtual ICollection<BlockRec> BlockRecs { get; set; }
    }
}
