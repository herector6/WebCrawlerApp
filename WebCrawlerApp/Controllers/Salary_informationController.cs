using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class Salary_informationController : Controller
    {
        private readonly Salary_informationDbContext _context;

        public Salary_informationController(Salary_informationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Salary_informationViewModel model = new Salary_informationViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int salary_informationId, string salary_information)
        {
            Salary_informationViewModel model = new Salary_informationViewModel(_context);

            Salary_informationModel salary_informationDetails = new(salary_informationId, salary_information);

            model.SaveSalary_information(salary_informationDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Salary information has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            Salary_informationViewModel model = new Salary_informationViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Salary_informationViewModel model = new Salary_informationViewModel(_context);

            if (id > 0)
            {
                model.RemoveSalary_information(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Salary information has been removed";
            return View("Index", model);
        }
    }
}
