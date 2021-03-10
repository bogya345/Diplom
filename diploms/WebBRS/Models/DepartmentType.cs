using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class DepartmentType
	{
		//[Column("DepartTypeID")]
		[Required, Key]
		public int DepartTypeID { get; set; }

		[Required]
		public string FullDepartTypeName { get; set; }
		[Required]
		public string ShortDepartTypeName { get; set; }
		public List<Department> Departments { get; set; }

	}
}
