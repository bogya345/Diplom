using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class TypeStudy
	{
		[Required, Key]
		public int IdTS { get; set; }
		public string TypeStudyName { get; set; }
		public string ShortTypeStudyName { get; set; }
		public List<SubjectForGroup> SubjectForGroups { get; set; }
		public List<SubjectLecturer> SubjectLecturers { get; set; }
	}
}
