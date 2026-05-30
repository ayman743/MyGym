using MyGym.DataAccess.Models;
using MyGym.DataAccess.Repositories.Generic;

namespace MyGym.DataAccess.Repositories.Members
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<Member?> GetWithMembership(int id);
        Task<Member?> GetHealthRecordByMemberIdAsync(int id);


    }
}
