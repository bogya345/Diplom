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
	[Route("departments")]

	public class DepartmentController : Controller
	{
		// GET: DepartmentController
		private UnitOfWork unit = new UnitOfWork();

		public ActionResult Index()
		{
			return View();
		}
		[HttpGet("getall")]
		public IEnumerable<Department> GetDepartmentss()
		{
			try
			{
				IEnumerable<Department> tmp = unit.Departments.GetAll();
				//int i;
				return tmp;
				//return unit.CathInfo.GetAll();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		// GET: DepartmentController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: DepartmentController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: DepartmentController/Create
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

		// GET: DepartmentController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: DepartmentController/Edit/5
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

		// GET: DepartmentController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: DepartmentController/Delete/5
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
