using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class Job_DescriptionViewModel
    {
        private Job_DescriptionRepositories _repo;

        public List<Job_DescriptionModel> Job_DescriptionList { get; set; }
        public Job_DescriptionModel CurrentJob_Description { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public Job_DescriptionViewModel(Job_DescriptionDbContext context)
        {
            _repo = new Job_DescriptionRepositories(context);
            Job_DescriptionList = GetAllJob_Description();
            CurrentJob_Description = Job_DescriptionList.FirstOrDefault();
        }
        public Job_DescriptionViewModel(Job_DescriptionDbContext context, int job_DescriptionId)
        {
            _repo = new Job_DescriptionRepositories(context);
            Job_DescriptionList = GetAllJob_Description();

            if (job_DescriptionId > 0)
            {
                CurrentJob_Description = GetJob_Description(job_DescriptionId);
            }
            else
            {
                CurrentJob_Description = new Job_DescriptionModel();
            }
        }
        public void SaveJob_Description(Job_DescriptionModel job_Description)
        {
            if (job_Description.Job_DescriptionID > 0)
            {
                _repo.Update(job_Description);
            }
            else
            {
                job_Description.Job_DescriptionID = _repo.Create(job_Description);
            }
            Job_DescriptionList = GetAllJob_Description();
            CurrentJob_Description = GetJob_Description(job_Description.Job_DescriptionID);
        }
        public void RemoveJob_Description(int job_DescriptionId)
        {
            _repo.Delete(job_DescriptionId);
            Job_DescriptionList = GetAllJob_Description();
            CurrentJob_Description = Job_DescriptionList.FirstOrDefault();
        }
        public List<Job_DescriptionModel> GetAllJob_Description()
        {
            return _repo.GetAllJob_Description();
        }
        public Job_DescriptionModel GetJob_Description(int job_DescriptionId)
        {
            return _repo.GetJob_DescriptionByID(job_DescriptionId);
        }

    }
}
