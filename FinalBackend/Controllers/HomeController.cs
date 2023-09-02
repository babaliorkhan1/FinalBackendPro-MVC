using FinalBackend.Context;
using FinalBackend.Models;
using FinalBackend.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly RentDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(RentDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }

        public async Task<IActionResult> Index()
        {
           settinguser settinguser=new settinguser();   

           
            settinguser.setting =_context.settings.Where(x=>!x.IsDeleted).FirstOrDefault();
            if (User.Identity.IsAuthenticated)
            {
                settinguser.appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            
            return View(settinguser);
        }

      
    }
}