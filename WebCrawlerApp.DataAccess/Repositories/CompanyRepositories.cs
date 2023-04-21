using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class CompanyRepositories
    {
        private readonly CompanyDbContext _dbContext;

        public CompanyRepositories(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(CompanyModel company)
        {
            _dbContext.Add(company);
            _dbContext.SaveChanges();

            return company.CompanyID;
        }
        public int Update(CompanyModel company)
        {
            CompanyModel existingCompany = _dbContext.CompanyDetails.Find(company.CompanyID);

            existingCompany.company = company.company;

            _dbContext.SaveChanges();

            return existingCompany.CompanyID;
        }
        public bool Delete(int benfitsId)
        {
            CompanyModel company = _dbContext.CompanyDetails.Find(benfitsId);
            _dbContext.Remove(company);
            _dbContext.SaveChanges();

            return true;
        }
        public List<CompanyModel> GetAllCompany()
        {
            List<CompanyModel> companyList = _dbContext.CompanyDetails.ToList();

            return companyList;
        }
        public CompanyModel GetCompanyByID(int companyId)
        {
            CompanyModel company = _dbContext.CompanyDetails.Find(companyId);

            return company;
        }
    }
}