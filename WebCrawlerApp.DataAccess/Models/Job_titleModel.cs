using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class Job_titleModel
    {
        public int Job_titleID { get; set; }
        public string job_title { get; set; }

        public Job_titleModel(int job_titleID, string job_title)
        {
            Job_titleID = job_titleID;
            job_title = job_title;
        }
        public Job_titleModel()
        {

        }
    }
}
