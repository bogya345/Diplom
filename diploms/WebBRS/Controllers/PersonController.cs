using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;
using WebBRS.DAL;
using System.ComponentModel.DataAnnotations;

namespace WebBRS.Controllers
{
	public interface IBrainstormSessionRepository
	{
		Task<BrainstormSession> GetByIdAsync(int id);
		Task<List<BrainstormSession>> ListAsync();
		Task AddAsync(BrainstormSession session);
		Task UpdateAsync(BrainstormSession session);
	}
	public class BrainstormSession
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTimeOffset DateCreated { get; set; }

		public List<Idea> Ideas { get; } = new List<Idea>();

		public void AddIdea(Idea idea)
		{
			Ideas.Add(idea);
		}
	}
	public class StormSessionViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTimeOffset DateCreated { get; set; }
		public int IdeaCount { get; set; }
	}
	public class Idea
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTimeOffset DateCreated { get; set; }
	}
	public class NewSessionModel
	{
		[Required]
		public string SessionName { get; set; }
	}


	[Route("person")]
	public class PersonController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var sessionList = await _sessionRepository.ListAsync();

			var model = sessionList.Select(session => new StormSessionViewModel()
			{
				Id = session.Id,
				DateCreated = session.DateCreated,
				Name = session.Name,
				IdeaCount = session.Ideas.Count
			});

			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> Index(NewSessionModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{
				await _sessionRepository.AddAsync(new BrainstormSession()
				{
					DateCreated = DateTimeOffset.Now,
					Name = model.SessionName
				});
			}

			return RedirectToAction(actionName: nameof(Index));
		}
		private readonly IBrainstormSessionRepository _sessionRepository;

		//public PersonController(IBrainstormSessionRepository sessionRepository)
		//{
		//	_sessionRepository = sessionRepository;
		//}
		private UnitOfWork unit = new UnitOfWork();
		//public PersonController(UnitOfWork sessionRepository)
		//{
		//	unit = sessionRepository;
		//}
		//GET: PersonController
		//public ActionResult Index()
		//{
		//	return View();
		//}

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
				return tmp;
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
		[HttpPost("createNew")]
		[ValidateAntiForgeryToken]
		public JsonResult Create([FromBody] Person value)
		{
			unit.Save();
			//Person person = value;
			unit.Persons.Create(value);
		skip:

			return Json("Create Successful.");
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
