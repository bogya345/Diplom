using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models
{
    [Table("Departments", Schema = "Import")]
    public class Departments
    {
        [Key]
        public int dep_id { get; set; }
        public string dep_name { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime? dateEnd { get; set; }
        public int id_role { get; set; }
        public int? id_head_employee { get; set; }
    }
}
