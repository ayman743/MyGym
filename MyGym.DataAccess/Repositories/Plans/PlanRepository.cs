using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Repositories.Plans
{
    public class PlanRepository(GYMDbcontext DbContext) : IPlanRepository
    {
        public void Add(Plan plan)
        => DbContext.Plans.Add(plan);


        public void Delete(Plan plan)
        => DbContext.Plans.Remove(plan);


        public void Update(Plan plan)
        => DbContext.Plans.Update(plan);


        public async Task<Plan?> GetByIdAsync(int id)
        {
            return await DbContext.Plans
                .FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IEnumerable<Plan>> GetPlansAsync()
        {
            return await DbContext.Plans
               .ToListAsync(); 
        }

        public async Task<int> SaveChangesAsync()
        => await DbContext.SaveChangesAsync();
    }
}
