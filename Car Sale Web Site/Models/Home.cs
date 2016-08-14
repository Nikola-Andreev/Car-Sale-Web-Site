using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Sale_Web_Site.Models
{
    public class Home
    {
        public List<PostCar> lastThreePosts { get; set; }
        public PostCar Car { get; set; }

    }
}