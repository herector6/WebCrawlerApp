using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class BenefitsModel
    {
        public int BenefitsID { get; set; }
        public string benefits {  get; set; }

        public BenefitsModel(int benefitsID, string benefits)
        {
            BenefitsID = benefitsID;
            benefits = benefits;
        }
        public BenefitsModel()
        {

        }
    }
}
