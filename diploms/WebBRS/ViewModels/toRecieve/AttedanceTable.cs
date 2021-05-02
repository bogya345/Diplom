using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.ViewModels.toRecieve
{
	public class StudentTable
	{
		public int IdStudent { get; set; }
		public string PersonFIO { get; set; }
		public List<string> Attedanced { get; set; }

	}
	public class GroupAttedanceTable
	{
		public int idGroup { get; set; }
		public string PersonFIO { get; set; }
		public List<string> Attedanced { get; set; }
	}
	public class ExactClassForLecturerClassTable
	{
		public int IdECFLCT { get; set; }
		public Lecturer Lecturer { get; set; }
		public List<ExactClass> ExactClasses { get; set; }
		public List<GroupAttedanceTable> Groups { get; set; }
		public string SubjectName { get; set; }
		public int SelectedGroup { get; set; }

	}

}

