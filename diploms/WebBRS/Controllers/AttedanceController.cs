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

		[HttpGet("getLecturerClass/{IdEXCFLC}/{id_group}/{actual}")]
		public ExactClassForLecturerClassVM GetLecturerClass(string IdEXCFLC, string id_selected_group, string actual)
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
					SubjectForGroup subjectForGroup = unit.SubjectForGroups.Get(sfg => sfg.IdSFG == ec.SubjectForGroup.IdSFG);
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
					Person person = unit.Persons.Get(p=>p.IdPerson == item.Student.IdPerson);
					item.Student.Person = person;
				};
				classVM.Students = new List<StudentEXC>();
				foreach (var item in students)
				{
					StudentEXC student = new StudentEXC()
					{
						IdStudent = item.IdSGH,
						PersonFIO = item.Student.Person.PersonFIOShort(),
						Attedanced = unit.Attendances.Get(at => at.SGH.IdSGH == item.IdSGH && at.ExactClass.ExactClassForLecturerClass.IdEXCFLC == classVM.IdECFLC).TypeAttedance

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
