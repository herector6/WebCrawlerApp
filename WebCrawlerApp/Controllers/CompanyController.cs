using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyDbContext _context;

        public CompanyController(CompanyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            CompanyViewModel model = new CompanyViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int companyId, string company)
        {
            CompanyViewModel model = new CompanyViewModel(_context);

            CompanyModel companyDetails = new(companyId, company);

            model.SaveCompany(companyDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Company info has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            CompanyViewModel model = new CompanyViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            CompanyViewModel model = new CompanyViewModel(_context);

            if (id > 0)
            {
                model.RemoveCompany(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Company info has been removed";
            return View("Index", model);
        }
    }
}