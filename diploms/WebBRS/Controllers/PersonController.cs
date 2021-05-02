using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;
using WebBRS.DAL;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.IO;
using Newtonsoft.Json;

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
	public class SerTest
	{
		public string TITLE { get; set; }
		public string NAME { get; set; }
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
		[Route("testSerioja")]

		public async Task PostRequestAsync()
		{

			SerTest serTest = new SerTest();
			serTest.TITLE = "kek1";
			serTest.NAME = "kekName";
			WebRequest request = WebRequest.CreateHttp("https://avdetailing.bitrix24.ru/rest/1/h5ygusbnly052bsc/crm.lead.add.json?" + "FIELDS[TITLE] =" + serTest.TITLE + " & FIELDS[NAME] = " + serTest.NAME);
			request.Method = "POST"; // для отправки используется метод Post
									 //						 // данные для отправки
									 //string data = JsonConvert.SerializeObject(serTest);
									 //// преобразуем данные в массив байтов
									 //byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
									 //// устанавливаем тип содержимого - параметр ContentType
									 //request.ContentType = "application/x-www-form-urlencoded";
									 //// Устанавливаем заголовок Content-Length запроса - свойство ContentLength
									 //request.ContentLength = byteArray.Length;
									 ////записываем данные в поток запроса
									 //using (Stream dataStream = request.GetRequestStream())
									 //{
									 //	dataStream.Write(byteArray, 0, byteArray.Length);
									 //}

			WebResponse response = request.GetResponse();
			//using (Stream stream = response.GetResponseStream())
			//{
			//	using (StreamReader reader = new StreamReader(stream))
			//	{
			//		Console.WriteLine(reader.ReadToEnd());
			//	}
			//}
			response.Close();
			Console.WriteLine("Запрос выполнен...");
		}
		[HttpPost]
		public async Task<IActionResult> Index(NewSessionModel model)
		{
			if (!ModelState.IsValid)
			{
				//return BadRequest(ModelState);
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
				IEnumerable<StudentsGroupHistory> tmp1 = unit.StudentGroupHistories.GetAll(sgh=>(sgh.GroupIdGroup == 1739436558) &&( sgh.CourseIdCourse== 1363575543));
				//tmp1 =
				List<Student> students = new List<Student>();
				foreach (var item in tmp1)
				{
					students.Add(item.Student);
				}
				List<Person> tmpPersons = new List<Person>();
				foreach (var item in students)
				{
					Person person = unit.Persons.Get(p => p.IdPerson == item.IdPerson);
					tmpPersons.Add(person);
				}
				IEnumerable<Person> tmp = unit.Persons.GetAll();
				return tmpPersons.ToArray();
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
