using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class Company_sizeRepositories
    {
        private readonly Company_sizeDbContext _dbContext;

        public Company_sizeRepositories(Company_sizeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Company_sizeModel company_size)
        {
            _dbContext.Add(company_size);
            _dbContext.SaveChanges();

            return company_size.Company_sizeID;
        }
        public int Update(Company_sizeModel company_size)
        {
            Company_sizeModel existingCompany_size = _dbContext.Company_sizeDetails.Find(company_size.Company_sizeID);

            existingCompany_size.company_size = company_size.company_size;

            _dbContext.SaveChanges();

            return existingCompany_size.Company_sizeID;
        }
        public bool Delete(int benfitsId)
        {
            Company_sizeModel company_size = _dbContext.Company_sizeDetails.Find(benfitsId);
            _dbContext.Remove(company_size);
            _dbContext.SaveChanges();

            return true;
        }
        public List<Company_sizeModel> GetAllCompany_size()
        {
            List<Company_sizeModel> company_sizeList = _dbContext.Company_sizeDetails.ToList();

            return company_sizeList;
        }
        public Company_sizeModel GetCompany_sizeByID(int company_sizeId)
        {
            Company_sizeModel company_size = _dbContext.Company_sizeDetails.Find(company_sizeId);

            return company_size;
        }
    }
}
