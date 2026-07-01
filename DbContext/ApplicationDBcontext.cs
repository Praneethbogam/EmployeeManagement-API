using Microsoft.EntityFrameworkCore;

namespace TestEmployeeManagement.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasOne(e => e.Department)
                .WithMany(e => e.Employees) 
                .HasForeignKey(e=> e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);
            // Employee configuration
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeName)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Salary)
                      .HasColumnType("decimal(10,2)");

       

                // FK → Department
                //entity.HasOne<Departments>()
                //      .WithMany()
                //      .HasForeignKey(e => e.DepartmentId)
                //      .OnDelete(DeleteBehavior.Restrict);
            });

            //Department configuration
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(d => d.DepartmentId);

                entity.Property(d => d.Name)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(d => d.Description)
                      .HasMaxLength(250);

                entity.Property(d => d.Location)
                      .HasMaxLength(150);
            });

            // Salary configuration
            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(s => s.SalaryId);

                entity.Property(s => s.Amount)
                      .HasColumnType("decimal(10,2)");

                entity.Property(s => s.EffectiveFrom)
                      .IsRequired();

                entity.HasOne(s => s.Employee)
                      .WithMany(e => e.Salaries)
                      .HasForeignKey(s => s.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

