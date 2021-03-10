using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL
{
	public class Context : DbContext
	{

		public DbSet<Attendance> Attendances { get; set; }
		public DbSet<ClassWork> ClassWorks { get; set; }
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

		public Context(DbContextOptions<Context> options)
	: base(options)
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-CBO4Q8H;Initial Catalog=DbBDRS;Integrated Security=True");
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
