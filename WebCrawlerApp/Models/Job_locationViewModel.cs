using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class Job_locationViewModel
    {
        private Job_locationRepositories _repo;

        public List<Job_locationModel> Job_locationList { get; set; }
        public Job_locationModel CurrentJob_location { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public Job_locationViewModel(Job_locationDbContext context)
        {
            _repo = new Job_locationRepositories(context);
            Job_locationList = GetAllJob_location();
            CurrentJob_location = Job_locationList.FirstOrDefault();
        }
        public Job_locationViewModel(Job_locationDbContext context, int job_locationId)
        {
            _repo = new Job_locationRepositories(context);
            Job_locationList = GetAllJob_location();

            if (job_locationId > 0)
            {
                CurrentJob_location = GetJob_location(job_locationId);
            }
            else
            {
                CurrentJob_location = new Job_locationModel();
            }
        }
        public void SaveJob_location(Job_locationModel job_location)
        {
            if (job_location.Job_locationID > 0)
            {
                _repo.Update(job_location);
            }
            else
            {
                job_location.Job_locationID = _repo.Create(job_location);
            }
            Job_locationList = GetAllJob_location();
            CurrentJob_location = GetJob_location(job_location.Job_locationID);
        }
        public void RemoveJob_location(int job_locationId)
        {
            _repo.Delete(job_locationId);
            Job_locationList = GetAllJob_location();
            CurrentJob_location = Job_locationList.FirstOrDefault();
        }
        public List<Job_locationModel> GetAllJob_location()
        {
            return _repo.GetAllJob_location();
        }
        public Job_locationModel GetJob_location(int job_locationId)
        {
            return _repo.GetJob_locationByID(job_locationId);
        }

    }
}
