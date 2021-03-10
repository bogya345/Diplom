using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class ExactClass
	{
		public int IdClass { get; set; }

		[ForeignKey("IdSFG")]
		public int? IdSFG { get; set; }
		public SubjectForGroup SubjectForGroup { get; set; }
		public DateTime DateClass { get; set; }


	}
}
