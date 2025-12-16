using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        // DbSet'ы для таблиц
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Employee)
                .WithMany(emp => emp.Equipments)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.EquipmentType)
                .WithMany(et => et.Equipments)
                .HasForeignKey(e => e.EquipmentTypeId);
        }
    }
}