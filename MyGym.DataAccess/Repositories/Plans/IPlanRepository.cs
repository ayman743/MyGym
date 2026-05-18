using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Repositories.Plans
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetPlansAsync();

        Task<Plan?>GetByIdAsync(int id);

        void Add(Plan plan);

        void Update(Plan plan);

        void Delete(Plan plan);

        Task<int> SaveChangesAsync();


    }
}
