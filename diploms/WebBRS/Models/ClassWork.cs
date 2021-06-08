
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebBRS.Models
{
	public class ClassWork
	{
		[Required, Key]
		public int IdClassWork { get; set; }
		public int IdClass { get; set; }

		[ForeignKey("IdClass")]
		[JsonIgnore]

		public ExactClass ExactClass { get; set; }
		public string  TextWork { get; set; }
		public string  FilePathWork { get; set; }
		public double MaxBall { get; set; }
		[NotMapped]
		public IFormFile File { get; set; }
		[JsonIgnore]
		public List<DoClassWorkAttend> DoClassWorkAttends { get; set; } = new List<DoClassWorkAttend>();
		public int IdWT { get; set; }
		[ForeignKey("IdWT")]

		public WorkType WorkType { get; set; }
		public DateTime DateGiven { get; set; }
		public DateTime DatePass { get; set; }
	}
}
