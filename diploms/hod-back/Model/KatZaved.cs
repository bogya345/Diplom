using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("KatZaveds", Schema = "Import")]
    public partial class KatZaved
    {
        public KatZaved()
        {
            Directions = new HashSet<Direction>();
        }

        [Key]
        [Column("kZav_id")]
        public int KZavId { get; set; }
        [Column("kZav_name")]
        [StringLength(100)]
        public string KZavName { get; set; }
        [Column("kZav_fullname")]
        public string KZavFullname { get; set; }
        [Column("kZav_adjective")]
        [StringLength(100)]
        public string KZavAdjective { get; set; }

        [InverseProperty(nameof(Direction.KZav))]
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
