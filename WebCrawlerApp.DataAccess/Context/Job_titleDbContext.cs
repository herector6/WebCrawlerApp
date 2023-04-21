using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class Job_titleDbContext : DbContext
    {
        public Job_titleDbContext(DbContextOptions options) : base(options)
        {

        }
        protected Job_titleDbContext()
        {

        }
        public DbSet<Job_titleModel> Job_titleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job_titleModel>(
                entity =>
                {
                    entity.HasKey("Job_titleID");
                    entity.Property("Job_titleID");
                    entity.Property("job_title");
                }
                );
        }
    }
}
