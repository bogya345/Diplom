using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class SubjectType
    {
        public SubjectType()
        {
            TeacherLoads = new HashSet<TeacherLoad>();
        }

        [Key]
        [Column("subType_id")]
        public int SubTypeId { get; set; }
        [Column("subType_name")]
        [StringLength(50)]
        public string SubTypeName { get; set; }
        [Column("subType_shortname")]
        [StringLength(10)]
        public string SubTypeShortname { get; set; }

        [InverseProperty(nameof(TeacherLoad.SubType))]
        public virtual ICollection<TeacherLoad> TeacherLoads { get; set; }
    }
}
