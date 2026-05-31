using Microsoft.EntityFrameworkCore;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Models;
using MyGym.DataAccess.Repositories.Generic;
namespace MyGym.DataAccess.Repositories.Members
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {

        public MemberRepository(GYMDbcontext dbcontext) : base(dbcontext)
        {

        }
        public async Task<Member?> GetHealthRecordByMemberIdAsync(int id)
        {

            return await _dbcontext.Members
                      .Include(m => m.HealthRecord)
                      .FirstOrDefaultAsync(m => m.Id == id);

        }

  
        public async Task<Member?> GetWithMembership(int id)
        {
            var member = await _dbcontext.Members
                .Include(m => m.Memberships
                .Where(x => x.EndDate > DateOnly
                        .FromDateTime(DateTime.Now))
                )
                .ThenInclude(ms => ms.Plan)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            return member;
        }

       
    }
}
