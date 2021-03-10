using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBRS.Models
{
	public class SubjectLecturer
	{
		public int IdSL { get; set; }
		public int IdLecturer { get; set; }
		public int IdTS { get; set; }

		[ForeignKey("IdLecturer")]
		public virtual Lecturer Lecturer { get; set; }
		[ForeignKey("IdSubject")]
		public virtual Subject Subject { get; set; }
	}
}
