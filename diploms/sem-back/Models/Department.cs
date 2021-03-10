using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class Department
	{
		//[Column("IdDepart")]
		[Required, Key]
		public int IdDepart { get; set; }
		[Required]
		public string FullNameDepart { get; set; }
		[Required]
		public string ShortNameDepart { get; set; }

		[ForeignKey("HeadDepartId")]
		public Guid? HeadDepartId { get; set; }
		public Department HeadDepart { get; set; }
		[ForeignKey("DepartmentTypeID")]
		public int? DepartmentTypeID { get; set; }
		public DepartmentType DepartmentType { get; set; }
	}
}
