using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.ViewModels.toRecieve
{
	public class ProfileVM
	{
		public int IdPerson { get; set; }
		public string PersonFIO { get; set; }
		public int NopeAttedance { get; set; }
		public int NopeAttedanceConfirmed { get; set; }
		public int NopeAttedanceProc { get; set; }
		public string Group { get; set; }
		public List<PortfolioVM> Portfolios { get; set; } = new List<PortfolioVM>();
	}
	public class PortfolioVM
	{
		public int IdPortfolio { get; set; }
		public int IdPerson { get; set; }
		public int IdCurator { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string FilePath { get; set; }
		public string PersonFIOconfirmed { get; set; }
		public string PersonFIO { get; set; }
		[NotMapped]
		public IFormFile File { get; set; }
		public string DateAdded { get; set; }
		public string DateConfirmed { get; set; }
		public string DateNotConfirmed { get; set; }
		public string Confirmed { get; set; }

	}
	public class AttedanceReasonVM
	{
		public int IdAttReas { get; set; }
		public string DocName { get; set; }
		public int IdPerson { get; set; }
		public int IdSGH { get; set; }
		public int IdCurator { get; set; }
		public string PersonFIO { get; set; }
		public string CuratorFIO { get; set; }
		public string FilePath { get; set; }
		public string DateTimeStart { get; set; }
		public string DateTimeEnd { get; set; }
		public string Confirmed { get; set; }
		public IFormFile File { get; set; }

		public string DateAdded { get; set; }
		public string DateConfirmed { get; set; }
		public string DateNotConfirmed { get; set; }
	}
}


