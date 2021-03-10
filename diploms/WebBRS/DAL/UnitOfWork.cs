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

        private PersonsRepository personsRepository;
		//private DepartmenRepository personsRepository;
		//private BlockRecsRepository blockRecsRepository;
		private DepartmentsRepository departsRepository;
		private HomeWorkRepository homeworksRepository;
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
		private AuthUsersRepository usersAuthRepository;
		//private DepartmentsRepository DepartsRepository;
		//private HomeWorkRepository HomeWorksRepository;

        //private ViewTeacherLoadRepository viewTeacherLoadRepository;
        //private CathInfoRepository cathInfoRepository;

        #endregion


        #endregion


        #region Repository Access
        public AuthUsersRepository AuthUsers
        {
            get
            {
                if (usersAuthRepository == null)
                    usersAuthRepository = new AuthUsersRepository(context);
                return usersAuthRepository;
            }
        }
        public PersonsRepository Persons
        {
            get
            {
                if (personsRepository == null)
                    personsRepository = new PersonsRepository(context);
                return personsRepository;
            }
        }
        public DepartmentsRepository Departments
        {
            get
            {
                if (departsRepository == null)
                    departsRepository = new DepartmentsRepository(context);
                return departsRepository;
            }
        } 
        public HomeWorkRepository Homeworks
        {
            get
            {
                if (homeworksRepository == null)
                    homeworksRepository = new HomeWorkRepository(context);
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
