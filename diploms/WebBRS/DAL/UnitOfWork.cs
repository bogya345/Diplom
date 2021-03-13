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
        private AttendanceRepo attendanceRepository;
		//private DepartmenRepository personsRepository;
		//private BlockRecsRepository blockRecsRepository;
		private DepartmentsRepo departsRepository;
		private HomeWorkRepo homeworksRepository;
		private StudentRepo studentsRepository;
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
        public StudentGroupHistoryRepo StudentGroupHistories
        {
            get
            {
                if (studentGroupHistoryRepo == null)
                    studentGroupHistoryRepo = new StudentGroupHistoryRepo(context);
                return studentGroupHistoryRepo;
            }
        } 
        public AttendanceRepo Attendances
        {
            get
            {
                if (attendanceRepository == null)
                    attendanceRepository = new AttendanceRepo(context);
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
