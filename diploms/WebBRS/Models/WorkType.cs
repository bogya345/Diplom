using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class WorkType
	{
		[Required, Key]
		public int IdWT { get; set; }
		public byte[] ID_1c { get; set; }
		public string WorkTypeName { get; set; }
		public string ShortWorkTypeName { get; set; }
		public List<ClassWork> ClassWorks { get; set; } = new List<ClassWork>();
	}
}
