using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class Job_titleRepositories
    {
        private readonly Job_titleDbContext _dbContext;

        public Job_titleRepositories(Job_titleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Job_titleModel job_title)
        {
            _dbContext.Add(job_title);
            _dbContext.SaveChanges();

            return job_title.Job_titleID;
        }
        public int Update(Job_titleModel job_title)
        {
            Job_titleModel existingJob_title = _dbContext.Job_titleDetails.Find(job_title.Job_titleID);

            existingJob_title.job_title = job_title.job_title;

            _dbContext.SaveChanges();

            return existingJob_title.Job_titleID;
        }
        public bool Delete(int job_titleId)
        {
            Job_titleModel job_title = _dbContext.Job_titleDetails.Find(job_titleId);
            _dbContext.Remove(job_title);
            _dbContext.SaveChanges();

            return true;
        }
        public List<Job_titleModel> GetAllJob_title()
        {
            List<Job_titleModel> job_titleList = _dbContext.Job_titleDetails.ToList();

            return job_titleList;
        }
        public Job_titleModel GetJob_titleByID(int job_titleId)
        {
            Job_titleModel job_title = _dbContext.Job_titleDetails.Find(job_titleId);

            return job_title;
        }
    }
}
