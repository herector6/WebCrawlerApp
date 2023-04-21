using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class Job_typeModel
    {
        public int Job_typeID { get; set; }
        public string job_type { get; set; }

        public Job_typeModel(int job_typeID, string job_type)
        {
            Job_typeID = job_typeID;
            job_type = job_type;
        }
        public Job_typeModel()
        {

        }
    }
}
