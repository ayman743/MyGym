using MyGym.BusinessLogic.ViewModels.MemberViewModels;

namespace MyGym.BusinessLogic.Services.Members
{
    public interface IMemberService
    {
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<MemberVm>> GetAllMembersAsync(CancellationToken cancellationToken);
        Task CreateMemberAsync(CreateMemberVm memberVm);
        Task<MemberDetailsVm?> MemberDetails(int id);
        Task<HealthRecordVm?> GetMemberHealthRecord(int id);
        Task<bool?> DeleteMember(int id);
        Task<EditMemberVm?> GetUpdateMember(int id);
        Task UpdateMember(int id,EditMemberVm editMemberVm);


    }
}
