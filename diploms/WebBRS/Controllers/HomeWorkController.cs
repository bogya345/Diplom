using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.DAL;
using WebBRS.Models;


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
		[HttpGet("get/{id_student}")]

		public IEnumerable<DoClassWorkAttend> GetNotDoned(string id_student)
		{
			try
			{
				int id_stud = Convert.ToInt32(id_student);
				Student student = unit.Students.Get(s => s.IdStudent == id_stud);
				StudentsGroupHistory studentsGroupHistory = unit.StudentGroupHistories.Get(sgh => sgh.Student.IdStudent == student.IdStudent);
				Attendance attendance = unit.Attendances.Get(att => att.SGH.IdSGH == studentsGroupHistory.IdSGH);
				IEnumerable<DoClassWorkAttend> tmp = unit.PersonHomeworks.GetAll( x=>x.Attendance.IdAtt == attendance.IdAtt);
				//int i;
				return tmp;
				//return unit.CathInfo.GetAll();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
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
