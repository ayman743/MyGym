using MyGym.BusinessLogic.ViewModels.PlanViewModel;
using MyGym.DataAccess.Models;

namespace MyGym.BusinessLogic.Services.Plans
{
    public interface IPlanServiece
    {
        Task TogglePlanAsync(int id);
        Task<IEnumerable<Plan>> GetPlansAsync();
        Task<Plan?> GetPlanDeyailAsync(int id);
        Task<EditPlanVM?> GetEditPlanAsync(int id);
        Task UpdatePlanAsync(int id, EditPlanVM planVM);
    }
}
