using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{

	//Справочник Специальности 1с Конфигурация
	public class Specialty
	{
		//[Column("DepartTypeID")]
		[Required, Key]
		public int  IdSpec { get; set; }
		public byte[] ID_1c { get; set; }
		public string NameSpec { get; set; }
		public string ShortNameSpec { get; set; }
		public List<Group> Groups { get; set; }

	}
}
