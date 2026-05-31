using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Enums;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Seed
{
    public static class TrainerSeeder
    {
        public static async Task SeedAsync(GYMDbcontext context)
        {
            if (await context.Trainers.AnyAsync())
                return;

            var trainers = new List<Trainer>
            {
                new()
                {
                    Name = "Ahmed Hassan",
                    Email = "ahmed@gym.com",
                    Phone = "01012345678",
                    DateOfBirth = new DateOnly(1990,5,1),
                    Gender = Gender.Male,
                    Specialty = Specialties.CrossFit,

                    Address = new Address
                    {
                        City = "Cairo",
                        Street = "Nasr City",
                        BuildingNumber = 10
                    }
                },

                new()
                {
                    Name = "Sara Ali",
                    Email = "sara@gym.com",
                    Phone = "01112345678",
                    DateOfBirth = new DateOnly(1995,3,15),
                    Gender = Gender.Female,
                    Specialty = Specialties.Yoga,

                    Address = new Address
                    {
                        City = "Giza",
                        Street = "Dokki",
                        BuildingNumber = 22
                    }
                }
            };

            await context.Trainers.AddRangeAsync(trainers);
            await context.SaveChangesAsync();
        }
    }
}