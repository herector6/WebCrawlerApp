using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class Job_typeViewModel
    {
        private Job_typeRepositories _repo;

        public List<Job_typeModel> Job_typeList { get; set; }
        public Job_typeModel CurrentJob_type { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public Job_typeViewModel(Job_typeDbContext context)
        {
            _repo = new Job_typeRepositories(context);
            Job_typeList = GetAllJob_type();
            CurrentJob_type = Job_typeList.FirstOrDefault();
        }
        public Job_typeViewModel(Job_typeDbContext context, int job_typeId)
        {
            _repo = new Job_typeRepositories(context);
            Job_typeList = GetAllJob_type();

            if (job_typeId > 0)
            {
                CurrentJob_type = GetJob_type(job_typeId);
            }
            else
            {
                CurrentJob_type = new Job_typeModel();
            }
        }
        public void SaveJob_type(Job_typeModel job_type)
        {
            if (job_type.Job_typeID > 0)
            {
                _repo.Update(job_type);
            }
            else
            {
                job_type.Job_typeID = _repo.Create(job_type);
            }
            Job_typeList = GetAllJob_type();
            CurrentJob_type = GetJob_type(job_type.Job_typeID);
        }
        public void RemoveJob_type(int job_typeId)
        {
            _repo.Delete(job_typeId);
            Job_typeList = GetAllJob_type();
            CurrentJob_type = Job_typeList.FirstOrDefault();
        }
        public List<Job_typeModel> GetAllJob_type()
        {
            return _repo.GetAllJob_type();
        }
        public Job_typeModel GetJob_type(int job_typeId)
        {
            return _repo.GetJob_typeByID(job_typeId);
        }

    }
}
