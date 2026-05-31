using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Enums;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Seed
{
    public static class MemberSeeder
    {
        public static async Task SeedAsync(GYMDbcontext context)
        {
            if (await context.Members.AnyAsync())
                return;

            var members = new List<Member>
            {
                new()
                {
                    Name = "Mohamed Adel",
                    Email = "mohamed@gmail.com",
                    Phone = "01212345678",
                    DateOfBirth = new DateOnly(2000,1,1),
                    Gender = Gender.Male,

                    Address = new Address
                    {
                        City = "Cairo",
                        Street = "Maadi",
                        BuildingNumber = 5
                    }
                },

                new()
                {
                    Name = "Mona Sameh",
                    Email = "mona@gmail.com",
                    Phone = "01512345678",
                    DateOfBirth = new DateOnly(2002,6,10),
                    Gender = Gender.Female,

                    Address = new Address
                    {
                        City = "Alex",
                        Street = "Stanley",
                        BuildingNumber = 12
                    }
                }
            };

            await context.Members.AddRangeAsync(members);
            await context.SaveChangesAsync();
        }
    }
}