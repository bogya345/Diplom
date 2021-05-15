using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class TypeAttedance
	{
		[Required, Key]

		public int IdTA { get; set; }
		public string TAName { get; set; }
		public string TAShortName { get; set; }
		[JsonIgnore]
		public virtual List<Attendance> Attendances { get; set; } = new List<Attendance>();

	}
}
