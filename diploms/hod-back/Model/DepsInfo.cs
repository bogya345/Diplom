using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class DepsInfo
    {
        [Column("dep_id")]
        public int DepId { get; set; }
        [Column("dep_guid")]
        public Guid? DepGuid { get; set; }
        [Column("dep_name")]
        [StringLength(100)]
        public string DepName { get; set; }
        [Column("count_groups")]
        public int? CountGroups { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string MiddleName { get; set; }
    }
}
