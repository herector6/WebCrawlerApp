using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class Job_locationController : Controller
    {
        private readonly Job_locationDbContext _context;

        public Job_locationController(Job_locationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Job_locationViewModel model = new Job_locationViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int job_locationId, string job_location)
        {
            Job_locationViewModel model = new Job_locationViewModel(_context);

            Job_locationModel job_locationDetails = new(job_locationId, job_location);

            model.SaveJob_location(job_locationDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Job location has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            Job_locationViewModel model = new Job_locationViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Job_locationViewModel model = new Job_locationViewModel(_context);

            if (id > 0)
            {
                model.RemoveJob_location(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Job location has been removed";
            return View("Index", model);
        }
    }
}
