using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.ViewModels.toRecieve
{
	public class ProfileVM
	{
		public int IdPerson { get; set; }
		public string PersonFIO { get; set; }
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
		public string DateAdded { get; set; }
		public string DateConfirmed { get; set; }
		public string Confirmed { get; set; }

	}
}


