using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("PostTypes", Schema = "Import")]
    public partial class PostType
    {
        public PostType()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        [Column("postType_id")]
        public int PostTypeId { get; set; }
        [Column("postType_name")]
        [StringLength(20)]
        public string PostTypeName { get; set; }

        [InverseProperty(nameof(Post.PostType))]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
