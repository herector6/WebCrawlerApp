using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class BenefitsViewModel
    {
        private BenefitsRepositories _repo;

        public List<BenefitsModel> BenefitsList { get; set; }
        public BenefitsModel CurrentBenefits { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public BenefitsViewModel(BenefitsDbContext context)
        {
            _repo = new BenefitsRepositories(context);
            BenefitsList = GetAllBenefits();
            CurrentBenefits = BenefitsList.FirstOrDefault();
        }
        public BenefitsViewModel(BenefitsDbContext context, int benefitsId)
        {
            _repo = new BenefitsRepositories(context);
            BenefitsList = GetAllBenefits();

            if (benefitsId > 0)
            {
                CurrentBenefits = GetBenefits(benefitsId);
            }
            else
            {
                CurrentBenefits = new BenefitsModel();
            }
        }
        public void SaveBenefits(BenefitsModel benefits)
        {
            if (benefits.BenefitsID > 0)
            {
                _repo.Update(benefits);
            }
            else
            {
                benefits.BenefitsID = _repo.Create(benefits);
            }
            BenefitsList = GetAllBenefits();
            CurrentBenefits = GetBenefits(benefits.BenefitsID);
        }
        public void RemoveBenefits(int benefitsId)
        {
            _repo.Delete(benefitsId);
            BenefitsList = GetAllBenefits();
            CurrentBenefits = BenefitsList.FirstOrDefault();
        }
        public List<BenefitsModel> GetAllBenefits()
        {
            return _repo.GetAllBenefits();
        }
        public BenefitsModel GetBenefits(int benefitsId)
        {
            return _repo.GetBenefitsByID(benefitsId);
        }

    }
}
