using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class SubjectForGroup
	{
		[Required, Key]
		public int IdSFG { get; set; }
		[ForeignKey("IdSubject")]

		public int? IdSubject { get; set; }
		public Subject Subject { get; set; }
		[ForeignKey("IdGroup")]
		public int? IdGroup { get; set; }
		public Group Group { get; set; }
		[ForeignKey("IdSLecturer")]
		public int? IdSLecturer { get; set; }
		public Lecturer Lecturer { get; set; }
		[ForeignKey("IdTSk")]
		public int? IdTS { get; set; }
		public TypeStudy TypeStudy { get; set; }
	}
}
