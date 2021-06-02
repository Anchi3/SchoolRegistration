using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolRegistration.Models
{
    public partial class MVCRegistrationContext : DbContext
    {
        public MVCRegistrationContext()
        {
        }

        public MVCRegistrationContext(DbContextOptions<MVCRegistrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<RegType> RegType { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SAG0-HPZ;Database=MVCRegistration;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__Courses__C92D7187C078C225");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Instructor)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Instructo__Cours__34C8D9D1");
            });

            modelBuilder.Entity<RegType>(entity =>
            {
                entity.HasKey(e => e.StudentType)
                    .HasName("PK__RegType__45EDBF3ADDB7FA1C");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Cours__3A81B327");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Instr__398D8EEE");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Stude__3B75D760");

                entity.HasOne(d => d.StudentTypeNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.StudentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Stude__3C69FB99");
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentCo__Cours__48CFD27E");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentCo__Stude__47DBAE45");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Students__32C52A799723257A");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__Course__33D4B598");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
