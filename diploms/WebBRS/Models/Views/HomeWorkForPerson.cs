using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models.Views
{
	public class HomeWorkForPerson
	{
		public int IdDCWA { get; set; }
		public string SubjectName { get; set; }
		public string LecturerName { get; set; }
		public string TextWork { get; set; }
		public string FilePathWork { get; set; }
		public double MaxBall { get; set; }
		public double MyBall { get; set; }
		public string TypeWork { get; set; }
	}
}
