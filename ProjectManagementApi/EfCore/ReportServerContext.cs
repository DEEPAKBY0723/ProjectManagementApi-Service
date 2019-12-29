using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.EfCore
{
    public partial class ReportServerContext : DbContext
    {
        public ReportServerContext()
        {
        }

        public ReportServerContext(DbContextOptions<ReportServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UsersTable> UsersTable { get; set; }

        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Task> Task { get; set; }

        public virtual DbSet<ParentTask> ParentTask { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DOTNET;Database=ReportServer;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersTable>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("Employee_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .IsRequired()
                    .HasColumnName("Project_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaskId)
                    .IsRequired()
                    .HasColumnName("Task_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("Project_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Project)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("datetime");
            });
            modelBuilder.Entity<Task>(entity =>
            {
               
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.TaskId).HasColumnName("Task_ID");

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParentId)
                    .HasColumnName("Parent_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .IsRequired()
                    .HasColumnName("Project_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Task1)
                    .IsRequired()
                    .HasColumnName("Task")
                    .HasMaxLength(100)
                    .IsUnicode(false);

              
            });
            modelBuilder.Entity<ParentTask>(entity =>
            {
                entity.HasKey(e => e.ParentId);

                entity.Property(e => e.ParentId).HasColumnName("Parent_ID");
             
                entity.Property(e => e.ParentTasks)
                    .HasColumnName("Parent_Task");
                   
            });
        }
    }
}
