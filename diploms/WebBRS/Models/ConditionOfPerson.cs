using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class ConditionOfPerson
	{
		[Required, Key]

		public int  IdConditionOfPerson { get; set; }
		public byte[] ID_1c { get; set; }
		public string _Description { get; set; }
		public virtual List<StudentsGroupHistory> StudentsGroupHistories { get; set; }

	}
}
