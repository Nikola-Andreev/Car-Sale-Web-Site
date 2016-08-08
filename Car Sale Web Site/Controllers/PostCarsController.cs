using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_Sale_Web_Site.Models;

namespace Car_Sale_Web_Site.Controllers
{
    [ValidateInput(false)]
    public class PostCarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PostCars
        public ActionResult Index()
        {
            return View(db.PostCar.Include(p => p.Author).ToList());
        }

        // GET: PostCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCar postCar = db.PostCar.Find(id);
            if (postCar == null)
            {
                return HttpNotFound();
            }
            return View(postCar);
        }

        // GET: PostCars/Create
        [Authorize]

        public ActionResult Create()
        {
            return View();
        }

        // POST: PostCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCar model)
        {
            if (model != null && ModelState.IsValid)
            {
                var c = new PostCar()
                {
                    CarModel = model.CarModel,
                    Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name),
                    CarDescription = model.CarDescription,
                    Town = model.Town
                };
                //postCar.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                
                db.PostCar.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

       


        // GET: PostCars/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCar postCar = db.PostCar.Find(id);
            if (postCar == null)
            {
                return HttpNotFound();
            }
            return View(postCar);
        }

        // POST: PostCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,CarModel,CarDescription,Date")] PostCar postCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postCar);
        }

        // GET: PostCars/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCar postCar = db.PostCar.Find(id);
            if (postCar == null)
            {
                return HttpNotFound();
            }
            return View(postCar);
        }

        // POST: PostCars/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostCar postCar = db.PostCar.Find(id);
            db.PostCar.Remove(postCar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
