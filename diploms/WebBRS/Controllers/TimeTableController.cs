using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBRS.DAL;
using WebBRS.Models;
using WebBRS.Models.Auth;
using System.Security.Claims;

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
		[HttpGet("GetTimeTableStudent/{IdSelectedDraft}/{IdSelectedDraftType}/{DateTimeExact}/{IdCourse}")]
		public TimeTable2 GetTimeTableStudent(string IdSelectedDraft, string IdSelectedDraftType, string DateTimeExact, string IdCourse)
		{
			TimeTable2 timeTable = new TimeTable2();
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
			timeTable.Courses = unit.Courses.GetAll().ToList();
			DateTime dateChoosen = Convert.ToDateTime(DateTimeExact);
			dateChoosen = dateChoosen.AddYears(1995);
			ClaimsIdentity claimsIdentity;
			claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
			var yearClaims = claimsIdentity.FindFirst("Name");
			User user = unit.Users.Get(u => u.login == yearClaims.Value);
			int IdPerson = user.PersonIdPerson;
			//int IdPerson = 1739436577;

			Person person = unit.Persons.Get(IdPerson);
			Student student = unit.Students.Get(st => st.IdPerson == person.IdPerson);

			List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
				.GetAll(sgh => sgh.IdStudent == student.IdStudent && sgh.CourseIdCourse.ToString() == IdCourse && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
			var studentsSorted = from s in studentsGroupHistories
								 orderby s.DateSGHStart
								 select s;
			List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
			StudentsGroupHistory sgh = studentsSortedList[0];
			List<SubjectForGroup> sfgs = unit.SubjectForGroups.GetAll(sfg => sfg.IdGroup == sgh.GroupIdGroup && sfg.DraftTimeTableIdDFTT.ToString() == IdSelectedDraft).ToList();
			List<ExactClass> exactClasses = unit.ExactClasses.GetAll(ex => ex.DraftTimeTableIdDFTT.ToString() == IdSelectedDraft && ex.TypeTimeTableidTTT.ToString() == IdSelectedDraftType).ToList();
			List<SubjectVM> subjectVMs = new List<SubjectVM>();
			List<DayStudent> Days = new List<DayStudent>();
			int currentDoW = Convert.ToInt32(dateChoosen.DayOfWeek);

			DateTime dayBuf = dateChoosen;
			if (currentDoW > 1)
			{
				var Day1 = dayBuf.AddDays(-currentDoW+1);
				DayStudent dayVM1 = new DayStudent();
				dayVM1.Date = Day1.Date;
				dayVM1.DayOfWeek = GetDayOfWeek(Day1);
				Days.Add(dayVM1);
			}
			if (currentDoW == 1)
			{
				var Day1 = dayBuf;
				DayStudent dayVM1 = new DayStudent();
				dayVM1.Date = Day1.Date;
				dayVM1.DayOfWeek = GetDayOfWeek(Day1);
				Days.Add(dayVM1);
			}
			int j = 1;
			//dayBuf = ;
			while (/*Convert.ToInt32(Days[j-1].Date.DayOfWeek)*/Days.Count < 7)
			{
				DayStudent day = new DayStudent();
				try { 
				day.Date = Days[j - 1].Date.AddDays(1);
				}
				catch
				{
					day.Date = DateTime.Now;
				}
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
			foreach (var item in exactClasses)
			{
				if (Days.Any(d => d.Date == item.DateClassStart.Date))
				{
					EXTCforStudentTimeTable newExclass = new EXTCforStudentTimeTable();
					newExclass.DateTime = item.DateClassStart.ToShortTimeString();
					//newExclass.DateTime = item.DateClassStart.TimeOfDay.ToString("t");
			
					newExclass.DayOfWeek = item.DateClassStart.DayOfWeek.ToString();
					newExclass.IdECFLCT = item.ID_reff;
					newExclass.IdClass = item.IdClass;
					if (item.Auditory != null)
					{
						newExclass.Auditory = item.Auditory.ShortNameDepart;

					}
					else
					{
						newExclass.Auditory = "нет";

					}
					SubjectForGroup subjectForGroup = unit.SubjectForGroups.Get(sfg => sfg.ID_reff == item.ID_reff);
					newExclass.SubjectName = subjectForGroup.Subject.NameSubject;
					newExclass.DateTime = item.DateClassStart.TimeOfDay.ToString();
					newExclass.DateTime = newExclass.DateTime.Substring(0, 5);
					if (Days[Days.FindIndex(d => d.Date == item.DateClassStart.Date)].EXTCforTimeTablesStudent.Any(ec => ec.IdECFLCT == newExclass.IdECFLCT))
					{
						if (newExclass.Auditory != "nope")
						{
							int id = Days[Days.FindIndex(d => d.Date == item.DateClassStart.Date)].EXTCforTimeTablesStudent.FindIndex(ec => ec.IdECFLCT == newExclass.IdECFLCT);
							Days[Days.FindIndex(d => d.Date == item.DateClassStart.Date)].EXTCforTimeTablesStudent[id].Auditory = newExclass.Auditory;
						}
					}
					else
					{
						Days[Days.FindIndex(d => d.Date == item.DateClassStart.Date)].EXTCforTimeTablesStudent.Add(newExclass);
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
			List<DraftTimeTable> dfts = unit.DraftTimeTables.GetAll().ToList();
			List<TypeTimeTable> dttt = unit.TypesTimeTable.GetAll().ToList();

			//teacherSubjects.SubjectVMs = subjectVMs;
			//teacherSubjects.idLect = lecturer.IdPerson;
			//teacherSubjects.LecturerFIO = lecturer.PersonFIOShort();
			timeTable.DaysStudent = Days;

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
			foreach (var item in timeTable.DaysStudent)
			{
			
				item.EXTCforTimeTables.Distinct();
			}
			foreach (var d in timeTable.DaysStudent)
			{
				var lessonsSorted = from s in d.EXTCforTimeTablesStudent
									orderby s.DateTime
									select s;
				d.EXTCforTimeTablesStudent = lessonsSorted.ToList();
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
		public string GetDayOfWeek(DateTime dateTime)
		{
			DateTimeFormatInfo dateTimeFormats = new CultureInfo("ru-RU").DateTimeFormat;
			string dateString = dateTime.Date.ToString();

			//day.Date = dateTime.DateClassStart.Date;

			//StudentsGroupHistory studentsGroupHistory = unit.StudentGroupHistories.Get();
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
			dateChoosen = dateChoosen.AddYears(1995);
			ClaimsIdentity claimsIdentity;
			claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
			var yearClaims = claimsIdentity.FindFirst("Name");
			User user = unit.Users.Get(u => u.login == yearClaims.Value);
			int IdPerson = user.PersonIdPerson;
			//int IdPerson = 1739436573;
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
			if (currentDoW == 0)
			{
				currentDoW = 6;
			}
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
					newExclass.Auditory = item.Auditory.ShortNameDepart;
					SubjectForGroup subjectForGroup = unit.SubjectForGroups.Get(sfg => sfg.ID_reff == item.ID_reff);
					newExclass.SubjectName = subjectForGroup.Subject.NameSubject;
					newExclass.DateTime = item.DateClassStart.TimeOfDay.ToString("t");
					newExclass.DateTime = newExclass.DateTime.Substring(0, 5);
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
