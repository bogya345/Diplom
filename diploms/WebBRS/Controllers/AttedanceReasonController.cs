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
	[Route("attedanceReason")]
	[ApiController]
	public class AttedanceReasonController : ControllerBase
	{
		private UnitOfWork unit = new UnitOfWork();
		[HttpGet("GetAttedanceReason")]
		public List<AttedanceReasonVM> GetAttedanceReason()
		{
			List<AttedanceReasonVM> AttedanceReasonVMs = new List<AttedanceReasonVM>();
			//изменить когда появится авторизация

			int idPerson = 1739436577;
			Person person = unit.Persons.Get(p => p.IdPerson == idPerson);
			List<AttedanceReason> attedances = unit.AttedanceReasons.GetAll(po => po.IdPerson == idPerson).ToList();
			foreach (var i in attedances)
			{
				AttedanceReasonVM buf = new AttedanceReasonVM();
				buf.IdPerson = i.IdPerson;
				buf.PersonFIO = person.PersonFIOShort();
				buf.IdCurator = i.IdCurator;
				buf.IdAttReas = i.IdAttReas;
				buf.IdSGH = i.IdSGH;
				Person curator = unit.Persons.Get(p => p.IdPerson == i.Curator.PersonIdPerson);
				buf.CuratorFIO = curator.PersonFIOShort();
				buf.DateAdded = i.DateAdded.ToShortDateString();
				buf.DateTimeStart = i.DateTimeStart.ToString("d");
				buf.DateTimeEnd = i.DateTimeEnd.ToString("d");

				if (i.DateConfirmed != null)
				{
					buf.DateConfirmed = Convert.ToString(i.DateConfirmed);
				}
				if (i.DateNotConfirmed != null)
				{
					buf.DateNotConfirmed = Convert.ToString(i.DateNotConfirmed);
				}
			
				buf.DocName = i.DocName;
				buf.FilePath = i.FilePath;
				buf.DateAdded = i.DateAdded.ToString("d");
				if (i.DateConfirmed != null)
				{
					buf.DateConfirmed = Convert.ToDateTime(i.DateConfirmed).ToString("d");
				}
				buf.CuratorFIO = unit.Persons.Get(p => p.IdPerson == i.Curator.PersonIdPerson).PersonFIOShort();
				AttedanceReasonVMs.Add(buf);
			}
			return AttedanceReasonVMs;
		}

		[HttpGet("GetAttedanceReason/{IdPortfolio}")]

		public AttedanceReasonVM GetAttedanceReason(int IdPortfolio)
		{
			AttedanceReason portfolio = unit.AttedanceReasons.Get(cw => cw.IdAttReas == IdPortfolio);
			AttedanceReasonVM portfolioVM = new AttedanceReasonVM();
			//изменить когда появится авторизация

			portfolioVM.IdPerson = 1739436577;

			Person person = unit.Persons.Get(portfolioVM.IdPerson);
			Student student = unit.Students.Get(st => st.IdPerson == person.IdPerson);

			List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
				.GetAll(sgh => sgh.IdStudent == student.IdStudent &&/* sgh.CourseIdCourse.ToString() == IdCourse && */sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
			var studentsSorted = from s in studentsGroupHistories
								 orderby s.DateSGHStart
								 select s;
			List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
			StudentsGroupHistory sgh = studentsSortedList[0];
			Curator curator = unit.Curators.Get(c => c.GroupIdGroup == sgh.GroupIdGroup);
			if (portfolio == null)
			{
				portfolio = new AttedanceReason();
				portfolioVM.IdAttReas = 0;
				portfolioVM.IdPerson = person.IdPerson;
				portfolioVM.CuratorFIO = curator.Person.PersonFIOShort();
				portfolioVM.PersonFIO = person.PersonFIOShort();
				portfolioVM.IdSGH = sgh.IdSGH;
				portfolioVM.DateAdded = DateTime.Now.ToString();

				portfolioVM.IdCurator = curator.CuratorID;
				portfolioVM.FilePath = "";
			}
			else
			{
				//portfolioVM.IdPortfolio = portfolio.IdPortfolio;
				//portfolioVM.IdPortfolio = portfolio.IdPortfolio;
				//portfolioVM.IdPerson = portfolio.IdPerson; ;
				//portfolioVM.Description = portfolio.Description;
				//portfolioVM.FilePath = portfolio.FilePath;
				//portfolioVM.DateAdded = portfolio.DateAdded.ToString("d");
				//portfolioVM.DateConfirmed = portfolio.DateConfirmed ;

			}
			return portfolioVM;
		}
		[HttpGet("GetAttedanceForConfirm/{conf}/{datestart}/{dateend}")]

		public List<AttedanceReasonVM> GetAttedanceForConfirm(bool conf, DateTime datestart, DateTime dateend)
		{
			List<AttedanceReasonVM> portfolioVMs = new List<AttedanceReasonVM>();
			//изменить когда появится авторизация

			int idPerson = 1739436573;
			List<Curator> curators = unit.Curators.GetAll(c => c.PersonIdPerson == idPerson && c.Actual == true).ToList();
			List<AttedanceReason> portfolios = new List<AttedanceReason>();
			if (!conf)
			{
				foreach (var c in curators)
				{
					List<AttedanceReason> portfoliosBUF = unit.AttedanceReasons.GetAll(po => po.IdCurator == c.CuratorID && po.Confirmed == conf && po.DateAdded > datestart && po.DateAdded < dateend).ToList();
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
					List<AttedanceReason> portfoliosBUF = unit.AttedanceReasons.GetAll(po => po.IdCurator == c.CuratorID && po.DateAdded > datestart && po.DateAdded < dateend).ToList();
					foreach (var p in portfoliosBUF)
					{
						portfolios.Add(p);
					}
				}
			}

			foreach (var i in portfolios)
			{
				AttedanceReasonVM buf = new AttedanceReasonVM();
				buf.IdPerson = i.IdPerson;
				Person person = unit.Persons.Get(p => p.IdPerson == buf.IdPerson);
				buf.PersonFIO = person.PersonFIOShort();
				buf.IdCurator = i.IdCurator;
				buf.IdAttReas = i.IdAttReas;
				buf.DocName = i.DocName;
				//buf.Description = i.Description;
				buf.FilePath = i.FilePath;
				buf.DateAdded = i.DateAdded.ToString("d");
				if (i.DateConfirmed != null)
				{
					buf.DateConfirmed = Convert.ToDateTime(i.DateConfirmed).ToString("d");
				}
				if (i.DateNotConfirmed != null)
				{
					buf.DateNotConfirmed = Convert.ToDateTime(i.DateNotConfirmed).ToString("d");
				}
				buf.PersonFIO = unit.Persons.Get(p => p.IdPerson == i.Curator.PersonIdPerson).PersonFIOShort();
				portfolioVMs.Add(buf);
			}
			return portfolioVMs;
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteAttedanceReason(int id)
		{
			if (ModelState.IsValid)
			{
				//int IdPortfolio2 = Convert.ToInt32(data.IdPortfolio);
				AttedanceReason portfolio = unit.AttedanceReasons.Get(id);
				unit.AttedanceReasons.Delete(portfolio);
				unit.Save();
			}
			return Ok(id);

		}

		[HttpPost("UpdateAttedanceReason")]
		public IActionResult UpdateAttedanceReason(AttedanceReasonVM data)
		{
			if (ModelState.IsValid)
			{
				AttedanceReason cw = new AttedanceReason();

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
				if (data.IdAttReas != 0)
				{
					cw = unit.AttedanceReasons.Get(c => c.IdAttReas == data.IdAttReas);
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
					//cw.Description = data.Description;
					//cw.IdPerson = data.IdPerson;
					cw.DocName = data.DocName;
					cw.FilePath = data.FilePath;
					//cw.DateAdded = DateTime.Now;
					unit.AttedanceReasons.Update(cw);
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
					cw.IdSGH = sgh.IdSGH;
					cw.DateTimeStart = Convert.ToDateTime(data.DateTimeStart);
					cw.DateTimeEnd = Convert.ToDateTime(data.DateTimeEnd);
					
					//cw./*Description*/ = data.Description;
					cw.DocName = data.DocName;
					cw.IdPerson = data.IdPerson;
					//cw.IdCurator = data.IdCurator;
					unit.AttedanceReasons.Create(cw);
				}


				unit.Save();
				return Ok(data);
			}
			return BadRequest(ModelState);
		}
	}
}
