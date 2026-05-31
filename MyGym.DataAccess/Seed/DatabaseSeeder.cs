using MyGym.DataAccess.DbContexts;

namespace MyGym.DataAccess.Seed
{
    public class DatabaseSeeder
    {
        public static async Task SeedallAsync(GYMDbcontext context)
        {
            await CategorySeeder.SeedAsync(context);

            await PlanSeeder.SeedAsync(context);


            await TrainerSeeder.SeedAsync(context);
            await MemberSeeder.SeedAsync(context);

            await HealthRecordSeeder.SeedAsync(context);

            await MembershipSeeder.SeedAsync(context);

            await SessionSeeder.SeedAsync(context);

            await BookingSeeder.SeedAsync(context);
        }
    }
}