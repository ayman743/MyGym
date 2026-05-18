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

            var trainerIds = await context.Trainers
                .Select(t => t.Id)
                .ToListAsync();

            var categoryIds = await context.Categories
                .Select(c => c.Id)
                .ToListAsync();

            if (trainerIds.Count == 0 || categoryIds.Count < 3)
                return;

            var start1 = DateTime.UtcNow.AddDays(1);
            var start2 = DateTime.UtcNow.AddDays(2);
            var start3 = DateTime.UtcNow.AddDays(3);

            var sessions = new List<Session>
            {
                new Session
                {
                    Capacity = 15,

                    StartDate = start1,

                    EndDate = start1.AddHours(1),

                    TrainerId = trainerIds[0],

                    CategoryId = categoryIds[0]
                },

                new Session
                {
                    Capacity = 20,

                    StartDate = start2,

                    EndDate = start2.AddHours(2),

                    TrainerId = trainerIds[0],

                    CategoryId = categoryIds[1]
                },

                new Session
                {
                    Capacity = 10,

                    StartDate = start3,

                    EndDate = start3.AddHours(1),

                    TrainerId = trainerIds[0],

                    CategoryId = categoryIds[2]
                }
            };

            await context.Sessions.AddRangeAsync(sessions);

            await context.SaveChangesAsync();
        }
    }
}