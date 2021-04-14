using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class TypeStudyPlanRecord
	{
		[Key]
		public int IdTSPR { get; set; }
		public byte[] ID_1c { get; set; }
		public string  _Code { get; set; }
		public string  _Description { get; set; }
		public string  _Fld9231 { get; set; }
	}
}
