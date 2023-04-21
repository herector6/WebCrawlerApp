using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class IndustryModel
    {
        public int IndustryID { get; set; }
        public string industry { get; set; }

        public IndustryModel(int industryID, string industry)
        {
            IndustryID = industryID;
            industry = industry;
        }
        public IndustryModel()
        {

        }
    }
}