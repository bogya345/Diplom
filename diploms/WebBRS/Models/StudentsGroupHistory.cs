using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	/// <summary>
	/// Факт перевода обучающего между группами. Так же отчисление обучающегося реализуется через данный класс
	/// </summary>
	public class StudentsGroupHistory
	{
		[Required, Key]
		public int IdSGH { get; set; }
		public byte[] ID_1c { get; set; }
		public DateTime DateSGHStart { get; set; }
		public DateTime? DateSGHFinished { get; set; }
		[ForeignKey("CourseIdCourse")]

		public Course? Course { get; set; }

		public StudyYear? StudyYear { get; set; }
		public byte[] ID_1c_Course { get; set; }
		public byte[] ID_1c_Person { get; set; }
		public byte[] ID_1c_Group { get; set; }
		public byte[] ID_1c_CounditionOfPerson { get; set; }
		public int? ConditionOfPersonIdConditionOfPerson { get; set; }
		//public int ConditionOfPersonIdConditionOfPerson { get; set; }

		[ForeignKey("ConditionOfPersonIdConditionOfPerson")]
		public ConditionOfPerson? ConditionOfPerson { get; set; }
		[ForeignKey("IdStudent")]
		public Student? Student { get; set; }
		public int GroupIdGroup { get; set; }
		public int  IdStudent { get; set; }
		public int CourseIdCourse { get; set; }
		[ForeignKey("GroupIdGroup")]
		public Group? Group { get; set; }
		public virtual List<Attendance> Attendances { get; set; } = new List<Attendance>();
		[JsonIgnore]

		public virtual List<AttedanceReason> AttedanceReasons { get; set; } = new List<AttedanceReason>();
	}
}
