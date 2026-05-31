using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Seed
{
    public static class CategorySeeder
    {
        public static async Task SeedAsync(GYMDbcontext context)
        {
            if (await context.Categories.AnyAsync())
                return;

            var categories = new List<Category>
            {
                new() { Name = "Yoga" },
                new() { Name = "Boxing" },
                new() { Name = "CrossFit" },
                new() { Name = "Fitness" }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }
    }
}