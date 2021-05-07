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
			//			public int IdClassWork { get; set; }
			//public int IdClass { get; set; }
			//public string TextWork { get; set; }
			//public string FilePathWork { get; set; }
			//public double MaxBall { get; set; }

			//public DateTime DateTimeGiven { get; set; }
			//goto skip;

			HomeWorksModelView tmp = new HomeWorksModelView
			{
				IdClassWork = 1,
				IdClass = 1,
				TextWork = "Задание тест 1",
				FilePathWork = "/homework/tasks/",
				DateTimeGiven = new DateTime(),
				MaxBall = 25
			};
			Attendance attendance = unit.Attendances.Get(a => a.ExactClass.IdClass == tmp.IdClass);
			ClassWork cw = new ClassWork();
			attendance.DateTimePass = DateTime.Now;
			attendance.FilePath = tmp.FilePathWork;
			attendance.TextDoClassWork = "kek";

			//cw.DateGiven = DateTime.Now;
			//cw.MaxBall = tmp.MaxBall;
			//cw.FilePathWork = tmp.FilePathWork;
			//cw.ExactClass.IdClass = tmp.IdClass;
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
			foreach(var i in exactClasses)
			{
				ExactClassVMforTable ex = new ExactClassVMforTable
				{
					IdClass = i.IdClass,
					DateExactClass = Convert.ToString(i.DateClassStart.Date)
				};
				ecflct.ExactClasses.Add(ex);
			}
			ecflct.IdECFLCT = -1194773169;
			ecflct.SelectedGroup = Convert.ToInt32(id_selected_group);
			ecflct.IdSFG = Convert.ToInt32(ID_reff);
			//SubjectForGroup sfgReact = unit.SubjectForGroups.Get(sfg => sfg.IdSFG.ToString() == id_selected_group);
			SubjectForGroup sfgReact = unit.SubjectForGroups.Get(sfg=>sfg.ID_reff ==  Convert.ToInt32(ID_reff));
			ecflct.SubjectName = sfgReact.ToString();
			ecflct.Students = new List<StudentTable>();
			ecflct.Groups = new List<GroupAttedanceTable>();
			List<SubjectForGroup> subjectForGroups = unit.SubjectForGroups.GetAll(sfg => sfg.IdPerson == sfgReact.IdPerson && (sfg.IdGroup!=null||sfg.IdGroup!=0) && sfg.IdSubject==sfgReact.IdSubject).ToList();
			foreach (var item in subjectForGroups)
			{
				GroupAttedanceTable gr_temp = new GroupAttedanceTable();
				gr_temp.idGroup = item.IdGroup;
				gr_temp.GroupName = item.Group.GroupName;
				if (!ecflct.Groups.Any(g=>g.idGroup == item.IdGroup))
				{
					ecflct.Groups.Add(gr_temp);
				}
			};
			List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories.GetAll(sgh => sgh.GroupIdGroup.ToString() == id_selected_group && sgh.CourseIdCourse== sfgReact.IdCourse && sgh.ConditionOfPersonIdConditionOfPerson== 1601441643).ToList();
			var studentsSorted = from student in studentsGroupHistories
												  orderby student.DateSGHFinished
									   select  student;
			List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
			//foreach (var item in studentsSorted)
			//{
			//	if(item.ConditionOfPersonIdConditionOfPerson== 1601441637)
			//	{
			//		List <StudentsGroupHistory> studentConditions = studentsSortedList
			//						.Where(sgh => sgh.IdStudent == item.IdStudent&&sgh.GroupIdGroup==item.GroupIdGroup).ToList();
			//		foreach (var studentCond in studentConditions)
			//		{
			//			if (studentCond.ConditionOfPersonIdConditionOfPerson== 1601441637) 
			//			{
			//				studentsSortedList.RemoveAll(sgh=>sgh.IdStudent==studentCond.IdStudent);
			//			}
			//		}
			//		//if (item.IdStudent=)
			//	}
			//}
			//studentsSortedList = studentsSortedList.Distinct()
			foreach (var item in studentsSortedList)
			{
				StudentTable groupAttedanceTable = new StudentTable();
				Person person = unit.Persons.Get(p => p.IdPerson == item.Student.IdPerson);
				groupAttedanceTable.PersonFIO = person.PersonFIOShort();
				groupAttedanceTable.IdStudent = item.IdStudent;
				List<Attendance> attendances = unit.Attendances.GetAll(a => a.SGH.IdSGH == item.IdSGH && a.SGH.ConditionOfPerson.IdConditionOfPerson == 1601441643).ToList();
				foreach (var item2 in attendances)
				{
					groupAttedanceTable.Attedanced.Add(item2.TypeAttedance.TAShortName);
				}
				ecflct.Students.Add(groupAttedanceTable);
			}
			var buf = ecflct.Groups.Find(g => g.idGroup.ToString() == id_selected_group);
			var buf2 = ecflct.Groups[ecflct.Groups.Count() - 1];
			ecflct.Groups[ecflct.Groups.Count() - 1] = buf;
			ecflct.Groups[ecflct.Groups.FindIndex(g => g.idGroup.ToString() == id_selected_group)] = buf2;
			ecflct.Groups.Reverse();
			return ecflct;
		}
		[HttpGet("getLecturerClass/{IdEXCFLC}/{id_group}/{actual}")]
		public ExactClassForLecturerClassVM GetClass(string IdEXCFLC, string id_selected_group, string actual)
		{
			try
			{
				//Lecturer lecturer = unit.Lecturers.Get(l => l.Person.Email == HttpContext.User.Identity.Name);
				Lecturer lecturer = unit.Lecturers.Get(l => l.Person.IdPerson == -1291072592);
				ExactClassForLecturerClass exactClassForLecturer = unit.ExactClassForLectureres
																		.Get(excfl => excfl.IdEXCFLC == Convert.ToInt32(IdEXCFLC));
				IEnumerable<ExactClass> exactClasses = exactClassForLecturer.ExactClasses;
				List<Group> groupesLecturerClass = new List<Group>();
				List<StudentsGroupHistory> students = new List<StudentsGroupHistory>();
				//if (actual == "true")
				//{
				//	 students = unit.StudentGroupHistories
				//				.GetAll(s => s.GroupIdGroup.ToString() == "156471939" && s.ConditionOfPersonIdConditionOfPerson== 1601441643).ToList();
				//}
				//else
				//{
				//  students = unit.StudentGroupHistories
				//			.GetAll(s => s.GroupIdGroup.ToString() == id_selected_group).ToList();
				//}

				foreach (ExactClass exactClass in exactClasses)
				{
					ExactClass ec = unit.ExactClasses.Get(ec => ec.IdClass == exactClass.IdClass);
					SubjectForGroup subjectForGroup = unit.SubjectForGroups.Get(sfg => sfg.IdSFG == Convert.ToInt32(ec.ID_reff));
					Group group = subjectForGroup.Group;
					groupesLecturerClass.Add(group);
				}
				exactClassForLecturer.Groups = groupesLecturerClass;
				//IEnumerable<StudentsGroupHistory> students = unit.StudentGroupHistories.GetAll(st => st.Group.IdGroup.ToString() == id_group);
				//int i;
				//tmp.ExactClasses = exactClasses.ToList();
				//tmp.Students = students.ToList();
				ExactClassForLecturerClassVM classVM = new ExactClassForLecturerClassVM()
				{
					IdECFLC = exactClassForLecturer.IdEXCFLC,
					Lecturer = new LecturerVM()
					{
						IdLecturer = lecturer.IdSLecturer,
						PersonFIO = lecturer.Person.PersonFIOShort(),
						email = lecturer.Person.Email
					},
					//SubjectName = 

				};
				classVM.TypeAttedances = unit.TypeAttedances.GetAll().ToList();
				foreach (var item in students)
				{
					Person person = unit.Persons.Get(p => p.IdPerson == item.Student.IdPerson);
					item.Student.Person = person;
				};
				classVM.Students = new List<StudentEXC>();
				foreach (var item in students)
				{
					StudentEXC student = new StudentEXC()
					{
						IdStudent = item.IdSGH,
						PersonFIO = item.Student.Person.PersonFIOShort(),
						Attedanced = unit.Attendances.Get(at => at.SGH.IdSGH == item.IdSGH && Convert.ToInt32(at.ExactClass.ID_reff) == classVM.IdECFLC).TypeAttedance

					};
					classVM.Students.Add(student);
				};

				return classVM;
				//return unit.CathInfo.GetAll();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
