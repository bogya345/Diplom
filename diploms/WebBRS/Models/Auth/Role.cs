using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models.Auth
{
	public class Role
	{
		/// <summary>
		/// Роли системы
		/// </summary>
		[Key]
		public int id_role { get; set; }    // generated (NOT AUTO-INCREMENT)

		public string name_role { get; set; }
	}
}
