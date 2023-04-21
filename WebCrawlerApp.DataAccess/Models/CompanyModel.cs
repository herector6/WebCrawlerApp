using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class CompanyModel
    {
        public int CompanyID { get; set; }
        public string company { get; set; }

        public CompanyModel(int companyID, string company)
        {
            CompanyID = companyID;
            company = company;
        }
        public CompanyModel()
        {

        }
    }
}