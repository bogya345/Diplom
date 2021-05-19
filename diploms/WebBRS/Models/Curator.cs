using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Curator
	{
		[Required, Key]

		public int CuratorID { get; set; }
		public int PersonIdPerson { get; set; }
		public int GroupIdGroup { get; set; }

		[ForeignKey("PersonIdPerson")]
		public Person Person { get; set; }
		[ForeignKey("GroupIdGroup")]
		public Group Group { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		public bool Actual { get; set; }
		public virtual List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
	}
}
