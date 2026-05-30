using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Enums;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Seed
{
    public static class HealthRecordSeeder
    {
        public static async Task SeedAsync(GYMDbcontext context)
        {
            if (await context.HealthRecords.AnyAsync())
                return;

            var member1 = await context.Members.FirstAsync();
            var member2 = await context.Members.Skip(1).FirstAsync();

            var records = new List<HealthRecord>
            {
                new()
                {
                    Height = 175,
                    Weight = 80,
                    BloodType = BloodType.OPositive,
                    Note = "Healthy",
                    MemberId = member1.Id
                },

                new()
                {
                    Height = 165,
                    Weight = 60,
                    BloodType = BloodType.APositive,
                    Note = "Needs cardio",
                    MemberId = member2.Id
                }
            };

            await context.HealthRecords.AddRangeAsync(records);
            await context.SaveChangesAsync();
        }
    }
}