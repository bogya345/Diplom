using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models.Auth
{
	public class User
	{
        [Key]
        public int id_user { get; set; }    // generated (NOT AUTO-INCREMENT)

        [ForeignKey("Employees")]
        public int id_employee { get; set; }

        [ForeignKey("Roles")]
        public int id_role { get; set; }


        [NotMapped]
        public string login { get; set; }
        [NotMapped]
        public string name_role { get; set; }
        [NotMapped]
        public int id_department { get; set; }
        [NotMapped]
        public List<Role> Roles { get; set; }
    }
}
