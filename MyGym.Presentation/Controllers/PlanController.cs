using Microsoft.AspNetCore.Mvc;
using MyGym.DataAccess.Repositories.Plans;

namespace MyGym.Presentation.Controllers 
{
    public class PlanController(IPlanRepository PlanRepo) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Plans = await PlanRepo.GetPlansAsync();
            return View(Plans);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Plan = await PlanRepo.GetByIdAsync(id);

            if (Plan == null)
            {
                return NotFound();
            }

            return View(Plan);
        }
    }
}
