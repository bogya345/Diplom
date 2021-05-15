using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	//Расписание в 1с конфигурации
	public class ExactClass
	{
		[Required, Key]

		public int IdClass { get; set; }
		//public int? IdSFG { get; set; }


		//[ForeignKey("IdSFG")]

		//public virtual SubjectForGroup SubjectForGroup { get; set; }
		public DateTime DateClassStart { get; set; }
		public DateTime DateClassEnd { get; set; }
		//public int IdDFTT { get; set; }
		public int DraftTimeTableIdDFTT { get; set; }
		public int TypeTimeTableidTTT { get; set; }
		public DraftTimeTable DraftTimeTable { get; set; }
		public TypeTimeTable TypeTimeTable { get; set; }
		//public byte ClassNumber { get; set; }
		//public ExactClassForLecturerClass ExactClassForLecturerClass { get; set; }
		//public virtual SubjectLecturer SubjectLecturer { get; set; }
		public int PersonLecturerIdPerson { get; set; }

		public Person PersonLecturer { get; set; }
		public byte[] ID_1c_person { get; set; }
		public byte[] ID_1c_audit { get; set; }
		/// <summary>
		/// _Fld4106
		/// </summary>
		public int ID_reff { get; set; }
		public Department? Auditory { get; set; }

		//public virtual List<ClassWork> ClassWorks { get; set; } = new List<ClassWork>();
		public virtual List<Attendance> Attendances { get; set; } = new List<Attendance>();
		
	}
}
