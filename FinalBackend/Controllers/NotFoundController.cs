using Microsoft.AspNetCore.Mvc;

namespace FinalBackend.Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
