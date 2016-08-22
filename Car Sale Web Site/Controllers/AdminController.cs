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
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Car_Sale_Web_Site.Controllers
{
    public class AdminController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /File/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditImages(int page = 1, int pageSize = 30)
        {
            var model = db.Files.ToList();
            PagedList<File> paged = new PagedList<File>(model.OrderByDescending(a => a.FileId), page, pageSize);
            return View(paged);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
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

        [Authorize(Roles = "Admin")]
        public ActionResult Delete2(string id)
        {
            List<PostCar> userCars = db.PostCar.Where(car => car.AuthorId == id).ToList();
            foreach (var item in userCars)
            {
                if (item.Files.Any(f => f.FileType == Car_Sale_Web_Site.Models.FileType.Photo))
                {
                    db.Files.RemoveRange(item.Files);
                }
                db.PostCar.Remove(item);
            }

            ApplicationUser user = db.Users.FirstOrDefault(x => x.Id == id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("EditUsers");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            File file = db.Files.Find(id);
            db.Files.Remove(file);
            db.SaveChanges();
            return RedirectToAction("EditImages");
        }

        public ActionResult EditUsers(int page = 1, int pageSize = 10)
        {
            List<ApplicationUser> list = db.Users.OrderBy(a => a.FullName).ThenBy(b => b.UserName).ToList();
            PagedList<ApplicationUser> paged = new PagedList<ApplicationUser>(list, page, pageSize);
            return View(paged);
        }

        [Authorize]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.AddToRole(user.Id, user.role);

            db.Entry(userToUpdate).State = EntityState.Modified;
            db.SaveChanges();
            this.AddNotification("Success! The user is edited.", NotificationType.INFO);

            return RedirectToAction("EditUsers");
        }
    }
} 