using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class Job_titleController : Controller
    {
        private readonly Job_titleDbContext _context;

        public Job_titleController(Job_titleDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Job_titleViewModel model = new Job_titleViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int job_titleId, string job_title)
        {
            Job_titleViewModel model = new Job_titleViewModel(_context);

            Job_titleModel job_titleDetails = new(job_titleId, job_title);

            model.SaveJob_title(job_titleDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Job title has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            Job_titleViewModel model = new Job_titleViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Job_titleViewModel model = new Job_titleViewModel(_context);

            if (id > 0)
            {
                model.RemoveJob_title(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Job title has been removed";
            return View("Index", model);
        }
    }
}