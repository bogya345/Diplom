using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Groups", Schema = "Import")]
    public partial class Group
    {
        public Group()
        {
            AcademicPlans = new HashSet<AcademicPlan>();
        }

        [Key]
        [Column("group_id")]
        public int GroupId { get; set; }
        [Column("direct_id")]
        public int? DirectId { get; set; }
        [Column("group_name")]
        [StringLength(50)]
        public string GroupName { get; set; }
        [Column("nYear_post")]
        public int? NYearPost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateExit { get; set; }

        [ForeignKey(nameof(DirectId))]
        [InverseProperty(nameof(Direction.Groups))]
        public virtual Direction Direct { get; set; }
        [InverseProperty(nameof(AcademicPlan.Group))]
        public virtual ICollection<AcademicPlan> AcademicPlans { get; set; }
    }
}
