using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class PrikazRow
	{
		[Required, Key]
		public int IdPrikazRow { get; set; }
		public int IdPrikaz { get; set; }

		[ForeignKey("IdPrikaz")]
		public Prikaz Prikaz { get; set; }
		public int CuratorID { get; set; }

		[ForeignKey("CuratorID")]
		public Person Curator { get; set; }
		public int IdGroup { get; set; }
		
		[ForeignKey("IdGroup")]
		public Group Group { get; set; }

	}	
	public class PrikazRowVM
	{
		[Required, Key]
		public int IdPrikazRow { get; set; }
		public int IdPrikaz { get; set; }


		public string Prikaz { get; set; }
		public int CuratorID { get; set; }

		public string Curator { get; set; }
		public string CuratorDoljn { get; set; }
		public int IdGroup { get; set; }
		

		public string Group { get; set; }

	}
	public class Prikaz
	{
		[Required, Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int IdPrikaz { get; set; }
		public string DekanFIO { get; set; }
		public DateTime DateAdd { get; set; }
		[NotMapped]
		public string DateAddString { get; set; }
		public string TextPrikaz { get; set; }
		public int IdStudyYear { get; set; }
		[ForeignKey("IdStudyYear")]
		public StudyYear StudyYear { get; set; }
		[NotMapped]

		public List<PrikazRow> Rows  { get; set; }
		[JsonIgnore]
		public List<PrikazRow> RowsForSend { get; set; } = new List<PrikazRow>();
		public List<PrikazRowVM> PrikazRowVMs { get; set; } = new List<PrikazRowVM>();


	}
}
