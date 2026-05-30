using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Seed
{
    public static class SessionSeeder
    {
        public static async Task SeedAsync(GYMDbcontext context)
        {
            if (await context.Sessions.AnyAsync())
                return;

            var category = await context.Categories.FirstAsync();
            var trainer = await context.Trainers.FirstAsync();

            var sessions = new List<Session>
            {
                new()
                {
                    Capacity = 20,
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(1).AddHours(2),
                    CategoryId = category.Id,
                    TrainerId = trainer.Id
                },

                new()
                {
                    Capacity = 15,
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(2).AddHours(1),
                    CategoryId = category.Id,
                    TrainerId = trainer.Id
                }
            };

            await context.Sessions.AddRangeAsync(sessions);
            await context.SaveChangesAsync();
        }
    }
}