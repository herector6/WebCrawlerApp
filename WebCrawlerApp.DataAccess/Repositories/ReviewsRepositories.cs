using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class ReviewsRepositories
    {
        private readonly ReviewsDbContext _dbContext;

        public ReviewsRepositories(ReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(ReviewsModel reviews)
        {
            _dbContext.Add(reviews);
            _dbContext.SaveChanges();

            return reviews.ReviewsID;
        }
        public int Update(ReviewsModel reviews)
        {
            ReviewsModel existingReviews = _dbContext.ReviewsDetails.Find(reviews.ReviewsID);

            existingReviews.reviews = reviews.reviews;

            _dbContext.SaveChanges();

            return existingReviews.ReviewsID;
        }
        public bool Delete(int reviewsId)
        {
            ReviewsModel reviews = _dbContext.ReviewsDetails.Find(reviewsId);
            _dbContext.Remove(reviews);
            _dbContext.SaveChanges();

            return true;
        }
        public List<ReviewsModel> GetAllReviews()
        {
            List<ReviewsModel> reviewsList = _dbContext.ReviewsDetails.ToList();

            return reviewsList;
        }
        public ReviewsModel GetReviewsByID(int reviewsId)
        {
            ReviewsModel reviews = _dbContext.ReviewsDetails.Find(reviewsId);

            return reviews;
        }
    }
}
