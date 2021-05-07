using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Attendance
	{
		[Required, Key]
		public int IdAtt { get; set; }
		public int IdSGH { get; set; }
		[ForeignKey("IdSGH")]
		public StudentsGroupHistory SGH { get; set; }

		public int ExactClassIdClass { get; set; }
		[ForeignKey("ExactClassIdClass")]

		public ExactClass ExactClass { get; set; }
		
		public int TypeAttedanceIdTA { get; set; }
		[ForeignKey("TypeAttedanceIdTA")]

		public TypeAttedance TypeAttedance { get; set; }
		public int? ClassWorkIdClassWork { get; set; }
		[ForeignKey("ClassWorkIdClassWork")]


		public ClassWork? ClassWork { get; set; }
		//[ForeignKey("IdAtt")]
		//public Attendance Attendance { get; set; }
		public DateTime DateTimePass { get; set; }
		public string TextDoClassWork { get; set; }
		public string FilePath { get; set; }
		public double Ball { get; set; }
		public bool Done { get; set; }
		public DateTime? DatePass { get; set; }

		public int? WorkPersonStatusIdWPS { get; set; }
		[ForeignKey("WorkPersonStatusIdWPS")]
		public WorkPersonStatus? WorkPersonStatus { get; set; }
	}
}
