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
		public int  IdTS { get; set; }
		public byte[] ID_1c { get; set; }
		public string TypeStudyName { get; set; }
		public string ShortTypeStudyName { get; set; }
		public virtual List<SubjectForGroup> SubjectsForGroup { get; set; } = new List<SubjectForGroup>();

		public List<SubjectLecturer> SubjectLecturers { get; set; }
	}
}
