using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class Salary_informationModel
    {
        public int Salary_informationID { get; set; }
        public string salary_information { get; set; }

        public Salary_informationModel(int salary_informationID, string salary_information)
        {
            Salary_informationID = salary_informationID;
            salary_information = salary_information;
        }
        public Salary_informationModel()
        {

        }
    }
}
