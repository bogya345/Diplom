using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;
using WebBRS.DAL;
namespace WebBRS.Controllers
{
    [Route("person")]

	public class PersonController : Controller
	{
		private UnitOfWork unit = new UnitOfWork();

		// GET: PersonController
		public ActionResult Index()
		{
			return View();
		}

		// GET: PersonController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}
		[HttpGet("getall")]
		public IEnumerable<Person> GetPersons()
		{
			try
			{
				IEnumerable<Person> tmp = unit.Persons.GetAll();
				//int i;
				return tmp;
				//return unit.CathInfo.GetAll();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		// GET: PersonController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PersonController/Create
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

		// GET: PersonController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PersonController/Edit/5
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

		// GET: PersonController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PersonController/Delete/5
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
