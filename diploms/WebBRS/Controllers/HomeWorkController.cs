using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebBRS.DAL;
using WebBRS.Models;

using WebBRS.Models.Views;
using WebBRS.ViewModels.toRecieve;
namespace WebBRS.Controllers
{
	[ApiController]

	[Route("homeworks")]
	[Authorize]
	public class HomeWorkController : Controller
	{
		// GET: HomeWorkController
		private UnitOfWork unit = new UnitOfWork();
		private Guid UserId => Guid.Parse(User.Claims.Single(c=>c.Type==ClaimTypes.NameIdentifier).Value);
		public ActionResult Index()
		{
			return View();
		}
		[HttpGet("GetDraftTimeTables/{IdDraft}")]
		public List<DraftTimeTableVM> GetDraftTimeTables(int IdDraft)
		{
			List<DraftTimeTableVM> drafts = new List<DraftTimeTableVM>();
			List<DraftTimeTable> draftTimes = unit.DraftTimeTables.GetAll().ToList();
			foreach (var item in draftTimes)
			{
				DraftTimeTableVM tableVM = new DraftTimeTableVM();
				tableVM.IdDFTT = item.IdDFTT;
				tableVM._Description = item._Description;
				drafts.Add(tableVM);
			}
			return drafts;
		}
		[HttpGet("GetDraftTipes/{IdDraftType}")]

