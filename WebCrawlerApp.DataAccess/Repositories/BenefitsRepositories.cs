using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class BenefitsRepositories
    {
        private readonly BenefitsDbContext _dbContext;

        public BenefitsRepositories(BenefitsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(BenefitsModel benefits)
        {
            _dbContext.Add(benefits);
            _dbContext.SaveChanges();

            return benefits.BenefitsID;
        }
        public int Update(BenefitsModel benefits)
        {
            BenefitsModel existingBenefits = _dbContext.BenefitsDetails.Find(benefits.BenefitsID);

            existingBenefits.benefits = benefits.benefits;

            _dbContext.SaveChanges();

            return existingBenefits.BenefitsID;
        }
        public bool Delete(int benefitsId)
        {
            BenefitsModel benefits = _dbContext.BenefitsDetails.Find(benefitsId);
            _dbContext.Remove(benefits);
            _dbContext.SaveChanges();

            return true;
        }
        public List<BenefitsModel> GetAllBenefits()
        {
            List<BenefitsModel> benefitsList = _dbContext.BenefitsDetails.ToList();

            return benefitsList;
        }
        public BenefitsModel GetBenefitsByID(int benefitsId)
        {
            BenefitsModel benefits = _dbContext.BenefitsDetails.Find(benefitsId);

            return benefits;
        }
    }
}
