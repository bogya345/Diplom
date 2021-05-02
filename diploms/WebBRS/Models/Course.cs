using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Course
	{
		[Required, Key]
		
		public int IdCourse { get; set; }
		public byte[] ID_1c { get; set; }
		public string _Description { get; set; }
		public string _Number { get; set; }
		public virtual List<StudentsGroupHistory> StudentsGroupHistories { get; set; } = new List<StudentsGroupHistory>();
		//public virtual List<InformationForTimeTable> InformationForTimeTables { get; set; } = new List<InformationForTimeTable>();
		public virtual List<SubjectForGroup> SubjectForGroups { get; set; } = new List<SubjectForGroup>();

	}
}
