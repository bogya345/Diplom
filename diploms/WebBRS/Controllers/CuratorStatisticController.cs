using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using WebBRS.Models;
using WebBRS.DAL;
using WebBRS.ViewModels;
using WebBRS.ViewModels.toRecieve;
using WebBRS.Models.Auth;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebBRS.Controllers
{
	[Route("CuratorStatisticController")]
	[ApiController]
	[Authorize]
	public class CuratorStatisticController : ControllerBase
	{
		private UnitOfWork unit = new UnitOfWork();

		[Route("GetCharts/{dateTimeStart}/{dateTimeEnd}")]
		[HttpGet]
		[Authorize(Roles ="curator, lectcurstud, lectcur")]
		public List<GroupVMStatic> GetChartsData(DateTime dateTimeStart, DateTime dateTimeEnd)
		{
			//изменить авторизация
			ClaimsIdentity claimsIdentity;
			claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
			var yearClaims = claimsIdentity.FindFirst("Name");
			User user = unit.Users.Get(u => u.login == yearClaims.Value);
			//int IdPerson = user.PersonIdPerson;
			int curatorPersonId = user.PersonIdPerson;
			Person person = unit.Persons.Get(p => p.IdPerson == curatorPersonId);
			List<Curator> curator = unit.Curators.GetAll(c => c.PersonIdPerson == curatorPersonId).ToList();
			List<GroupVMStatic> groupVMs = new List<GroupVMStatic>(curator.Count);
			dateTimeEnd = dateTimeEnd.AddYears(2000);
			dateTimeStart = dateTimeStart.AddYears(2000);
			int i = 0;
			foreach (var c in curator)
			{
				List<SubjectForGroup> subjectForGroups = unit.SubjectForGroups.GetAll(s => s.IdGroup == c.GroupIdGroup).ToList();
				List<StudentsGroupHistory> students = unit.StudentGroupHistories
					.GetAll(sgh => sgh.GroupIdGroup == c.GroupIdGroup
					&& sgh.ConditionOfPersonIdConditionOfPerson == 1601441643
					&& sgh.DateSGHStart > dateTimeStart && sgh.DateSGHFinished < dateTimeEnd)
					.ToList();
				GroupVMStatic groupVM = new GroupVMStatic(); 
				groupVM.idGroup = c.GroupIdGroup;
				groupVM.GroupName = c.Group.GroupName;
				List<SubjectForGroup> subjects = new List<SubjectForGroup>();
				foreach(var sfg in subjectForGroups)
				{
					ExactClass exactClass = unit.ExactClasses.Get(e => e.ID_reff == sfg.ID_reff&&e.DateClassStart>dateTimeStart&&e.DateClassStart<dateTimeEnd);
					if (exactClass != null)
					{
						subjects.Add(sfg);
					}
				}
				foreach(var sfg in subjects)
				{
					SubjectVM subjectVM = new SubjectVM();
					subjectVM.IdSubject = sfg.IdSubject;
					subjectVM.SubjectName = sfg.Subject.NameSubject + "	"+sfg.TypeStudy.TypeStudyName;
					groupVM.SubjectVMs.Add(subjectVM);

				}
				groupVMs.Add(groupVM);
				foreach (var s in students)
				{
					StudentVM studentVM = new StudentVM();
					studentVM.IdStudent = s.IdStudent;
					Person personStudent = unit.Persons.Get(p => p.IdPerson == s.Student.IdPerson);
					studentVM.IdStudent = s.IdStudent;
					studentVM.PersonFIO = personStudent.PersonFIOShort();
					List<Attendance> attendances = unit.Attendances.GetAll(a => a.IdSGH == s.IdSGH).ToList();
					foreach(var a in attendances)
					{
						//ExactClass exactClass = 
						a.ExactClass = unit.ExactClasses.Get(e => e.IdClass == a.ExactClassIdClass);
					}
					studentVM.Attedanced = new List<AttedancedVM>();
					foreach (var sg in subjects)
					{
						AttedancedVM attedancedVM = new AttedancedVM();
						attedancedVM.IdReff = sg.ID_reff;
						//attedancedVM.attedanced = sg.ID_reff;
						studentVM.Attedanced.Add(attedancedVM);
					};
					foreach (var att in studentVM.Attedanced)
					{
						List<Attendance> attedanceBuf = attendances.Where(a => a.ExactClass.ID_reff == att.IdReff).ToList();
						foreach(var a in attedanceBuf)
						{
							if (a.TypeAttedanceIdTA ==3)
							{
								att.attedanced += 1;
							}
							if (a.Ball!=null)
							{
								att.Ball += Convert.ToInt32(a.Ball);

							}
							if (a.BallHW!=null)
							{
								att.BallHW += Convert.ToInt32(a.BallHW);

							}
						}
					}

					groupVMs[i].studentVMs.Add(studentVM);
				}
				i++;
			}
			//ChartsDemoEntities DB = new ChartsDemoEntities();
			return groupVMs;
		}

	}
}
