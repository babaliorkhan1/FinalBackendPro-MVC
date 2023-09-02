using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalBackend.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = "Admin,SuperAdmin")]

        //[Authorize(Roles = "Admin,SuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
