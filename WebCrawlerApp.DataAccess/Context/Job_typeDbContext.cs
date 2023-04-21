using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class Job_typeDbContext : DbContext
    {
        public Job_typeDbContext(DbContextOptions options) : base(options)
        {

        }
        protected Job_typeDbContext()
        {

        }
        public DbSet<Job_typeModel> Job_typeDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job_typeModel>(
                entity =>
                {
                    entity.HasKey("Job_typeID");
                    entity.Property("Job_typeID");
                    entity.Property("job_type");
                }
                );
        }
    }
}
