using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class Company_sizeDbContext : DbContext
    {
        public Company_sizeDbContext(DbContextOptions options) : base(options)
        {

        }
        protected Company_sizeDbContext()
        {

        }
        public DbSet<Company_sizeModel> Company_sizeDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company_sizeModel>(
                entity =>
                {
                    entity.HasKey("Company_sizeID");
                    entity.Property("Company_sizeID");
                    entity.Property("company_size");
                }
                );
        }
    }
}