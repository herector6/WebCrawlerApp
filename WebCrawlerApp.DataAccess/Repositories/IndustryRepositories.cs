using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class IndustryRepositories
    {
        private readonly IndustryDbContext _dbContext;

        public IndustryRepositories(IndustryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(IndustryModel industry)
        {
            _dbContext.Add(industry);
            _dbContext.SaveChanges();

            return industry.IndustryID;
        }
        public int Update(IndustryModel industry)
        {
            IndustryModel existingIndustry = _dbContext.IndustryDetails.Find(industry.IndustryID);

            existingIndustry.industry = industry.industry;

            _dbContext.SaveChanges();

            return existingIndustry.IndustryID;
        }
        public bool Delete(int benfitsId)
        {
            IndustryModel industry = _dbContext.IndustryDetails.Find(benfitsId);
            _dbContext.Remove(industry);
            _dbContext.SaveChanges();

            return true;
        }
        public List<IndustryModel> GetAllIndustry()
        {
            List<IndustryModel> industryList = _dbContext.IndustryDetails.ToList();

            return industryList;
        }
        public IndustryModel GetIndustryByID(int industryId)
        {
            IndustryModel industry = _dbContext.IndustryDetails.Find(industryId);

            return industry;
        }
    }
}
