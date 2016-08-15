using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_Sale_Web_Site.Extensions;
using Car_Sale_Web_Site.Models;
using PagedList;

namespace Car_Sale_Web_Site.Controllers
{
    [ValidateInput(false)]
    public class PostCarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult MyCars(int page = 1, int pageSize = 5)
        {
            List<PostCar> listCars = db.PostCar.Where(a => a.Author_UserName == User.Identity.Name).ToList();
            PagedList<PostCar> model = new PagedList<PostCar>(listCars, page, pageSize);
            return View(model);
        }

        // GET: PostCars
        public ActionResult Index(int page = 1,int pageSize=5)
        {
            List<PostCar> listCars = db.PostCar.OrderByDescending(a => a.Date).ThenBy(b => b.Manufacturer).ToList();
            PagedList<PostCar> model = new PagedList<PostCar>(listCars, page, pageSize);
            return View(model);
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

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarModel,CarDescription,Town,Author_UserName,Price,Date,CategoryId,DoorId,Manufacturer,FuelId,GearId,YearMin,HorsePower,ColorId,Climatronic,Climatic,Leather,ElWindows,ElMirrors,ElSeats,SeatsHeat,Audio,Retro,AllowWeels,DVDTV,Airbag,FourByFour,ABS,ESP,HallogenLights,NavigationSystem,SevenSeats,ASRTractionControl,Parktronic,Alarm,Imobilazer,CentralLocking,Insurance,Typetronic,Autopilot,TAXI,Computer,ServiceHistory,Tunning,BrandNew,SecondHand,Damaged")] PostCar model, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Photo,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    model.Files = new List<File> { avatar };
                }
                var a = model;
                model.EditedDate = DateTime.Now;
                model.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                model.Date = DateTime.Now;
                model.Author_UserName = User.Identity.Name;
                db.PostCar.Add(model);
                db.SaveChanges();
                this.AddNotification("Success! You just created new listing for your car!", NotificationType.INFO);
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
            PostCar postCar = db.PostCar.Include(s => s.Files).SingleOrDefault(s => s.Id == id);
            if (postCar == null)
            {
                return HttpNotFound();
            }
            var authors = db.Users.ToList();
            ViewBag.Authors = authors;
            return View(postCar);
        }

        // POST: PostCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Post(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carToUpdate = db.PostCar.Find(id);

            carToUpdate.Author_UserName = User.Identity.Name;
            carToUpdate.EditedDate = DateTime.Now;

            if (TryUpdateModel(carToUpdate, "",
               new string[] { "Id", "CarModel", "CarDescription", "Town", "Author_UserName", "Price", "Date", "CategoryId", "DoorId", "Manufacturer", "FuelId", "GearId", "YearMin", "HorsePower", "ColorId", "Climatronic", "Climatic", "Leather", "ElWindows", "ElMirrors", "ElSeats", "SeatsHeat", "Audio", "Retro", "AllowWeels", "DVDTV", "Airbag", "FourByFour", "ABS", "ESP", "HallogenLights", "NavigationSystem", "SevenSeats", "ASRTractionControl", "Parktronic", "Alarm", "Imobilazer", "CentralLocking", "Insurance", "Typetronic", "Autopilot", "TAXI", "Computer", "ServiceHistory", "Tunning", "BrandNew", "SecondHand", "Damaged" }))
            {
                try
                {

                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (carToUpdate.Files.Any(f => f.FileType == FileType.Photo))
                        {
                            db.Files.Remove(carToUpdate.Files.First(f => f.FileType == FileType.Photo));
                        }
                        var avatar = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Photo,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        carToUpdate.Files = new List<File> { avatar };
                    }
                    db.Entry(carToUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    this.AddNotification("Success! Your Ad is edited.", NotificationType.INFO);
                    return RedirectToAction("MyCars");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(carToUpdate);
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
            if (postCar.Files.Any(f => f.FileType == Car_Sale_Web_Site.Models.FileType.Photo))
            {
                db.Files.RemoveRange(postCar.Files);
            }
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
