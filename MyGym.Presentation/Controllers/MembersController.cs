using Microsoft.AspNetCore.Mvc;
using MyGym.BusinessLogic.Exceptions;
using MyGym.BusinessLogic.Services.Members;
using MyGym.BusinessLogic.ViewModels.MemberViewModels;

namespace MyGym.Presentation.Controllers
{
    public class MembersController(IMemberService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var members = await service.GetAllMembersAsync(cancellationToken);

            return View(members);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberVm memberVm)
        {
            if (!ModelState.IsValid)
            {
                return View(memberVm);
            }

            try
            {
                await service.CreateMemberAsync(memberVm);

                TempData["SuccessMessage"] = "Member created successfully";

                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(memberVm);
            }
        }



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var details = await service.MemberDetails(id);

            if (details == null)
            {
                TempData["ErrorMessage"] = "Member Not found";

                return RedirectToAction(nameof(Index));
            }

            return View(details);
        }



        [HttpGet]
        public async Task<IActionResult> HealthRecordDetails(int id)
        {
            try
            {
                var healthRecord = await service.GetMemberHealthRecord(id);

                return View(healthRecord);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Member Not Found")
                {
                    TempData["ErrorMessage"] = "Member Not Found";
                }
                else if (ex.Message == "This Member Has No Health Record")
                {
                    TempData["ErrorMessage"] = "This Member Has No Health Record";
                }

                return RedirectToAction(nameof(Index));
            }
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var IsExists = await service.ExistsAsync(id);

            if (!IsExists)
            {
                TempData["ErrorMessage"] = "Member Not Found";

                return RedirectToAction(nameof(Index));
            }

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await service.DeleteMember(id);
            if (member == null)
            {
                TempData["ErrorMessage"] = "member not found";
                return RedirectToAction(nameof(Index));
            }
            if (member == false)
            {
                TempData["ErrorMessage"] = "Can Not Delete member with active session";
                return RedirectToAction(nameof(Index));
            }
            TempData["SuccessMessage"] = "member Deleted Succefully";
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> EditMember(int id)
        {
            var result = await service.GetUpdateMember(id);

            if (result == null)
            {
                TempData["ErrorMessage"] = "Member Not Found";

                return RedirectToAction(nameof(Index));
            }

            return View(result);
        }



        [HttpPost]
       
        public async Task<IActionResult> EditMember(int id,EditMemberVm editMemberVm)
        {
            if (!ModelState.IsValid)
            {
                return View(editMemberVm);
            }

            try
            {
                await service.UpdateMember(id,editMemberVm);

                TempData["SuccessMessage"] = "Member Updated Successfully";

                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    if (error.Key == "ErrorMessage")
                    {
                        TempData["ErrorMessage"] = error.Value;
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }

                }

                return View(editMemberVm);
            }
        }
    }
}