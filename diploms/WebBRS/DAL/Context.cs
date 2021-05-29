using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;
using WebBRS.Models.Auth;
using WebBRS.Models.Views;

namespace WebBRS.DAL
{
	public class MyContext : DbContext
	{
		#region Tables
		public DbSet<Attendance> Attendances { get; set; }
		public DbSet<AttedanceReason> AttedanceReasons { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<DraftTimeTable> DraftTimeTable { get; set; }
		public DbSet<Portfolio> Portfolios { get; set; }
		public DbSet<TypeTimeTable> TypeTimeTables { get; set; }
		public DbSet<TypeAttedance> TypeAttedances { get; set; }
		public DbSet<TypeControl> TypeControls { get; set; }
		//public DbSet<InformationForTimeTable> InformationForTimeTables { get; set; }
		public DbSet<ExactClassForLecturerClass> ExactClassForLecturerClasses { get; set; }
		public DbSet<ClassWork> ClassWorks { get; set; }
		public DbSet<Curator> Curators { get; set; }
		public DbSet<ConditionOfPerson> ConditionOfPersons { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<WorkPersonStatus> WorkPersonStatuses { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<DepartmentType> DepartmentTypes { get; set; }
		public DbSet<User> Users { get; set; }
		//public DbSet<Role> Roles { get; set; }
		public DbSet<TypeStudy> TypeStudies { get; set; }
		public DbSet<StudyPlanRecord> StudyPlanRecords { get; set; }
		public DbSet<StudyYear> StudyYears { get; set; }
		public DbSet<TypeStudyPlanRecord> TypeStudyPlanRecords { get; set; }
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
		public DbSet<SemestrBase> SemestrBases { get; set; }
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
			//optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBKSLRS\\SQLEXPRESS;Initial Catalog=DbBRS;Integrated Security=True");

			optionsBuilder.UseSqlServer("Data Source=DESKTOP-CBO4Q8H;Initial Catalog=DbBRS;Integrated Security=True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Student>()
				.HasOne(p => p.Person)
				.WithMany(t => t.Students)
				.HasForeignKey(st => st.IdPerson);
			modelBuilder.Entity<AttedanceReason>()
				.HasOne(p => p.Person)
				.WithMany(t => t.AttedanceReasons)
				.HasForeignKey(st => st.IdPerson);
			modelBuilder.Entity<AttedanceReason>()
				.HasOne(p => p.Curator)
				.WithMany(t => t.AttedanceReasons)
				.HasForeignKey(st => st.IdCurator);
			modelBuilder.Entity<AttedanceReason>()
				.HasOne(p => p.SGH)
				.WithMany(t => t.AttedanceReasons)
				.HasForeignKey(st => st.IdSGH);
			modelBuilder.Entity<Attendance>()
			.HasOne(p => p.SGH)
			.WithMany(t => t.Attendances);
			modelBuilder.Entity<Portfolio>()
			.HasOne(p => p.Person)
			.WithMany(t => t.Portfolios)
			.HasForeignKey(st => st.IdPerson);
			modelBuilder.Entity<Portfolio>()
			.HasOne(p => p.Curator)
			.WithMany(t => t.Portfolios)
			.HasForeignKey(st => st.IdCurator);
			modelBuilder.Entity<Curator>()
			.HasOne(p => p.Person)
			.WithMany(t => t.Curators)
			.HasForeignKey(st => st.PersonIdPerson);
			//.HasForeignKey(st => st.IdSGH);	
			//modelBuilder.Entity<Attendance>()
			//.HasOne(p => p.ExactClass)
			//.WithMany(t => t.Attendances)
			//.HasForeignKey(st => st.ExactClassIdClass);
			modelBuilder.Entity<Attendance>()
			.HasOne(p => p.TypeAttedance)
			.WithMany(t => t.Attendances)
			.HasForeignKey(st => st.TypeAttedanceIdTA);
			modelBuilder.Entity<User>()
			.HasOne(p => p.Role)
			.WithMany(t => t.Users)
			.HasForeignKey(st => st.Roleid_role);
			modelBuilder.Entity<Attendance>()
			.HasOne(p => p.ExactClass)
			.WithMany(t => t.Attendances)
			.HasForeignKey(st => st.ExactClassIdClass);
			modelBuilder.Entity<DraftTimeTable>()
			.HasOne(p => p.StudyYear)
			.WithMany(t => t.DraftTimeTables)
			.HasForeignKey(st => st.StudyYearIdStudyYear);
			modelBuilder.Entity<StudentsGroupHistory>()
			.HasOne(p => p.Course)
			.WithMany(t => t.StudentsGroupHistories)
			.HasForeignKey(st => st.CourseIdCourse);
			modelBuilder.Entity<StudentsGroupHistory>()
			.HasOne(p => p.Group)
			.WithMany(t => t.StudentsGroupHistories)
			.HasForeignKey(st => st.GroupIdGroup);
			//	modelBuilder.Entity<StudentsGroupHistory>()
			//.HasOne(p => p.ConditionOfPerson)
			//.WithMany(t => t.StudentsGroupHistories)
			//.HasForeignKey(st => st.ConditionOfPersonIdConditionOfPerson);



			modelBuilder.Entity<StudentsGroupHistory>()
			.HasOne(p => p.Student)
			.WithMany(t => t.StudentsGroupHistories)
			.HasForeignKey(st => st.IdStudent);
			modelBuilder.Entity<StudentsGroupHistory>()
			.HasOne(p => p.ConditionOfPerson)
			.WithMany(t => t.StudentsGroupHistories)
			.HasForeignKey(st => st.ConditionOfPersonIdConditionOfPerson);
			//modelBuilder.Entity<ExactClass>()
			//.HasOne(p => p.ExactClassForLecturerClass)
			//.WithMany(t => t.ExactClasses)
			//.HasForeignKey(st => st.ExactClassForLecturerClass.IdEXCFLC);	
			//modelBuilder.Entity<ExactClass>()
			//.HasOne(p => p.SubjectForGroup)
			//.WithMany(t => t.ExactClasses)
			//.HasForeignKey(st => st.IdSFG);
			//modelBuilder.Entity<ClassWork>()
			//.HasOne(p => p.ExactClass)
			//.WithMany(t => t.ClassWorks)
			//.HasForeignKey(st => st.IdClassWork);
			//данные для расписания
			#region SubjectForGroup
			modelBuilder.Entity<SubjectForGroup>()
			.HasOne(p => p.Person)
			.WithMany(t => t.SubjectsForGroup)
			.HasForeignKey(st => st.IdPerson);
			modelBuilder.Entity<SubjectForGroup>()
			.HasOne(p => p.DraftTimeTable)
			.WithMany(t => t.SubjectsForGroup)
			.HasForeignKey(st => st.DraftTimeTableIdDFTT);
			modelBuilder.Entity<SubjectForGroup>()
			.HasOne(p => p.Group)
			.WithMany(t => t.SubjectForGroups)
			.HasForeignKey(st => st.IdGroup);
			modelBuilder.Entity<SubjectForGroup>()
			.HasOne(p => p.Subject)
			.WithMany(t => t.SubjectForGroups)
			.HasForeignKey(st => st.IdSubject);
			modelBuilder.Entity<SubjectForGroup>()
			.HasOne(p => p.Department)
			.WithMany(t => t.SubjectForGroups)
			.HasForeignKey(st => st.DepartmentID);
			modelBuilder.Entity<SubjectForGroup>()
			.HasOne(p => p.Course)
			.WithMany(t => t.SubjectForGroups)
			.HasForeignKey(st => st.IdCourse);
			modelBuilder.Entity<SubjectForGroup>()
			.HasOne(p => p.StudyPlanRecord)
			.WithMany(t => t.SubjectForGroups)
			.HasForeignKey(st => st.IdStudyPlan);
			modelBuilder.Entity<SubjectForGroup>()
			.HasOne(p => p.Person)
			.WithMany(t => t.SubjectsForGroup)
			.HasForeignKey(st => st.IdPerson);
			modelBuilder.Entity<SubjectForGroup>()
			.HasOne(p => p.TypeStudy)
			.WithMany(t => t.SubjectsForGroup)
			.HasForeignKey(st => st.TypeStudyIdTS);

			//modelBuilder.Entity<SubjectForGroup>()
			//.HasOne(p => p.Group)
			//.WithMany(t => t.SubjectForGroups)
			//.HasForeignKey(st => st.IdGroup);


			#endregion
			modelBuilder.Entity<Student>()
			.HasOne(p => p.Person)
			.WithMany(t => t.Students)
			.HasForeignKey(st => st.IdPerson);
			modelBuilder.Entity<ClassWork>()
			.HasOne(p => p.WorkType)
			.WithMany(t => t.ClassWorks)
			.HasForeignKey(st => st.IdWT);

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
