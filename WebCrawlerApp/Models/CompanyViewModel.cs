using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class CompanyViewModel
    {
        private CompanyRepositories _repo;

        public List<CompanyModel> CompanyList { get; set; }
        public CompanyModel CurrentCompany { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public CompanyViewModel(CompanyDbContext context)
        {
            _repo = new CompanyRepositories(context);
            CompanyList = GetAllCompany();
            CurrentCompany = CompanyList.FirstOrDefault();
        }
        public CompanyViewModel(CompanyDbContext context, int companyId)
        {
            _repo = new CompanyRepositories(context);
            CompanyList = GetAllCompany();

            if (companyId > 0)
            {
                CurrentCompany = GetCompany(companyId);
            }
            else
            {
                CurrentCompany = new CompanyModel();
            }
        }
        public void SaveCompany(CompanyModel company)
        {
            if (company.CompanyID > 0)
            {
                _repo.Update(company);
            }
            else
            {
                company.CompanyID = _repo.Create(company);
            }
            CompanyList = GetAllCompany();
            CurrentCompany = GetCompany(company.CompanyID);
        }
        public void RemoveCompany(int companyId)
        {
            _repo.Delete(companyId);
            CompanyList = GetAllCompany();
            CurrentCompany = CompanyList.FirstOrDefault();
        }
        public List<CompanyModel> GetAllCompany()
        {
            return _repo.GetAllCompany();
        }
        public CompanyModel GetCompany(int companyId)
        {
            return _repo.GetCompanyByID(companyId);
        }

    }
}