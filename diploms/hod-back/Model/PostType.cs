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
        [Column("postT_id")]
        public int PostTId { get; set; }
        [Column("postT_name")]
        [StringLength(100)]
        public string PostTName { get; set; }

        [InverseProperty(nameof(Post.PostT))]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
