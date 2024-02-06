using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Loadings;

public partial class AcademyContext : DbContext
{
    public AcademyContext()
    {
    }

    public AcademyContext(DbContextOptions<AcademyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<FirstView> FirstViews { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupDatum> GroupData { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudyPlan> StudyPlans { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            // .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=localhost; Initial Catalog=Academy; User Id=sa;Password=Elvin123;Trust Server Certificate=True");
    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC073940FE99");

            entity.ToTable("Employee");

            entity.Property(e => e.Salary).HasColumnType("smallmoney");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Faculty__3214EC07BE7623E3");

            entity.ToTable("Faculty");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<FirstView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FirstView");

            entity.Property(e => e.Gpa).HasColumnName("GPA");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC07A0637C34");

            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.Faculty).WithMany(p => p.Groups)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__Groups__FacultyI__47DBAE45");
        });

        modelBuilder.Entity<GroupDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupDat__3214EC0775E3A637");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupData)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__GroupData__Group__4BAC3F29");

            entity.HasOne(d => d.Student).WithMany(p => p.GroupData)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__GroupData__Stude__4AB81AF0");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC072A68FFD7");

            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Surname).HasMaxLength(30);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07C97AA0B0");

            entity.Property(e => e.Gpa)
                .HasDefaultValueSql("((0.0))")
                .HasColumnName("GPA");

            entity.HasOne(d => d.Person).WithMany(p => p.Students)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Students__Person__403A8C7D");
        });

        modelBuilder.Entity<StudyPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudyPla__3214EC076FF798FA");

            entity.ToTable("StudyPlan");

            entity.HasOne(d => d.Group).WithMany(p => p.StudyPlans)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__StudyPlan__Group__4F7CD00D");

            entity.HasOne(d => d.Teacher).WithMany(p => p.StudyPlans)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__StudyPlan__Teach__4E88ABD4");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC077D434FD9");

            entity.HasOne(d => d.Employee).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Teachers__Employ__440B1D61");

            entity.HasOne(d => d.Person).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Teachers__Person__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
