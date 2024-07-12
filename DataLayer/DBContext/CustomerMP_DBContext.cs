
using CustomerMP.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerMP.DataLayer.DBContext
{
    public class CustomerMP_DBContext : DbContext
    {
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=Customer_MP;");
        }

        public DbSet<Customers> Customers { get; set; }
    }
}
