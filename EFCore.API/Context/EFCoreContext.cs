using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.API.Context
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Nome = "IT" },
                new Department { Id = 2, Nome = "Human Resources" },
                new Department { Id = 3, Nome = "Economics " }
            );
        }

    }
}
