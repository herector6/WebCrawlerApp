using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class Job_typeController : Controller
    {
        private readonly Job_typeDbContext _context;

        public Job_typeController(Job_typeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Job_typeViewModel model = new Job_typeViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int job_typeId, string job_type)
        {
            Job_typeViewModel model = new Job_typeViewModel(_context);

            Job_typeModel job_typeDetails = new(job_typeId, job_type);

            model.SaveJob_type(job_typeDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Job type has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            Job_typeViewModel model = new Job_typeViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Job_typeViewModel model = new Job_typeViewModel(_context);

            if (id > 0)
            {
                model.RemoveJob_type(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Job type has been removed";
            return View("Index", model);
        }
    }
}
