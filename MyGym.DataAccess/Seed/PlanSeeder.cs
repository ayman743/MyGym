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
                new Plan
                {
                    Name = "Basic Plan",

                    Description =
                    "Access to gym equipment only",

                    DurationInDays = 30,

                    Price = 500,

                    IsActive = true
                },

                new Plan
                {
                    Name = "Premium Plan",

                    Description =
                    "Access to gym equipment and group classes",

                    DurationInDays = 90,

                    Price = 1500,

                    IsActive = true
                },

                new Plan
                {
                    Name = "VIP Plan",

                    Description =
                    "Full access with personal training sessions",

                    DurationInDays = 180,

                    Price = 3000,

                    IsActive = true
                }
            };

            await context.Plans.AddRangeAsync(plans);

            await context.SaveChangesAsync();
        }
    }
}