using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.ViewModels.toRecieve
{
	public class HomeWorksModelView
	{
		public int IdClassWork { get; set; }
		public string LecturerFIO { get; set; }
		public int IdClass { get; set; }
		public string TextWork { get; set; }
		public string FilePathWork { get; set; }
		public double MaxBall { get; set; }
		public double MyBall { get; set; }
		public DateTime DateTimeGiven { get; set; }
		public DateTime DateTimePassed { get; set; }
		public DateTime DateTimeLoaded { get; set; }
		public string Passed { get; set; }
	}
	public class AttedanceForWork
	{
		public int IdAtt { get; set; }
		public string PersonFIO { get; set; }
		public string TextDoClassWork { get; set; }
		public string FilePath { get; set; }
		public double BallHW { get; set; }
		public bool Done { get; set; }
		public string? DatePass { get; set; }

	}
}
