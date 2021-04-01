using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace WebBRS.Models
{
	public class SemestrBase
	{
		[Required, Key]

		public int IdSemestr { get; set; }
		public string NameSemestr { get; set; }
	}
	public class Semestr : SemestrBase
	{
		[Required, Key]

		public int IdSemestr { get; set; }
		public Group Group { get; set; }
	}
}
