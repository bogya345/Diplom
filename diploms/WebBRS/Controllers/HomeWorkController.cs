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
		public IEnumerable<ClassWork> GetDepartmentss()
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
