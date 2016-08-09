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
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModel { get; set; }


        //[Required]
        [StringLength(50)]
        public string Town { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string CarDescription { get; set; }

       
        public DateTime Date { get; set; }

        [ForeignKey("Author_Id")]
        public ApplicationUser Author { get; set; }

        public string Author_Id { get; set; }
        public string Author_UserName { get; set; }

        [Required]
        public int Price { get; set; }

        public DateTime CarYear { get; set; }

    }
}