using MyGym.DataAccess.Enums;

namespace MyGym.BusinessLogic.ViewModels.MemberViewModels
{
    public class MemberDetailsVm
    {
        public int Id {  get; set; }
        public string Email { get; set; } = default!;
        public string Name { get; set; } = default!;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? PlanName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string? Photo { get; set; }
    }
}
