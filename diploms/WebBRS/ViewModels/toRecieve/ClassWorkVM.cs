using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.ViewModels.toRecieve
{
	public class ClassWorkVMUnion
	{
		public List<ClassWorkVM> classWorkVM { get; set; } = new List<ClassWorkVM>();
		public List<ClassWorkVM> classWorkVMAll { get; set; } = new List<ClassWorkVM>();
	}
	public class ClassWorkVM
	{
		public string DateGiven { get; set; }
		public string DatePass { get; set; }
		public string TextWork { get; set; }
		public string FilePathWork { get; set; }
		public double MaxBall { get; set; }
		public int IdClassWork { get; set; }
		public int IdClass { get; set; }
		public string LecturerFIO { get; set; }
		public string SubjectName { get; set; }
	}
}
