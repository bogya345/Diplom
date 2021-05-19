using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.ViewModels.toRecieve
{
	public class StudentTable
	{
		public int IdStudent { get; set; }
		public string PersonFIO { get; set; }
		public double Balls { get; set; }
		public List<string> Attedanced { get; set; } = new List<string>();

	}
	public class GroupAttedanceTable
	{
		public int idGroup { get; set; }
		public string GroupName { get; set; }
		//public List<ExactClassVMforTable> Attedanced { get; set; }
	}
	public class ExactClassForLecturerClassTable
	{
		public int IdECFLCT { get; set; }
		public Lecturer Lecturer { get; set; }

		public List<ExactClassVMforTable> ExactClasses { get; set; } = new List<ExactClassVMforTable>();
		public List<StudentTable> Students { get; set; } = new List<StudentTable>();
		public List<GroupAttedanceTable> Groups { get; set; } = new List<GroupAttedanceTable>();
		public string SubjectName { get; set; }
		public int IdSFG { get; set; }
		public int SelectedGroup { get; set; }

	}
	public class ExactClassVMforTable
	{
		public int IdClass { get; set; }
		public string DateExactClass { get; set; }
		//[JsonIgnore]
		//public virtual List<int> idClasses { get; set; } = new List<int>();

	}
}

