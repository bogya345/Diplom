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
		public List<SubjectForGroup> SubjectForGroups { get; set; } = new List<SubjectForGroup>();
		public List<Group> Groups { get; set; } = new List<Group>();
		public List<SubjectLecturer> SubjectLecturers { get; set; } = new List<SubjectLecturer>();

		public List<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
	}
}
