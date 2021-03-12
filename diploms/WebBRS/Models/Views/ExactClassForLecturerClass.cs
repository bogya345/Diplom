using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models.Views
{
	public class ExactClassForLecturerClass
	{
		public Lecturer Lecturer { get; set; }
		public List<ExactClass> ExactClasses { get; set; }
		public List<Group> Groups { get; set; }
		public List<Student> Students { get; set; }
	}
}
