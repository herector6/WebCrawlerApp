using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class IndustryController : Controller
    {
        private readonly IndustryDbContext _context;

        public IndustryController(IndustryDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IndustryViewModel model = new IndustryViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int industryId, string industry)
        {
            IndustryViewModel model = new IndustryViewModel(_context);

            IndustryModel industryDetails = new(industryId, industry);

            model.SaveIndustry(industryDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Industry has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            IndustryViewModel model = new IndustryViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            IndustryViewModel model = new IndustryViewModel(_context);

            if (id > 0)
            {
                model.RemoveIndustry(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Industry has been removed";
            return View("Index", model);
        }
    }
}
