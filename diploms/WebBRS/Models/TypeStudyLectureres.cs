using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class TypeStudyLectureres
	{
		public byte[] IdSL { get; set; }
		public byte[] IdLecturer { get; set; }
		public byte[] IdTypeStudy { get; set; }

		[ForeignKey("IdLecturer")]
		public virtual Lecturer Lecturer { get; set; }
		[ForeignKey("IdTypeStudy")]
		public virtual TypeStudy TypeStudy { get; set; }
	}
}
