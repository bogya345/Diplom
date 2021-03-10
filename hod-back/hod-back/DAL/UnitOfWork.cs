using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL.Contexts;
using hod_back.DAL.Repositories;

namespace hod_back.DAL
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
                DAL_Settings.localAccess = true;
            }
        }

        public Context context = new Context();

        #region Repositories

        #region Tables Reposes

        private ApplyTypesRepository applyTypesRepository;
        private BlockRecsRepository blockRecsRepository;
        private DepartmentsRepository cathedrasRepository;
        private EducFormsRepository educFormsRepository;
        private GroupsRepository groupsRepository;
        private QualificationRepository qualificationRepository;
        private SubjectsRepository subjectsRepository;
        //private TeacherCathedrasRepository teacherCathedrasRepository;
        private TeacherLoadRepository teacherLoadRepository;
        private EmployeesRepository employeeRepository;

        #endregion

        #region Views Reposes

        /// <summary>
        /// авторизация
        /// </summary>
        private AuthUsersRepository usersAuthRepository;

        private ViewTeacherLoadRepository viewTeacherLoadRepository;
        private CathInfoRepository cathInfoRepository;

        #endregion


        #endregion


        #region Repository Access

        #region Tables

        public ApplyTypesRepository ApplyTypes
        {
            get
            {
                if (applyTypesRepository == null)
                    applyTypesRepository = new ApplyTypesRepository(context);
                return applyTypesRepository;
            }
        }
        public BlockRecsRepository BlockRecs
        {
            get
            {
                if (blockRecsRepository == null)
                    blockRecsRepository = new BlockRecsRepository(context);
                return blockRecsRepository;
            }
        }
        public DepartmentsRepository Departments
        {
            get
            {
                if (cathedrasRepository == null)
                    cathedrasRepository = new DepartmentsRepository(context);
                return cathedrasRepository;
            }
        }
        public EducFormsRepository EducForms
        {
            get
            {
                if (educFormsRepository == null)
                    educFormsRepository = new EducFormsRepository(context);
                return educFormsRepository;
            }
        }
        public GroupsRepository Groups
        {
            get
            {
                if (groupsRepository == null)
                    groupsRepository = new GroupsRepository(context);
                return groupsRepository;
            }
        }
        public QualificationRepository Qualifications
        {
            get
            {
                if (qualificationRepository == null)
                    qualificationRepository = new QualificationRepository(context);
                return qualificationRepository;
            }
        }
        public SubjectsRepository Subjects
        {
            get
            {
                if (subjectsRepository == null)
                    subjectsRepository = new SubjectsRepository(context);
                return subjectsRepository;
            }
        }
        //public TeacherCathedrasRepository TeachersCathedras
        //{
        //    get
        //    {
        //        if (teacherCathedrasRepository == null)
        //            teacherCathedrasRepository = new TeacherCathedrasRepository(context);
        //        return teacherCathedrasRepository;
        //    }
        //}
        public TeacherLoadRepository TeacherLoads
        {
            get
            {
                if (teacherLoadRepository == null)
                    teacherLoadRepository = new TeacherLoadRepository(context);
                return teacherLoadRepository;
            }
        }
        public EmployeesRepository Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeesRepository(context);
                return employeeRepository;
            }
        }


        public AuthUsersRepository AuthUsers
        {
            get
            {
                if (usersAuthRepository == null)
                    usersAuthRepository = new AuthUsersRepository(context);
                return usersAuthRepository;
            }
        }
        #endregion


        #region Views

        public ViewTeacherLoadRepository ViewTeacherLoads
        {
            get
            {
                if (viewTeacherLoadRepository == null)
                    viewTeacherLoadRepository = new ViewTeacherLoadRepository(context);
                return viewTeacherLoadRepository;
            }
        }

        public CathInfoRepository CathInfo
        {
            get
            {
                if (cathInfoRepository == null)
                    cathInfoRepository = new CathInfoRepository(context);
                return cathInfoRepository;
            }
        }

        #endregion

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
