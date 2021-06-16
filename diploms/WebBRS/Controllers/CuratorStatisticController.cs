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
	//[Authorize]
	public class CuratorStatisticController : ControllerBase
	{
		private UnitOfWork unit = new UnitOfWork();
		[Route("GetCharts3/{Id}/{dateTimeStart}/{dateTimeEnd}")]
		[HttpGet]

		public List<GroupVMStatic> GetChartsData3(string Id, DateTime dateTimeStart, DateTime dateTimeEnd)
		{
		
			ClaimsIdentity claimsIdentity;
			claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
			var yearClaims = claimsIdentity.FindFirst("Name");
			User user = unit.Users.Get(u => u.login == yearClaims.Value);

			int curatorPersonId = Convert.ToInt32(Id);
			Person person = unit.Persons.Get(p => p.IdPerson == curatorPersonId);
			List<GroupVMStatic> groupVMs = new List<GroupVMStatic>(0);
			Student student = unit.Students.Get(st => st.IdPerson == person.IdPerson);
			int IdCourse = 1363575543;
			List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
				.GetAll(sgh => sgh.IdStudent == student.IdStudent && sgh.CourseIdCourse == IdCourse && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
			var studentsSorted = from s in studentsGroupHistories
								 orderby s.DateSGHStart
								 select s;
			List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
			try
			{


				StudentsGroupHistory sghTemp = studentsSortedList[1];

				List<Curator> curator = unit.Curators.GetAll(c => c.GroupIdGroup == sghTemp.GroupIdGroup).ToList();
				groupVMs = new List<GroupVMStatic>(curator.Count);
				dateTimeEnd = dateTimeEnd.AddYears(1995);
				dateTimeStart = dateTimeStart.AddYears(1995);
				int i = 0;
				foreach (var c in curator)
				{
					List<SubjectForGroup> subjectForGroups = unit.SubjectForGroups.GetAll(s => s.IdGroup == c.GroupIdGroup).ToList();
					List<StudentsGroupHistory> students = unit.StudentGroupHistories
						.GetAll(sgh => sgh.GroupIdGroup == c.GroupIdGroup
						&& sgh.ConditionOfPersonIdConditionOfPerson == 1601441643
						&& sgh.DateSGHStart > dateTimeStart && sgh.DateSGHFinished < dateTimeEnd && sgh.IdSGH == sghTemp.IdSGH)
						.ToList();
					GroupVMStatic groupVM = new GroupVMStatic();
					groupVM.idGroup = c.GroupIdGroup;
					groupVM.GroupName = c.Group.GroupName;
					List<SubjectForGroup> subjects = new List<SubjectForGroup>();
					foreach (var sfg in subjectForGroups)
					{
						ExactClass exactClass = unit.ExactClasses.Get(e => e.ID_reff == sfg.ID_reff && e.DateClassStart > dateTimeStart && e.DateClassStart < dateTimeEnd);
						if (exactClass != null)
						{
							subjects.Add(sfg);
						}
					}
					foreach (var sfg in subjects)
					{
						SubjectVM subjectVM = new SubjectVM();
						subjectVM.IdSubject = sfg.IdSubject;
						subjectVM.SubjectName = sfg.Subject.NameSubject + "	" + sfg.TypeStudy.TypeStudyName;
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
						foreach (var a in attendances)
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
							foreach (var a in attedanceBuf)
							{
								if (a.TypeAttedanceIdTA == 3)
								{

									att.attedanced += 1;
								}
								if (a.Ball != null)
								{
									att.Ball += Convert.ToInt32(a.Ball);

								}
								if (a.BallHW != null)
								{
									att.BallHW += Convert.ToInt32(a.BallHW);

								}
							}
						}

						groupVMs[i].studentVMs.Add(studentVM);
					}
					i++;
				}
			}
			catch
			{

			}
			//ChartsDemoEntities DB = new ChartsDemoEntities();
			return groupVMs;
		}
		[Route("GetCharts2/{dateTimeStart}/{dateTimeEnd}")]
		[HttpGet]

		public List<GroupVMStatic> GetChartsData2(DateTime dateTimeStart, DateTime dateTimeEnd)
		{
			//изменить авторизация
			ClaimsIdentity claimsIdentity;
			claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
			var yearClaims = claimsIdentity.FindFirst("Name");
			User user = unit.Users.Get(u => u.login == yearClaims.Value);
			//int IdPerson = user.PersonIdPerson;
			int curatorPersonId = user.PersonIdPerson;
			Person person = unit.Persons.Get(p => p.IdPerson == curatorPersonId);
			List<GroupVMStatic> groupVMs = new List<GroupVMStatic>(0);
			Student student = unit.Students.Get(st => st.IdPerson == person.IdPerson);
			int IdCourse = 1363575543;
			List<StudentsGroupHistory> studentsGroupHistories = unit.StudentGroupHistories
				.GetAll(sgh => sgh.IdStudent == student.IdStudent && sgh.CourseIdCourse == IdCourse && sgh.ConditionOfPersonIdConditionOfPerson == 1601441643).ToList();
			var studentsSorted = from s in studentsGroupHistories
								 orderby s.DateSGHStart
								 select s;
			List<StudentsGroupHistory> studentsSortedList = studentsSorted.ToList();
			try
			{


				StudentsGroupHistory sghTemp = studentsSortedList[1];

				List<Curator> curator = unit.Curators.GetAll(c => c.GroupIdGroup == sghTemp.GroupIdGroup).ToList();
			 groupVMs = new List<GroupVMStatic>(curator.Count);
				dateTimeEnd = dateTimeEnd.AddYears(1995);
				dateTimeStart = dateTimeStart.AddYears(1995);
				int i = 0;
				foreach (var c in curator)
				{
					List<SubjectForGroup> subjectForGroups = unit.SubjectForGroups.GetAll(s => s.IdGroup == c.GroupIdGroup).ToList();
					List<StudentsGroupHistory> students = unit.StudentGroupHistories
						.GetAll(sgh => sgh.GroupIdGroup == c.GroupIdGroup
						&& sgh.ConditionOfPersonIdConditionOfPerson == 1601441643
						&& sgh.DateSGHStart > dateTimeStart && sgh.DateSGHFinished < dateTimeEnd && sgh.IdSGH == sghTemp.IdSGH)
						.ToList();
					GroupVMStatic groupVM = new GroupVMStatic();
					groupVM.idGroup = c.GroupIdGroup;
					groupVM.GroupName = c.Group.GroupName;
					List<SubjectForGroup> subjects = new List<SubjectForGroup>();
					foreach (var sfg in subjectForGroups)
					{
						ExactClass exactClass = unit.ExactClasses.Get(e => e.ID_reff == sfg.ID_reff && e.DateClassStart > dateTimeStart && e.DateClassStart < dateTimeEnd);
						if (exactClass != null)
						{
							subjects.Add(sfg);
						}
					}
					foreach (var sfg in subjects)
					{
						SubjectVM subjectVM = new SubjectVM();
						subjectVM.IdSubject = sfg.IdSubject;
						subjectVM.SubjectName = sfg.Subject.NameSubject + "	" + sfg.TypeStudy.TypeStudyName;
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
						foreach (var a in attendances)
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
							foreach (var a in attedanceBuf)
							{
								if (a.TypeAttedanceIdTA == 3)
								{

									att.attedanced += 1;
								}
								if (a.Ball != null)
								{
									att.Ball += Convert.ToInt32(a.Ball);

								}
								if (a.BallHW != null)
								{
									att.BallHW += Convert.ToInt32(a.BallHW);

								}
							}
						}

						groupVMs[i].studentVMs.Add(studentVM);
					}
					i++;
				}
			}
			catch
			{
				
			}
			//ChartsDemoEntities DB = new ChartsDemoEntities();
			return groupVMs;
		}
		[Route("GetCharts/{dateTimeStart}/{dateTimeEnd}")]
		[HttpGet]
		[Authorize(Roles = "curator, lectcurstud, lectcur")]
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
			dateTimeEnd = dateTimeEnd.AddYears(1995);
			dateTimeStart = dateTimeStart.AddYears(1995);
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
				foreach (var sfg in subjectForGroups)
				{
					ExactClass exactClass = unit.ExactClasses.Get(e => e.ID_reff == sfg.ID_reff && e.DateClassStart > dateTimeStart && e.DateClassStart < dateTimeEnd);
					if (exactClass != null)
					{
						subjects.Add(sfg);
					}
				}
				foreach (var sfg in subjects)
				{
					SubjectVM subjectVM = new SubjectVM();
					subjectVM.IdSubject = sfg.IdSubject;
					subjectVM.SubjectName = sfg.Subject.NameSubject + "	" + sfg.TypeStudy.TypeStudyName;
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
					foreach (var a in attendances)
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
						foreach (var a in attedanceBuf)
						{
							if (a.TypeAttedanceIdTA == 3)
							{

								att.attedanced += 1;
							}
							if (a.Ball != null)
							{
								att.Ball += Convert.ToInt32(a.Ball);

							}
							if (a.BallHW != null)
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

		[HttpPost("CreatePrikaz")]
		public IActionResult CreatePrikaz(Prikaz data)
		{
			if (ModelState.IsValid)
			{
				Prikaz cw = new Prikaz();
				cw.DateAdd = DateTime.Now;
				cw.IdStudyYear = data.IdStudyYear;
				cw.TextPrikaz = data.TextPrikaz;
				//cw.IdPrikaz = null;
				unit.Prikazes.Create(cw);
				unit.Save();
				//cw.TextPrikaz = "текст приказа";
				cw.Rows = data.Rows;
				int IdPrikaza = cw.IdPrikaz;
				List<PrikazRow> Rows = new List<PrikazRow>();
				foreach (var i in cw.Rows)
				{
					Rows.Add(i);
				}
				foreach (var j in Rows)
				{
					PrikazRow prikazRow = new PrikazRow();
					prikazRow.CuratorID = j.CuratorID;
					//prikazRow.Curator = unit.Persons.Get(p => p.IdPerson == j.CuratorID);
					//prikazRow.Group = unit.Groups.Get(p => p.IdGroup == j.IdGroup);
					prikazRow.IdPrikaz = IdPrikaza;
					prikazRow.IdGroup = j.IdGroup;
					unit.PrikazeRowes.Create(prikazRow);
				}
				unit.Save();

				foreach (var j in Rows)
				{
					Curator prikazRow = new Curator();
					prikazRow.PersonIdPerson = j.CuratorID;
					//prikazRow.Curator = unit.Persons.Get(p => p.IdPerson == j.CuratorID);
					//prikazRow.Group = unit.Groups.Get(p => p.IdGroup == j.IdGroup);
					//prikazRow. = IdPrikaza;
					prikazRow.GroupIdGroup = j.IdGroup;
					prikazRow.DateTimeStart = DateTime.Now;
					unit.Curators.Create(prikazRow);
				}
				//cw.FilePath = count.ToString() + data.FilePath;
				//cw.DateAdded = DateTime.Now;

				unit.Save();

				return Ok(data);
			}
			return BadRequest(ModelState);
		}
		[Route("GetPortfolioCards")]

		[HttpGet]
		[Authorize(Roles = "curator, lectcurstud, lectcur")]
		public List<ProfileVM> GetPortfolioCards()
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

			List<ProfileVM> profilesVM = new List<ProfileVM>();
			List<SubjectForGroup> subjectForGroups = unit.SubjectForGroups.GetAll(s => s.IdGroup == curator[0].GroupIdGroup).ToList();
			List<StudentsGroupHistory> students = unit.StudentGroupHistories
				.GetAll(sgh => sgh.GroupIdGroup == curator[0].GroupIdGroup
				&& sgh.ConditionOfPersonIdConditionOfPerson == 1601441643 && sgh.CourseIdCourse == 1363575543)
				.ToList();
			GroupVMStatic groupVM = new GroupVMStatic();
			groupVM.idGroup = curator[0].GroupIdGroup;
			groupVM.GroupName = curator[0].Group.GroupName;
			List<SubjectForGroup> subjects = new List<SubjectForGroup>();
			foreach (var sfg in subjectForGroups)
			{
				ExactClass exactClass = unit.ExactClasses.Get(e => e.ID_reff == sfg.ID_reff);
				if (exactClass != null)
				{
					subjects.Add(sfg);
				}
			}


			foreach (var s in students)
			{
				StudentVM studentVM = new StudentVM();
				studentVM.IdStudent = s.IdStudent;
				ProfileVM profileVM = new ProfileVM();

				Person personStudent = unit.Persons.Get(p => p.IdPerson == s.Student.IdPerson);
				studentVM.IdStudent = s.IdStudent;
				studentVM.PersonFIO = personStudent.PersonFIOShort();
				List<Attendance> attendances = unit.Attendances.GetAll(a => a.IdSGH == s.IdSGH).ToList();
				foreach (var i in attendances)
				{
					if (i.TypeAttedanceIdTA == 3)
					{
						profileVM.NopeAttedance += 1;
					};
					if (i.TypeAttedanceIdTA == 4)
					{
						profileVM.NopeAttedanceConfirmed += 1;
					};

				};
				studentVM.Attedanced = new List<AttedancedVM>();
				foreach (var sg in subjects)
				{
					AttedancedVM attedancedVM = new AttedancedVM();
					attedancedVM.IdReff = sg.ID_reff;
					//attedancedVM.attedanced = sg.ID_reff;
					studentVM.Attedanced.Add(attedancedVM);
				};
				double count = attendances.Count();
				double procents = (profileVM.NopeAttedance) / count * 100;
				try
				{
					profileVM.NopeAttedanceProc = Convert.ToInt32(procents);

				}
				catch
				{
					profileVM.NopeAttedanceProc = 0;

				}
				profileVM.Group = s.Group.GroupName;
				profileVM.Rabota = personStudent.Rabota;
				profileVM.IdPerson = personStudent.IdPerson;
				profileVM.PersonFIO = personStudent.PersonFIOShort();
				profileVM.Telephone = personStudent.Telephone;
				profilesVM.Add(profileVM);

			}

			//ChartsDemoEntities DB = new ChartsDemoEntities();
			return profilesVM;
		}

		[Route("GetPikazes")]
		[HttpGet]
		//[Authorize(Roles = "decan")]
		public List<Prikaz> GetPikazes()
		{
			//изменить авторизация
			//ClaimsIdentity claimsIdentity;

			//claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
			//var yearClaims = claimsIdentity.FindFirst("Name");
			//User user = unit.Users.Get(u => u.login == yearClaims.Value);
			////int IdPerson = user.PersonIdPerson;
			//int curatorPersonId = user.PersonIdPerson;
			//Person person = unit.Persons.Get(p => p.IdPerson == curatorPersonId);
			List<Prikaz> prikazes = unit.Prikazes.GetAll().ToList();
			foreach (var p in prikazes)
			{
				foreach (var pr in p.RowsForSend)
				{
					PrikazRowVM prikazRowVM = new PrikazRowVM();
					prikazRowVM.Curator = unit.Persons.Get(p => p.IdPerson == pr.CuratorID).PersonFIOShort();
					prikazRowVM.Group = unit.Groups.Get(g => g.IdGroup == pr.IdGroup).GroupName;
					prikazRowVM.IdGroup = pr.IdGroup;
					prikazRowVM.CuratorID = pr.CuratorID;
					prikazRowVM.IdPrikaz = pr.IdPrikaz;
					prikazRowVM.IdPrikazRow = pr.IdPrikazRow;
					p.PrikazRowVMs.Add(prikazRowVM);

				}
				p.RowsForSend = null;
			}


			//ChartsDemoEntities DB = new ChartsDemoEntities();
			return prikazes;
		}
		[Route("GetPikazPrint/{IdPrikaza}")]
		[HttpGet]
		//[Authorize(Roles = "decan")]
		public Prikaz GetPikazPrint(int IdPrikaza)
		{
			//изменить авторизация
			//ClaimsIdentity claimsIdentity;

			//claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
			//var yearClaims = claimsIdentity.FindFirst("Name");
			//User user = unit.Users.Get(u => u.login == yearClaims.Value);
			////int IdPerson = user.PersonIdPerson;
			//int curatorPersonId = user.PersonIdPerson;
			//Person person = unit.Persons.Get(p => p.IdPerson == curatorPersonId);
			Prikaz p = unit.Prikazes.Get(p => p.IdPrikaz == IdPrikaza);

			foreach (var pr in p.RowsForSend)
			{
				PrikazRowVM prikazRowVM = new PrikazRowVM();
				prikazRowVM.Curator = unit.Persons.Get(p => p.IdPerson == pr.CuratorID).PersonFIOShort();
				prikazRowVM.CuratorDoljn = unit.Persons.Get(p => p.IdPerson == pr.CuratorID).Rabota;
				prikazRowVM.Group = unit.Groups.Get(g => g.IdGroup == pr.IdGroup).GroupName;
				prikazRowVM.IdGroup = pr.IdGroup;
				prikazRowVM.CuratorID = pr.CuratorID;
				prikazRowVM.IdPrikaz = pr.IdPrikaz;
				prikazRowVM.IdPrikazRow = pr.IdPrikazRow;
				p.PrikazRowVMs.Add(prikazRowVM);

			}
			p.RowsForSend = null;



			//ChartsDemoEntities DB = new ChartsDemoEntities();
			return p;
		}

		[Route("GetCuratorsForPrikaz")]
		[HttpGet]
		[Authorize(Roles = "decan")]
		public List<ProfileVM> GetCuratorsForPrikaz()
		{

			//Person person = unit.Persons.Get(p => p.IdPerson == curatorPersonId);
			List<Person> curators = unit.Persons.GetAll(c => c.IdPerson == 1739436573 || c.IdPerson == 156471936 || c.IdPerson == -927650154).ToList();
			List<ProfileVM> profilesVM = new List<ProfileVM>();
			List<Group> groups = unit.Groups.GetAll(g => g.IdGroup == -1483657984 || g.IdGroup == -1483657983 || g.IdGroup == -1483657983 || g.IdGroup == -1483657982 || g.IdGroup == 156471939 || g.IdGroup == 156471940 || g.IdGroup == 156471941 || g.IdGroup == 1584633433 || g.IdGroup == 1739436558).ToList();
			//237609111 - Ира
			//Кураторы:

			//1739436573 - 
			//156471936

			//-927650154
			foreach (var p in curators)
			{
				ProfileVM profileVM = new ProfileVM();
				profileVM.IdPerson = p.IdPerson;
				profileVM.PersonFIO = p.LastName + " " + p.FirstName + " " + p.PatronicName;
				profileVM.Rabota = p.Rabota;
				profilesVM.Add(profileVM);
			}

			//Группы:
			//-1483657984
			//-1483657983
			//-1483657982
			//156471939
			//156471940
			//156471941
			//1584633433
			//1739436558
			//ChartsDemoEntities DB = new ChartsDemoEntities();
			return profilesVM;
		}
		[Route("GetGroupsForPrikaz")]
		[HttpGet]
		[Authorize(Roles = "decan")]
		public List<GroupVMStatic> GetGroupsForPrikaz()
		{

			//Person person = unit.Persons.Get(p => p.IdPerson == curatorPersonId);
			//List<Person> curators = unit.Persons.GetAll(c => c.PersonIdPerson == 1739436573 || c.PersonIdPerson == 156471936 || c.PersonIdPerson == -927650154).ToList();
			List<ProfileVM> profilesVM = new List<ProfileVM>();
			List<GroupVMStatic> groupsVM = new List<GroupVMStatic>();
			List<Group> groups = unit.Groups.GetAll(g => g.IdGroup == -1483657984 || g.IdGroup == -1483657983 || g.IdGroup == -1483657983 || g.IdGroup == -1483657982 || g.IdGroup == 156471939 || g.IdGroup == 156471940 || g.IdGroup == 156471941 || g.IdGroup == 1584633433 || g.IdGroup == 1739436558).ToList();
			//237609111 - Ира
			//Кураторы:

			//1739436573 - 
			//156471936

			//-927650154
			foreach (var p in groups)
			{
				GroupVMStatic groupVM = new GroupVMStatic();
				groupVM.idGroup = p.IdGroup;
				groupVM.GroupName = p.GroupName;

				groupsVM.Add(groupVM);
			}
			//Группы:
			//-1483657984
			//-1483657983
			//-1483657982
			//156471939
			//156471940
			//156471941
			//1584633433
			//1739436558
			//ChartsDemoEntities DB = new ChartsDemoEntities();
			return groupsVM;
		}
		[Route("GetPrikaz")]
		[HttpGet]
		[Authorize(Roles = "decan")]
		public Prikaz GetPrikaz()
		{
			Prikaz prikaz = new Prikaz();
			prikaz.StudyYear = unit.StudyYears.Get(y => y.IdStudyYear == 237609141);
			prikaz.IdStudyYear = 237609141;
			prikaz.DateAdd = DateTime.Now;
			prikaz.Rows = new List<PrikazRow>();
			PrikazRow prikazRow = new PrikazRow();
			prikaz.Rows.Add(prikazRow);
			prikaz.DateAddString = DateTime.Now.ToString("d");
			//Группы:
			//-1483657984
			//-1483657983
			//-1483657982
			//156471939
			//156471940
			//156471941
			//1584633433
			//1739436558
			//ChartsDemoEntities DB = new ChartsDemoEntities();
			return prikaz;
		}
	}
}
