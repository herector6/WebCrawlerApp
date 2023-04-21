using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class Company_sizeViewModel
    {
        private Company_sizeRepositories _repo;

        public List<Company_sizeModel> Company_sizeList { get; set; }
        public Company_sizeModel CurrentCompany_size { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public Company_sizeViewModel(Company_sizeDbContext context)
        {
            _repo = new Company_sizeRepositories(context);
            Company_sizeList = GetAllCompany_size();
            CurrentCompany_size = Company_sizeList.FirstOrDefault();
        }
        public Company_sizeViewModel(Company_sizeDbContext context, int company_sizeId)
        {
            _repo = new Company_sizeRepositories(context);
            Company_sizeList = GetAllCompany_size();

            if (company_sizeId > 0)
            {
                CurrentCompany_size = GetCompany_size(company_sizeId);
            }
            else
            {
                CurrentCompany_size = new Company_sizeModel();
            }
        }
        public void SaveCompany_size(Company_sizeModel company_size)
        {
            if (company_size.Company_sizeID > 0)
            {
                _repo.Update(company_size);
            }
            else
            {
                company_size.Company_sizeID = _repo.Create(company_size);
            }
            Company_sizeList = GetAllCompany_size();
            CurrentCompany_size = GetCompany_size(company_size.Company_sizeID);
        }
        public void RemoveCompany_size(int company_sizeId)
        {
            _repo.Delete(company_sizeId);
            Company_sizeList = GetAllCompany_size();
            CurrentCompany_size = Company_sizeList.FirstOrDefault();
        }
        public List<Company_sizeModel> GetAllCompany_size()
        {
            return _repo.GetAllCompany_size();
        }
        public Company_sizeModel GetCompany_size(int company_sizeId)
        {
            return _repo.GetCompany_sizeByID(company_sizeId);
        }

    }
}