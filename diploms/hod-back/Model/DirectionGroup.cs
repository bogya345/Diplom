using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class DirectionGroup
    {
        [Column("direct_id")]
        public int DirectId { get; set; }
        public int? YearObuch { get; set; }
        [Column("group_id")]
        public int GroupId { get; set; }
        [Column("group_name")]
        [StringLength(50)]
        public string GroupName { get; set; }
        [Column("nYear_post")]
        public int? NYearPost { get; set; }
    }
}
