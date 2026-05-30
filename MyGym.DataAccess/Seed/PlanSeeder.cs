using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Seed
{
    public static class PlanSeeder
    {
        public static async Task SeedAsync(GYMDbcontext context)
        {
            if (await context.Plans.AnyAsync())
                return;

            var plans = new List<Plan>
            {
                new()
                {
                    Name = "Basic",
                    Description = "Basic gym access",
                    DurationInDays = 30,
                    Price = 500,
                    IsActive = true
                },

                new()
                {
                    Name = "Standard",
                    Description = "Gym + Sessions",
                    DurationInDays = 90,
                    Price = 1200,
                    IsActive = true
                },

                new()
                {
                    Name = "Premium",
                    Description = "Full access with trainer",
                    DurationInDays = 180,
                    Price = 2500,
                    IsActive = true
                }
            };

            await context.Plans.AddRangeAsync(plans);
            await context.SaveChangesAsync();
        }
    }
}