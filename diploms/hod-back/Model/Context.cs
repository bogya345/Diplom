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

        public virtual DbSet<AcPlan> AcPlans { get; set; }
        public virtual DbSet<AcPlanDep> AcPlanDeps { get; set; }
        public virtual DbSet<ApplyType> ApplyTypes { get; set; }
        public virtual DbSet<AttachedAcPlan> AttachedAcPlans { get; set; }
        public virtual DbSet<AuthUser> AuthUsers { get; set; }
        public virtual DbSet<BlockNum> BlockNums { get; set; }
        public virtual DbSet<BlockRec> BlockRecs { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<DepDirFac> DepDirFacs { get; set; }
        public virtual DbSet<DepType> DepTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentLoad> DepartmentLoads { get; set; }
        public virtual DbSet<DepsInfo> DepsInfos { get; set; }
        public virtual DbSet<DirFgo> DirFgos { get; set; }
        public virtual DbSet<DirGroup> DirGroups { get; set; }
        public virtual DbSet<DirRequir> DirRequirs { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
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
        public virtual DbSet<FactStaff> FactStaffs { get; set; }
        public virtual DbSet<FactStaffsHistory> FactStaffsHistories { get; set; }
        public virtual DbSet<FgosRequir> FgosRequirs { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<KatZaved> KatZaveds { get; set; }
        public virtual DbSet<ListSpeciality> ListSpecialities { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<PlanStaff> PlanStaffs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostType> PostTypes { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ScienceType> ScienceTypes { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectType> SubjectTypes { get; set; }
        public virtual DbSet<TeacherDep> TeacherDeps { get; set; }
        public virtual DbSet<TeacherEducDoc> TeacherEducDocs { get; set; }
        public virtual DbSet<TeacherLoadSuitability> TeacherLoadSuitabilities { get; set; }
        public virtual DbSet<TeacherLoadsView> TeacherLoadsViews { get; set; }
        public virtual DbSet<TeacherRate> TeacherRates { get; set; }
        public virtual DbSet<TeacherSuitability> TeacherSuitabilities { get; set; }
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

            modelBuilder.Entity<AcPlan>(entity =>
            {
                entity.HasKey(e => e.AcPlId)
                    .HasName("PK__AcPlans__5BFF92491FC8360D");
            });

            modelBuilder.Entity<AcPlanDep>(entity =>
            {
                entity.HasKey(e => e.AcPlDepId)
                    .HasName("PK__AcPlanDe__DE0245C6CA2B04EE");

                entity.Property(e => e.AcPlDepId).ValueGeneratedNever();

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.AcPlanDeps)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("AcPlanDeps_department");
            });

            modelBuilder.Entity<ApplyType>(entity =>
            {
                entity.HasKey(e => e.ApplyTId)
                    .HasName("PK__ApplyTyp__4841E18D3CE002E4");

                entity.Property(e => e.ApplyTId).ValueGeneratedNever();
            });

            modelBuilder.Entity<AttachedAcPlan>(entity =>
            {
                entity.HasKey(e => e.AttAcPlId)
                    .HasName("PK__Attached__96BCE5867F77FF6E");

                entity.HasOne(d => d.BlockRec)
                    .WithMany(p => p.AttachedAcPlans)
                    .HasForeignKey(d => d.BlockRecId)
                    .HasConstraintName("BlockRecs_blockRec");

                entity.HasOne(d => d.FshId1Navigation)
                    .WithMany(p => p.AttachedAcPlanFshId1Navigations)
                    .HasForeignKey(d => d.FshId1)
                    .HasConstraintName("BlockRecs_factStaffsHistory");

                entity.HasOne(d => d.FshId2Navigation)
                    .WithMany(p => p.AttachedAcPlanFshId2Navigations)
                    .HasForeignKey(d => d.FshId2)
                    .HasConstraintName("BlockRecs_factStaffsHistory2");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AttachedAcPlans)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("BlockRecs_group");

                entity.HasOne(d => d.SubT)
                    .WithMany(p => p.AttachedAcPlans)
                    .HasForeignKey(d => d.SubTId)
                    .HasConstraintName("BlockRecs_subjectType");
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToView("AuthUsers", "Auth");

                entity.Property(e => e.UserLogin).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);
            });

            modelBuilder.Entity<BlockRec>(entity =>
            {
                entity.HasOne(d => d.AcPl)
                    .WithMany(p => p.BlockRecs)
                    .HasForeignKey(d => d.AcPlId)
                    .HasConstraintName("BlockRecs_acPlan");

                entity.HasOne(d => d.BlockNum)
                    .WithMany(p => p.BlockRecs)
                    .HasForeignKey(d => d.BlockNumId)
                    .HasConstraintName("BlockRecs_blockNum");

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.BlockRecs)
                    .HasForeignKey(d => d.SubId)
                    .HasConstraintName("BlockRecs_subject");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.HasKey(e => e.DegId)
                    .HasName("PK__Degrees__2EB5580CBDDE0574");

                entity.Property(e => e.DegId).ValueGeneratedNever();
            });

            modelBuilder.Entity<DepDirFac>(entity =>
            {
                entity.ToView("DepDirFac");

                entity.Property(e => e.StartYear).IsUnicode(false);
            });

            modelBuilder.Entity<DepType>(entity =>
            {
                entity.HasKey(e => e.DepTId)
                    .HasName("PK__DepTypes__C699243F8A6C8700");

                entity.Property(e => e.DepTId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__Departme__BB4BD8F82D6A44DC");

                entity.Property(e => e.DepId).ValueGeneratedNever();

                entity.HasOne(d => d.DepT)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DepTId)
                    .HasConstraintName("Departments_depType");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("Departments_role");
            });

            modelBuilder.Entity<DepartmentLoad>(entity =>
            {
                entity.ToView("DepartmentLoads");

                entity.Property(e => e.StartYear).IsUnicode(false);
            });

            modelBuilder.Entity<DepsInfo>(entity =>
            {
                entity.ToView("DepsInfo");
            });

            modelBuilder.Entity<DirFgo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Dir)
                    .WithMany(p => p.DirFgos)
                    .HasForeignKey(d => d.DirId)
                    .HasConstraintName("DirFgos_direction");

                entity.HasOne(d => d.Fgos)
                    .WithMany(p => p.DirFgos)
                    .HasForeignKey(d => d.FgosId)
                    .HasConstraintName("DirFgos_fgosRequirs");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.DirFgos)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("DirFgos_unit");
            });

            modelBuilder.Entity<DirGroup>(entity =>
            {
                entity.ToView("DirGroups");
            });

            modelBuilder.Entity<DirRequir>(entity =>
            {
                entity.ToView("DirRequirs");

                entity.Property(e => e.StartYear).IsUnicode(false);
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.DirId)
                    .HasName("PK__Directio__D886CF4CE4D2F44B");

                entity.Property(e => e.DirId).ValueGeneratedNever();

                entity.Property(e => e.StartYear).IsUnicode(false);

                entity.HasOne(d => d.AcPl)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.AcPlId)
                    .HasConstraintName("Directions_acPlan");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("Directions_directions");

                entity.HasOne(d => d.EBr)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.EBrId)
                    .HasConstraintName("Directions_educBranch");

                entity.HasOne(d => d.EForm)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.EFormId)
                    .HasConstraintName("Directions_educForm");

                entity.HasOne(d => d.Fac)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.FacId)
                    .HasConstraintName("Directions_fac");

                entity.HasOne(d => d.KZav)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.KZavId)
                    .HasConstraintName("Directions_katZaved");
            });

            modelBuilder.Entity<EducBranch>(entity =>
            {
                entity.HasKey(e => e.EBrId)
                    .HasName("PK__EducBran__6A897236DCC4E716");

                entity.Property(e => e.EBrId).ValueGeneratedNever();

                entity.HasOne(d => d.ELvl)
                    .WithMany(p => p.EducBranches)
                    .HasForeignKey(d => d.ELvlId)
                    .HasConstraintName("EducBranches_educLevel");
            });

            modelBuilder.Entity<EducDoc>(entity =>
            {
                entity.HasKey(e => e.EDocId)
                    .HasName("PK__EducDocs__5B6D943A1CA01747");

                entity.Property(e => e.EDocId).ValueGeneratedNever();

                entity.HasOne(d => d.EDocT)
                    .WithMany(p => p.EducDocs)
                    .HasForeignKey(d => d.EDocTId)
                    .HasConstraintName("EducDocs_educDocType");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.InverseOrg)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("EducDocs_organization");
            });

            modelBuilder.Entity<EducDocType>(entity =>
            {
                entity.HasKey(e => e.EDocTId)
                    .HasName("PK__EducDocT__BF3D4DDF917C77FF");

                entity.Property(e => e.EDocTId).ValueGeneratedNever();
            });

            modelBuilder.Entity<EducForm>(entity =>
            {
                entity.HasKey(e => e.EFormId)
                    .HasName("PK__EducForm__C39B7D15AB7BC366");

                entity.Property(e => e.EFormId).ValueGeneratedNever();
            });

            modelBuilder.Entity<EducLevel>(entity =>
            {
                entity.HasKey(e => e.ELvlId)
                    .HasName("PK__EducLeve__BB821201C04F7555");

                entity.Property(e => e.ELvlId).ValueGeneratedNever();
            });

            modelBuilder.Entity<EmpDegree>(entity =>
            {
                entity.HasOne(d => d.Deg)
                    .WithMany()
                    .HasForeignKey(d => d.DegId)
                    .HasConstraintName("EmpDegrees_degrees");

                entity.HasOne(d => d.EDoc)
                    .WithMany()
                    .HasForeignKey(d => d.EDocId)
                    .HasConstraintName("EmpDegrees_educDoc");

                entity.HasOne(d => d.ListSpec)
                    .WithMany()
                    .HasForeignKey(d => d.ListSpecId)
                    .HasConstraintName("EmpDegrees_listSpecialities");

                entity.HasOne(d => d.SciT)
                    .WithMany()
                    .HasForeignKey(d => d.SciTId)
                    .HasConstraintName("EmpDegrees_scienceTypes");
            });

            modelBuilder.Entity<EmpEducDoc>(entity =>
            {
                entity.HasOne(d => d.EDoc)
                    .WithMany()
                    .HasForeignKey(d => d.EDocId)
                    .HasConstraintName("EmpEducDocs_educDocs");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("EmpEducDocs_employees");
            });

            modelBuilder.Entity<EmpRank>(entity =>
            {
                entity.HasOne(d => d.EDoc)
                    .WithMany()
                    .HasForeignKey(d => d.EDocId)
                    .HasConstraintName("EmpRanks_educDoc");

                entity.HasOne(d => d.Rank)
                    .WithMany()
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("EmpRanks_rank");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__1299A8617500B104");

                entity.Property(e => e.EmpId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Fac>(entity =>
            {
                entity.Property(e => e.FacId).ValueGeneratedNever();
            });

            modelBuilder.Entity<FactStaff>(entity =>
            {
                entity.HasKey(e => e.FsId)
                    .HasName("PK__FactStaf__E67B2F30D7B8E494");

                entity.Property(e => e.FsId).ValueGeneratedNever();

                entity.HasOne(d => d.ApplyT)
                    .WithMany(p => p.FactStaffs)
                    .HasForeignKey(d => d.ApplyTId)
                    .HasConstraintName("FactStaff_applyType");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.FactStaffs)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FactStaff_employee");

                entity.HasOne(d => d.Ps)
                    .WithMany(p => p.FactStaffs)
                    .HasForeignKey(d => d.PsId)
                    .HasConstraintName("FactStaff_planStaff");

                entity.HasOne(d => d.WorkT)
                    .WithMany(p => p.FactStaffs)
                    .HasForeignKey(d => d.WorkTId)
                    .HasConstraintName("FactStaff_workType");
            });

            modelBuilder.Entity<FactStaffsHistory>(entity =>
            {
                entity.HasKey(e => e.FshId)
                    .HasName("PK__FactStaf__E8D313449B088F28");

                entity.Property(e => e.FshId).ValueGeneratedNever();

                entity.HasOne(d => d.Fs)
                    .WithMany(p => p.FactStaffsHistories)
                    .HasForeignKey(d => d.FsId)
                    .HasConstraintName("FactStaffsHistory_factStaff");

                entity.HasOne(d => d.WorkT)
                    .WithMany(p => p.FactStaffsHistories)
                    .HasForeignKey(d => d.WorkTId)
                    .HasConstraintName("FactStaffsHistory_workType");
            });

            modelBuilder.Entity<FgosRequir>(entity =>
            {
                entity.HasKey(e => e.FgosId)
                    .HasName("PK__FgosRequ__5257782837116523");

                entity.Property(e => e.FgosId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupId).ValueGeneratedNever();

                entity.HasOne(d => d.AcPl)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.AcPlId)
                    .HasConstraintName("Groups_acPlan");

                entity.HasOne(d => d.Dir)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.DirId)
                    .HasConstraintName("Groups_direction");
            });

            modelBuilder.Entity<KatZaved>(entity =>
            {
                entity.HasKey(e => e.KZavId)
                    .HasName("PK__KatZaved__7829778A1C409E9E");

                entity.Property(e => e.KZavId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ListSpeciality>(entity =>
            {
                entity.HasKey(e => e.ListSpecId)
                    .HasName("PK__ListSpec__5F2A2811D2518047");

                entity.Property(e => e.ListSpecId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.OrgId)
                    .HasName("PK__Organiza__F6AD8012000CF9B1");

                entity.Property(e => e.OrgId).ValueGeneratedNever();
            });

            modelBuilder.Entity<PlanStaff>(entity =>
            {
                entity.HasKey(e => e.PsId)
                    .HasName("PK__PlanStaf__5CFD143FA22E2FDD");

                entity.Property(e => e.PsId).ValueGeneratedNever();

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.PlanStaffs)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("PlanStaff_department");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PlanStaffs)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("PlanStaff_post");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).ValueGeneratedNever();

                entity.HasOne(d => d.PostT)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostTId)
                    .HasConstraintName("Posts_postType");
            });

            modelBuilder.Entity<PostType>(entity =>
            {
                entity.HasKey(e => e.PostTId)
                    .HasName("PK__PostType__1B1C66FEF941EF3A");

                entity.Property(e => e.PostTId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.Property(e => e.RankId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ScienceType>(entity =>
            {
                entity.HasKey(e => e.SciTId)
                    .HasName("PK__ScienceT__7C273E25C6E1BC6A");

                entity.Property(e => e.SciTId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubId)
                    .HasName("PK__Subjects__694106B0F7AF68A6");

                entity.HasOne(d => d.AcPlDep)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.AcPlDepId)
                    .HasConstraintName("Subjects_acPlanDep");
            });

            modelBuilder.Entity<SubjectType>(entity =>
            {
                entity.HasKey(e => e.SubTId)
                    .HasName("PK__SubjectT__3ABFCBEF78242733");

                entity.Property(e => e.SubTId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TeacherDep>(entity =>
            {
                entity.ToView("TeacherDeps");
            });

            modelBuilder.Entity<TeacherEducDoc>(entity =>
            {
                entity.ToView("TeacherEducDocs");
            });

            modelBuilder.Entity<TeacherLoadSuitability>(entity =>
            {
                entity.ToView("TeacherLoadSuitability");
            });

            modelBuilder.Entity<TeacherLoadsView>(entity =>
            {
                entity.ToView("TeacherLoadsView");
            });

            modelBuilder.Entity<TeacherRate>(entity =>
            {
                entity.ToView("TeacherRates");
            });

            modelBuilder.Entity<TeacherSuitability>(entity =>
            {
                entity.ToView("TeacherSuitability");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.UnitId).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserLogin).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.HasOne(d => d.Fs)
                    .WithMany()
                    .HasForeignKey(d => d.FsId)
                    .HasConstraintName("Users_factStaff");

                entity.HasOne(d => d.Ps)
                    .WithMany()
                    .HasForeignKey(d => d.PsId)
                    .HasConstraintName("Users_planStaff");
            });

            modelBuilder.Entity<WorkType>(entity =>
            {
                entity.HasKey(e => e.WorkTId)
                    .HasName("PK__WorkType__4CE17D1F44D09DB2");

                entity.Property(e => e.WorkTId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
