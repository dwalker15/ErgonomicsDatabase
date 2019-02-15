using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ErgonomicsDatabase.Models
{
    public partial class PrototypeDatabaseContext : DbContext
    {
        public PrototypeDatabaseContext()
        {
        }

        public PrototypeDatabaseContext(DbContextOptions<PrototypeDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAction> TAction { get; set; }
        public virtual DbSet<TDimension> TDimension { get; set; }
        public virtual DbSet<TFile> TFile { get; set; }
        public virtual DbSet<TFileType> TFileType { get; set; }
        public virtual DbSet<TForce> TForce { get; set; }
        public virtual DbSet<TForceType> TForceType { get; set; }
        public virtual DbSet<THand> THand { get; set; }
        public virtual DbSet<THandedness> THandedness { get; set; }
        public virtual DbSet<TObjectHandle> TObjectHandle { get; set; }
        public virtual DbSet<TObjectHandleMeasurements> TObjectHandleMeasurements { get; set; }
        public virtual DbSet<TObjectHandlePhoto> TObjectHandlePhoto { get; set; }
        public virtual DbSet<TPosture> TPosture { get; set; }
        public virtual DbSet<TPosturePhoto> TPosturePhoto { get; set; }
        public virtual DbSet<TProcedure> TProcedure { get; set; }
        public virtual DbSet<TRotationAxis> TRotationAxis { get; set; }
        public virtual DbSet<TStrengthData> TStrengthData { get; set; }
        public virtual DbSet<TStudy> TStudy { get; set; }
        public virtual DbSet<TStudySubject> TStudySubject { get; set; }
        public virtual DbSet<TSubject> TSubject { get; set; }
        public virtual DbSet<TUnit> TUnit { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:prototypetestserver.database.windows.net,1433;Initial Catalog=Prototype Database;Persist Security Info=False;User ID=djw0017;Password=Djdwa35393696!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<TAction>(entity =>
            {
                entity.HasKey(e => e.IActionId);

                entity.ToTable("tAction");

                entity.Property(e => e.IActionId).HasColumnName("iActionID");

                entity.Property(e => e.IForceId).HasColumnName("iForceID");

                entity.Property(e => e.IHandednessId).HasColumnName("iHandednessID");

                entity.Property(e => e.IObjectHandleId).HasColumnName("iObjectHandleID");

                entity.Property(e => e.IPostureId).HasColumnName("iPostureID");

                entity.Property(e => e.IProcedureId).HasColumnName("iProcedureID");

                entity.HasOne(d => d.IForce)
                    .WithMany(p => p.TAction)
                    .HasForeignKey(d => d.IForceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tAction_tForce");

                entity.HasOne(d => d.IHandedness)
                    .WithMany(p => p.TAction)
                    .HasForeignKey(d => d.IHandednessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tAction_tHandedness");

                entity.HasOne(d => d.IObjectHandle)
                    .WithMany(p => p.TAction)
                    .HasForeignKey(d => d.IObjectHandleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tAction_tObjectHandle");

                entity.HasOne(d => d.IPosture)
                    .WithMany(p => p.TAction)
                    .HasForeignKey(d => d.IPostureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tAction_tPosture");

                entity.HasOne(d => d.IProcedure)
                    .WithMany(p => p.TAction)
                    .HasForeignKey(d => d.IProcedureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tAction_tProcedure");
            });

            modelBuilder.Entity<TDimension>(entity =>
            {
                entity.HasKey(e => e.IDimensionId);

                entity.ToTable("tDimension");

                entity.Property(e => e.IDimensionId).HasColumnName("iDimensionID");

                entity.Property(e => e.VcDimension)
                    .IsRequired()
                    .HasColumnName("vcDimension")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TFile>(entity =>
            {
                entity.HasKey(e => e.IFileId);

                entity.ToTable("tFile");

                entity.Property(e => e.IFileId).HasColumnName("iFileID");

                entity.Property(e => e.BArchived).HasColumnName("bArchived");

                entity.Property(e => e.IFileTypeId).HasColumnName("iFileTypeID");

                entity.Property(e => e.VcFileName)
                    .IsRequired()
                    .HasColumnName("vcFileName")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.VcFilePath)
                    .IsRequired()
                    .HasColumnName("vcFilePath")
                    .IsUnicode(false);

                entity.HasOne(d => d.IFileType)
                    .WithMany(p => p.TFile)
                    .HasForeignKey(d => d.IFileTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tFile_tFileType");
            });

            modelBuilder.Entity<TFileType>(entity =>
            {
                entity.HasKey(e => e.IFileTypeId);

                entity.ToTable("tFileType");

                entity.Property(e => e.IFileTypeId)
                    .HasColumnName("iFileTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.VcFileType)
                    .IsRequired()
                    .HasColumnName("vcFileType")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TForce>(entity =>
            {
                entity.HasKey(e => e.IForceId);

                entity.ToTable("tForce");

                entity.Property(e => e.IForceId).HasColumnName("iForceID");

                entity.Property(e => e.IForceTypeId).HasColumnName("iForceTypeID");

                entity.HasOne(d => d.IForceType)
                    .WithMany(p => p.TForce)
                    .HasForeignKey(d => d.IForceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tForce_tForceType");
            });

            modelBuilder.Entity<TForceType>(entity =>
            {
                entity.HasKey(e => e.IForceTypeId);

                entity.ToTable("tForceType");

                entity.Property(e => e.IForceTypeId).HasColumnName("iForceTypeID");

                entity.Property(e => e.VcForce)
                    .IsRequired()
                    .HasColumnName("vcForce")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<THand>(entity =>
            {
                entity.HasKey(e => e.IHandId);

                entity.ToTable("tHand");

                entity.Property(e => e.IHandId).HasColumnName("iHandID");

                entity.Property(e => e.VcHand)
                    .IsRequired()
                    .HasColumnName("vcHand")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<THandedness>(entity =>
            {
                entity.HasKey(e => e.IHandednessId);

                entity.ToTable("tHandedness");

                entity.Property(e => e.IHandednessId).HasColumnName("iHandednessID");

                entity.Property(e => e.BIsDominant).HasColumnName("bIsDominant");

                entity.Property(e => e.IHandId).HasColumnName("iHandID");

                entity.HasOne(d => d.IHand)
                    .WithMany(p => p.THandedness)
                    .HasForeignKey(d => d.IHandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tHandedness_tHand");
            });

            modelBuilder.Entity<TObjectHandle>(entity =>
            {
                entity.HasKey(e => e.IObjectHandleId);

                entity.ToTable("tObjectHandle");

                entity.Property(e => e.IObjectHandleId).HasColumnName("iObjectHandleID");

                entity.Property(e => e.TiRotationAxisId).HasColumnName("tiRotationAxisID");

                entity.Property(e => e.VcObjectHandle)
                    .IsRequired()
                    .HasColumnName("vcObjectHandle")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.TiRotationAxis)
                    .WithMany(p => p.TObjectHandle)
                    .HasForeignKey(d => d.TiRotationAxisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tObjectHandle_tRotationAxis");
            });

            modelBuilder.Entity<TObjectHandleMeasurements>(entity =>
            {
                entity.HasKey(e => e.BiObjectHandleMeasurementsId);

                entity.ToTable("tObjectHandleMeasurements");

                entity.Property(e => e.BiObjectHandleMeasurementsId)
                    .HasColumnName("biObjectHandleMeasurementsID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IDimensionId).HasColumnName("iDimensionID");

                entity.Property(e => e.IMeasurement).HasColumnName("iMeasurement");

                entity.Property(e => e.IObjectHandleId).HasColumnName("iObjectHandleID");

                entity.Property(e => e.IUnitId).HasColumnName("iUnitID");

                entity.HasOne(d => d.IDimension)
                    .WithMany(p => p.TObjectHandleMeasurements)
                    .HasForeignKey(d => d.IDimensionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tObjectHandleMeasurements_tDimension");

                entity.HasOne(d => d.IObjectHandle)
                    .WithMany(p => p.TObjectHandleMeasurements)
                    .HasForeignKey(d => d.IObjectHandleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tObjectHandleMeasurements_tObjectHandle");

                entity.HasOne(d => d.IUnit)
                    .WithMany(p => p.TObjectHandleMeasurements)
                    .HasForeignKey(d => d.IUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tObjectHandleMeasurements_tUnit1");
            });

            modelBuilder.Entity<TObjectHandlePhoto>(entity =>
            {
                entity.HasKey(e => e.IObjectHandlePhotoId)
                    .HasName("PK__tObjectH__6266271E62ED2870");

                entity.ToTable("tObjectHandlePhoto");

                entity.Property(e => e.IObjectHandlePhotoId)
                    .HasColumnName("iObjectHandlePhotoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IFileId).HasColumnName("iFileID");

                entity.Property(e => e.IObjectHandleId).HasColumnName("iObjectHandleID");

                entity.HasOne(d => d.IFile)
                    .WithMany(p => p.TObjectHandlePhoto)
                    .HasForeignKey(d => d.IFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tObjectHandlePhoto_tFile");
            });

            modelBuilder.Entity<TPosture>(entity =>
            {
                entity.HasKey(e => e.IPostureId);

                entity.ToTable("tPosture");

                entity.Property(e => e.IPostureId).HasColumnName("iPostureID");

                entity.Property(e => e.VcPostureDetails)
                    .IsRequired()
                    .HasColumnName("vcPostureDetails")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TPosturePhoto>(entity =>
            {
                entity.HasKey(e => e.IPosturePhotoId);

                entity.ToTable("tPosturePhoto");

                entity.Property(e => e.IPosturePhotoId).HasColumnName("iPosturePhotoID");

                entity.Property(e => e.IFileId).HasColumnName("iFileID");

                entity.Property(e => e.IPostureId).HasColumnName("iPostureID");

                entity.HasOne(d => d.IFile)
                    .WithMany(p => p.TPosturePhoto)
                    .HasForeignKey(d => d.IFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tPosturePhoto_tFile");

                entity.HasOne(d => d.IPosture)
                    .WithMany(p => p.TPosturePhoto)
                    .HasForeignKey(d => d.IPostureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tPosturePhoto_tPosture");
            });

            modelBuilder.Entity<TProcedure>(entity =>
            {
                entity.HasKey(e => e.IProcedureId);

                entity.ToTable("tProcedure");

                entity.Property(e => e.IProcedureId).HasColumnName("iProcedureID");

                entity.Property(e => e.VcProcedure)
                    .IsRequired()
                    .HasColumnName("vcProcedure")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TRotationAxis>(entity =>
            {
                entity.HasKey(e => e.TiRotationAxisId)
                    .HasName("PK__Rotation__39962B91C6705B8F");

                entity.ToTable("tRotationAxis");

                entity.Property(e => e.TiRotationAxisId).HasColumnName("tiRotationAxisID");

                entity.Property(e => e.VcRotationAxis)
                    .IsRequired()
                    .HasColumnName("vcRotationAxis")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TStrengthData>(entity =>
            {
                entity.HasKey(e => e.IStrengthDataId);

                entity.ToTable("tStrengthData");

                entity.Property(e => e.IStrengthDataId).HasColumnName("iStrengthDataID");

                entity.Property(e => e.FMeanFemale).HasColumnName("fMeanFemale");

                entity.Property(e => e.FMeanMale).HasColumnName("fMeanMale");

                entity.Property(e => e.FSdfemale).HasColumnName("fSDFemale");

                entity.Property(e => e.FSdmale).HasColumnName("fSDMale");
            });

            modelBuilder.Entity<TStudy>(entity =>
            {
                entity.HasKey(e => e.IStudyId);

                entity.ToTable("tStudy");

                entity.Property(e => e.IStudyId).HasColumnName("iStudyID");

                entity.Property(e => e.BArchived).HasColumnName("bArchived");

                entity.Property(e => e.DtStudyYear)
                    .HasColumnName("dtStudyYear")
                    .HasColumnType("datetime");

                entity.Property(e => e.IActionId).HasColumnName("iActionID");

                entity.Property(e => e.IStrengthDataId).HasColumnName("iStrengthDataID");

                entity.Property(e => e.IStudyFileId).HasColumnName("iStudyFileID");

                entity.Property(e => e.VcSource)
                    .IsRequired()
                    .HasColumnName("vcSource")
                    .IsUnicode(false);

                entity.HasOne(d => d.IAction)
                    .WithMany(p => p.TStudy)
                    .HasForeignKey(d => d.IActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tStudy_tAction");

                entity.HasOne(d => d.IStrengthData)
                    .WithMany(p => p.TStudy)
                    .HasForeignKey(d => d.IStrengthDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tStudy_tStrengthData");
            });

            modelBuilder.Entity<TStudySubject>(entity =>
            {
                entity.HasKey(e => e.IStudySubjectId);

                entity.ToTable("tStudySubject");

                entity.Property(e => e.IStudySubjectId).HasColumnName("iStudySubjectID");

                entity.Property(e => e.IStudyId).HasColumnName("iStudyID");

                entity.Property(e => e.ISubjectId).HasColumnName("iSubjectID");

                entity.HasOne(d => d.IStudy)
                    .WithMany(p => p.TStudySubject)
                    .HasForeignKey(d => d.IStudyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tStudySubject_tStudy");

                entity.HasOne(d => d.ISubject)
                    .WithMany(p => p.TStudySubject)
                    .HasForeignKey(d => d.ISubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tStudySubject_tSubject");
            });

            modelBuilder.Entity<TSubject>(entity =>
            {
                entity.HasKey(e => e.ISubjectId)
                    .HasName("PK__tSubject__6898CD5F6E734D56");

                entity.ToTable("tSubject");

                entity.Property(e => e.ISubjectId)
                    .HasColumnName("iSubjectID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TiFemaleSubjectCount).HasColumnName("tiFemaleSubjectCount");

                entity.Property(e => e.TiMaleSubjectCount).HasColumnName("tiMaleSubjectCount");

                entity.Property(e => e.TiSubjectAgeRangeBegin).HasColumnName("tiSubjectAgeRangeBegin");

                entity.Property(e => e.TiSubjectAgeRangeEnd).HasColumnName("tiSubjectAgeRangeEnd");

                entity.Property(e => e.VcSubjectDescription)
                    .IsRequired()
                    .HasColumnName("vcSubjectDescription")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUnit>(entity =>
            {
                entity.HasKey(e => e.IUnitId);

                entity.ToTable("tUnit");

                entity.Property(e => e.IUnitId).HasColumnName("iUnitID");

                entity.Property(e => e.VcUnit)
                    .IsRequired()
                    .HasColumnName("vcUnit")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.IUserId)
                    .HasName("PK__tUser__BA95FFD11CDDEB42");

                entity.ToTable("tUser");

                entity.Property(e => e.IUserId)
                    .HasColumnName("iUserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BArchived).HasColumnName("bArchived");

                entity.Property(e => e.VcEmailAddress)
                    .IsRequired()
                    .HasColumnName("vcEmailAddress")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.VcPassword)
                    .IsRequired()
                    .HasColumnName("vcPassword")
                    .IsUnicode(false);

                entity.Property(e => e.VcUsername)
                    .IsRequired()
                    .HasColumnName("vcUsername")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });
        }
    }
}
