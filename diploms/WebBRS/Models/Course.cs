using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Course
	{
		[Required, Key]

		public int IdCourse { get; set; }
		public string _Description { get; set; }
		public string _Number { get; set; }
	}
}
