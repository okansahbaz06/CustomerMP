
using CustomerMP.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerMP.DataLayer.DBContext
{
    public class CustomerMP_DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=Customer_MP;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "superadmin",
                    Password = "admin", 
                    Role = "SuperAdmin"
                },
                new User
                {
                    Id = 2,
                    Username = "guest",
                    Password = "guest",
                    Role = "Guest"
                }
            );

        }
    }
}
