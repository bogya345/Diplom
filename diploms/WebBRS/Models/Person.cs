using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	[Table("Persons", Schema = "dbo")]

	public class Person
	{
		//[Column("DepartTypeID")]
		[Required, Key]
		public Guid GuidPerson { get; set; }
		public int? nCode { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PatronicName { get; set; }
		public string? Email { get; set; }
		public DateTime? DateTimeReg { get; set; }  
		public DateTime? BirthDate { get; set; }
		public string PhotoFilePath { get; set; }
		public virtual List<Student> Students { get; set; }
		public virtual List<Lecturer> Lecturers { get; set; }
	}
}
