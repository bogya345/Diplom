using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("Organizations", Schema = "Import")]
    public partial class Organization
    {
        [Key]
        [Column("org_id")]
        public int OrgId { get; set; }
        [Column("org_name")]
        [StringLength(100)]
        public string OrgName { get; set; }
    }
}
