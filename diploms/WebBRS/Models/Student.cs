using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Student
	{
		//[Column("DepartTypeID")]
		[Required, Key]
		public int IdStudent { get; set; }
		public byte[] ID_Person_1c { get; set; }


		[ForeignKey("IdPerson")]
		public int IdPerson { get; set; }
		public Person Person { get; set; }
		public string ZachNumber { get; set; }
		public byte[] ID_1c { get; set; }
		public List<StudentsGroupHistory> StudentsGroupHistories { get; set; }

	}
}
