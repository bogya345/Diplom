using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class StudyYear
	{
		public int IdStudyYear { get; set; }
		public string Description { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
	}
}
