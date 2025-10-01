using Microsoft.EntityFrameworkCore;
using CustomersApi.Models;

namespace CustomerApi.Data
{
    public class ApiDbContext:DbContext
    {
     public DbSet<Vehicle> Vehicle { get; set; }
     public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CustomerApiDb;");
        }
    }
}
