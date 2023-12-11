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

    public virtual DbSet<SysDescription> SysDescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
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
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Roles)
                .HasMaxLength(50)
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

        modelBuilder.Entity<SysDescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYS_DESCRIPTION");

            entity.Property(e => e.Syncoperation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SYNCOPERATION");
            entity.Property(e => e.Syncversion)
                .HasColumnType("datetime")
                .HasColumnName("SYNCVERSION");
            entity.Property(e => e.TableField)
                .HasMaxLength(100)
                .HasColumnName("TABLE_FIELD");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasColumnName("TABLE_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
