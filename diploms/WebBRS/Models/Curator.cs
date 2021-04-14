using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Curator
	{
		[Required, Key]

		public int CuratorID { get; set; }
		public Person Person { get; set; }
		public Group Group { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		public bool Actual { get; set; }
	}
}
