using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL;
using hod_back.DAL.Models.Dictionaries;
using hod_back.DAL.Models.Auth;
using hod_back.DAL.Models.Views;
using Microsoft.Data.SqlClient;
//using DocumentFormat.OpenXml.Spreadsheet;

using hod_back.Model;

namespace hod_back.DAL.Contexts
{
    public partial class Context : DbContext
    {

        //public DbSet<TableTest> TableTest { get; set; }

        public Context()
        {
        }

        public Context getContext()
        {
            //try
            //{
            //    this.Database.CanConnect();
            //}
            //catch (Exception ex)
            //{
            //    Type tmp = ex.GetType();
            //    if (tmp.FullName == "Microsoft.Data.SqlClient.SqlException")
            //    {
            //        return new local_Context();
            //    }
            //}

            return new Context();
        }
        public virtual DbSet<AcademicPlan> AcademicPlans { get; set; }
        public virtual DbSet<AuthUser> AuthUsers { get; set; }
        public virtual DbSet<BlockRec> BlockRecs { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentType> DepartmentTypes { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<DirectionFgo> DirectionFgos { get; set; }
        public virtual DbSet<DirectionGroup> DirectionGroups { get; set; }
        public virtual DbSet<EducBranch> EducBranches { get; set; }
        public virtual DbSet<EducDoc> EducDocs { get; set; }
        public virtual DbSet<EducDocType> EducDocTypes { get; set; }
        public virtual DbSet<EducForm> EducForms { get; set; }
        public virtual DbSet<EducLevel> EducLevels { get; set; }
        public virtual DbSet<EmpDegree> EmpDegrees { get; set; }
        public virtual DbSet<EmpEducDoc> EmpEducDocs { get; set; }
        public virtual DbSet<EmpRank> EmpRanks { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Fac> Facs { get; set; }
        public virtual DbSet<FactStaffHistory> FactStaffHistories { get; set; }
        public virtual DbSet<FgosRequir> FgosRequirs { get; set; }
        public virtual DbSet<FgosrequiresToDirection> FgosrequiresToDirections { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<KatZaved> KatZaveds { get; set; }
        public virtual DbSet<ListSpeciality> ListSpecialities { get; set; }
        public virtual DbSet<Load> Loads { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostType> PostTypes { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ScienceType> ScienceTypes { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectType> SubjectTypes { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfos { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkType> WorkTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost,1402;Initial Catalog=hod;Persist Security Info=True;User ID=agent;Password=Agent_P@ssword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
