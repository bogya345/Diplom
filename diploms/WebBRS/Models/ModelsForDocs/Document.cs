using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models.ModelsForDocs
{
	public class Document
	{
		[Required, Key]
		public int IdDoc { get; set; }
		public Person WhoseDoc { get; set; }
	}
}
