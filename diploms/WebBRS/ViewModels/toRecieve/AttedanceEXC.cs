using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.ViewModels.toRecieve
{
	public class HomeWorkStudent
	{
		public int IdHWS { get; set; }
		public string ShortTextHW { get; set; }
		public string StringFilePath { get; set; }

	}
	public class Group
	{
		public int idGroup { get; set; }
		public string GroupName { get; set; }
		public string Specialty { get; set; }
		public List<StudentEXC> Students { get; set; }

	}
	public class ClassWork
	{
		public int IdCW { get; set; }
		public string TextWork { get; set; }
		public string FilePathWork { get; set; }
		public double MaxBall { get; set; }
	}
	public class ExactClass
	{
		public int IdClass { get; set; }
		public string DateExactClass { get; set; }
		public int numberClass { get; set; }
		public Group Group { get; set; }
	}
	public class StudentEXC
	{
		public int IdStudent { get; set; }
		public string PersonFIO { get; set; }
		public  string Attedanced { get; set; }
		public  double Ball { get; set; }
		public HomeWorkStudent HW { get; set; }
	}
	public class ExactClassForLecturerClass
	{
		public int IdECFLC { get; set; }
		public Lecturer Lecturer { get; set; }
		public List<StudentEXC> Students { get; set; }
		public  Group Group { get; set; }
		public string SubjectName { get; set; }
		public string DateTime { get; set; }
	}
	public class Lecturer
	{
		public int IdLecturer { get; set; }
		public string PersonFIO { get; set; }

	}
}




