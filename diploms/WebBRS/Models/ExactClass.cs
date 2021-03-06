using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class ExactClass
	{
		[Required, Key]

		public int IdClass { get; set; }

		[ForeignKey("IdSFG")]
		public SubjectForGroup SubjectForGroup { get; set; }
		public DateTime DateClass { get; set; }
		public byte ClassNumber { get; set; }
		public ExactClassForLecturerClass ExactClassForLecturerClass { get; set; }
		public virtual SubjectLecturer SubjectLecturer { get; set; }
		public virtual List<ClassWork> ClassWorks { get; set; } = new List<ClassWork>();
		public virtual List<Attendance> Attendances { get; set; } = new List<Attendance>();
		

	}
}
