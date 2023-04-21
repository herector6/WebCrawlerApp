using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class Job_DescriptionDbContext : DbContext
    {
        public Job_DescriptionDbContext(DbContextOptions options) : base(options)
        {

        }
        protected Job_DescriptionDbContext()
        {

        }
        public DbSet<Job_DescriptionModel> Job_DescriptionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job_DescriptionModel>(
                entity =>
                {
                    entity.HasKey("Job_DescriptionID");
                    entity.Property("Job_DescriptionID");
                    entity.Property("job_Description");
                }
                );
        }
    }
}