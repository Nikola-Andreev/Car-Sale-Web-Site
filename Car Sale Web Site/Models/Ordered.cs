using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Sale_Web_Site.Models
{
    public class Ordered
    {
        public int? Page { get; set; }

        public List<PostCar> CarsOrdered { get; set; }

        public IPagedList<PostCar> CarsPaged { get; set; }

        public string redirect { get; set; }

        public Ordering Order { get; set; }
        public enum Ordering
        {
            Date_Lastest_First = 0,
            Price_Low_To_High = 1,
            Price_High_To_Low = 2,
        }
    }
}