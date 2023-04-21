using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class Job_locationDbContext : DbContext
    {
        public Job_locationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected Job_locationDbContext()
        {

        }
        public DbSet<Job_locationModel> Job_locationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job_locationModel>(
                entity =>
                {
                    entity.HasKey("Job_locationID");
                    entity.Property("Job_locationID");
                    entity.Property("job_location");
                }
                );
        }
    }
}
