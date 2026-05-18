 using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.DbContexts
{
    public class GYMDbcontext:DbContext
    {
        public GYMDbcontext(DbContextOptions options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .UseTpcMappingStrategy();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GYMDbcontext).Assembly);
            
            modelBuilder.Entity<User>()
            .HasQueryFilter(x => !x.IsDeleted);

        }
    

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> MemberShips { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
       


    }
}
 