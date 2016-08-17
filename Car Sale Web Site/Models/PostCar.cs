using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_Sale_Web_Site.Models
{
    public class PostCar
    {
        public PostCar()
        {
            this.Date = DateTime.Now;
            this.EditedDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModel { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(50)]
        public string Town { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string CarDescription { get; set; }

        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }

        public DateTime EditedDate { get; set; }

        public string AuthorId { get; set; }

        public DateTime Date { get; set; }

        public string Author_UserName { get; set; }

        [Required]
        public int Price { get; set; }

        public int PriceMax { get; set; }

        [Required]
        public int HorsePower { get; set; }

        public int HorsePowerMax{ get; set; }

        //DROPDOWN
        public Category CategoryId { get; set; }
        public enum Category
        {
            Sedan = 1,
            Combi = 4,
            Cabrio = 6,
            Jeep = 7,
            Van = 9
        }

        public Door DoorId { get; set; }
        public enum Door
        {
            TwoThree = 1,
            FourFive = 2
        }

        public Fuel FuelId { get; set; }
        public enum Fuel
        {
            Petrol = 1,
            Diesel = 2,
            LPG = 3,
            Methane = 4,
            Hybrid = 6,
            Electric = 7
        }

        public Gear GearId { get; set; }
        public enum Gear
        {
            Hand = 1,
            Automatic = 2
        }

        public int YearMin { get; set; }

        public int YearMax { get; set; }
      
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

        public virtual ICollection<File> Files { get; set; }

    }
}