using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Accreditation.Models;

public partial class AccreditationContext : DbContext
{
    public AccreditationContext()
    {
    }

    public AccreditationContext(DbContextOptions<AccreditationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccUser> AccUsers { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Fileupload> Fileuploads { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=Accreditation;User ID=sa;Password=1;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__ACC_USER__F3BEEBFFF2DA94ED");

            entity.ToTable("ACC_USER");

            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .HasColumnName("USER_ID");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.Syncoperation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SYNCOPERATION");
            entity.Property(e => e.Syncversion)
                .HasColumnType("datetime")
                .HasColumnName("SYNCVERSION");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__COURSE__71CB31DB14F07AFD");

            entity.ToTable("COURSE");

            entity.Property(e => e.CourseId)
                .HasMaxLength(5)
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.ApproveDt)
                .HasColumnType("datetime")
                .HasColumnName("APPROVE_DT");
            entity.Property(e => e.CourseDesc).HasColumnName("COURSE_DESC");
            entity.Property(e => e.CourseName)
                .HasMaxLength(200)
                .HasColumnName("COURSE_NAME");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(200)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.ExpirtyDt)
                .HasColumnType("datetime")
                .HasColumnName("EXPIRTY_DT");
            entity.Property(e => e.Faculty)
                .HasMaxLength(200)
                .HasColumnName("FACULTY");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("STATUS");
            entity.Property(e => e.Syncoperation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SYNCOPERATION");
            entity.Property(e => e.Syncversion)
                .HasColumnType("datetime")
                .HasColumnName("SYNCVERSION");
        });

        modelBuilder.Entity<Fileupload>(entity =>
        {
            entity.HasKey(e => e.FileName).HasName("PK__FILEUPLO__448AD0BEFB2F697B");

            entity.ToTable("FILEUPLOAD");

            entity.Property(e => e.FileName)
                .HasMaxLength(200)
                .HasColumnName("FILE_NAME");
            entity.Property(e => e.Attachment).HasColumnName("ATTACHMENT");
            entity.Property(e => e.CourseId)
                .HasMaxLength(5)
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.Syncoperation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SYNCOPERATION");
            entity.Property(e => e.Syncversion)
                .HasColumnType("datetime")
                .HasColumnName("SYNCVERSION");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__ROLES__5AC4D222B8A62C2D");

            entity.ToTable("ROLES");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("ROLE_ID");
            entity.Property(e => e.Roles)
                .HasMaxLength(100)
                .HasColumnName("ROLES");
            entity.Property(e => e.Syncoperation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SYNCOPERATION");
            entity.Property(e => e.Syncversion)
                .HasColumnType("datetime")
                .HasColumnName("SYNCVERSION");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
