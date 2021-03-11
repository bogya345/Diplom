using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class WorkPersonStatus
	{
		[Required, Key]

		public int IdWPS { get; set; }
		[Required]

		public string WorkpersonStatusName { get; set; }

		public string WorkpersonStatusNameShort { get; set; }
	}
}
