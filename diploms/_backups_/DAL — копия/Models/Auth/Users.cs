using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.Auth
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }    // generated (NOT AUTO-INCREMENT)

        [ForeignKey("Employees")]
        public int employee_id { get; set; }

        [ForeignKey("Roles")]
        public int role_id { get; set; }

        
        [NotMapped]
        public string login { get; set; }
        [NotMapped]
        public string name_role { get; set; }
        [NotMapped]
        public int id_department { get; set; }
        [NotMapped]
        public List<Roles> Roles { get; set; }
    }
}
