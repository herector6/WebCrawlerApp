using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class Job_DescriptionRepositories
    {
        private readonly Job_DescriptionDbContext _dbContext;

        public Job_DescriptionRepositories(Job_DescriptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Job_DescriptionModel job_Description)
        {
            _dbContext.Add(job_Description);
            _dbContext.SaveChanges();

            return job_Description.Job_DescriptionID;
        }
        public int Update(Job_DescriptionModel job_Description)
        {
            Job_DescriptionModel existingJob_Description = _dbContext.Job_DescriptionDetails.Find(job_Description.Job_DescriptionID);

            existingJob_Description.job_Description = job_Description.job_Description;

            _dbContext.SaveChanges();

            return existingJob_Description.Job_DescriptionID;
        }
        public bool Delete(int job_DescriptionId)
        {
            Job_DescriptionModel job_Description = _dbContext.Job_DescriptionDetails.Find(job_DescriptionId);
            _dbContext.Remove(job_Description);
            _dbContext.SaveChanges();

            return true;
        }
        public List<Job_DescriptionModel> GetAllJob_Description()
        {
            List<Job_DescriptionModel> job_DescriptionList = _dbContext.Job_DescriptionDetails.ToList();

            return job_DescriptionList;
        }
        public Job_DescriptionModel GetJob_DescriptionByID(int job_DescriptionId)
        {
            Job_DescriptionModel job_Description = _dbContext.Job_DescriptionDetails.Find(job_DescriptionId);

            return job_Description;
        }
    }
}
