using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class ClassWork
	{
		[Required, Key]
		public int IdClassWork { get; set; }
		[ForeignKey("IdClasss")]
		public int? IdClass { get; set; }
		public ExactClass ExactClass { get; set; }
		public string  TextWork { get; set; }
		public string  FilePathWork { get; set; }
		public double MaxBall { get; set; }
	}
}
