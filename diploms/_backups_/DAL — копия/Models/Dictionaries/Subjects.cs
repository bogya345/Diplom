using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("Subjects")]
    public class Subjects : Dictionary
    {
        [Column("id_subject")]
        public override int ID { get; set; }

        [Column("name_subject")]
        public override string NAME { get; set; }
    }
}
