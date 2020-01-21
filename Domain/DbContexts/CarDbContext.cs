using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.DbContexts
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=Domain.DbContexts.CarDbContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }

        public virtual DbSet<Car> Cars { get; set; }
    }
}
