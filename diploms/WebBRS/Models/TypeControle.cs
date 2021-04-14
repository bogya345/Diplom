using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class TypeControl
	{
		[Key]
		public int IdTC { get; set; }
		public byte[] ID_1c { get; set; }
		public bool _Marked { get; set; }
		public string _Code { get; set; }
		public string _Descriptpion { get; set; }
		public string _ShortDescr{ get; set; }
	}
}
