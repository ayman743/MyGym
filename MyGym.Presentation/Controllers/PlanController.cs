using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGym.Presentation.DbContexts;

namespace MyGym.Presentation.Controllers
{
    public class PlanController(GYMDbcontext dbcontext) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Plans = await dbcontext.Plans
                
                .ToListAsync();
         
            return View(Plans);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Plan = await dbcontext.Plans
                .FirstOrDefaultAsync(p => p.Id == id);
            if(Plan == null)
            {
                return NotFound();
            }
               
            return View(Plan);
        }
    }
}
