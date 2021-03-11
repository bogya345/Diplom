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

		public virtual Person Person { get; set; }

		public List<SubjectForGroup> SubjectForGroups { get; set; } = new List<SubjectForGroup>();
		public List<SubjectLecturer> SubjectLecturers { get; set; } = new List<SubjectLecturer>();
		public List<Subject> Subjects { get; set; } = new List<Subject>();
	}
}
