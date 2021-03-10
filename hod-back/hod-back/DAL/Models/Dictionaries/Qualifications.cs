using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("Qualifications", Schema = "Import")]
    public class Qualifications : Dictionary
    {
        [Column("id_qualification")]
        public override int ID { get; set; }

        [Column("name_qualification")]
        public override string NAME { get; set; }
    }
}
