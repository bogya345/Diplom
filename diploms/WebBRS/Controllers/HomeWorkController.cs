using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBRS.DAL;
using WebBRS.Models;
using WebBRS.ViewModels.toRecieve;

namespace WebBRS.Controllers
{
	[Route("homeworks")]

	public class HomeWorkController : Controller
	{
		// GET: HomeWorkController
		private UnitOfWork unit = new UnitOfWork();

		public ActionResult Index()
		{
			return View();
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
		[HttpPost("addHW")]

		public IActionResult AddHomeWork()
		{
			return null;
		}
		[HttpPost("addMyHW")]
		public JsonResult AddCW([FromBody] HomeWorksModelView data)
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
		//[HttpGet("get/{id_student}")]

		//public IEnumerable<Attendance> GetNotDoned(string id_student)
		//{
		//	try
		//	{
		//		int id_stud = Convert.ToInt32(id_student);
		//		Student student = unit.Students.Get(s => s.IdStudent.ToString() ==  id_student);
		//		StudentsGroupHistory studentsGroupHistory = unit.StudentGroupHistories.Get(sgh => sgh.Student.IdStudent == student.IdStudent);
		//		Attendance attendance = unit.Attendances.GetAll(att => att.SGH.IdSGH == studentsGroupHistory.IdSGH);
		//		//IEnumerable<DoClassWorkAttend> tmp = unit.PersonHomeworks.GetAll( x=>x.Attendance.IdAtt == attendance.IdAtt);
		//		//int i;
		//		return attendance;
		//		//return unit.CathInfo.GetAll();
		//	}
		//	catch (Exception ex)
		//	{
		//		return null;
		//	}
		//}
		// GET: HomeWorkController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: HomeWorkController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: HomeWorkController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: HomeWorkController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: HomeWorkController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: HomeWorkController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: HomeWorkController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
