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
                    "Access to gym equipment during staffed hours",

                    DurationInDays = 30,

                    Price = 300,

                    IsActive = true
                },

                new Plan
                {
                    Name = "Standard Plan",

                    Description =
                    "Includes gym equipment and 2 group classes per week",

                    DurationInDays = 60,

                    Price = 500,

                    IsActive = true
                },

                new Plan
                {
                    Name = "Premium Plan",

                    Description =
                    "Unlimited access to equipment, classes, and sauna",

                    DurationInDays = 90,

                    Price = 900,

                    IsActive = false
                },

                new Plan
                {
                    Name = "Annual Plan",

                    Description =
                    "Full year access with personal trainer sessions",

                    DurationInDays = 365,

                    Price = 3000,

                    IsActive = false
                }
            };
                
            await context.Plans.AddRangeAsync(plans);

            await context.SaveChangesAsync();
        }
    }
}