using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_Sale_Web_Site.Models
{
    public class PostCar
    {
        public PostCar()
        {
            this.Date = DateTime.Now; 
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModel { get; set; }

        //ADD PRICE, CAR IMAGE

       // [Required]
        [StringLength(50)]
        public string Town { get; set; }

        [Required]
        [StringLength(500)]
        public string CarDescription { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public ApplicationUser Author { get; set; }
    }
}