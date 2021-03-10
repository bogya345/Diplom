using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("ApplyTypes", Schema = "Import")]
    public class ApplyTypes : Dictionary
    {
        [Column("id_applyType")]
        public override int ID { get; set; }

        [Column("name_applyType")]
        public override string NAME { get; set; }
    }
}
