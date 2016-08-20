using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Sale_Web_Site.Models;

namespace Car_Sale_Web_Site.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Count unread messages
            var messagez = db.Messages.Where(m => m.ToUser == User.Identity.Name).ToList();
            var unreadCount = 0;

            foreach (var date in messagez)
            {
                if (DateTime.Compare(date.ReadDate, new DateTime(2001, 1, 1)) < 0)
                {
                    unreadCount++;
                }
            }
            ViewBag.unreadMessages = unreadCount;

            base.OnActionExecuting(filterContext);
        }
    }
}