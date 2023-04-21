using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class Job_DescriptionModel
    {
        public int Job_DescriptionID { get; set; }
        public string job_Description { get; set; }

        public Job_DescriptionModel(int job_DescriptionID, string job_Description)
        {
            Job_DescriptionID = job_DescriptionID;
            job_Description = job_Description;
        }
        public Job_DescriptionModel()
        {

        }
    }
}
