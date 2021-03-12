using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Zach
	{
		[Required, Key]

		public int Ik_zach { get; set; }
		public int? nCode { get; set; }
		public Person Person { get; set; }
		public string Nn_zach { get; set; }

	}
}
