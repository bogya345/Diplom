using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class WorkType
	{
		[Required, Key]
		public int IdWT { get; set; }
		public string WorkTypeName { get; set; }
		public string ShortWorkTypeName { get; set; }
		
	}
}
