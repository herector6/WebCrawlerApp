using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class Job_locationModel
    {
        public int Job_locationID { get; set; }
        public string job_location { get; set; }

        public Job_locationModel(int job_locationID, string job_location)
        {
            Job_locationID = job_locationID;
            job_location = job_location;
        }
        public Job_locationModel()
        {

        }
    }
}
