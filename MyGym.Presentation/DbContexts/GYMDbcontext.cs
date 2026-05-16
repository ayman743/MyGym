using Microsoft.EntityFrameworkCore;
using MyGym.Presentation.Models;

namespace MyGym.Presentation.DbContexts
{
    public class GYMDbcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=.;Database=GYMDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GYMDbcontext).Assembly);

        }
        public DbSet<Plan> Plans { get; set; }
    }
}
 