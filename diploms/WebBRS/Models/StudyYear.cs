using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
namespace WebBRS.Models
{
	public class StudyYear
	{
		[Key]
		public int IdStudyYear { get; set; }
		[JsonIgnore]
		public byte[] ID_1c { get; set; }
		[JsonIgnore]
		public string _Code { get; set; }
		public string _Description { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		[JsonIgnore]
		public virtual List<DraftTimeTable> DraftTimeTables { get; set; }  = new List<DraftTimeTable>();
	}
}
