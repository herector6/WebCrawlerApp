using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class Job_typeRepositories
    {
        private readonly Job_typeDbContext _dbContext;

        public Job_typeRepositories(Job_typeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Job_typeModel job_type)
        {
            _dbContext.Add(job_type);
            _dbContext.SaveChanges();

            return job_type.Job_typeID;
        }
        public int Update(Job_typeModel job_type)
        {
            Job_typeModel existingJob_type = _dbContext.Job_typeDetails.Find(job_type.Job_typeID);

            existingJob_type.job_type = job_type.job_type;

            _dbContext.SaveChanges();

            return existingJob_type.Job_typeID;
        }
        public bool Delete(int job_typeId)
        {
            Job_typeModel job_type = _dbContext.Job_typeDetails.Find(job_typeId);
            _dbContext.Remove(job_type);
            _dbContext.SaveChanges();

            return true;
        }
        public List<Job_typeModel> GetAllJob_type()
        {
            List<Job_typeModel> job_typeList = _dbContext.Job_typeDetails.ToList();

            return Job_typeList;
        }
        public Job_typeModel GetJob_typeByID(int job_typeId)
        {
            Job_typeModel job_type = _dbContext.Job_typeDetails.Find(job_typeId);

            return job_type;
        }
    }
}
