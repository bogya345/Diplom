using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;
using hod_back.DAL.Repositories;

namespace hod_back.DAL
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork()
        {
        }

        public Context context = new Context();

        #region Accounts (авторизация)

        // tables

        // views
        private AuthUsersRepository usersAuthRepository;
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

        #region Departments (кафедры)

        // tables
        private DepartmentsRepository cathedrasRepository;
        public DepartmentsRepository Departments
        {
            get
            {
                if (cathedrasRepository == null)
                    cathedrasRepository = new DepartmentsRepository(context);
                return cathedrasRepository;
            }
        }
        private EmployeesRepository employeeRepository;
        public EmployeesRepository Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeesRepository(context);
                return employeeRepository;
            }
        }

        // views
        private DepsInfoRepository depsInfoRepository;
        public DepsInfoRepository DepsInfo
        {
            get
            {
                if (depsInfoRepository == null)
                    depsInfoRepository = new DepsInfoRepository(context);
                return depsInfoRepository;
            }
        }

        private DepDirFacRepository depDirFacRepository;
        public DepDirFacRepository DepDirFac
        {
            get
            {
                if (depDirFacRepository == null)
                    depDirFacRepository = new DepDirFacRepository(context);
                return depDirFacRepository;
            }
        }

        private DirGroupsRepository dirGroupsRepository;
        public DirGroupsRepository DirGroups
        {
            get
            {
                if (dirGroupsRepository == null)
                    dirGroupsRepository = new DirGroupsRepository(context);
                return dirGroupsRepository;
            }
        }

        private DirRequirsRepository dirRequirsRepository;
        public DirRequirsRepository DirRequirs
        {
            get
            {
                if (dirRequirsRepository == null)
                    dirRequirsRepository = new DirRequirsRepository(context);
                return dirRequirsRepository;
            }
        }

        #endregion

        #region Directions (направления)

        // tables
        private DirectionRepository directionRepository;
        public DirectionRepository Directions
        {
            get
            {
                if (directionRepository == null)
                    directionRepository = new DirectionRepository(context);
                return directionRepository;
            }
        }

        #endregion

        #region Groups (группы)

        // tables
        private GroupsRepository groupsRepository;
        public GroupsRepository Groups
        {
            get
            {
                if (groupsRepository == null)
                    groupsRepository = new GroupsRepository(context);
                return groupsRepository;
            }
        }
        private SubjectsRepository subjectsRepository;
        public SubjectsRepository Subjects
        {
            get
            {
                if (subjectsRepository == null)
                    subjectsRepository = new SubjectsRepository(context);
                return subjectsRepository;
            }
        }
        private BlockRecsRepository blockRecsRepository;
        public BlockRecsRepository BlockRecs
        {
            get
            {
                if (blockRecsRepository == null)
                    blockRecsRepository = new BlockRecsRepository(context);
                return blockRecsRepository;
            }
        }
        private EducFormsRepository educFormsRepository;
        public EducFormsRepository EducForms
        {
            get
            {
                if (educFormsRepository == null)
                    educFormsRepository = new EducFormsRepository(context);
                return educFormsRepository;
            }
        }

        //views

        #endregion

        #region AcPlans (учебные планы)

        // tables
        private AcPlanRepository acPlanRepository;
        public AcPlanRepository AcPlans
        {
            get
            {
                if (acPlanRepository == null)
                    acPlanRepository = new AcPlanRepository(context);
                return acPlanRepository;
            }
        }
        private BlockNumRepository blockNumRepository;
        public BlockNumRepository BlockNums
        {
            get
            {
                if (blockNumRepository == null)
                    blockNumRepository = new BlockNumRepository(context);
                return blockNumRepository;
            }
        }

        #endregion

        #region Misc

        // tables
        private WorkTypesRepository applyTypesRepository;
        public WorkTypesRepository ApplyTypes
        {
            get
            {
                if (applyTypesRepository == null)
                    applyTypesRepository = new WorkTypesRepository(context);
                return applyTypesRepository;
            }
        }

        // views

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
