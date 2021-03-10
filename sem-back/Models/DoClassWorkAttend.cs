using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class DoClassWorkAttend
	{
		[Required, Key]
		public int IdDCWA { get; set; }
		[ForeignKey("IdClassWork")]
		public int? IdClassWork { get; set; }
		public ClassWork ClassWork { get; set; }
		[ForeignKey("IdAtt")]
		public int? IdAtt { get; set; }
		public Attendance Attendance { get; set; }
		public DateTime DateTimePass { get; set; }
		public string TextDoClassWork { get; set; }
		public string FilePath { get; set; }
		public double Ball { get; set; }

	}
}
