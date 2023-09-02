using FinalBackend.Context;
using FinalBackend.Extensions;
using FinalBackend.FileImage;
using FinalBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CompanyController : Controller
    {
       
        private readonly RentDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CompanyController(RentDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env; 
        }
       
        public IActionResult Index()
        {
            IEnumerable<Company> companies=_context.companies.Where(x=>!x.IsDeleted).ToList();  
            return View(companies);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }

            if (!ContentImage.isImage(company.FormFile1))
            {
                ModelState.AddModelError("", "It is Not Image");
                return View(company);   
            }
            if (!ContentImage.isImage(company.FormFile2))
            {
                ModelState.AddModelError("", "It is Not Image");
                return View(company);
            }
            company.Image1 = company.FormFile1.CreateImage(_env.WebRootPath,"assets/Images");
            company.Image2 = company.FormFile2.CreateImage(_env.WebRootPath,"assets/Images");
            _context.companies.Add(company);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Company company=_context.companies.Where(x=>!x.IsDeleted&&x.Id==id).FirstOrDefault();
            return View(company);
        }

        [HttpPost]
        public IActionResult Update(int id,Company company)
        {
            Company updateCompany = _context.companies.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefault();
            if (updateCompany == null)
            {
                return View(company);
            }
            if (company.FormFile1!=null)
            {
                company.Image1 = company.FormFile1.CreateImage(_env.WebRootPath,"assets/Images");
            }
            if (company.FormFile2 != null)
            {
                company.Image2 = company.FormFile2.CreateImage(_env.WebRootPath, "assets/Images");
            }
            updateCompany.Title1=company.Title1;
            updateCompany.Title2=company.Title2;
            updateCompany.Title3=company.Title3;
            updateCompany.Description1=company.Description1;    
            updateCompany.Description2=company.Description2;    
            updateCompany.Description3=company.Description3;    
            updateCompany.Description4=company.Description4;    
            updateCompany.Description5=company.Description5;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
      public IActionResult Delete(int id)
        {
            Company company=_context.companies.Where(x=>!x.IsDeleted &&x.Id==id).FirstOrDefault();
            company.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); 
        }

    }
}
