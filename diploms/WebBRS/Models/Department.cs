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
		public Guid DepartmentGUID { get; set; }
		[Required]
		public string FullNameDepart { get; set; }
		[Required]
		public string ShortNameDepart { get; set; }

		[ForeignKey("HeadDepartId")]
		public Department HeadDepart { get; set; }
		[ForeignKey("DepartmentTypeID")]
		public DepartmentType DepartmentType { get; set; }
		public List<Department> Departments { get; set; }
		public List<Group> Groups { get; set; }

	}
}
