using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerApp.DataAccess.Models
{
    public class ReviewsModel
    {
        public int ReviewsID { get; set; }
        public string reviews { get; set; }

        public ReviewsModel(int reviewsID, string reviews)
        {
            ReviewsID = reviewsID;
            reviews = reviews;
        }
        public ReviewsModel()
        {

        }
    }
}
