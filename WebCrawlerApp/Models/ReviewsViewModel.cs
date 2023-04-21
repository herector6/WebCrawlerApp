using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class ReviewsViewModel
    {
        private ReviewsRepositories _repo;

        public List<ReviewsModel> ReviewsList { get; set; }
        public ReviewsModel CurrentReviews { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public ReviewsViewModel(ReviewsDbContext context)
        {
            _repo = new ReviewsRepositories(context);
            ReviewsList = GetAllReviews();
            CurrentReviews = ReviewsList.FirstOrDefault();
        }
        public ReviewsViewModel(ReviewsDbContext context, int reviewsId)
        {
            _repo = new ReviewsRepositories(context);
            ReviewsList = GetAllReviews();

            if (reviewsId > 0)
            {
                CurrentReviews = GetReviews(reviewsId);
            }
            else
            {
                CurrentReviews = new ReviewsModel();
            }
        }
        public void SaveReviews(ReviewsModel reviews)
        {
            if (reviews.ReviewsID > 0)
            {
                _repo.Update(reviews);
            }
            else
            {
                reviews.ReviewsID = _repo.Create(reviews);
            }
            ReviewsList = GetAllReviews();
            CurrentReviews = GetReviews(reviews.ReviewsID);
        }
        public void RemoveReviews(int reviewsId)
        {
            _repo.Delete(reviewsId);
            ReviewsList = GetAllReviews();
            CurrentReviews = ReviewsList.FirstOrDefault();
        }
        public List<ReviewsModel> GetAllReviews()
        {
            return _repo.GetAllReviews();
        }
        public ReviewsModel GetReviews(int reviewsId)
        {
            return _repo.GetReviewsByID(reviewsId);
        }

    }
}
