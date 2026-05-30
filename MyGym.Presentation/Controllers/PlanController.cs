using Microsoft.AspNetCore.Mvc;
using MyGym.BusinessLogic.Exceptions;
using MyGym.BusinessLogic.Services.Plans;
using MyGym.BusinessLogic.ViewModels.PlanViewModel;


namespace MyGym.Presentation.Controllers
{
    public class PlanController(IPlanServiece serviece) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Plans = await serviece.GetPlansAsync();
            return View(Plans);
        }


        [HttpPost]
        public async Task<IActionResult> Activate(int id)
        {
            try
            {
                await serviece.TogglePlanAsync(id);
                TempData["SuccessMessage"] = "Plan Status Changed";
                return RedirectToAction("Index");
            }
            catch(ValidationException errors)
            {
                foreach(var error in errors.Errors)
                {
                    TempData["ErrorMessage"] = error.Value;
                }
                return RedirectToAction("Index");
            }
          

        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Plan = await serviece.GetPlanDeyailAsync(id);

            if (Plan == null)
            {
                TempData["ErrorMessage"] = "Plan Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(Plan);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           
            var EditPlanVM = await serviece.GetEditPlanAsync(id);
            if (EditPlanVM == null)
            {
                TempData["ErrorMessage"] = "Plan Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(EditPlanVM);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPlanVM planVM)
        {
            if (!ModelState.IsValid)
            {
                return View(planVM);
            }
            try
            {
                await serviece.UpdatePlanAsync(id, planVM);
                TempData["SuccessMessage"] = "Plan Updated Succefully";
                return RedirectToAction(nameof(Index));
            }

            catch (ValidationException errors)
            {
                foreach (var error in errors.Errors)
                {
                    if (error.Key == "ErrorMessage")
                    {
                        TempData[error.Key] = error.Value;
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError(error.Key, error.Value);
                }
                return View(planVM);
            }
        }
    }
}
