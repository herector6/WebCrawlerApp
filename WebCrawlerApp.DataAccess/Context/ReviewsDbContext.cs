using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class ReviewsDbContext : DbContext
    {
        public ReviewsDbContext(DbContextOptions options) : base(options)
        {

        }
        protected ReviewsDbContext()
        {

        }
        public DbSet<ReviewsModel> ReviewsDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewsModel>(
                entity =>
                {
                    entity.HasKey("ReviewsID");
                    entity.Property("ReviewsID");
                    entity.Property("reviews");
                }
                );
        }
    }
}
