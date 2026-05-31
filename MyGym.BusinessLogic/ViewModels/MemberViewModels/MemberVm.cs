using MyGym.DataAccess.Enums;

namespace MyGym.BusinessLogic.ViewModels.MemberViewModels
{
    public class MemberVm
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string Name { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string? Photo { get; set; }

    }
}
