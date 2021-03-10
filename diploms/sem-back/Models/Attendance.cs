using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Attendance
	{
		[Required, Key]
		public int IdAtt { get; set; }
		public int? IdSGH { get; set; }
		public StudentsGroupHistory SGH { get; set; }
		public int? IdClass { get; set; }
		public ExactClass ExactClass { get; set; }

	}
}
