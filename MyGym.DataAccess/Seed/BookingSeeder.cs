using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Seed
{
    public static class BookingSeeder
    {
        public static async Task SeedAsync(GYMDbcontext context)
        {
            if (await context.Bookings.AnyAsync())
                return;

            var member = await context.Members.FirstAsync();
            var session = await context.Sessions.FirstAsync();

            var bookings = new List<Booking>
            {
                new()
                {
                    MemberId = member.Id,
                    SessionId = session.Id,
                    IsAttended = false
                }
            };

            await context.Bookings.AddRangeAsync(bookings);
            await context.SaveChangesAsync();
        }
    }
}