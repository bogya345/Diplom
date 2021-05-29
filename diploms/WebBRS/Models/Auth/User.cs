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
		[ForeignKey("PersonIdPerson")]

		public int PersonIdPerson { get; set; }    // generated (NOT AUTO-INCREMENT)

		public Person Person { get; set; }
		[ForeignKey("Roleid_role")]
		public int Roleid_role { get; set; }    // generated (NOT AUTO-INCREMENT)

		public Role Role { get; set; }
		

		//[NotMapped]
		public string login { get; set; }
		public string password { get; set; }
		[NotMapped]
		public string name_role { get; set; }
		[NotMapped]
		public int id_department { get; set; }
		//[NotMapped]
		//public List<Role> Roles { get; set; }
	}
}
