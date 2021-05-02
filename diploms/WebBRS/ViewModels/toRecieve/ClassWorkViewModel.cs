using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.ViewModels.toRecieve
{
	public class ClassWorkViewModel
	{
		public int IdClassWork { get; set; }
		public int IdClass { get; set; }
		public string TextWork { get; set; }
		public string FilePathWork { get; set; }
		public double MaxBall { get; set; }

		public DateTime DateTimeGiven { get; set; }

	}
}
