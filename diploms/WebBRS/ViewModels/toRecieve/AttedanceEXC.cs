using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.ViewModels.toRecieve
{
	public class HomeWorkStudent
	{
		public int IdHWS { get; set; }
		public string ShortTextHW { get; set; }
		public string StringFilePath { get; set; }

	}
	public class GroupVM
	{
		public int idGroup { get; set; }
		public string GroupName { get; set; }
		//public string Specialty { get; set; }
		//public List<StudentEXC> Students { get; set; }

	}

	public class ExactClassVM
	{
		public int IdClass { get; set; }
		public string DateExactClass { get; set; }
		//public int numberClass { get; set; }
		//public GroupVM Group { get; set; }
	}
	public class TypeAttedanceVM : TypeAttedance
	{

		public int IdAtt { get; set; }
	}
	public class StudentEXC
	{
		public int IdAttedance { get; set; }
		public int IdStudent { get; set; }
		public string PersonFIO { get; set; }
		public int AttedanceTypeSelected { get; set; }
		public List<TypeAttedanceVM> Attedanced { get; set; } = new List<TypeAttedanceVM>();
		public double Ball { get; set; }
		public HomeWorkStudent HW { get; set; }
	}
	public class ExactClassForLecturerClassVM
	{
		public int IdClass { get; set; }
		public int IdECFLCT { get; set; }

		public LecturerVM Lecturer { get; set; }
		public List<StudentEXC> Students { get; set; } = new List<StudentEXC>();
		public List<GroupVM> Groups { get; set; } = new List<GroupVM>();
		public int SelectedGroup { get; set; }
		public string SubjectName { get; set; }
		public string DateTime { get; set; }

		public List<TypeAttedance> TypeAttedances { get; set; }

	}
	public class LecturerVM
	{
		public int IdLecturer { get; set; }
		public string PersonFIO { get; set; }


	}
}




