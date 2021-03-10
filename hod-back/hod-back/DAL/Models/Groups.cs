using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hod_back.DAL.Models
{
    [Table("Groups", Schema = "Import")]
    public class Groups
    {
        [Key]
        public int id_group { get; set; }
        public string name_group { get; set; }
        public DateTime startYear { get; set; }
        public int id_qualification { get; set; }
        public int id_educForm { get; set; }
        public int id_department { get; set; }
    }
}
