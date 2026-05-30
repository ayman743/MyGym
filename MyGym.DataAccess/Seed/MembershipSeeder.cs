using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Seed
{
    public static class MembershipSeeder
    {
        public static async Task SeedAsync(GYMDbcontext context)
        {
            if (await context.Memberships.AnyAsync())
                return;

            var member1 = await context.Members.FirstAsync();
            var member2 = await context.Members.Skip(1).FirstAsync();

            var basicPlan = await context.Plans.FirstAsync();
            var premiumPlan = await context.Plans.Skip(1).FirstAsync();

            var memberships = new List<Membership>
            {
                new()
                {
                    
                    EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(1)),
                    MemberId = member1.Id,
                    PlanId = basicPlan.Id
                },

                new()
                {
                  
                    EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(3)),
                    MemberId = member2.Id,
                    PlanId = premiumPlan.Id
                }
            };

            await context.Memberships.AddRangeAsync(memberships);
            await context.SaveChangesAsync();
        }
    }
}