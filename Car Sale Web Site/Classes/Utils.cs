using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Sale_Web_Site.Classes
{
    public class Utils
    {
        public static string CutText(string text, int maxLenght = 200)
        {
            if (text.Length <= maxLenght || text == null)
            {
                return text;
            }
            var shortText = text.Substring(0, maxLenght) + " ...";
            return shortText;
        }
    }
}