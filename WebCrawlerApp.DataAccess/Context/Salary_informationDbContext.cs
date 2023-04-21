using Microsoft.EntityFrameworkCore;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Context
{
    public class Salary_informationDbContext : DbContext
    {
        public Salary_informationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected Salary_informationDbContext()
        {

        }
        public DbSet<Salary_informationModel> Salary_informationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salary_informationModel>(
                entity =>
                {
                    entity.HasKey("Salary_informationID");
                    entity.Property("Salary_informationID");
                    entity.Property("salary_information");
                }
                );
        }
    }
}
