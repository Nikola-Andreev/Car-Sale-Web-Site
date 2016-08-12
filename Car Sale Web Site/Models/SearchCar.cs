using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_Sale_Web_Site.Models
{
    public class SearchCar
    {        

        [StringLength(50)]
        public string CarModel { get; set; }

        [StringLength(50)]
        public string CarMake { get; set; }

        [StringLength(50)]
        public string Town { get; set; }

        public string Author_UserName { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public int HorsePower { get; set; }

        public Category CarType { get; set; }

        public enum Category
        {
            Sedan = 1,
            Combi = 4,
            Cabrio = 6,
            Jeep = 7,
            Van = 9
        }

        public Door DoorsNumbes { get; set; }

        public enum Door
        {
            TwoThree = 1,
            FourFive = 2
        }

        public Fuel FuelType { get; set; }

        public enum Fuel
        {
            Petrol = 1,
            Diesel = 2,
            LPG = 3,
            Methane = 4,
            Hybrid = 6,
            Electric = 7
        }

        public Gear Transmission { get; set; }

        public enum Gear
        {
            Hand = 1,
            Automatic = 2
        }

        public Year YearMin { get; set; }

        public enum Year
        {
            Y2016 = 2016,
            Y2015 = 2015,
            Y2014 = 2014,
            Y2013 = 2013,
            Y2012 = 2012,
            Y2011 = 2011,
            Y2010 = 2010,
            Y2009 = 2009,
            Y2008 = 2008,
            Y2007 = 2007,
            Y2006 = 2006,
            Y2005 = 2005,
            Y2004 = 2004,
            Y2003 = 2003,
            Y2002 = 2002,
            Y2001 = 2001,
            Y2000 = 2000,
            Y1999 = 1999,
            Y1998 = 1998,
            Y1997 = 1997,
            Y1996 = 1996,
            Y1995 = 1995,
            Y1994 = 1994,
            Y1993 = 1993,
            Y1992 = 1992,
            Y1991 = 1991,
            Y1990 = 1990,
            Y1989 = 1989,
            Y1988 = 1988,
            Y1987 = 1987,
            Y1986 = 1986,
            Y1985 = 1985,
            Y1984 = 1984,
            Y1983 = 1983,
            Y1982 = 1982,
            Y1981 = 1981,
            Y1980 = 1980,
            Y1979 = 1979,
            Y1978 = 1978,
            Y1977 = 1977,
            Y1976 = 1976,
            Y1975 = 1975,
            Y1974 = 1974,
            Y1973 = 1973,
            Y1972 = 1972,
            Y1971 = 1971
        }

        public YearMax YearM { get; set; }

        public enum YearMax
        {
            Y2016 = 2016,
            Y2015 = 2015,
            Y2014 = 2014,
            Y2013 = 2013,
            Y2012 = 2012,
            Y2011 = 2011,
            Y2010 = 2010,
            Y2009 = 2009,
            Y2008 = 2008,
            Y2007 = 2007,
            Y2006 = 2006,
            Y2005 = 2005,
            Y2004 = 2004,
            Y2003 = 2003,
            Y2002 = 2002,
            Y2001 = 2001,
            Y2000 = 2000,
            Y1999 = 1999,
            Y1998 = 1998,
            Y1997 = 1997,
            Y1996 = 1996,
            Y1995 = 1995,
            Y1994 = 1994,
            Y1993 = 1993,
            Y1992 = 1992,
            Y1991 = 1991,
            Y1990 = 1990,
            Y1989 = 1989,
            Y1988 = 1988,
            Y1987 = 1987,
            Y1986 = 1986,
            Y1985 = 1985,
            Y1984 = 1984,
            Y1983 = 1983,
            Y1982 = 1982,
            Y1981 = 1981,
            Y1980 = 1980,
            Y1979 = 1979,
            Y1978 = 1978,
            Y1977 = 1977,
            Y1976 = 1976,
            Y1975 = 1975,
            Y1974 = 1974,
            Y1973 = 1973,
            Y1972 = 1972,
            Y1971 = 1971
        }


        public Color ColorId { get; set; }

        public enum Color
        {
            Beige = 12,
            Bordo = 11,
            Bronze = 14,
            Brown = 8,
            Blue = 6,
            Black = 10,
            Gold = 15,
            Green = 7,
            Grey = 9,
            Orange = 3,
            Purple = 16,
            Pink = 19,
            Red = 4,
            Silver = 13,
            Violet = 5,
            White = 1,
            Wellow = 2
        }

        //CHECKBOX
        public bool Climatronic { get; set; }
        public bool Climatic { get; set; }
        public bool Leather { get; set; }
        public bool ElWindows { get; set; }
        public bool ElMirrors { get; set; }
        public bool ElSeats { get; set; }
        public bool SeatsHeat { get; set; }
        public bool Audio { get; set; }
        public bool Retro { get; set; }
        public bool AllowWeels { get; set; }
        public bool DVDTV { get; set; }
        public bool Airbag { get; set; }

        public bool FourByFour { get; set; }
        public bool ABS { get; set; }
        public bool ESP { get; set; }

        public bool HallogenLights { get; set; }

        public bool NavigationSystem { get; set; }

        public bool SevenSeats { get; set; }
        public bool ASRTractionControl { get; set; }
        public bool Parktronic { get; set; }
        public bool Alarm { get; set; }
        public bool Imobilazer { get; set; }
        public bool CentralLocking { get; set; }
        public bool Insurance { get; set; }
        public bool Typetronic { get; set; }
        public bool Autopilot { get; set; }
        public bool TAXI { get; set; }
        public bool Computer { get; set; }
        public bool ServiceHistory { get; set; }
        public bool Tunning { get; set; }

        //Condition
        public bool BrandNew { get; set; }
        public bool SecondHand { get; set; }
        public bool Damaged { get; set; }
        //NEW


    }
}