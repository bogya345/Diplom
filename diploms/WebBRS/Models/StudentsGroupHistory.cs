using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
		public DateTime DateSGHStart { get; set; }
		public DateTime DateSGHFinished { get; set; }

		[ForeignKey("IdStudent")]
		public Student Student { get; set; }
		[ForeignKey("IdGroup")]
		public Group Group { get; set; }

		public List<Attendance> Attendances { get; set; } = new List<Attendance>();

	}
}
