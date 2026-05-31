using MyGym.DataAccess.Models;
using System.Linq.Expressions;

namespace MyGym.DataAccess.Repositories.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {


        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool IsTracking = false);

        public void Add(T entity);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        public void Delete(T entity);

        public void Update(T entity);

        public Task<T?> GetByIdAsync(int id);

        public Task<IEnumerable<T>> GetAllAsync(bool IsTracking = false);

        public Task<int> SaveChangesAsync();
    
    }
}
