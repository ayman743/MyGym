using MyGym.BusinessLogic.Exceptions;
using MyGym.BusinessLogic.ViewModels.PlanViewModel;
using MyGym.DataAccess.Models;
using MyGym.DataAccess.Repositories.Generic;

namespace MyGym.BusinessLogic.Services.Plans
{
    public class PlanServiece(IGenericRepository<Plan> _PlanRepo,IGenericRepository<Membership> _MembershipRepo):IPlanServiece
    {
        public async Task<bool>IsActiveMemebrship(int id)
        {
            return await _MembershipRepo.AnyAsync(ms => ms.PlanId == id && ms.EndDate > DateOnly.FromDateTime(DateTime.Today));
           
        }

        public async Task TogglePlanAsync(int id)
        {
            var errors = new Dictionary<string, string>();
            var plan = await _PlanRepo.GetByIdAsync(id);
            if (plan == null)
            {
                errors.Add("ErrorMessage", "Plan Not Found");
                throw new ValidationException(errors);
            }
            if(plan.IsActive==true&& await IsActiveMemebrship(id))
            {
                errors.Add("ErrorMessage", "Can Not Deactive Plan with Active Membership");
                throw new ValidationException(errors);
            }

            plan.IsActive = !plan.IsActive;
            await _PlanRepo.SaveChangesAsync();
        }
        public async Task<EditPlanVM?> GetEditPlanAsync(int id)
        {
            var plan=await _PlanRepo.GetByIdAsync(id);
            if (plan == null)
            {
                return null;
            }
            var result = new EditPlanVM()
            {
                  Description=plan.Description,
                  DurationInDays= plan.DurationInDays,
                  Name=plan.Name,
                  Price=plan.Price,
            };
            return result;
        }


        public async Task UpdatePlanAsync(int id,EditPlanVM planVM)
        {
            var errors=new Dictionary<string,string>();
            var plan=await _PlanRepo.GetByIdAsync(id);
            if (plan == null)
            {
                errors.Add("ErrorMessage", "No Plan Found");
                throw new ValidationException(errors);
            }
            if (planVM.Name!= plan.Name) 
            {
                errors.Add("Name", "Can Not Change Plan Name");
                throw new ValidationException(errors);
            }
           
            if (await IsActiveMemebrship(id))
            {
                errors.Add("ErrorMessage", "Can Not Updated Plan with Active Membership");
                throw new ValidationException(errors);
            }

            plan.Description = planVM.Description;
            plan.DurationInDays = planVM.DurationInDays!.Value;
            plan.Price=planVM.Price!.Value;
       

           await _PlanRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Plan>>GetPlansAsync()
        {
            var plans = await _PlanRepo.GetAllAsync();
            return plans;
        }

        public async Task<Plan?> GetPlanDeyailAsync(int id)
        {
            var plan = await _PlanRepo.GetByIdAsync(id);
            return plan;
        }
    }
}
