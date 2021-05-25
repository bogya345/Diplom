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
		public int? IdStudyPlan { get; set; }
		[ForeignKey("IdStudyPlan")]

		public StudyPlanRecord? StudyPlanRecord { get; set; }
		public int IdGroup { get; set; }
		[ForeignKey("IdGroup")]

		public Group Group { get; set; }
		public int IdCourse { get; set; }
		[ForeignKey("IdCourse")]

		public Course Course { get; set; }
		public int? DraftTimeTableIdDFTT { get; set; }

		[ForeignKey("DraftTimeTableIdDFTT")]

		public DraftTimeTable DraftTimeTable { get; set; }

		public int DepartmentID { get; set; }
		[ForeignKey("DepartmentID")]

		public Department Department { get; set; }
		public int IdPerson { get; set; }
		public int TypeStudyIdTS { get; set; }

		[ForeignKey("IdPerson")]

		public Person Person { get; set; }
		public int IdSubject { get; set; }
		[ForeignKey("IdSubject")]

		public Subject Subject { get; set; }

		public virtual SubjectLecturer? Lecturer { get; set; }
		[ForeignKey("TypeStudyIdTS")]

		public virtual TypeStudy TypeStudy { get; set; }
		/// <summary>
		/// _Fld6093
		/// </summary>
		/// 
		public int ID_reff { get; set; }
		public DateTime SFGDate { get; set; }
		//public virtual List<ExactClass> ExactClasses { get; set; } = new List<ExactClass>();
		public override string ToString()
		{
			return Subject.ToString();
		}
	}
}
