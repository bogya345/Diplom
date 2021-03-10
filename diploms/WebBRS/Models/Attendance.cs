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
		public StudentsGroupHistory SGH { get; set; }
		public ExactClass ExactClass { get; set; }
		public List<DoClassWorkAttend> DoClassWorkAttends { get; set; } = new List<DoClassWorkAttend>();
	}
}
