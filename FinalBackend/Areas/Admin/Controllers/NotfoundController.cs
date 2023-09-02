using Microsoft.AspNetCore.Mvc;

namespace FinalBackend.Areas.Admin.Controllers
{
    public class NotfoundController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
