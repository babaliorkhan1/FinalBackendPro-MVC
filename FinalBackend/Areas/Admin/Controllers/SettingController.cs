using FinalBackend.Context;
using FinalBackend.Extensions;
using FinalBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SettingController : Controller
    {
        private readonly RentDbContext _context;
        private IWebHostEnvironment _env;
        public SettingController(RentDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            Setting setting =_context.settings.Where(x=>!x.IsDeleted).FirstOrDefault();
            return View(setting);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View(setting);
            }
            setting.Image1 = setting.FormFile1.CreateImage(_env.WebRootPath,"assets/Images");
            setting.AboutImage = setting.FormFile2.CreateImage(_env.WebRootPath,"assets/Images");
            _context.Add(setting);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int id)
        {

            Setting setting =_context.settings.Where(x=>!x.IsDeleted &&x.Id==id).FirstOrDefault();
            if (setting==null)
            {
                return RedirectToAction("index","notfound");
            }
            return View(setting);
        }

        [HttpPost]
        public IActionResult Update(int id,Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index","notfound");
            }

            Setting updateSetting = _context.settings.Where(x => !x.IsDeleted).FirstOrDefault();
            if (updateSetting==null)
            {
                return View(setting);
            }

            updateSetting.Title=setting.Title;
            updateSetting.Description=setting.Description;  
            updateSetting.AboutTitle=setting.AboutTitle;    
            updateSetting.AboutText=setting.AboutText;      
            updateSetting.AllTitle=setting.AllTitle;
            updateSetting.FooterTitle=setting.FooterTitle;  
            updateSetting.FooterText=setting.FooterText;
            if (setting.FormFile1!=null)
            {
                updateSetting.Image1 = setting.FormFile1.CreateImage(_env.WebRootPath,"assets/Images");
            }
            if (setting.FormFile2!=null)
            {
                updateSetting.AboutImage= setting.FormFile2.CreateImage(_env.WebRootPath, "assets/Images");
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            int count=_context.settings.Where(x=>!x.IsDeleted).ToList().Count();        
            if (count==1)
            {
                TempData["admin"] = "Siyahida 1 setting movcud oldugda silmek mumkun deyil,zehmet olmasa 1 daha yaradin sonra tekrar yoxlayin";
                return RedirectToAction(nameof(Index));
            }
            Setting? setting = _context.settings.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefault();
            if (setting == null)
            {
                return RedirectToAction("index","notfound");
            }

            setting.IsDeleted = true;       
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
