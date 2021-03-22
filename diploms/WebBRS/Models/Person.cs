using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	[Table("Persons", Schema = "dbo")]

	//Справочник Физические лица 1с Конфигурация

	public class Person
	{
		//[Column("DepartTypeID")]
		[Required, Key]
		public Guid GuidPerson { get; set; }
		public int? nCode { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? PatronicName { get; set; }
		public string? Email { get; set; }
		public DateTime? DateTimeReg { get; set; }  
		public DateTime? BirthDate { get; set; }
		public string? PhotoFilePath { get; set; }
		public Person()
		{

		}
		public string PersonsEmailUpdate()
		{
			return Email;
		}
		public Person(int? nCode, string fN, string lN, string pN)
		{
			this.GuidPerson = new Guid();
			this.nCode = nCode;
			this.FirstName = fN;
			this.LastName = lN;
			this.PatronicName = pN;
		}
		public virtual List<Student> Students { get; set; }
		public virtual List<Lecturer> Lecturers { get; set; }
	}
}
