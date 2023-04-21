using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class BenefitsDbContext : DbContext
    {
        public BenefitsDbContext(DbContextOptions options) : base(options)
        {

        }
        protected BenefitsDbContext()
        {

        }
        public DbSet<BenefitsModel> BenefitsDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BenefitsModel>(
                entity =>
                {
                    entity.HasKey("BenefitsID");
                    entity.Property("BenefitsID");
                    entity.Property("benefits");
                }
                );
        }
    }
}
