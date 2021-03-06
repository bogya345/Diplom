using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.DAL;
//using WebBRS.Models.Views;
//using WebBRS.DAL.Contexts;
using WebBRS.DAL.Repositories;

namespace WebBRS.DAL
{
	public class UnitOfWork : IDisposable
	{
		public UnitOfWork()
		{
			try
			{
				AuthUsers.Get(x => x.id_employee == 1);
			}
			catch (Exception ex)
			{
				//DAL_Settings.localAccess = true;
			}
		}

		public MyContext context = new MyContext();

		#region Repositories

		#region Tables Reposes

		private PersonsRepo personsRepository;
		private AttendancesRepo attendanceRepository;
		private GroupsRepo groupsRepo;
		private ExactClassesRepo exactClassRepo;
		private LecturersRepo lecturersRepo;
		private SubjectForGroupRepo subjectForGroupRepo;
		private SubjectLecturerRepo subjectLecturerRepo;
		//private DepartmenRepository personsRepository;
		//private BlockRecsRepository blockRecsRepository;
		private DepartmentsRepo departsRepository;
		private HomeWorkRepo homeworksRepository;
		private StudentRepo studentsRepository;
		private ExactClassForLecturerRepo exactClassForLecturer;
		private HomeWorkStudentsRepo homeWorkStudentsRepo;
		private StudentGroupHistoryRepo studentGroupHistoryRepo;
		//private EducFormsRepository educFormsRepository;
		//private GroupsRepository groupsRepository;
		//private QualificationRepository qualificationRepository;
		//private SubjectsRepository subjectsRepository;
		////private TeacherCathedrasRepository teacherCathedrasRepository;
		//private TeacherLoadRepository teacherLoadRepository;
		//private EmployeesRepository employeeRepository;

		#endregion

		#region Views Reposes

		/// <summary>
		/// авторизация
		/// </summary>
		private AuthUsersRepo usersAuthRepository;
		//private DepartmentsRepository DepartsRepository;
		//private HomeWorkRepository HomeWorksRepository;

		//private ViewTeacherLoadRepository viewTeacherLoadRepository;
		//private CathInfoRepository cathInfoRepository;

		#endregion


		#endregion


		#region Repository Access
		public AuthUsersRepo AuthUsers
		{
			get
			{
				if (usersAuthRepository == null)
					usersAuthRepository = new AuthUsersRepo(context);
				return usersAuthRepository;
			}
		}
		public StudentRepo Students
		{
			get
			{
				if (studentsRepository == null)
					studentsRepository = new StudentRepo(context);
				return studentsRepository;
			}
		}
		public LecturersRepo Lecturers
		{
			get
			{
				if (lecturersRepo == null)
					lecturersRepo = new LecturersRepo(context);
				return lecturersRepo;
			}
		}
		public GroupsRepo Groups
		{
			get
			{
				if (groupsRepo == null)
					groupsRepo = new GroupsRepo(context);
				return groupsRepo;
			}

		}
		public ExactClassesRepo ExactClasses
		{
			get
			{
				if (exactClassRepo == null)
					exactClassRepo = new ExactClassesRepo(context);
				return exactClassRepo;
			}
		}
		public SubjectLecturerRepo SubjectLecturers
		{
			get
			{
				if (subjectLecturerRepo == null)
					subjectLecturerRepo = new SubjectLecturerRepo(context);
				return subjectLecturerRepo;
			}
		}		
		public ExactClassForLecturerRepo ExactClassForLectureres
		{
			get
			{
				if (exactClassForLecturer == null)
					exactClassForLecturer = new ExactClassForLecturerRepo(context);
				return exactClassForLecturer;
			}
		}
		public SubjectForGroupRepo SubjectForGroups
		{
			get
			{
				if (subjectForGroupRepo == null)
					subjectForGroupRepo = new SubjectForGroupRepo(context);
				return subjectForGroupRepo;
			}
		}
		public StudentGroupHistoryRepo StudentGroupHistories
		{
			get
			{
				if (studentGroupHistoryRepo == null)
					studentGroupHistoryRepo = new StudentGroupHistoryRepo(context);
				return studentGroupHistoryRepo;
			}
		}
		public AttendancesRepo Attendances
		{
			get
			{
				if (attendanceRepository == null)
					attendanceRepository = new AttendancesRepo(context);
				return attendanceRepository;
			}
		}
		public PersonsRepo Persons
		{
			get
			{
				if (personsRepository == null)
					personsRepository = new PersonsRepo(context);
				return personsRepository;
			}
		}
		public HomeWorkStudentsRepo PersonHomeworks
		{
			get
			{
				if (homeWorkStudentsRepo == null)
					homeWorkStudentsRepo = new HomeWorkStudentsRepo(context);
				return homeWorkStudentsRepo;
			}
		}
		public DepartmentsRepo Departments
		{
			get
			{
				if (departsRepository == null)
					departsRepository = new DepartmentsRepo(context);
				return departsRepository;
			}
		}
		public HomeWorkRepo Homeworks
		{
			get
			{
				if (homeworksRepository == null)
					homeworksRepository = new HomeWorkRepo(context);
				return homeworksRepository;
			}
		}
		#endregion



		/// <summary>
		/// Save Changes
		/// </summary>
		public void Save()
		{
			context.SaveChanges();
		}

		private bool disposed = false;
		public void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
				this.disposed = true;
			}
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
