using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Portfolio
	{
		[Key]
		public int IdPortfolio { get; set; }
		public int IdPerson { get; set; }
		public int IdCurator { get; set; }

		[ForeignKey("IdPerson")]
		public Person Person { get; set; }	
		[ForeignKey("IdCurator")]
		public Curator Curator { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string FilePath { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime? DateConfirmed { get; set; }
		public DateTime? DateNotConfirmed { get; set; }
		public bool Confirmed { get; set; }
		//public File File { get; set; }
	}
}
