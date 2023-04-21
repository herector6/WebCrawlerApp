using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class IndustryDbContext : DbContext
    {
        public IndustryDbContext(DbContextOptions options) : base(options)
        {

        }
        protected IndustryDbContext()
        {

        }
        public DbSet<IndustryModel> IndustryDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndustryModel>(
                entity =>
                {
                    entity.HasKey("IndustryID");
                    entity.Property("IndustryID");
                    entity.Property("industry");
                }
                );
        }
    }
}
