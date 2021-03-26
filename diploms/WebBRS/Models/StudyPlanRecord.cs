using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models
{
	public class StudyPlanRecord
	{
		[Key]
		public int IdStudyPlan { get; set; }
		public Department Facultet { get; set; }
		public StudyYear StudyYear { get; set; }
		public Specialty Specialty { get; set; }
		public TypeControl TypeControl { get; set; }
		public TypeStudyPlanRecord TypeStudyPlanRecord { get; set; }
	}
}
