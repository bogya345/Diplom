using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("EducForms", Schema = "Import")]
    public class EducForms : Dictionary
    {
        [Column("id_educForm")]
        public override int ID { get; set; }

        [Column("name_educForm")]
        public override string NAME { get; set; }
    }
}
