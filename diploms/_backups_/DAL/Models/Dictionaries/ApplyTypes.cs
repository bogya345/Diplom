using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("WorkTypes", Schema = "Import")]
    public class ApplyTypes : Dictionary
    {
        [Column("workType_id")]
        public override int ID { get; set; }

        [Column("workType_name")]
        public override string NAME { get; set; }
    }
}
