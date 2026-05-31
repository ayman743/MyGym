using Microsoft.AspNetCore.Mvc;
using MyGym.BusinessLogic.Services.Trainers;
using MyGym.BusinessLogic.ViewModels.TrainerViewModels;
using MyGym.BusinessLogic.Exceptions;
namespace MyGym.Presentation.Controllers
{
    public class TrainersController(ITrainerService service):Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trainers=await service.GetTrainersAsync();
          
            return View(trainers);
        }

        [HttpGet]
        public async Task<IActionResult>Details(int id)
        {
            var TrainerDetails =await service.getTrainerDetails(id);
            if(TrainerDetails==null)
            {
                TempData["ErrorMessage"] = "Trainer Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(TrainerDetails);
        }

        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            var result=await service.getEditTrainerAsync(id);
            if(result==null)
            {
                TempData["ErrorMessage"] = "Trainer Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,EditTrainerVM trainerVM)
        {
            if(!ModelState.IsValid)
            {
                return View(trainerVM);
            }
            try
            {
                await service.UpdateTrainerAsync(id, trainerVM);
                TempData["SuccessMessage"] = "Trainer Updated Succefully";
                return RedirectToAction(nameof(Index));
            }
            catch(ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    if (error.Key == "ErrorMessage")
                    {
                        TempData["ErrorMessage"]=error.Value;
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError(error.Key, error.Value);
                  
                }
                return View(trainerVM);
            }
           

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTrainerVM trainerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(trainerVM);
            }
            try
            {
                await service.CreateTrainerAsync(trainerVM);
                TempData["SuccessMessage"] = "Trainer Added Succefully";
                return RedirectToAction("Index");
            }
            catch(ValidationException ex)
            {
               foreach(var error in ex.Errors)
               {
                    ModelState.AddModelError(error.Key, error.Value);
               }
               return View(trainerVM);
            }
            
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var IsExists=await service.ExistsAsync(id);
            if(!IsExists)
            {
                TempData["ErrorMessage"] = "trainer not found";
                return RedirectToAction("Index");
            }
            return View();

        }
       [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainer = await service.DeleteTrainer(id);
            if(trainer==null)
            {
                TempData["ErrorMessage"] = "trainer not found";
                return RedirectToAction(nameof(Index));
            }
            if(trainer==false)
            {
                TempData["ErrorMessage"] = "Can Not Delete Train with active session";
                return RedirectToAction(nameof(Index));
            }
            TempData["SuccessMessage"] = "Trainer Deleted Succefully";
            return RedirectToAction(nameof(Index));
        }
        

    }
}
