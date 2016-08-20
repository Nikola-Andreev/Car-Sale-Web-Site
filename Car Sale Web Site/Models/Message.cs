using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_Sale_Web_Site.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public string AuthorMsgUserName { get; set; }

        public string ToUser { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string MyMessage { get; set; }

        public DateTime CreateDate { get; set; }
    }
}