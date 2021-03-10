using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Specialty
	{
		//[Column("DepartTypeID")]
		[Required, Key]
		public int IdSpec { get; set; }
		public string NameSpec { get; set; }
		public string ShortNameSpec { get; set; }
	}
}
