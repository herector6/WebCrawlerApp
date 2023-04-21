using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class BenefitsController : Controller
    {
        private readonly BenefitsDbContext _context;

        public BenefitsController(BenefitsDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            BenefitsViewModel model = new BenefitsViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int benefitsId, string benefits)
        {
            BenefitsViewModel model = new BenefitsViewModel(_context);

            BenefitsModel benefitsDetails = new(benefitsId, benefits);

            model.SaveBenefits(benefitsDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Benefit has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            BenefitsViewModel model = new BenefitsViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            BenefitsViewModel model = new BenefitsViewModel(_context);

            if (id > 0)
            {
                model.RemoveBenefits(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Benefit has been removed";
            return View("Index", model);
        }
    }
}
