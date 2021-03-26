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
        [Key]
        [Column("post_id")]
        public int PostId { get; set; }
        [Column("post_name")]
        [StringLength(300)]
        public string PostName { get; set; }
        [Column("isManager")]
        public bool? IsManager { get; set; }
        [Column("post_guid")]
        public Guid? PostGuid { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateEnd { get; set; }
        [Column("post_code")]
        [StringLength(100)]
        public string PostCode { get; set; }
        [Column("postType_id")]
        public int? PostTypeId { get; set; }

        [ForeignKey(nameof(PostTypeId))]
        [InverseProperty("Posts")]
        public virtual PostType PostType { get; set; }
    }
}
