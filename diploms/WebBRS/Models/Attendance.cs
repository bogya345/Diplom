using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Attendance
	{
		[Required, Key]
		public int IdAtt { get; set; }
		public StudentsGroupHistory SGH { get; set; }
		public ExactClass ExactClass { get; set; }
		public TypeAttedance TypeAttedance { get; set; }
		public ClassWork ClassWork { get; set; }
		//[ForeignKey("IdAtt")]
		//public Attendance Attendance { get; set; }
		public DateTime DateTimePass { get; set; }
		public string TextDoClassWork { get; set; }
		public string FilePath { get; set; }
		public double Ball { get; set; }
		public bool Done { get; set; }
		public DateTime? DatePass { get; set; }


		public WorkPersonStatus WorkPersonStatus { get; set; }
	}
}
