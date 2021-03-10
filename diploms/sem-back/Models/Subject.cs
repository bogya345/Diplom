using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Subject
	{
		[Required, Key]

		public int IdSubject { get; set; }
		public string NameSubject { get; set; }
		public string SubjectShortName { get; set; }
		public DateTime DateTimeSubject { get; set; }
	}
}
