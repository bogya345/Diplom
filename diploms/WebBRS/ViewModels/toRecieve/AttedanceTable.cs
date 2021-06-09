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
		public int Misses { get; set; }
		public List<AttedancedVMType> Attedanced { get; set; } = new List<AttedancedVMType>();

	}
	public class AttedancedVMType
	{
		public string Type { get; set; }
		public string attedanced { get; set; }
		public string Ball { get; set; }
		public string BallHW { get; set; }
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
		public string LecturerFIO { get; set; }
		public string Date { get; set; }

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
		public string Theme { get; set; }
		public string ThemeShort { get; set; }
		//[JsonIgnore]
		//public virtual List<int> idClasses { get; set; } = new List<int>();

	}
}

