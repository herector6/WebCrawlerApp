using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions options) : base(options)
        {

        }
        protected CompanyDbContext()
        {

        }
        public DbSet<CompanyModel> CompanyDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyModel>(
                entity =>
                {
                    entity.HasKey("CompanyID");
                    entity.Property("CompanyID");
                    entity.Property("company");
                }
                );
        }
    }
}