﻿using System;
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
		public int IdPerson { get; set; }
		public string _Code { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? PatronicName { get; set; }
		public string? Email { get; set; }
		public DateTime? DateTimeReg { get; set; }  
		public DateTime? BirthDate { get; set; }
		public byte[] ID_1c { get; set; }

		public string? PhotoFilePath { get; set; }
		public Person()
		{

		}
		public string PersonsEmailUpdate()
		{
			return Email;
		}

		public virtual List<Student> Students { get; set; }
		public virtual List<Lecturer> Lecturers { get; set; }
	}
}
