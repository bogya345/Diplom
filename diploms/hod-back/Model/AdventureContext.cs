using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace hod_back.Model
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
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
        public virtual DbSet<KafTeacher> KafTeachers { get; set; }
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
        public virtual DbSet<TeacherLoad> TeacherLoads { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkType> WorkTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost,1402;Initial Catalog=hod;Persist Security Info=True;User ID=SA;Password=P@ssword_ugtu");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AcademicPlan>(entity =>
            {
                entity.HasKey(e => e.AcPlanId)
                    .HasName("PK__Academic__BE4F597BAD387297");

                entity.Property(e => e.AcPlanId).ValueGeneratedNever();

                entity.HasOne(d => d.Direct)
                    .WithMany(p => p.AcademicPlans)
                    .HasForeignKey(d => d.DirectId)
                    .HasConstraintName("AcademicPlan_directions");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AcademicPlans)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("AcademicPlan_groups");
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToView("AuthUsers");

                entity.Property(e => e.UserLogin).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);
            });

            modelBuilder.Entity<BlockRec>(entity =>
            {
                entity.HasOne(d => d.AcPlan)
                    .WithMany(p => p.BlockRecs)
                    .HasForeignKey(d => d.AcPlanId)
                    .HasConstraintName("BlockRecs_academPlans");

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.BlockRecs)
                    .HasForeignKey(d => d.SubId)
                    .HasConstraintName("BlockRecs_subject");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.HasKey(e => e.DegId)
                    .HasName("PK__Degrees__2EB5580CF22095CB");

                entity.Property(e => e.DegId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepGuid)
                    .HasName("PK__Departme__E69BD0869DE39450");

                entity.Property(e => e.DepGuid).ValueGeneratedNever();

                entity.HasOne(d => d.DepType)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DepTypeId)
                    .HasConstraintName("Departments_depType");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("Departments_role");
            });

            modelBuilder.Entity<DepartmentType>(entity =>
            {
                entity.HasKey(e => e.DepTypeId)
                    .HasName("PK__Departme__DD1BF756E81B87B1");

                entity.Property(e => e.DepTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.DirectId)
                    .HasName("PK__Directio__F9DF14F11730A487");

                entity.Property(e => e.DirectId).ValueGeneratedNever();

                entity.HasOne(d => d.EducBr)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.EducBrId)
                    .HasConstraintName("Direction_educBranches");

                entity.HasOne(d => d.EducForm)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.EducFormId)
                    .HasConstraintName("Direction_educForms");

                entity.HasOne(d => d.Fac)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.FacId)
                    .HasConstraintName("Direction_facs");

                entity.HasOne(d => d.KatZaved)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.KatZavedId)
                    .HasConstraintName("Direction_katZaved");
            });

            modelBuilder.Entity<DirectionFgo>(entity =>
            {
                entity.HasOne(d => d.Direct)
                    .WithMany()
                    .HasForeignKey(d => d.DirectId)
                    .HasConstraintName("Direction_fgos_direction");

                entity.HasOne(d => d.Fgos)
                    .WithMany()
                    .HasForeignKey(d => d.FgosId)
                    .HasConstraintName("Direction_fgos_fgos");

                entity.HasOne(d => d.Unit)
                    .WithMany()
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("Direction_fgos_units");
            });

            modelBuilder.Entity<DirectionGroup>(entity =>
            {
                entity.ToView("DirectionGroup", "own");
            });

            modelBuilder.Entity<EducBranch>(entity =>
            {
                entity.HasKey(e => e.EducBrId)
                    .HasName("PK__EducBran__73C93C439ADFCB2A");

                entity.Property(e => e.EducBrId).ValueGeneratedNever();

                entity.HasOne(d => d.EducLvl)
                    .WithMany(p => p.EducBranches)
                    .HasForeignKey(d => d.EducLvlId)
                    .HasConstraintName("EducBranch_educLevel");
            });

            modelBuilder.Entity<EducDoc>(entity =>
            {
                entity.Property(e => e.EducDocId).ValueGeneratedNever();

                entity.HasOne(d => d.EducDocType)
                    .WithMany(p => p.EducDocs)
                    .HasForeignKey(d => d.EducDocTypeId)
                    .HasConstraintName("EducDocs_educDocType");
            });

            modelBuilder.Entity<EducDocType>(entity =>
            {
                entity.Property(e => e.EducDocTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<EducForm>(entity =>
            {
                entity.Property(e => e.EducFormId).ValueGeneratedNever();
            });

            modelBuilder.Entity<EducLevel>(entity =>
            {
                entity.HasKey(e => e.EducLvlId)
                    .HasName("PK__EducLeve__591A08E72B913E7C");

                entity.Property(e => e.EducLvlId).ValueGeneratedNever();
            });

            modelBuilder.Entity<EmpDegree>(entity =>
            {
                entity.HasKey(e => e.EducDocId)
                    .HasName("PK__EmpDegre__30B8CFA90836A097");

                entity.Property(e => e.EducDocId).ValueGeneratedNever();

                entity.Property(e => e.DiplWhere).IsUnicode(false);

                entity.Property(e => e.DissertCouncil).IsUnicode(false);

                entity.HasOne(d => d.Deg)
                    .WithMany(p => p.EmpDegrees)
                    .HasForeignKey(d => d.DegId)
                    .HasConstraintName("EmpDegree_degrees");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpDegrees)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("EmpDegree_employee");

                entity.HasOne(d => d.ListSpec)
                    .WithMany(p => p.EmpDegrees)
                    .HasForeignKey(d => d.ListSpecId)
                    .HasConstraintName("EmpDegree_listSpecialities");

                entity.HasOne(d => d.SciType)
                    .WithMany(p => p.EmpDegrees)
                    .HasForeignKey(d => d.SciTypeId)
                    .HasConstraintName("EmpDegree_scienceType");
            });

            modelBuilder.Entity<EmpEducDoc>(entity =>
            {
                entity.HasOne(d => d.EducDoc)
                    .WithMany()
                    .HasForeignKey(d => d.EducDocId)
                    .HasConstraintName("EmpEducDocs_educDocs");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("EmpEducDocs_employees");
            });

            modelBuilder.Entity<EmpRank>(entity =>
            {
                entity.HasOne(d => d.Rank)
                    .WithMany()
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("EmpRanks_rank");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__1299A8613289BA77");

                entity.Property(e => e.EmpId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Fac>(entity =>
            {
                entity.Property(e => e.FacId).ValueGeneratedNever();

                entity.HasOne(d => d.DepGu)
                    .WithMany(p => p.Facs)
                    .HasForeignKey(d => d.DepGuid)
                    .HasConstraintName("Facs_department");
            });

            modelBuilder.Entity<FactStaffHistory>(entity =>
            {
                entity.HasKey(e => e.FshId)
                    .HasName("PK__FactStaf__E8D3134483186887");

                entity.Property(e => e.FshId).ValueGeneratedNever();

                entity.HasOne(d => d.WorkType)
                    .WithMany(p => p.FactStaffHistories)
                    .HasForeignKey(d => d.WorkTypeId)
                    .HasConstraintName("FactStaffHistories_typeWork");
            });

            modelBuilder.Entity<FgosRequir>(entity =>
            {
                entity.HasKey(e => e.FgosId)
                    .HasName("PK__fgos_req__5257782818C6E5DE");

                entity.Property(e => e.FgosId).ValueGeneratedNever();
            });

            modelBuilder.Entity<FgosrequiresToDirection>(entity =>
            {
                entity.ToView("FGOSRequiresToDirections");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupId).ValueGeneratedNever();

                entity.HasOne(d => d.Direct)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.DirectId)
                    .HasConstraintName("Groups_directions");
            });

            modelBuilder.Entity<KafTeacher>(entity =>
            {
                entity.HasKey(e => e.FshId)
                    .HasName("PK__KafTeach__E8D313448C70B7CC");

                entity.Property(e => e.FshId).ValueGeneratedNever();

                entity.Property(e => e.Login).IsUnicode(false);
            });

            modelBuilder.Entity<KatZaved>(entity =>
            {
                entity.Property(e => e.KatZavedId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ListSpeciality>(entity =>
            {
                entity.HasKey(e => e.ListSpecId)
                    .HasName("PK__ListSpec__5F2A281181635914");

                entity.Property(e => e.ListSpecId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Load>(entity =>
            {
                entity.ToView("Loads");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).ValueGeneratedNever();

                entity.HasOne(d => d.PostType)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostTypeId)
                    .HasConstraintName("Posts_postTypes");
            });

            modelBuilder.Entity<PostType>(entity =>
            {
                entity.Property(e => e.PostTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.Property(e => e.RankId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName).IsUnicode(false);
            });

            modelBuilder.Entity<ScienceType>(entity =>
            {
                entity.HasKey(e => e.SciTypeId)
                    .HasName("PK__ScienceT__4647A8BD37497B2A");

                entity.Property(e => e.SciTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubId)
                    .HasName("PK__Subjects__694106B0AD0ED5B6");

                entity.Property(e => e.SubId).ValueGeneratedNever();
            });

            modelBuilder.Entity<SubjectType>(entity =>
            {
                entity.HasKey(e => e.SubTypeId)
                    .HasName("PK__SubjectT__574E8472F968BBE6");

                entity.Property(e => e.SubTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TeacherInfo>(entity =>
            {
                entity.ToView("TeacherInfo");
            });

            modelBuilder.Entity<TeacherLoad>(entity =>
            {
                entity.HasKey(e => e.TeachLoadId)
                    .HasName("PK__TeacherL__AF77714DB7CEF881");

                entity.Property(e => e.TeachLoadId).ValueGeneratedNever();

                entity.HasOne(d => d.BlocRec)
                    .WithMany(p => p.TeacherLoads)
                    .HasForeignKey(d => d.BlocRecId)
                    .HasConstraintName("TeacherLoads_blockRec");

                entity.HasOne(d => d.Fsh)
                    .WithMany(p => p.TeacherLoads)
                    .HasForeignKey(d => d.FshId)
                    .HasConstraintName("TeacherLoads_fsh");

                entity.HasOne(d => d.SubType)
                    .WithMany(p => p.TeacherLoads)
                    .HasForeignKey(d => d.SubTypeId)
                    .HasConstraintName("TeacherLoads_subTypes");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.UnitId).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserLogin).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.HasOne(d => d.Fsh)
                    .WithMany()
                    .HasForeignKey(d => d.FshId)
                    .HasConstraintName("Users_kafTeachers");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("Users_roles");
            });

            modelBuilder.Entity<WorkType>(entity =>
            {
                entity.Property(e => e.WorkTypeId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
