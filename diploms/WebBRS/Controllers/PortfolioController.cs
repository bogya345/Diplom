using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.DAL;
using WebBRS.Models;

using WebBRS.Models.Views;
using WebBRS.ViewModels.toRecieve;
namespace WebBRS.Controllers
{
	public class Stroka
	{
		public string IdPortfolio { get; set; }
	}
	[Route("prortfolio")]
	[ApiController]
	public class PortfolioController : ControllerBase
	{
		private UnitOfWork unit = new UnitOfWork();
		[HttpGet("GetPortfile")]

		public ProfileVM GetProfile()
		{
			//изменить когда появится авторизация
			int IdPerson = 1739436577;
			ProfileVM profileVM = new ProfileVM();
			Person person = unit.Persons.Get(p => p.IdPerson == IdPerson);
			Student student = unit.Students.Get(st => st.IdPerson == person.IdPerson);
			int IdCourse = 1363575543;
			List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
				.GetAll(sgh => sgh.IdStudent == student.IdStudent && sgh.CourseIdCourse == IdCourse && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
			var studentsSorted = from s in studentsGroupHistories
								 orderby s.DateSGHStart
								 select s;
			List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
			StudentsGroupHistory sgh = studentsSortedList[0];
			profileVM.IdPerson = IdPerson;
			profileVM.PersonFIO = person.PersonFIOShort();
			List<Attendance> attendances = unit.Attendances.GetAll(at => at.IdSGH == sgh.IdSGH).ToList();
			foreach (var i in attendances)
			{
				if (i.TypeAttedanceIdTA == 3)
				{
					profileVM.NopeAttedance += 1;
				};
				if (i.TypeAttedanceIdTA == 4)
				{
					profileVM.NopeAttedanceConfirmed += 1;
				};

			};
			double count = attendances.Count();
			double procents = (profileVM.NopeAttedance) / count * 100;
			profileVM.NopeAttedanceProc =Convert.ToInt32(procents);
			profileVM.Group = sgh.Group.GroupName;
			return profileVM;
		}
		[HttpGet("GetPortfolios")]

		public List<PortfolioVM> GetAllPortfolios()
		{
			List<PortfolioVM> portfolioVMs = new List<PortfolioVM>();
			//изменить когда появится авторизация

			int idPerson = 1739436577;
			Person person = unit.Persons.Get(p => p.IdPerson == idPerson);
			List<Portfolio> portfolios = unit.Portfolios.GetAll(po => po.IdPerson == idPerson).ToList();
			foreach (var i in portfolios)
			{
				PortfolioVM buf = new PortfolioVM();
				buf.IdPerson = i.IdPerson;
				buf.PersonFIO = person.PersonFIOShort();
				buf.IdPortfolio = i.IdPortfolio;
				buf.Name = i.Name;
				buf.Description = i.Description;
				buf.FilePath = i.FilePath;
				buf.DateAdded = i.DateAdded.ToString("d");
				if (i.DateConfirmed != null)
				{
					buf.DateConfirmed = Convert.ToDateTime(i.DateConfirmed).ToString("d");

				}
				buf.PersonFIOconfirmed = unit.Persons.Get(p => p.IdPerson == i.Curator.PersonIdPerson).PersonFIOShort();
				portfolioVMs.Add(buf);
			}
			return portfolioVMs;
		}
		[HttpGet("GetPortfoliosForConfirm/{conf}")]

		public List<PortfolioVM> GetPortfoliosForConfirm(bool conf)
		{
			List<PortfolioVM> portfolioVMs = new List<PortfolioVM>();
			//изменить когда появится авторизация

			int idPerson = 1739436573;
			List<Curator> curators = unit.Curators.GetAll(c => c.PersonIdPerson == idPerson && c.Actual == true).ToList();
			List<Portfolio> portfolios = new List<Portfolio>();
			if (!conf)
			{
				foreach (var c in curators)
				{
					List<Portfolio> portfoliosBUF = unit.Portfolios.GetAll(po => po.IdCurator == c.CuratorID && po.Confirmed == conf).ToList();
					foreach (var p in portfoliosBUF)
					{
						portfolios.Add(p);
					}
				}
			}
			else
			{
				foreach (var c in curators)
				{
					List<Portfolio> portfoliosBUF = unit.Portfolios.GetAll(po => po.IdCurator == c.CuratorID).ToList();
					foreach (var p in portfoliosBUF)
					{
						portfolios.Add(p);
					}
				}
			}
			
			foreach (var i in portfolios)
			{
				PortfolioVM buf = new PortfolioVM();
				buf.IdPerson = i.IdPerson;
				Person person = unit.Persons.Get(p => p.IdPerson == buf.IdPerson);
				buf.PersonFIO = person.PersonFIOShort();
				buf.IdCurator = i.IdCurator;
				buf.IdPortfolio = i.IdPortfolio;
				buf.Name = i.Name;
				buf.Description = i.Description;
				buf.FilePath = i.FilePath;
				buf.DateAdded = i.DateAdded.ToString("d");
				if (i.DateConfirmed != null)
				{
					buf.DateConfirmed = Convert.ToDateTime(i.DateConfirmed).ToString("d");
				}if (i.DateNotConfirmed != null)
				{
					buf.DateNotConfirmed = Convert.ToDateTime(i.DateNotConfirmed).ToString("d");
				}
				buf.PersonFIOconfirmed = unit.Persons.Get(p => p.IdPerson == i.Curator.PersonIdPerson).PersonFIOShort();
				portfolioVMs.Add(buf);
			}
			return portfolioVMs;
		}
		[HttpGet("GetPortfolio/{IdPortfolio}")]

		public PortfolioVM GetPortfolio(int IdPortfolio)
		{
			Portfolio portfolio = unit.Portfolios.Get(cw => cw.IdPortfolio == IdPortfolio);
			PortfolioVM portfolioVM = new PortfolioVM();
			if (portfolio == null)
			{
				portfolio = new Portfolio();
				portfolioVM.IdPortfolio = 0;
				//изменить когда появится авторизация
				portfolioVM.IdPerson = 1739436577;
				portfolioVM.Description = "";
				portfolioVM.FilePath = "";
			}
			else
			{
				portfolioVM.IdPortfolio = portfolio.IdPortfolio;
				portfolioVM.IdPortfolio = portfolio.IdPortfolio;
				portfolioVM.IdPerson = portfolio.IdPerson; ;
				portfolioVM.Description = portfolio.Description;
				portfolioVM.FilePath = portfolio.FilePath;
				portfolioVM.DateAdded = portfolio.DateAdded.ToString("d");
				//portfolioVM.DateConfirmed = portfolio.DateConfirmed ;

			}
			return portfolioVM;
		}
		[HttpDelete("{id}")]

		public IActionResult DeletePortfolio(int id)
		{
			if (ModelState.IsValid)
			{
				//int IdPortfolio2 = Convert.ToInt32(data.IdPortfolio);
				Portfolio portfolio = unit.Portfolios.Get(id);
				unit.Portfolios.Delete(portfolio);
				unit.Save();
			}
			return Ok(id);

		}
		[HttpPost("UpdatePortfolioWork")]
		public IActionResult UpdatePortfolioWork(PortfolioVM data)
		{
			if (ModelState.IsValid)
			{
				Portfolio cw = new Portfolio();

				//int IdPerson = 1739436577;

				Person person = unit.Persons.Get(data.IdPerson);
				Student student = unit.Students.Get(st => st.IdPerson == person.IdPerson);
				int IdCourse = 1363575543;
				List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
					.GetAll(sgh => sgh.IdStudent == student.IdStudent && sgh.CourseIdCourse == IdCourse && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
				var studentsSorted = from s in studentsGroupHistories
									 orderby s.DateSGHFinished
									 select s;
				List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
				StudentsGroupHistory sgh = studentsSortedList[0];
				Curator curator = unit.Curators.Get(c => c.GroupIdGroup == sgh.GroupIdGroup);
				if (data.IdPortfolio != 0)
				{
					cw = unit.Portfolios.Get(c => c.IdPortfolio == data.IdPortfolio);
					cw.DateConfirmed = DateTime.Now;
					cw.Confirmed = Convert.ToBoolean(data.Confirmed);

					if (cw.Confirmed)
					{
						if (!Convert.ToBoolean(data.Confirmed))
						{
							cw.DateConfirmed = null;
							cw.DateNotConfirmed = DateTime.Now;
							cw.Confirmed = Convert.ToBoolean(data.Confirmed);
						}
						else
						{
							cw.DateNotConfirmed = null;

						}
					}
					else
					{
						if (!Convert.ToBoolean(data.Confirmed))
						{
							cw.DateConfirmed = null;
							cw.DateNotConfirmed = DateTime.Now;
							cw.Confirmed = Convert.ToBoolean(data.Confirmed);
						}
						else
						{
							cw.DateNotConfirmed = null;

						}
					}
					cw.Description = data.Description;
					//cw.IdPerson = data.IdPerson;
					cw.Name = data.Name;
					cw.FilePath = data.FilePath;
					//cw.DateAdded = DateTime.Now;
					unit.Portfolios.Update(cw);
					unit.Save();

				}
				else
				{
					//изменить после добавления авторизации
					cw.IdCurator = 3;					
					cw.DateAdded = DateTime.Now;
					cw.DateConfirmed = null;
					cw.Confirmed = false;
					cw.FilePath = "";
					cw.Description = data.Description;
					cw.Name = data.Name;
					cw.IdPerson = data.IdPerson;
					//cw.IdCurator = data.IdCurator;
					unit.Portfolios.Create(cw);
				}


				unit.Save();
				return Ok(data);
			}
			return BadRequest(ModelState);
		}
	}
}
