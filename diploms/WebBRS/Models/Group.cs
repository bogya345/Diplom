using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Group
	{
		//[Column("DepartTypeID")]
		[Required, Key]
		public int IdGroup { get; set; }
		public byte[] ID_1c { get; set; }
		public string GroupName { get; set; }

		public Specialty Specialty { get; set; }
	
		public Department DepartmentGroup { get; set; }

		public Group GroupPrev { get; set; }
		public byte[] GroupPrev_ID_1c { get; set; }
		public DateTime? DateCreate { get; set; }
		public DateTime? DateExit { get; set; }

		public List<Group> PrevGroups { get; set; } = new List<Group>();
		public List<Subject> Subjects { get; set; } = new List<Subject>();
		public List<StudentsGroupHistory> StudentsGroupHistories { get; set; } = new List<StudentsGroupHistory>();
		public List<SubjectForGroup> SubjectForGroups { get; set; } = new List<SubjectForGroup>();
	}
}
