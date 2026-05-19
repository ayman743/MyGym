using MyGym.DataAccess.DbContexts;

namespace MyGym.DataAccess.Seed
{
    public  class DatabaseSeeder
    {

        public static async Task SeedallAsync(GYMDbcontext context)
        {
            await CategorySeeder.SeedAsync(context);
            await PlanSeeder.SeedAsync(context);
            await SessionSeeder.SeedAsync(context);
        }
    }
}
