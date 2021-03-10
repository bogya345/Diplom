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
		public ExactClass ExactClass { get; set; }
		public string  TextWork { get; set; }
		public string  FilePathWork { get; set; }
		public double MaxBall { get; set; }
		public List<DoClassWorkAttend> DoClassWorkAttends { get; set; } = new List<DoClassWorkAttend>();
		[ForeignKey("IdWT")]
		public WorkType WorkType { get; set; }
		public DateTime DateGiven { get; set; }
	}
}
