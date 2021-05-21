using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	[Table("Persons", Schema = "dbo")]

	//Справочник Физические лица 1с Конфигурация

	public class Person
	{
		//[Column("DepartTypeID")]
		[Required, Key]
		public int IdPerson { get; set; }
		public byte[] ID_1c { get; set; }
		public string _Code { get; set; }
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
		public string PersonFIOShort()
		{
			return LastName +"	"+ FirstName[0]+"." + PatronicName[0]+".";
		}
		[JsonIgnore]
		public virtual List<Student> Students { get; set; } = new List<Student>();
		[JsonIgnore]
		public virtual List<Lecturer> Lecturers { get; set; }
		[JsonIgnore]

		public virtual List<SubjectForGroup> SubjectsForGroup { get; set; } = new List<SubjectForGroup>();
		[JsonIgnore]

		public virtual List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();	
		[JsonIgnore]

		public virtual List<AttedanceReason> AttedanceReasons { get; set; } = new List<AttedanceReason>();
		[JsonIgnore]

		public virtual List<Curator> Curators { get; set; } = new List<Curator>();

	}
}
