using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.ViewModels.toRecieve
{
	public class GroupVMStatic
	{
		public int idGroup { get; set; }
		public string GroupName { get; set; }
		public List<StudentVM> studentVMs { get; set; } = new List<StudentVM>();
		public List<SubjectVM> SubjectVMs { get; set; } = new List<SubjectVM>();
	}
	public class StudentVM
	{
		public int IdStudent { get; set; }
		public string PersonFIO { get; set; }
		public int Balls { get; set; }

		public List<AttedancedVM> Attedanced { get; set; } = new List<AttedancedVM>();

	}
	public class SubjectForGroupVM
	{
	public int	IdSFG { get; set; }
		public int ID_reff { get; set; }
		public int IdSubject { get; set; }
		public string  NameSubject { get; set; }

	}

	public class AttedancedVM
	{
		public int IdReff { get; set; }
		public string Type { get; set; }
		public int attedanced { get; set; }
		public int Ball { get; set; }
		public int BallHW { get; set; }
	}
}
