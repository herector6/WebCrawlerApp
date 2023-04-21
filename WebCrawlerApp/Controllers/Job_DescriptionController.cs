using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class Job_DescriptionController : Controller
    {
        private readonly Job_DescriptionDbContext _context;

        public Job_DescriptionController(Job_DescriptionDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Job_DescriptionViewModel model = new Job_DescriptionViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int job_DescriptionId, string job_Description)
        {
            Job_DescriptionViewModel model = new Job_DescriptionViewModel(_context);

            Job_DescriptionModel job_DescriptionDetails = new(job_DescriptionId, job_Description);

            model.SaveJob_Description(job_DescriptionDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Job description has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            Job_DescriptionViewModel model = new Job_DescriptionViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Job_DescriptionViewModel model = new Job_DescriptionViewModel(_context);

            if (id > 0)
            {
                model.RemoveJob_Description(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Job description has been removed";
            return View("Index", model);
        }
    }
}