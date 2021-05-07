using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.ViewModels.toRecieve
{
	public class TimeTable
	{
		public List<Day> Days { get; set; } = new List<Day>();
		public List<DraftTimeTableVM> Drafts { get; set; } = new List<DraftTimeTableVM>();
		public int IdSelectedDraft { get; set; }
		public int IdSelectedDraftType { get; set; }
		public List<TypeTimeTableVM> DraftTypes { get; set; } = new List<TypeTimeTableVM>();




	}

	public class DraftTimeTableVM
	{
		public int IdDFTT { get; set; }
		public string _Description { get; set; }
	}
	public class TypeTimeTableVM
	{
		public int IdDTTT { get; set; }

		public string _Description { get; set; }
	}
	public class Day
	{
		public DateTime Date { get; set; }
		public string DayOfWeek { get; set; }
		public List<EXTCforTimeTable> EXTCforTimeTables { get; set; } = new List<EXTCforTimeTable>();
	}
	public class EXTCforTimeTable
	{
		public int IdECFLCT { get; set; }
		public string SubjectName { get; set; }
		public string DateTime { get; set; }
		public string DayOfWeek { get; set; }
		public string Auditory { get; set; }

	}
	public class TeacherSubjects
	{
		public List<StudyYear> StudyYears { get; set; } = new List<StudyYear>();
		public StudyYear selectedSY { get; set; }
		public List<SubjectVM> SubjectVMs { get; set; } = new List<SubjectVM>();
		public int idLect { get; set; }
		public string LecturerFIO { get; set; }
	}
	public class SubjectVM
	{
		//public List<SubjectForGroup> sfgs = new List<SubjectForGroup>();
		public int IdSubject { get; set; }
		public string SubjectName { get; set; }
	}
}
