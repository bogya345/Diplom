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
	}
}
