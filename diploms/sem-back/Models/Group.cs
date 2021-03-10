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
		public string GroupName { get; set; }
		[ForeignKey("IdSpec")]
		public int? IdSpec { get; set; }
		public Specialty Specialty { get; set; }
		[ForeignKey("IdDepart")]
		public int? IdDepart { get; set; }
		public Department DepartmentGroup { get; set; }
		[ForeignKey("IdGroupPrev")]
		public int? IdGroupPrev { get; set; }
		public Group GroupPrev { get; set; }
	}
}
