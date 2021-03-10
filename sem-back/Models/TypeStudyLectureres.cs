using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class TypeStudyLectureres
	{
		public int IdSL { get; set; }
		public int IdLecturer { get; set; }
		public int IdTypeStudy { get; set; }

		[ForeignKey("IdLecturer")]
		public virtual Lecturer Lecturer { get; set; }
		[ForeignKey("IdTypeStudy")]
		public virtual TypeStudy TypeStudy { get; set; }
	}
}
