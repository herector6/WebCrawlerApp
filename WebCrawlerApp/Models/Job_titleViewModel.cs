using WebCrawlerApp.DataAccess.Models;
using WebCrawlerApp.DataAccess.Repositories;
using WebCrawlerApp.DataAccess.Context;

namespace WebCrawlerApp.Models
{
    public class Job_titleViewModel
    {
        private Job_titleRepositories _repo;

        public List<Job_titleModel> Job_titleList { get; set; }
        public Job_titleModel CurrentJob_title { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public Job_titleViewModel(Job_titleDbContext context)
        {
            _repo = new Job_titleRepositories(context);
            Job_titleList = GetAllJob_title();
            CurrentJob_title = Job_titleList.FirstOrDefault();
        }
        public Job_titleViewModel(Job_titleDbContext context, int job_titleId)
        {
            _repo = new Job_titleRepositories(context);
            Job_titleList = GetAllJob_title();

            if (job_titleId > 0)
            {
                CurrentJob_title = GetJob_title(job_titleId);
            }
            else
            {
                CurrentJob_title = new Job_titleModel();
            }
        }
        public void SaveJob_title(Job_titleModel job_title)
        {
            if (job_title.Job_titleID > 0)
            {
                _repo.Update(job_title);
            }
            else
            {
                job_title.Job_titleID = _repo.Create(job_title);
            }
            Job_titleList = GetAllJob_title();
            CurrentJob_title = GetJob_title(job_title.Job_titleID);
        }
        public void RemoveJob_title(int job_titleId)
        {
            _repo.Delete(job_titleId);
            Job_titleList = GetAllJob_title();
            CurrentJob_title = Job_titleList.FirstOrDefault();
        }
        public List<Job_titleModel> GetAllJob_title()
        {
            return _repo.GetAllJob_title();
        }
        public Job_titleModel GetJob_title(int job_titleId)
        {
            return _repo.GetJob_titleByID(job_titleId);
        }

    }
}
