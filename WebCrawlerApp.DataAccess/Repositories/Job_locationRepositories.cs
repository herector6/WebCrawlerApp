using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class Job_locationRepositories
    {
        private readonly Job_locationDbContext _dbContext;

        public Job_locationRepositories(Job_locationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Job_locationModel job_location)
        {
            _dbContext.Add(job_location);
            _dbContext.SaveChanges();

            return job_location.Job_locationID;
        }
        public int Update(Job_locationModel job_location)
        {
            Job_locationModel existingJob_location = _dbContext.Job_locationDetails.Find(job_location.Job_locationID);

            existingJob_location.job_location = job_location.job_location;

            _dbContext.SaveChanges();

            return existingJob_location.Job_locationID;
        }
        public bool Delete(int job_locationId)
        {
            Job_locationModel job_location = _dbContext.Job_locationDetails.Find(job_locationId);
            _dbContext.Remove(job_location);
            _dbContext.SaveChanges();

            return true;
        }
        public List<Job_locationModel> GetAllJob_location()
        {
            List<Job_locationModel> job_locationList = _dbContext.Job_locationDetails.ToList();

            return job_locationList;
        }
        public Job_locationModel GetJob_locationByID(int job_locationId)
        {
            Job_locationModel job_location = _dbContext.Job_locationDetails.Find(job_locationId);

            return job_location;
        }
    }
}
