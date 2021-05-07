using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBRS.DAL;
using WebBRS.Models;

using WebBRS.Models.Views;
using WebBRS.ViewModels.toRecieve;

namespace WebBRS.Controllers
{
	[Route("timeTable")]
	public class TimeTableController : Controller
	{
		private UnitOfWork unit = new UnitOfWork();
		/// <summary>
		/// Получение расписания для преподавателя
		/// </summary>
		/// <param name="IdStudyYear"></param>
		/// <returns></returns>
		/// 
		//[HttpGet("GetTeachersClasses/{IdStudyYear}")]
		//public TimeTable GetTeachersClasses(string IdStudyYear)
		//{ 

		//}
		public string GetDayOfWeek(DateTime dateTime)
		{
			DateTimeFormatInfo dateTimeFormats = new CultureInfo("ru-RU").DateTimeFormat;

			//day.Date = dateTime.DateClassStart.Date;
			string dateString = dateTime.Date.ToString();

			DateTime dateValue = DateTime.ParseExact(dateString, "dd.MM.yyyy h:mm:ss", CultureInfo.InvariantCulture); ;
			DateTimeOffset dateOffsetValue;
			//dateValue = 
			dateOffsetValue = new DateTimeOffset(dateValue,
										 TimeZoneInfo.Local.GetUtcOffset(dateValue));


			return dateValue.ToString("dddd", dateTimeFormats);
		}
		[HttpGet("GetTimeTable/{IdSelectedDraft}/{IdSelectedDraftType}/{DateTimeExact}")]
		public TimeTable GetTimeTable(string IdSelectedDraft, string IdSelectedDraftType, string DateTimeExact)
		{
			if (IdSelectedDraft == null)
			{
				IdSelectedDraft = (-1096224828).ToString();
			}
			if (IdSelectedDraftType == null)
			{
				IdSelectedDraftType = (-1045036686).ToString();
			}
			if (DateTimeExact == "undefined")
			{
				DateTimeExact = DateTime.Now.ToString();
			}
			DateTime dateChoosen = Convert.ToDateTime(DateTimeExact);
			int IdPerson = 1739436573;
			//int IdPerson = 237609111;
			TeacherSubjects teacherSubjects = new TeacherSubjects();
			TimeTable timeTable = new TimeTable();
			int currentDoW = Convert.ToInt32(dateChoosen.DayOfWeek);
			Person lecturer = unit.Persons.Get(IdPerson);
			//StudyYear sty = unit.StudyYears.Get(Convert.ToInt32(IdStudyYear));
			List<DraftTimeTable> dfts = unit.DraftTimeTables.GetAll().ToList();
			List<TypeTimeTable> dttt = unit.TypesTimeTable.GetAll().ToList();
			List<SubjectForGroup> sfgs = unit.SubjectForGroups.GetAll(sfg => sfg.IdPerson == lecturer.IdPerson && sfg.DraftTimeTableIdDFTT.ToString() == IdSelectedDraft).ToList();
			List<ExactClass> exactClasses = unit.ExactClasses.GetAll(ex => ex.PersonLecturerIdPerson == IdPerson && ex.DraftTimeTableIdDFTT.ToString() == IdSelectedDraft && ex.TypeTimeTableidTTT.ToString() == IdSelectedDraftType).ToList();
			List<SubjectVM> subjectVMs = new List<SubjectVM>();
			List<Day> Days = new List<Day>();
			DateTime dayBuf = dateChoosen;
			if (currentDoW > 1)
			{
				var Day1 = dayBuf.AddDays(-currentDoW);
				Day dayVM1 = new Day();
				dayVM1.Date = Day1.Date;
				dayVM1.DayOfWeek = GetDayOfWeek(Day1);
				Days.Add(dayVM1);
			}
			if (currentDoW == 1)
			{
				var Day1 = dayBuf;
				Day dayVM1 = new Day();
				dayVM1.Date = Day1.Date;
				dayVM1.DayOfWeek = GetDayOfWeek(Day1);
				Days.Add(dayVM1);
			}
			int j = 1;
			//dayBuf = ;
			while (/*Convert.ToInt32(Days[j-1].Date.DayOfWeek)*/Days.Count < 7)
			{
				Day day = new Day();
				day.Date = Days[j - 1].Date.AddDays(1);
				day.DayOfWeek = GetDayOfWeek(day.Date);
				Days.Add(day);
				j++;
			}
			foreach (var item in sfgs)
			{
				if (subjectVMs.Any(svm => svm.IdSubject == item.IdSubject))
				{
					int id = subjectVMs.FindIndex(svm => svm.IdSubject == item.IdSubject);
				}
				else
				{
					SubjectVM svm = new SubjectVM();
					svm.IdSubject = item.IdSubject;
					svm.SubjectName = item.Subject.NameSubject;
					//svm.sfgs.Add(item);
					subjectVMs.Add(svm);
				}
			};
			//for 
			foreach (var item in exactClasses)
			{
				if (Days.Any(d => d.Date == item.DateClassStart.Date))
				{
					EXTCforTimeTable newExclass = new EXTCforTimeTable();
					newExclass.DateTime = item.DateClassStart.ToShortTimeString();
					newExclass.DayOfWeek = item.DateClassStart.DayOfWeek.ToString();
					newExclass.IdECFLCT = item.ID_reff;
					newExclass.Auditory = item.Auditory.FullNameDepart;
					SubjectForGroup subjectForGroup = unit.SubjectForGroups.Get(sfg => sfg.ID_reff == item.ID_reff);
					newExclass.SubjectName = subjectForGroup.Subject.NameSubject;
					newExclass.DateTime = item.DateClassStart.TimeOfDay.ToString();
					if (Days[Days.FindIndex(d => d.Date == item.DateClassStart.Date)].EXTCforTimeTables.Any(ec => ec.IdECFLCT == newExclass.IdECFLCT))
					{
						if (newExclass.Auditory != "nope") 
						{ 
						int id = Days[Days.FindIndex(d => d.Date == item.DateClassStart.Date)].EXTCforTimeTables.FindIndex(ec => ec.IdECFLCT == newExclass.IdECFLCT);
							Days[Days.FindIndex(d => d.Date == item.DateClassStart.Date)].EXTCforTimeTables[id].Auditory = newExclass.Auditory;
						}
					}
					else
					{
						Days[Days.FindIndex(d => d.Date == item.DateClassStart.Date)].EXTCforTimeTables.Add(newExclass);
					}
				}
				else
				{
					//Day day = new Day();
					//day.Date = item.DateClassStart.Date;
					//string dateString = item.DateClassStart.ToString();

					//DateTime dateValue = DateTime.Parse(dateString, CultureInfo.InvariantCulture); ;
					//DateTimeOffset dateOffsetValue;
					////dateValue = 
					//dateOffsetValue = new DateTimeOffset(dateValue,
					//							 TimeZoneInfo.Local.GetUtcOffset(dateValue));

					//day.DayOfWeek = dateValue.ToString("dddd", dateTimeFormats);
					//day.EXTCforTimeTables = new List<EXTCforTimeTable>();
					////svm.sfgs.Add(item);
					//Days.Add(day);
					//EXTCforTimeTable newExclass = new EXTCforTimeTable();
					//newExclass.DateTime = item.DateClassStart.ToShortTimeString();
					//newExclass.DayOfWeek = item.DateClassStart.DayOfWeek.ToString();
					//newExclass.IdECFLCT = item.ID_reff;
					//newExclass.Auditory = item.Auditory.FullNameDepart;
					//SubjectForGroup subjectForGroup = unit.SubjectForGroups.Get(sfg => sfg.ID_reff == item.ID_reff);
					//newExclass.SubjectName = subjectForGroup.Subject.NameSubject;
					//newExclass.DateTime = item.DateClassStart.TimeOfDay.ToString();
					//Days[Days.Count - 1].EXTCforTimeTables.Add(newExclass);
				}
			}

			teacherSubjects.SubjectVMs = subjectVMs;
			teacherSubjects.idLect = lecturer.IdPerson;
			teacherSubjects.LecturerFIO = lecturer.PersonFIOShort();
			timeTable.Days = Days;
			foreach (var item in dfts)
			{
				DraftTimeTableVM k = new DraftTimeTableVM();
				k.IdDFTT = item.IdDFTT;
				k._Description = item._Description;
				timeTable.Drafts.Add(k);
			}
			foreach (var item in dttt)
			{
				TypeTimeTableVM k = new TypeTimeTableVM();
				k.IdDTTT = item.idTTT;
				k._Description = item.Name;
				timeTable.DraftTypes.Add(k);
			}
			foreach (var item in timeTable.Days)
			{
				item.EXTCforTimeTables.Distinct();
			}
			#region SwapDrafts
			var buf = timeTable.Drafts.Find(g => g.IdDFTT.ToString() == IdSelectedDraft);
			var buf2 = timeTable.Drafts[timeTable.Drafts.Count() - 1];
			timeTable.Drafts[timeTable.Drafts.Count() - 1] = buf;
			timeTable.Drafts[timeTable.Drafts.FindIndex(g => g.IdDFTT.ToString() == IdSelectedDraft)] = buf2;
			timeTable.Drafts.Reverse();
			#endregion


			#region SwapDraftTypes
			var buf3 = timeTable.DraftTypes.Find(g => g.IdDTTT.ToString() == IdSelectedDraftType);
			var buf4 = timeTable.DraftTypes[timeTable.DraftTypes.Count() - 1];
			timeTable.DraftTypes[timeTable.DraftTypes.Count() - 1] = buf3;
			timeTable.DraftTypes[timeTable.DraftTypes.FindIndex(g => g.IdDTTT.ToString() == IdSelectedDraftType)] = buf4;
			timeTable.DraftTypes.Reverse();
			#endregion
			timeTable.IdDateSelected = DateTimeExact;
			timeTable.IdSelectedDraft = Convert.ToInt32(IdSelectedDraft);
			timeTable.IdSelectedDraftType = Convert.ToInt32(IdSelectedDraftType);
			return timeTable;
		}
	}
}
