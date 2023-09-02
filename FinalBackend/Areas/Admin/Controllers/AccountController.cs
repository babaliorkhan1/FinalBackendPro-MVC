using FinalBackend.Models;
using FinalBackend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalBackend.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> AdminCreate()
        {
            AppUser SuperAdmin = new AppUser
            {
                Name = "SuperAdmin",
                SurName = "SuperAdmin",
                Email = "SuperAdmin@code.edu.az",
                UserName = "SuperAdmin",
            };
            await _userManager.CreateAsync(SuperAdmin, "Admin123@");
            AppUser Admin = new AppUser
            {
                Name = "Admin",
                SurName = "Admin",
                Email = "Admin@code.edu.az",
                UserName = "Admin",
            };
            await _userManager.CreateAsync(Admin, "Admin123@");

            await _userManager.AddToRoleAsync(SuperAdmin, "SuperAdmin");
            await _userManager.AddToRoleAsync(Admin, "Admin");
            return Json("ok");
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Register()
        {
            return View();
           
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Register(RegsiterViewModel regsiterViewModel)
        {
            AppUser Admin = new AppUser
            {
                Name = regsiterViewModel.Name,
                SurName = regsiterViewModel.SurName,
                Email = regsiterViewModel.Email,
                UserName = regsiterViewModel.UserName,
                EmailConfirmed = true,
            };
            await _userManager.CreateAsync(Admin, regsiterViewModel.Password);
            await _userManager.AddToRoleAsync(Admin, "Admin");
            return RedirectToAction("Index","Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login loginView)
        {
            AppUser appUser = await _userManager.FindByNameAsync(loginView.UserName);
            if (appUser == null)
            {
                ModelState.AddModelError("", "UserName or Paswword is inCorrect");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(appUser, loginView.Password, loginView.IsRememberMe, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Your account is blocked for 5 minutes");
                    return View();
                }
                ModelState.AddModelError("", "UserName or Paswword is inCorrect");
                return View();
            }
            return RedirectToAction("index", "home");

        }
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        //public  async Task <ActionResult> CreateRole()
        //{

        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("User");
        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);
        //    return Json("CreatedRoles!");

        //}
    }
}
