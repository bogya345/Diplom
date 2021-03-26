using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("Ranks", Schema = "Import")]
    public class Ranks
    {
        public int rank_id { get; set; }
        public string rank_name { get; set; }
        public int kardId { get; set; } // ??
        public int rankOrder { get; set; }
        public int isAcademicRank { get; set; }
    }
}
