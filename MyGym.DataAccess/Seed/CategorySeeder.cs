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
            new Category
            {
                Name = "Yoga"
            },

            new Category
            {
                Name = "Boxing"
            },

            new Category
            {
                Name = "CrossFit"
            },

            new Category
            {
                Name = "General Fitness"
            }
        };

            await context.Categories.AddRangeAsync(categories);

            await context.SaveChangesAsync();
        }
    }
}
