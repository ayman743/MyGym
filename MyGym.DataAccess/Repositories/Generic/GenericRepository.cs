using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Models;
using System.Linq.Expressions;

namespace MyGym.DataAccess.Repositories.Generic
{

    public class GenericRepository<T>  :IGenericRepository<T> where T:BaseEntity, new()
    {
        protected readonly GYMDbcontext _dbcontext;
        private readonly DbSet<T> _set;

        public GenericRepository(GYMDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _set = dbcontext.Set<T>();
        }

        public async Task<T?> FirstOrDefaultAsync( Expression<Func<T, bool>> predicate, bool IsTracking = false)
        {
            IQueryable<T> query = IsTracking ? _set : _set.AsNoTracking();
            return await query.FirstOrDefaultAsync(predicate);

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool> >predicate)
            => await _set.AnyAsync(predicate) ;
       
        public void Add(T entity)
            => _set.Add(entity);

        public void Delete(T entity)
             =>_set.Remove(entity);

        public void Update(T entity)
            => _set.Update(entity);

        public async Task<T?> GetByIdAsync(int id)
            => await _set.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync(bool IsTracking = false)
        {
            IQueryable<T> query = IsTracking ? _set : _set.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
            => await _dbcontext.SaveChangesAsync();
    }
}
