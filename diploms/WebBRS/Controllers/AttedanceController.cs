using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.DAL;
using WebBRS.Models;
using WebBRS.Models.Views;

namespace WebBRS.Controllers
{
	[Route("attedance")]

	public class AttedanceController : Controller
	{
		private UnitOfWork unit = new UnitOfWork();

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet("getLecturerClass/{id_lecturer}/{IdEXCFLC}/{id_group}/{actual}")]
		public ExactClassForLecturerClass GetLecturerClass(string id_lecturer,string IdEXCFLC, string id_selected_group, string actual)
		{
			try
			{
				Lecturer lecturer = unit.Lecturers.Get(l => l.IdSLecturer == Convert.ToInt32(id_lecturer));
				ExactClassForLecturerClass exactClassForLecturer = unit.ExactClassForLectureres
																		.Get(excfl => excfl.IdEXCFLC == Convert.ToInt32(IdEXCFLC));
				IEnumerable<ExactClass> exactClasses = exactClassForLecturer.ExactClasses;
				List<Group> groupesLecturerClass = new List<Group>();
				if (actual=="true") 
				{
					List<StudentsGroupHistory> students = unit.StudentGroupHistories
								.GetAll(s => s.Group.IdGroup == Convert.ToInt32(id_selected_group) && s.DateSGHFinished == null).ToList();
				}
				else
				{
					List<StudentsGroupHistory> students = unit.StudentGroupHistories
							.GetAll(s => s.Group.IdGroup == Convert.ToInt32(id_selected_group)).ToList();
				}

				foreach (ExactClass exactClass in exactClasses)
				{
					ExactClass ec = unit.ExactClasses.Get(ec => ec.IdClass == exactClass.IdClass);
					SubjectForGroup subjectForGroup = unit.SubjectForGroups.Get(sfg => sfg.IdSFG == ec.SubjectForGroup.IdSFG);
					Group group = subjectForGroup.Group;
					groupesLecturerClass.Add(group);
				}
				exactClassForLecturer.Groups = groupesLecturerClass;
				//IEnumerable<StudentsGroupHistory> students = unit.StudentGroupHistories.GetAll(st => st.Group.IdGroup.ToString() == id_group);
				//int i;
				//tmp.ExactClasses = exactClasses.ToList();
				//tmp.Students = students.ToList();

				return exactClassForLecturer;
				//return unit.CathInfo.GetAll();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
