using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Keyless]
    public partial class FgosrequiresToDirection
    {
        [Column("direct_id")]
        public int DirectId { get; set; }
        [Column("fgos_id")]
        public int FgosId { get; set; }
        [Column("fgos_num")]
        [StringLength(11)]
        public string FgosNum { get; set; }
        [Column("settedValue")]
        public float? SettedValue { get; set; }
        [Column("unit_name")]
        [StringLength(50)]
        public string UnitName { get; set; }
        [Column("fgos_content")]
        public string FgosContent { get; set; }
    }
}
