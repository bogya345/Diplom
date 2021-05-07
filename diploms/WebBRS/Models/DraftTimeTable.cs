using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class DraftTimeTable
	{
		[ Key]

		public int IdDFTT { get; set; }
		public string _Description { get; set; }

		public int? StudyYearIdStudyYear { get; set; }
		[ForeignKey("StudyYearIdStudyYear")]

		public StudyYear? StudyYear { get; set; }
		public virtual List<SubjectForGroup> SubjectsForGroup { get; set; } = new List<SubjectForGroup>();
		

	}
	public class TypeTimeTable
	{
		[Key]
		public int idTTT { get; set; }
		public string Name { get; set; }

	}
}
