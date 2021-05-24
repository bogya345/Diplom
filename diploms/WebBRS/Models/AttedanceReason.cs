using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class AttedanceReason
	{
		[Key]
		public int IdAttReas { get; set; }
		public string DocName { get; set; }
		public int IdPerson { get; set; }
		public int IdSGH { get; set; }
		public int IdCurator { get; set; }
		[ForeignKey("IdPerson")]
		public Person Person { get; set; }
		[ForeignKey("IdSGH")]

		public StudentsGroupHistory SGH { get; set; }
		[ForeignKey("IdCurator")]

		public Curator  Curator { get; set; }
		public string FilePath { get; set; }
		public bool Confirmed { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime? DateConfirmed { get; set; }
		public DateTime? DateNotConfirmed { get; set; }
	}
}
