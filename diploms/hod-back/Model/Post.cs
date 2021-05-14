using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Posts", Schema = "Import")]
    public partial class Post
    {
        public Post()
        {
            PlanStaffs = new HashSet<PlanStaff>();
        }

        [Key]
        [Column("post_id")]
        public int PostId { get; set; }
        [Column("post_guid")]
        public Guid? PostGuid { get; set; }
        [Column("post_name")]
        [StringLength(100)]
        public string PostName { get; set; }
        [Column("post_code")]
        [StringLength(10)]
        public string PostCode { get; set; }
        [Column("postT_id")]
        public int? PostTId { get; set; }

        [ForeignKey(nameof(PostTId))]
        [InverseProperty(nameof(PostType.Posts))]
        public virtual PostType PostT { get; set; }
        [InverseProperty(nameof(PlanStaff.Post))]
        public virtual ICollection<PlanStaff> PlanStaffs { get; set; }
    }
}
