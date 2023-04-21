using Microsoft.AspNetCore.Mvc;
using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.Models;

namespace WebCrawlerApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ReviewsDbContext _context;

        public ReviewsController(ReviewsDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ReviewsViewModel model = new ReviewsViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int reviewsId, string reviews)
        {
            ReviewsViewModel model = new ReviewsViewModel(_context);

            ReviewsModel reviewsDetails = new(reviewsId, reviews);

            model.SaveReviews(reviewsDetails);
            model.IsActionSuccess = true;
            model.ActionMessage = "Review has been updated";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            ReviewsViewModel model = new ReviewsViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            ReviewsViewModel model = new ReviewsViewModel(_context);

            if (id > 0)
            {
                model.RemoveReviews(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Review has been removed";
            return View("Index", model);
        }
    }
}
