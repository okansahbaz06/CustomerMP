using CustomerMP.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerMP.DataLayer.DBContext
{
    public class CustomerMP_DBContext : DbContext
    {
        public CustomerMP_DBContext(DbContextOptions<CustomerMP_DBContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
