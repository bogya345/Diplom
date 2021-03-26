using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    public partial class TeacherLoad
    {
        [Key]
        [Column("teachLoad_id")]
        public int TeachLoadId { get; set; }
        [Column("fsh_id")]
        public int? FshId { get; set; }
        [Column("blocRec_id")]
        public int? BlocRecId { get; set; }
        [Column("subType_id")]
        public int? SubTypeId { get; set; }
        public int? LoadValue { get; set; }

        [ForeignKey(nameof(BlocRecId))]
        [InverseProperty(nameof(BlockRec.TeacherLoads))]
        public virtual BlockRec BlocRec { get; set; }
        [ForeignKey(nameof(FshId))]
        [InverseProperty(nameof(KafTeacher.TeacherLoads))]
        public virtual KafTeacher Fsh { get; set; }
        [ForeignKey(nameof(SubTypeId))]
        [InverseProperty(nameof(SubjectType.TeacherLoads))]
        public virtual SubjectType SubType { get; set; }
    }
}