		public List<TypeTimeTableVM> GetDraftTipes(int IdDraftType)
		{
			List<TypeTimeTableVM> drafts = new List<TypeTimeTableVM>();
			List<TypeTimeTable> draftTimes = unit.TypesTimeTable.GetAll().ToList();
			foreach (var item in draftTimes)
			{
				TypeTimeTableVM tableVM = new TypeTimeTableVM();
				tableVM.IdDTTT = item.idTTT;
				tableVM._Description = item.Name;
				drafts.Add(tableVM);
			}
			return drafts;
		}
		[HttpGet("getall")]
		public IEnumerable<ClassWork> GetDepartments()
		{
			try
			{
				IEnumerable<ClassWork> tmp = unit.Homeworks.GetAll();
				//int i;
				return tmp;
				//return unit.CathInfo.GetAll();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		[HttpGet("getWorkTypes/{IdWT}")]

		public List<WorkType> GetWorkTypes(string IdWT)
		{
			List<WorkType> workTypes = unit.context.WorkTypes.ToList();
			if (workTypes.Count > 2)
			{
				var buf = workTypes.Find(g => g.IdWT == Convert.ToInt32(IdWT));
				var buf2 = workTypes[workTypes.Count() - 1];
				workTypes[workTypes.Count() - 1] = buf;
				workTypes[workTypes.FindIndex(g => g.IdWT == Convert.ToInt32(IdWT))] = buf2;
			}
			return workTypes;
		}
		[HttpGet("getClassWork/{IdSelectedDraft}/{IdSelectedDraftType}/{DateTimeExact}/{Done}/{Checked}")]
		public List<AttedanceForWork> GetAttedanceForWorks(string IdSelectedDraft, string IdSelectedDraftType, bool Done, bool Checked)
		{
			List<AttedanceForWork> attedanceForWorks = new List<AttedanceForWork>();
			int IdLecturerPerson = 1739436573;
			Person person = unit.Persons.Get(p => p.IdPerson == IdLecturerPerson);
			List<ExactClass> exactClasses = unit.ExactClasses
				.GetAll(ex => ex.PersonLecturerIdPerson == person.IdPerson && ex.DraftTimeTableIdDFTT.ToString() == IdSelectedDraft && ex.TypeTimeTableidTTT.ToString() == IdSelectedDraftType).ToList();
			List<Attendance> attendances = new List<Attendance>();
			foreach (var item in exactClasses)
			{
				foreach (var j in item.Attendances)
				{
					if (j.Loaded != null)
					{
						if ((bool)j.Loaded)
						{
							AttedanceForWork attedanceForWork = new AttedanceForWork();
							attedanceForWork.IdAtt = j.IdAtt;
							attedanceForWork.BallHW = 0;
							attedanceForWork.FilePath = j.FilePath;
							attedanceForWork.PersonFIO = j.FilePath;
							attedanceForWork.TextDoClassWork = j.TextDoClassWork;
							attedanceForWork.DatePass = j.DatePass.ToString();
							StudentsGroupHistory studentsGroupHistory = unit.StudentGroupHistories.Get(sgh => sgh.IdSGH == j.IdSGH);
							Student student = unit.Students.Get(s => s.IdStudent == studentsGroupHistory.IdStudent);
							Person personStud = unit.Persons.Get(p => p.IdPerson == student.IdPerson);
							attedanceForWork.PersonFIO = personStud.PersonFIOShort();
							if (j.BallHW != null)
							{
								attedanceForWork.BallHW = (double)j.BallHW;
							}
							if (j.Done != null)
							{
								attedanceForWork.Done = (bool)j.Done;
							}
							attedanceForWorks.Add(attedanceForWork);
						}
					}

				}

				//attendances.Add(attendance);
			}

			return attedanceForWorks;
		}
		[HttpGet("getClassWork/{IdSelectedDraft}/{IdSelectedDraftType}/{DateTimeExact}/{IdCourse}")]
		public ClassWorkVMUnion GetClassWorks(string IdSelectedDraft, string IdSelectedDraftType, string DateTimeExact, string IdCourse)
		{
			//try
			{
				int IdPerson = 1739436577;

				Person person = unit.Persons.Get(IdPerson);
				Student student = unit.Students.Get(st => st.IdPerson == person.IdPerson);

				List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
					.GetAll(sgh => sgh.IdStudent == student.IdStudent && sgh.CourseIdCourse.ToString() == IdCourse && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
				var studentsSorted = from s in studentsGroupHistories
									 orderby s.DateSGHFinished
									 select s;
				List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
				StudentsGroupHistory sgh = studentsSortedList[0];
				List<SubjectForGroup> sfgs = unit.SubjectForGroups.GetAll(sfg => sfg.IdGroup == sgh.GroupIdGroup && sfg.DraftTimeTableIdDFTT.ToString() == IdSelectedDraft).ToList();
				List<DayStudent> Days = new List<DayStudent>();
				DateTime dateChoosen = Convert.ToDateTime(DateTimeExact);
				int currentDoW = Convert.ToInt32(dateChoosen.DayOfWeek);
				if (DateTimeExact == "undefined")
				{
					DateTimeExact = DateTime.Now.ToString();
				}
				DateTime dayBuf = dateChoosen;
				if (currentDoW == 0)
				{
					currentDoW = 6;
				}
				if (currentDoW > 1)
				{
					var Day1 = dayBuf.AddDays(-currentDoW);
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

				while (/*Convert.ToInt32(Days[j-1].Date.DayOfWeek)*/Days.Count < 7)
				{
					DayStudent day = new DayStudent();
					day.Date = Days[j - 1].Date.AddDays(1);
					day.DayOfWeek = GetDayOfWeek(day.Date);
					Days.Add(day);
					j++;
				}
				List<ExactClass> exactClasses = unit.ExactClasses.GetAll(ex => ex.DraftTimeTableIdDFTT.ToString() == IdSelectedDraft && ex.TypeTimeTableidTTT.ToString() == IdSelectedDraftType).ToList();
				List<ClassWorkVM> tmp = new List<ClassWorkVM>();
				foreach (var i in exactClasses)
				{
					ClassWork cw = unit.Homeworks.Get(cw => cw.IdClass == i.IdClass);
					if (cw != null)
					{
						Attendance attendance = unit.Attendances.Get(at => at.ExactClassIdClass == i.IdClass);
						if (attendance.Done == null)
						{
							attendance.Done = false;
						}
						if (!(bool)attendance.Done)
						{
							ClassWorkVM classWorkVM = new ClassWorkVM();
							classWorkVM.IdClass = cw.IdClass;
							classWorkVM.IdClassWork = cw.IdClassWork;
							classWorkVM.FilePathWork = cw.FilePathWork;
							classWorkVM.DateGiven = cw.DateGiven.ToString("d");
							classWorkVM.DatePass = cw.DatePass.ToString("d");
							classWorkVM.MaxBall = cw.MaxBall;
							classWorkVM.TextWork = cw.TextWork;

							if (cw.TextWork.Length > 14)
							{
								classWorkVM.TextWork = classWorkVM.TextWork.Substring(0, 15) + "...";
							}

							classWorkVM.LecturerFIO = i.PersonLecturer.PersonFIOShort();
							tmp.Add(classWorkVM);
						}

					}
				}
				List<ExactClass> exactClasses2 = unit.ExactClasses
					.GetAll(ex => ex.DraftTimeTableIdDFTT.ToString() == IdSelectedDraft
					&& ex.TypeTimeTableidTTT.ToString() == IdSelectedDraftType
					&& ex.DateClassStart > Days[0].Date && ex.DateClassStart < Days[6].Date).ToList();
				List<ClassWorkVM> tmp2 = new List<ClassWorkVM>();
				foreach (var i in exactClasses2)
				{
					ClassWork cw = unit.Homeworks.Get(cw => cw.IdClass == i.IdClass);
					if (cw != null)
					{
						Attendance attendance = unit.Attendances.Get(at => at.ExactClassIdClass == i.IdClass);
						if (attendance.Done == null)
						{
							attendance.Done = false;
						}
						if (!(bool)attendance.Done)
						{
							ClassWorkVM classWorkVM = new ClassWorkVM();
							classWorkVM.IdClass = cw.IdClass;
							classWorkVM.IdClassWork = cw.IdClassWork;
							classWorkVM.FilePathWork = cw.FilePathWork;
							classWorkVM.DateGiven = cw.DateGiven.ToString("d");
							classWorkVM.DatePass = cw.DatePass.ToString("d");
							classWorkVM.MaxBall = cw.MaxBall;
							classWorkVM.TextWork = cw.TextWork;

							if (cw.TextWork.Length > 14)
							{
								classWorkVM.TextWork = classWorkVM.TextWork.Substring(0, 15) + "...";
							}
							classWorkVM.LecturerFIO = i.PersonLecturer.PersonFIOShort();
							tmp2.Add(classWorkVM);
						}

					}
				}
				ClassWorkVMUnion classWorkVMUnion = new ClassWorkVMUnion();
				classWorkVMUnion.classWorkVMAll = tmp;
				classWorkVMUnion.classWorkVM = tmp2;
				return classWorkVMUnion;
			}
			//catch (Exception ex)
			{
				//return null;
			}
		}
		public string GetDayOfWeek(DateTime dateTime)
		{
			DateTimeFormatInfo dateTimeFormats = new CultureInfo("ru-RU").DateTimeFormat;
			string dateString = dateTime.Date.ToString();
			//StudentsGroupHistory studentsGroupHistory = unit.StudentGroupHistories.Get();
			DateTime dateValue = DateTime.ParseExact(dateString, "dd.MM.yyyy h:mm:ss", CultureInfo.InvariantCulture); ;
			DateTimeOffset dateOffsetValue;
			dateOffsetValue = new DateTimeOffset(dateValue,
										 TimeZoneInfo.Local.GetUtcOffset(dateValue));
			return dateValue.ToString("dddd", dateTimeFormats);
		}
		[HttpPost("addHW")]

		public IActionResult AddHomeWork()
		{
			return null;
		}
		[HttpPost("UpdateHomeWork")]
		public IActionResult UpdateHomeWork(AttedanceForWork data)
		{
			if (ModelState.IsValid)
			{
				Attendance att = unit.Attendances.Get(c => c.IdAtt == data.IdAtt);             //cw.IdWT = data.IdWT;
				att.TextDoClassWork = data.TextDoClassWork;
				att.DatePass = DateTime.Now;
				att.FilePath = data.FilePath;
				unit.Attendances.Update(att);
				unit.Save();

				return Ok(data);
			}
			return BadRequest(ModelState);
		}
		[HttpPost("addMyHW")]
		public JsonResult AddCW([FromBody] HomeWorksModelView data)
		{
			HomeWorksModelView tmp = new HomeWorksModelView
			{
				IdClassWork = 1,
				IdClass = 1,
				TextWork = "Задание тест 1",
				FilePathWork = "/homework/tasks/",
				DateTimeGiven = new DateTime(),
				MaxBall = 25
			};
			Attendance attendance = unit.Attendances.Get(a => a.IdAtt == 3);
			ClassWork cw = new ClassWork();
			attendance.DateTimePass = DateTime.Now;
			attendance.FilePath = tmp.FilePathWork;
			attendance.TextDoClassWork = "kek";
			unit.Attendances.Update(attendance);
			unit.Save();

		skip:

			return Json("nice");
		}

		// GET: HomeWorkController/Details/5
		[HttpPost("UpdateClassWork")]
		public IActionResult UpdateClassWork(ClassWork data)
		{
			if (ModelState.IsValid)
			{
				ClassWork cw = new ClassWork();
				ClassWork cw2 = unit.ClassWorks.Get(c => c.IdClass == data.IdClass);
				if (data.IdClassWork==0&&cw2==null)
				{
					cw.MaxBall = data.MaxBall;
					cw.TextWork = data.TextWork;
					cw.FilePathWork = data.FilePathWork;
					cw.DateGiven = data.DateGiven;
					cw.IdWT = data.IdWT;
					cw.IdClass = data.IdClass;
					cw.DatePass = data.DatePass;
					unit.ClassWorks.Create(cw);
				}
				else
				{
					cw = unit.ClassWorks.Get(c => c.IdClass == data.IdClass);             
					cw.MaxBall = data.MaxBall;
					cw.TextWork = data.TextWork;
					cw.FilePathWork = data.FilePathWork;
					cw.DateGiven = data.DateGiven;
					cw.IdWT = data.IdWT;					
					cw.DatePass = data.DatePass;
					unit.ClassWorks.Update(cw);
				}
		
				unit.Save();

				return Ok(cw);
			}
			return BadRequest(ModelState);
		}
		[HttpGet("GetClassWork/{IdClass}")]

		public ClassWork GetClassWork(int IdClass)
		{
			ClassWork classWork = unit.ClassWorks.Get(cw => cw.IdClass == IdClass);
			if (classWork == null)
			{
				classWork = new ClassWork();
				classWork.IdClassWork = 0;
				classWork.IdClass = IdClass;
				classWork.MaxBall = 0;
				classWork.TextWork = "";
				classWork.IdWT = 2;
				classWork.WorkType = unit.context.WorkTypes.Find(classWork.IdWT);

			}
			return classWork;
		}
		[HttpGet("GetClassWorkStudent/{IdClass}")]

		public ClassWorkVM GetClassWorkStudent(int IdClass)
		{
			ClassWork classWork = unit.ClassWorks.Get(cw => cw.IdClass == IdClass);
			ClassWorkVM classWorkVM = new ClassWorkVM();

			if (classWork != null)
			{
				classWorkVM.FilePathWork = classWork.FilePathWork;
				classWorkVM.IdClass = classWork.IdClass;
				classWorkVM.MaxBall = classWork.MaxBall;
				classWorkVM.TextWork = classWork.TextWork;
				classWorkVM.IdClassWork = classWork.IdClassWork;
				classWorkVM.DateGiven = classWork.DateGiven.ToString("d");
				classWorkVM.DatePass = classWork.DatePass.ToString("d");
				ExactClass exactClass = unit.ExactClasses.Get(ex => ex.IdClass == IdClass);
				SubjectForGroup sfg = unit.SubjectForGroups.Get(sfg => sfg.ID_reff == exactClass.ID_reff);
				classWorkVM.SubjectName = sfg.Subject.NameSubject;
				classWorkVM.LecturerFIO = exactClass.PersonLecturer.PersonFIOShort();
			}
			else
			{
				classWorkVM.FilePathWork = "";
				classWorkVM.IdClass = IdClass;
				classWorkVM.MaxBall = 0;
				classWorkVM.TextWork = "";
				classWorkVM.IdClassWork =0;
				classWorkVM.DateGiven = DateTime.Now.ToString("d");
				classWorkVM.DatePass = DateTime.Now.ToString("d");
				ExactClass exactClass = unit.ExactClasses.Get(ex => ex.IdClass == IdClass);
				SubjectForGroup sfg = unit.SubjectForGroups.Get(sfg => sfg.ID_reff == exactClass.ID_reff);
				classWorkVM.SubjectName = sfg.Subject.NameSubject;
				classWorkVM.LecturerFIO = exactClass.PersonLecturer.PersonFIOShort();
			}
			
			return classWorkVM;
		}
		[HttpGet("GetClassWorkStudentAnswer/{IdClass}")]

		public AttedanceForWork GetClassWorkStudentAnswer(int IdClass)
		{
			ClassWork classWork = unit.ClassWorks.Get(cw => cw.IdClass == IdClass);
			//изменить когда появится аутнетификация
			int IdPerson = 1739436577;
			Student student = unit.Students.Get(s => s.IdPerson == IdPerson);
			ExactClass exactClass = unit.ExactClasses.Get(ex => ex.IdClass == IdClass);
			SubjectForGroup subjectForGroup = unit.SubjectForGroups.Get(sfg => sfg.ID_reff == exactClass.ID_reff);
			List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
	.GetAll(sgh => sgh.IdStudent == student.IdStudent && sgh.CourseIdCourse == subjectForGroup.IdCourse && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
			var studentsSorted = from s in studentsGroupHistories
								 orderby s.DateSGHFinished
								 select s;
			List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
			StudentsGroupHistory sgh = studentsSortedList[0];
			Attendance attendance = unit.Attendances.Get(cw => cw.ExactClassIdClass == IdClass);
			AttedanceForWork attedanceForWork = new AttedanceForWork();
			attedanceForWork.IdAtt = attendance.IdAtt;
			attedanceForWork.BallHW = (double)attendance.BallHW;
			attedanceForWork.TextDoClassWork = attendance.TextDoClassWork;
			attedanceForWork.FilePath = attendance.FilePath;
			attedanceForWork.DatePass = "не сдано";

			if (attendance.DatePass != null)
			{
				DateTime datepass = (DateTime)attendance.DatePass;
				attedanceForWork.DatePass = datepass.ToString("d");
			}
			return attedanceForWork;
		}

		// GET: HomeWorkController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: HomeWorkController/Create


	}
}
