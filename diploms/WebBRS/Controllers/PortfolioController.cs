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
	[Route("prortfolio")]
	[ApiController]
	public class PortfolioController : ControllerBase
	{
		private UnitOfWork unit = new UnitOfWork();
		[HttpGet("GetPortfolios")]

		public List<PortfolioVM> GetAllPortfolios()
		{
			List<PortfolioVM> portfolioVMs = new List<PortfolioVM>();
			//изменить когда появится авторизация

			int idPerson = 1739436577;
			List<Portfolio> portfolios = unit.Portfolios.GetAll(po => po.IdPerson == idPerson).ToList();
			foreach(var i in portfolios)
			{
				PortfolioVM buf = new PortfolioVM();
				buf.IdPerson = i.IdPerson;
				buf.IdPortfolio = i.IdPortfolio;
				buf.Name = i.Name;
				buf.Description = i.Description;
				buf.FilePath = i.FilePath;
				buf.DateAdded = i.DateAdded.ToString("d");
				if (i.DateConfirmed != null)
				{
					buf.DateConfirmed = Convert.ToDateTime(i.DateConfirmed).ToString("d");

				}
				buf.PersonFIOconfirmed = unit.Persons.Get(p=>p.IdPerson == i.Curator.PersonIdPerson).PersonFIOShort();
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
				portfolioVM.FilePath = portfolio.FilePath ;
				portfolioVM.DateAdded= portfolio.DateAdded.ToString("d") ;
				//portfolioVM.DateConfirmed = portfolio.DateConfirmed ;

			}
			return portfolioVM;
		}
		[HttpGet("DeletePortfolio/{IdPortfolio}")]

		public IActionResult DeletePortfolio(int IdPortfolio)
		{
			Portfolio portfolio = unit.Portfolios.Get(IdPortfolio);
			unit.Portfolios.Delete(portfolio);
			return Ok(IdPortfolio);
		}
		[HttpPost("UpdatePortfolioWork")]
		public IActionResult UpdatePortfolioWork(PortfolioVM data)
		{
			if (ModelState.IsValid)
			{
				Portfolio cw = new Portfolio();
				if (data.IdPortfolio!=0)
				{
					cw = unit.Portfolios.Get(c => c.IdPortfolio == data.IdPortfolio);
					cw.Description = data.Description;
					cw.IdPerson = data.IdPerson;
					cw.Name = data.Name;
					cw.FilePath = data.FilePath;
					cw.DateAdded = DateTime.Now;
					cw.DateConfirmed = null;
					cw.Confirmed = false;
					unit.Portfolios.Update(cw);
				}
				else
				{
					cw.DateAdded = DateTime.Now;
					cw.DateConfirmed = null;
					cw.Confirmed = false;
					cw.FilePath = "";
					cw.Description = data.Description;
					cw.Description = data.Description;
					cw.IdPerson = data.IdPerson;
					cw.IdCurator = data.IdCurator;
					unit.Portfolios.Create(cw);
				}
				
				
				unit.Save();
				return Ok(data);
			}
			return BadRequest(ModelState);
		}
	}
}
