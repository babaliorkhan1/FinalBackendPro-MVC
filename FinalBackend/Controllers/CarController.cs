using FinalBackend.Context;
using FinalBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalBackend.Controllers
{
    public class CarController : Controller
    {
        private readonly RentDbContext _context;
        public CarController(RentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
          Setting? setting=_context.settings.Where(x=>!x.IsDeleted).FirstOrDefault();    

            return View(setting);
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
