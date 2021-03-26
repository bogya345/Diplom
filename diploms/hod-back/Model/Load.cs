using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class Load
    {
        [Column("fsh_id")]
        public int FshId { get; set; }
        [Column("dep_guid")]
        public Guid? DepGuid { get; set; }
        [Column("post_guid")]
        public Guid? PostGuid { get; set; }
        public int? LoadValue { get; set; }
        [Column("acPlan_id")]
        public int? AcPlanId { get; set; }
        [Column("blockRec_id")]
        public int BlockRecId { get; set; }
        [Column("sub_name")]
        [StringLength(100)]
        public string SubName { get; set; }
        [Column("subType_name")]
        [StringLength(50)]
        public string SubTypeName { get; set; }
    }
}
