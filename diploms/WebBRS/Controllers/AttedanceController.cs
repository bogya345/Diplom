using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBRS.DAL;
using WebBRS.Models;

using WebBRS.Models.Views;
using WebBRS.ViewModels.toRecieve;

namespace WebBRS.Controllers
{
	[ApiController]

	[Route("attedance")]
	public class AttedanceController : Controller
	{
		private UnitOfWork unit = new UnitOfWork();

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost("addMyHW")]
		public JsonResult AddAttdeancec([FromBody] HomeWorksModelView data)
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
			Attendance attendance = unit.Attendances.Get(a => a.IdAtt == 1);
			ClassWork cw = new ClassWork();
			attendance.DateTimePass = DateTime.Now;
			attendance.FilePath = tmp.FilePathWork;
			attendance.TextDoClassWork = "kek";
			unit.Attendances.Update(attendance);
			unit.Save();

		skip:

			return Json("nice");
		}
		/// <summary>
		/// Получение списка группы по конкретному предмету
		/// </summary>
		/// <param name="IdSfg"></param>
		/// <param name="id_selected_group"></param>
		/// <param name="actual"></param>
		/// <returns></returns>
		//[HttpGet("GetAttedanceTable/{IdSfg}/{id_selected_group}/{actual}")]
		[HttpGet("GetAttedanceTable/{ID_reff}/{id_selected_group}/{actual}")]
		public ExactClassForLecturerClassTable GetAttedanceTable(string ID_reff, string id_selected_group, string actual)
		{
			ExactClassForLecturerClassTable ecflct = new ExactClassForLecturerClassTable();

			List<ExactClass> exactClasses = unit.ExactClasses.GetAll(ec => ec.ID_reff.ToString() == ID_reff).ToList();
			ecflct.LecturerFIO = exactClasses[0].PersonLecturer.PersonFIOShort();
			ecflct.Date = DateTime.Now.ToString("d");
			foreach (var i in exactClasses)
			{
				ExactClassVMforTable ex = new ExactClassVMforTable
				{
					IdClass = i.IdClass,
					DateExactClass = i.DateClassStart.AddYears(-1995).ToString("d"),
					Theme = i.Theme,
				};
				if (i.Theme != null)
				{
					ex.ThemeShort = i.Theme.Substring(0, 11);
				}				
				ecflct.ExactClasses.Add(ex);
			}
			ecflct.IdSFG = Convert.ToInt32(ID_reff);
			SubjectForGroup sfgReact = unit.SubjectForGroups.Get(sfg => sfg.ID_reff == Convert.ToInt32(ID_reff));
			ecflct.SubjectName = sfgReact.ToString();
			ecflct.Students = new List<StudentTable>();
			ecflct.Groups = new List<GroupAttedanceTable>();
			List<SubjectForGroup> subjectForGroups = unit.SubjectForGroups.GetAll(sfg => sfg.IdPerson == sfgReact.IdPerson && (sfg.IdGroup != null || sfg.IdGroup != 0) && sfg.IdSubject == sfgReact.IdSubject).ToList();
			foreach (var item in subjectForGroups)
			{
				GroupAttedanceTable gr_temp = new GroupAttedanceTable();
				gr_temp.idGroup = item.IdGroup;
				gr_temp.GroupName = item.Group.GroupName;
				if (!ecflct.Groups.Any(g => g.idGroup == item.IdGroup))
				{
					ecflct.Groups.Add(gr_temp);
				}
			};
			if (id_selected_group == "null")
			{
				ecflct.SelectedGroup = ecflct.Groups[0].idGroup;

			}
			else { ecflct.SelectedGroup = Convert.ToInt32(id_selected_group); }
			List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
				.GetAll(sgh => sgh.GroupIdGroup == ecflct.SelectedGroup && sgh.CourseIdCourse == sfgReact.IdCourse && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
			var studentsSorted = from student in studentsGroupHistories
								 orderby student.DateSGHStart
								 select student;
			List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
			foreach (var item in studentsSortedList)
			{
				StudentTable groupAttedanceTable = new StudentTable();
				Person person = unit.Persons.Get(p => p.IdPerson == item.Student.IdPerson);
				groupAttedanceTable.PersonFIO = person.PersonFIOShort();
				groupAttedanceTable.IdStudent = item.IdStudent;
				groupAttedanceTable.Attedanced = new List<AttedancedVMType>(ecflct.ExactClasses.Count);
				List<Attendance> attendances = new List<Attendance>(ecflct.ExactClasses.Count);
				foreach (var i in ecflct.ExactClasses)
				{
					AttedancedVMType attedanced = new AttedancedVMType();
					groupAttedanceTable.Attedanced.Add(attedanced);
				}
				attendances = unit.Attendances.GetAll(a => a.SGH.IdSGH == item.IdSGH).ToList();
				//int i = 0;
				for (int i = 0; i < groupAttedanceTable.Attedanced.Count(); i++)
				{
					//string att = "";

					foreach (var item2 in attendances)
					{
						
						if (ecflct.ExactClasses[i].IdClass == item2.ExactClassIdClass)
						{
							if (item2.Ball != null)
							{
								groupAttedanceTable.Balls = (double)item2.Ball + groupAttedanceTable.Balls;
							};
							if(item2.TypeAttedanceIdTA == 3)
							{
								groupAttedanceTable.Misses += 1;
							}
							groupAttedanceTable.Attedanced[i].attedanced = item2.TypeAttedance.TAShortName ;
							groupAttedanceTable.Attedanced[i].Ball =  item2.Ball.ToString();
							groupAttedanceTable.Attedanced[i].BallHW =  item2.BallHW.ToString();
							List<AttedanceReason> attedanceReason = unit.AttedanceReasons.GetAll(ar=>ar.Confirmed==true&&ar.DateTimeStart<item2.ExactClass.DateClassStart&&ar.DateTimeEnd>item2.ExactClass.DateClassEnd).ToList();
							if (item2.TypeAttedanceIdTA == 4)
							{
								groupAttedanceTable.Attedanced[i].Type = "danger";

							}
							else
							{
								groupAttedanceTable.Attedanced[i].Type = "success";

							}

							foreach (var att in attedanceReason)
							{
								if (att.Confirmed)
								{
									groupAttedanceTable.Attedanced[i].Type = "success";

								}
							}
							break;
						}
						else
						{
							groupAttedanceTable.Attedanced[i].attedanced = " ";
						}
					}
				}
				ecflct.Students.Add(groupAttedanceTable);
			}
			if (ecflct.Groups.Count > 2)
			{
				var buf = ecflct.Groups.Find(g => g.idGroup == ecflct.SelectedGroup);
				var buf2 = ecflct.Groups[ecflct.Groups.Count() - 1];
				ecflct.Groups[ecflct.Groups.Count() - 1] = buf;
				ecflct.Groups[ecflct.Groups.FindIndex(g => g.idGroup == ecflct.SelectedGroup)] = buf2;
			}
			ecflct.IdECFLCT = Convert.ToInt32(ID_reff);
			ecflct.Groups.Reverse();
			return ecflct;
		}
		[HttpGet("getLecturerClass/{IdECFLCT}/{IdClass}/{id_group}/{actual}")]
		public ExactClassForLecturerClassVM GetClass(string IdECFLCT, string IdClass, string id_group, string actual)
		{
			//try
			{

				ExactClassForLecturerClassVM classVM = new ExactClassForLecturerClassVM();

				ExactClass exactClass = unit.ExactClasses.Get(ec => ec.IdClass.ToString() == IdClass);
				Person lecturer = unit.Persons
					.Get(l => l.IdPerson == exactClass.PersonLecturerIdPerson);
				SubjectForGroup sfgReact = unit.SubjectForGroups.Get(sfg => sfg.ID_reff == exactClass.ID_reff);
				List<SubjectForGroup> subjectForGroups = unit.SubjectForGroups.GetAll(sfg => sfg.IdPerson == sfgReact.IdPerson && (sfg.IdGroup != null || sfg.IdGroup != 0) && sfg.IdSubject == sfgReact.IdSubject).ToList();
				foreach (var item in subjectForGroups)
				{
					GroupVM gr_temp = new GroupVM();
					gr_temp.idGroup = item.IdGroup;
					gr_temp.GroupName = item.Group.GroupName;
					if (!classVM.Groups.Any(g => g.idGroup == item.IdGroup))
					{
						classVM.Groups.Add(gr_temp);
					}
				};
				if (id_group == "null")
				{
					id_group = "1739436558";
					classVM.SelectedGroup = Convert.ToInt32(id_group);
				}
				classVM.SubjectName = sfgReact.Subject.NameSubject;
				classVM.SelectedGroup = Convert.ToInt32(id_group);
				classVM.IdClass = Convert.ToInt32(IdClass);
				if (exactClass.Theme != null)
				{
					classVM.Theme = exactClass.Theme;
				}
				else
				{
					classVM.Theme = "";
				}
				var kek = CreateAttedances(IdECFLCT, IdClass, sfgReact.IdPerson, sfgReact.IdSubject);
				classVM.DateTime = exactClass.DateClassStart.AddYears(-1995).ToString("d");
				List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
				.GetAll(sgh => sgh.GroupIdGroup == classVM.SelectedGroup && sgh.CourseIdCourse == sfgReact.IdCourse && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
				var studentsSorted = from student in studentsGroupHistories
									 orderby student.DateSGHStart
									 select student;
				List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();


				classVM.Lecturer = new LecturerVM()
				{
					IdLecturer = lecturer.IdPerson,
					PersonFIO = lecturer.PersonFIOShort()
				};
				List<StudentsGroupHistory> students = new List<StudentsGroupHistory>();
				List<GroupVM> groupVMs = new List<GroupVM>();
				classVM.SelectedGroup = Convert.ToInt32(id_group);
				classVM.TypeAttedances = unit.TypeAttedances.GetAll().ToList();

				foreach (var item in studentsSortedList)
				{
					StudentEXC groupAttedanceTable = new StudentEXC();
					Person person = unit.Persons.Get(p => p.IdPerson == item.Student.IdPerson);
					groupAttedanceTable.PersonFIO = person.PersonFIOShort();
					groupAttedanceTable.IdStudent = item.IdStudent;
					List<Attendance> attendances = new List<Attendance>();
					Attendance attendance = unit.Attendances.Get(at => at.IdSGH == item.IdSGH && at.ExactClassIdClass == classVM.IdClass);
					groupAttedanceTable.AttedanceTypeSelected = attendance.TypeAttedanceIdTA;
					List<TypeAttedance> tas = unit.TypeAttedances.GetAll().ToList();
					foreach (var j in tas)
					{
						TypeAttedanceVM typeAttedanceVM = new TypeAttedanceVM();
						typeAttedanceVM.IdAtt = attendance.IdAtt;
						typeAttedanceVM.IdTA = j.IdTA;
						typeAttedanceVM.TAName = j.TAName;
						typeAttedanceVM.TAShortName = j.TAShortName;
						groupAttedanceTable.Attedanced.Add(typeAttedanceVM);
					}
					var buf = groupAttedanceTable.Attedanced.Find(g => g.IdTA == groupAttedanceTable.AttedanceTypeSelected);
					var buf2 = groupAttedanceTable.Attedanced[groupAttedanceTable.Attedanced.Count() - 1];
					groupAttedanceTable.Attedanced[groupAttedanceTable.Attedanced.Count() - 1] = buf;
					groupAttedanceTable.Attedanced[groupAttedanceTable.Attedanced.FindIndex(g => g.IdTA == groupAttedanceTable.AttedanceTypeSelected)] = buf2;
					groupAttedanceTable.IdAttedance = attendance.IdAtt;
					groupAttedanceTable.HW = new HomeWorkStudent();

					groupAttedanceTable.Ball = (double)attendance.Ball;
					groupAttedanceTable.BallHW = (double)attendance.BallHW;
					groupAttedanceTable.HW.StringFilePath = attendance.FilePath;
					groupAttedanceTable.HW.ShortTextHW = attendance.TextDoClassWork;
					classVM.Students.Add(groupAttedanceTable);
				}
				if (classVM.Groups.Count > 2)
				{
					var buf = classVM.Groups.Find(g => g.idGroup == classVM.SelectedGroup);
					var buf2 = classVM.Groups[classVM.Groups.Count() - 1];
					classVM.Groups[classVM.Groups.Count() - 1] = buf;
					classVM.Groups[classVM.Groups.FindIndex(g => g.idGroup == classVM.SelectedGroup)] = buf2;
				}
				classVM.IdECFLCT = Convert.ToInt32(IdECFLCT);
				classVM.Groups.Reverse();
				//Attendance attBuf = unit.Attendances.Get(at => at.IdAtt==3);

				return classVM;
			}
			//catch (Exception ex)
			//{
			//	return null;
			//}
		}

		//[Authorize(Roles = "Преподаватель,Заведующий,Админ")]
		[HttpPost("UpdateAttedance")]
		public IActionResult UpdateAttedance(ExactClassForLecturerClassVM data)
		{
			if (ModelState.IsValid)
			{
				List<Attendance> attendances = new List<Attendance>();
				List<TypeAttedanceVM> attVm = new List<TypeAttedanceVM>();
				var exactclass = unit.ExactClasses.Get(ex => ex.IdClass == data.IdClass);
				exactclass.Theme = data.Theme;
				unit.ExactClasses.Update(exactclass);
				foreach (var i in data.Students)
				{
					var att = unit.Attendances.Get(a => a.IdAtt == i.IdAttedance);
					att.TypeAttedanceIdTA = i.AttedanceTypeSelected;
					att.Ball = i.Ball;
					att.BallHW = i.BallHW;
					unit.Attendances.Update(att);
					unit.Save();
				}
				return Ok(data);
			}
			unit.Save();

			return BadRequest(ModelState);
		}
		[HttpPost("UpdateClassWork")]
		public IActionResult UpdateClassWork(ClassWork data)
		{
			if (ModelState.IsValid)
			{
				ClassWork cw = unit.ClassWorks.Get(c => c.IdClassWork == data.IdClassWork);
				cw.MaxBall = data.MaxBall;
				cw.TextWork = data.TextWork;
				cw.FilePathWork = data.FilePathWork;
				cw.DateGiven = data.DateGiven;
				unit.ClassWorks.Update(cw);
				unit.Save();
				return Ok(data);
			}
			return BadRequest(ModelState);
		}
		
		public bool CreateAttedances(string IdECFLCT, string IdClass, int IdPerson, int IdSubject)
		{
			ExactClass exactClass = unit.ExactClasses.Get(ec => ec.IdClass.ToString() == IdClass);
			List<SubjectForGroup> sfgs = unit.SubjectForGroups.GetAll(sfg => sfg.IdPerson == IdPerson && (sfg.IdGroup != null || sfg.IdGroup != 0) && sfg.IdSubject == IdSubject).ToList();
			List<StudentsGroupHistory> sghs = new List<StudentsGroupHistory>();
			List<Group> groups = new List<Group>();
			foreach (var i in sfgs)
			{
				if (!groups.Any(g => g.IdGroup == i.IdGroup))
				{
					groups.Add(i.Group);
				}
			}
			foreach (var j in groups)
			{
				SubjectForGroup sfg = sfgs.Where(s => s.IdGroup == j.IdGroup).FirstOrDefault();
				List<StudentsGroupHistory> sghBuf = unit.StudentGroupHistories
					 .GetAll(sgh => sgh.GroupIdGroup == j.IdGroup && sgh.CourseIdCourse == sfg.IdCourse
					 && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
				foreach (var k in sghBuf)
				{
					Attendance attBuf = unit.Attendances.Get(at => at.ExactClassIdClass == exactClass.IdClass && at.IdSGH == k.IdSGH);
					if (attBuf == null)
					{
						Attendance att = new Attendance();
						att.TypeAttedanceIdTA = 1;
						att.IdSGH = k.IdSGH;
						att.Ball = 0;
						att.BallHW = 0;
						att.Done = false;
						att.Checked = false;
						att.ExactClassIdClass = exactClass.IdClass;
						unit.Attendances.Create(att);
						unit.Save();
					}
				}
			}
			return true;
		}
	}
}
