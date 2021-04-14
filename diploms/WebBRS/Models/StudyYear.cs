using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class StudyYear
	{
		[Key]
		public int IdStudyYear { get; set; }
		public byte[] ID_1c { get; set; }
		public string _Code { get; set; }
		public string _Description { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
	}
}
