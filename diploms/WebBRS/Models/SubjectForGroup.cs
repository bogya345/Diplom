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

		public virtual SubjectLecturer Lecturer { get; set; }

		public virtual TypeStudy TypeStudy { get; set; }
		public DateTime SFGDate { get; set; }
		public List<ExactClass> ExactClasses { get; set; } = new List<ExactClass>();
	}
}
