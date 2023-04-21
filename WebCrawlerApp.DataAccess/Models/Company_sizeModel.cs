using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class Company_sizeModel
    {
        public int Company_sizeID { get; set; }
        public string company_size { get; set; }

        public Company_sizeModel(int company_sizeID, string company_size)
        {
            Company_sizeID = company_sizeID;
            company_size = company_size;
        }
        public Company_sizeModel()
        {

        }
    }
}