using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class Company_sizeController : Controller
    {
        private readonly Company_sizeDbContext _context;

        public Company_sizeController(Company_sizeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Company_sizeViewModel model = new Company_sizeViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int company_sizeId, string company_size)
        {
            Company_sizeViewModel model = new Company_sizeViewModel(_context);

            Company_sizeModel company_sizeDetails = new(company_sizeId, company_size);

            model.SaveCompany_size(company_sizeDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Company size info has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            Company_sizeViewModel model = new Company_sizeViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Company_sizeViewModel model = new Company_sizeViewModel(_context);

            if (id > 0)
            {
                model.RemoveCompany_size(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Company size info has been removed";
            return View("Index", model);
        }
    }
}