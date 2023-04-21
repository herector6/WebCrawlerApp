using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class Salary_informationViewModel
    {
        private Salary_informationRepositories _repo;

        public List<Salary_informationModel> Salary_informationList { get; set; }
        public Salary_informationModel CurrentSalary_information { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public Salary_informationViewModel(Salary_informationDbContext context)
        {
            _repo = new Salary_informationRepositories(context);
            Salary_informationList = GetAllSalary_information();
            CurrentSalary_information = Salary_informationList.FirstOrDefault();
        }
        public Salary_informationViewModel(Salary_informationDbContext context, int salary_informationId)
        {
            _repo = new Salary_informationRepositories(context);
            Salary_informationList = GetAllSalary_information();

            if (salary_informationId > 0)
            {
                CurrentSalary_information = GetSalary_information(salary_informationId);
            }
            else
            {
                CurrentSalary_information = new Salary_informationModel();
            }
        }
        public void SaveSalary_information(Salary_informationModel salary_information)
        {
            if (salary_information.Salary_informationID > 0)
            {
                _repo.Update(salary_information);
            }
            else
            {
                salary_information.Salary_informationID = _repo.Create(salary_information);
            }
            Salary_informationList = GetAllSalary_information();
            CurrentSalary_information = GetSalary_information(salary_information.Salary_informationID);
        }
        public void RemoveSalary_information(int salary_informationId)
        {
            _repo.Delete(salary_informationId);
            Salary_informationList = GetAllSalary_information();
            CurrentSalary_information = Salary_informationList.FirstOrDefault();
        }
        public List<Salary_informationModel> GetAllSalary_information()
        {
            return _repo.GetAllSalary_information();
        }
        public Salary_informationModel GetSalary_information(int salary_informationId)
        {
            return _repo.GetSalary_informationByID(salary_informationId);
        }

    }
}
