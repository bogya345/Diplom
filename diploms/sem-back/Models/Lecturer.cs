using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Lecturer
	{
		[Required, Key]
		public int IdSLecturer { get; set; }

		[ForeignKey("GuidPerson")]
		public Guid? GuidPerson { get; set; }
		public Person Person { get; set; }
	}
}
