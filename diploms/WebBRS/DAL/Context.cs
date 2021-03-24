using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;
using WebBRS.Models.Views;

namespace WebBRS.DAL
{
	public class MyContext : DbContext
	{
		#region Tables
		public DbSet<Attendance> Attendances { get; set; }
		public DbSet<ExactClassForLecturerClass> ExactClassForLecturerClasses { get; set; }
		public DbSet<ClassWork> ClassWorks { get; set; }
		public DbSet<WorkPersonStatus> WorkPersonStatuses { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<DepartmentType> DepartmentTypes { get; set; }
		public DbSet<DoClassWorkAttend> DoClassWorkAttends { get; set; }
		public DbSet<ExactClass> ExactClasses { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Lecturer> Lectureres { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Specialty> Specialties { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<StudentsGroupHistory> StudentsGroupHistories { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<SubjectForGroup> SubjectForGroups { get; set; }
		public DbSet<SubjectLecturer> SubjectLecturers { get; set; }
		public DbSet<WorkType> WorkTypes { get; set; }
		#endregion

		#region Views
		public virtual DbSet<AuthUsers> AuthUsers { get; set; }
		#endregion
		public MyContext(DbContextOptions<MyContext> options)
	: base(options)
		{
		}
		public MyContext()
		{
			//Database.EnsureDeleted();   // удаляем бд со старой схемой
			//Database.EnsureCreated();   // создаем бд с новой схемой
		}

		public MyContext getContext()
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

			return new MyContext();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer("Data Source=DESKTOP-CBO4Q8H;Initial Catalog=DbBDRS;Integrated Security=True");
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBKSLRS\\SQLEXPRESS;Initial Catalog=DbBRS;Integrated Security=True");

			//optionsBuilder.UseSqlServer("Data Source=DESKTOP-CBO4Q8H;Initial Catalog=DbBRS;Integrated Security=True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//string adminRoleName = "admin";
			//string userRoleName = "user";

			//string adminEmail = "semen.sychevforedu@gmail.ru";
			//string adminPassword = "123456";
			//modelBuilder.Entity<RequisitionTypeUser>()
			//   .HasOne(sc => sc.User)
			//   .WithMany(s => s.RequisitionTypeUsers)
			//   .HasForeignKey(sc => sc.IDUser);
			//modelBuilder.Entity<Person>()
			//	.HasKey(p => p.GuidPerson);
			modelBuilder.Entity<Student>()
				.HasOne(p => p.Person)
				.WithMany(t => t.Students)
				.HasForeignKey(st => st.GuidPerson);
			//modelBuilder.Entity<Department>()
			//	.HasOne(p => p.DepartmentType)
			//	.WithMany(t => t.Departments)
			//	.HasForeignKey(st => st.DepartmentTypeID);
			modelBuilder.Entity<Lecturer>()
				.HasMany(c => c.Subjects)
				.WithMany(s => s.Lecturers)
				.UsingEntity<SubjectLecturer>(
				   j => j
					.HasOne(pt => pt.Subject)
					.WithMany(t => t.SubjectLecturers)
					.HasForeignKey(pt => pt.IdSubject),
				j => j
					.HasOne(pt => pt.Lecturer)
					.WithMany(p => p.SubjectLecturers)
					.HasForeignKey(pt => pt.IdLecturer),
				j =>
				{
					j.Property(pt => pt.SLDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
					j.HasKey(t => new { t.IdLecturer, t.IdSubject });
					j.ToTable("SubjectLecturers");
				}
			);
			modelBuilder.Entity<AuthUsers>((item =>
			{
				item.HasNoKey();
				item.ToView("AuthUsers");
			}));
			modelBuilder.Entity<Group>()
			.HasMany(c => c.Subjects)
			.WithMany(s => s.Groups)
			.UsingEntity<SubjectForGroup>(
			   j => j
				.HasOne(pt => pt.Subject)
				.WithMany(t => t.SubjectForGroups)
				.HasForeignKey(pt => pt.IdSubject),
			j => j
				.HasOne(pt => pt.Group)
				.WithMany(p => p.SubjectForGroups)
				.HasForeignKey(pt => pt.IdGroup)

		);
			#region Справочники
			modelBuilder.Entity<DepartmentType>()
				.HasKey(p => p.DepartTypeID);
			modelBuilder.Entity<TypeStudy>()
				.HasKey(p => p.IdTS);
			modelBuilder.Entity<TypeStudy>()
				.HasKey(p => p.IdTS);
			modelBuilder.Entity<WorkType>()
				.HasKey(p => p.IdWT);
			modelBuilder.Entity<Specialty>()
				.HasKey(p => p.IdSpec);
			#endregion
			//modelBuilder.Entity<RequisitionTypeUser>()
			//	.HasOne(sc => sc.RequisitionType)
			//	.WithMany(c => c.RequisitionTypeUsers)
			//	.HasForeignKey(sc => sc.IDRequisitionType);
			//// добавляем роли
			//Role adminRole = new Role { Id = 1, Name = adminRoleName };
			//Role userRole = new Role { Id = 2, Name = userRoleName };
			//User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

			//modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
			//modelBuilder.Entity<User>().HasData(new User[] { adminUser });
			base.OnModelCreating(modelBuilder);
		}
	}
}
