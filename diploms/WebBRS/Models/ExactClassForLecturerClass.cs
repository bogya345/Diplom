using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class ExactClassForLecturerClass
	{
		[Required, Key]
		public int IdEXCFLC { get; set; }
		public Lecturer Lecturer { get; set; }
		public byte ClassNumber { get; set; }

		//public List<Attendance> Attendances { get; set; }
		public virtual List<ExactClass> ExactClasses { get; set; }
		//public List<Group> Groups { get; set; }
		[NotMapped]
		public virtual List<StudentsGroupHistory> Students { get; set; }
		[NotMapped]

		public virtual List<Group> Groups { get; set; }
	}
}
