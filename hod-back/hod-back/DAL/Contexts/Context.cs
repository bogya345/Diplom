using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL;
using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;
using hod_back.DAL.Models.Auth;
using hod_back.DAL.Models.Views;
using Microsoft.Data.SqlClient;
//using DocumentFormat.OpenXml.Spreadsheet;

namespace hod_back.DAL.Contexts
{
    public class Context : DbContext
    {
        #region Tables

        public virtual DbSet<ApplyTypes> ApplyTypes { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EducForms> EducForms { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Qualifications> Qualifications { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<BlockRecs> BlockRecs { get; set; }
        //public virtual DbSet<TeacherCathedra> TeacherCathedras { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<TeacherLoad> TeacherLoad { get; set; }

        #endregion


        #region Views

        /// <summary>
        /// Представление для авторизации
        /// </summary>
        public virtual DbSet<AuthUsers> AuthUsers { get; set; }

        /// <summary>
        /// Представление для показа учебного плана
        /// </summary>
        public virtual DbSet<ViewTeacherLoad> ViewTeacherLoad { get; set; }

        /// <summary>
        /// Представление для данных о кафедрах
        /// </summary>
        public virtual DbSet<CathInfo> CathInfo { get; set; }

        #endregion


        public DbSet<TableTest> TableTest { get; set; }

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

        //public TestContext(DbContextOptions<TestContext> options) : base(options)
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1402;Initial Catalog=ugtu;Persist Security Info=True;User ID=SA;Password=P@ssw0rd_ugtu");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TeacherLoad>()
                .HasKey(o => new { o.id_blockRec, o.typeSubject });
            modelBuilder.Entity<TeacherLoad>()
                .Property(e => e.id_employee)
                .ValueGeneratedOnAdd();

            // Users
            //modelBuilder.Entity<Models.Auth.Users>()
            //    .HasMany(x => x.Roles)
            //    .WithOne(y=>y.)


            /// Views jokes

            // AuthUsers
            modelBuilder.Entity<AuthUsers>((item =>
            {
                item.HasNoKey();
                item.ToView("AuthUsers");
            }));

            // ViewTeacherLoad
            modelBuilder.Entity<ViewTeacherLoad>((item =>
            {
                item.HasNoKey();
                item.ToView("ViewTeacherLoad");
            }));

            // CathInfo
            modelBuilder.Entity<CathInfo>((item =>
            {
                item.HasNoKey();
                item.ToView("CathInfo");
            }));

        }


    }
}
