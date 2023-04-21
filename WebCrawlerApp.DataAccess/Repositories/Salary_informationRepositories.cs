using WebCrawlerApp.DataAccess.Context;
using WebCrawlerApp.DataAccess.Models;

namespace WebCrawlerApp.DataAccess.Repositories
{
    public class Salary_informationRepositories
    {
        private readonly Salary_informationDbContext _dbContext;

        public Salary_informationRepositories(Salary_informationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Salary_informationModel salary_information)
        {
            _dbContext.Add(salary_information);
            _dbContext.SaveChanges();

            return salary_information.Salary_informationID;
        }
        public int Update(Salary_informationModel salary_information)
        {
            Salary_informationModel existingSalary_information = _dbContext.Salary_informationDetails.Find(salary_information.Salary_informationID);

            existingSalary_information.salary_information = salary_information.salary_information;

            _dbContext.SaveChanges();

            return existingSalary_information.Salary_informationID;
        }
        public bool Delete(int salary_informationId)
        {
            Salary_informationModel salary_information = _dbContext.Salary_informationDetails.Find(salary_informationId);
            _dbContext.Remove(salary_information);
            _dbContext.SaveChanges();

            return true;
        }
        public List<Salary_informationModel> GetAllSalary_information()
        {
            List<Salary_informationModel> salary_informationList = _dbContext.Salary_informationDetails.ToList();

            return salary_informationList;
        }
        public Salary_informationModel GetSalary_informationByID(int salary_informationId)
        {
            Salary_informationModel salary_information = _dbContext.Salary_informationDetails.Find(salary_informationId);

            return salary_information;
        }
    }
}
