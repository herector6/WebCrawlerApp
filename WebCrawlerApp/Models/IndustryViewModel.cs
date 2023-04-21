using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class IndustryViewModel
    {
        private IndustryRepositories _repo;

        public List<IndustryModel> IndustryList { get; set; }
        public IndustryModel CurrentIndustry { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public IndustryViewModel(IndustryDbContext context)
        {
            _repo = new IndustryRepositories(context);
            IndustryList = GetAllIndustry();
            CurrentIndustry = IndustryList.FirstOrDefault();
        }
        public IndustryViewModel(IndustryDbContext context, int industryId)
        {
            _repo = new IndustryRepositories(context);
            IndustryList = GetAllIndustry();

            if (industryId > 0)
            {
                CurrentIndustry = GetIndustry(industryId);
            }
            else
            {
                CurrentIndustry = new IndustryModel();
            }
        }
        public void SaveIndustry(IndustryModel industry)
        {
            if (industry.IndustryID > 0)
            {
                _repo.Update(industry);
            }
            else
            {
                industry.IndustryID = _repo.Create(industry);
            }
            IndustryList = GetAllIndustry();
            CurrentIndustry = GetIndustry(industry.IndustryID);
        }
        public void RemoveIndustry(int industryId)
        {
            _repo.Delete(industryId);
            IndustryList = GetAllIndustry();
            CurrentIndustry = IndustryList.FirstOrDefault();
        }
        public List<IndustryModel> GetAllIndustry()
        {
            return _repo.GetAllIndustry();
        }
        public IndustryModel GetIndustry(int industryId)
        {
            return _repo.GetIndustryByID(industryId);
        }

    }
}
