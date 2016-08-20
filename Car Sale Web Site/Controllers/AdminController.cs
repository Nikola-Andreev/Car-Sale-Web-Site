using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Sale_Web_Site.Models;
using System.Net;
using PagedList;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Car_Sale_Web_Site.Extensions;

namespace Car_Sale_Web_Site.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /File/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditImages()
        {
            var model = db.Files.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            File file = db.Files.Find(id);
            db.Files.Remove(file);
            db.SaveChanges();
            return RedirectToAction("EditImages");
        }

        public ActionResult EditUsers(int page = 1, int pageSize = 5)
        {
            List<ApplicationUser> list = db.Users.OrderBy(a => a.FullName).ThenBy(b => b.UserName).ToList();
            PagedList<ApplicationUser> paged = new PagedList<ApplicationUser>(list, page, pageSize);
            return View(paged);
        }

        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Edit")]
        [Authorize]
        public ActionResult Edit(ApplicationUser user)
        {
            if (user.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userToUpdate = db.Users.FirstOrDefault(x => x.Id == user.Id);

            userToUpdate.FullName = user.FullName;
            userToUpdate.UserName = user.UserName;
            userToUpdate.Email = user.Email;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.role = user.role;
            // to do 
            //if (userToUpdate.role=="Admin")
            //{
            //    userToUpdate.Roles = "Admin";
            //}

            db.Entry(userToUpdate).State = EntityState.Modified;
            db.SaveChanges();
            this.AddNotification("Success! The user is edited.", NotificationType.INFO);

            return RedirectToAction("EditUsers");
        }
    }
} 