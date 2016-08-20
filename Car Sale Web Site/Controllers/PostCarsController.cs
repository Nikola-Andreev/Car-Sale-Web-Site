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
    public class PostCarsController : BaseController
    {        
        private ApplicationDbContext db = new ApplicationDbContext();           

    [Authorize]
        public ActionResult MyCars(int page = 1, int pageSize = 5)
        {
            List<PostCar> listCars = db.PostCar.Where(a => a.Author_UserName == User.Identity.Name).OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer).ToList();
            PagedList<PostCar> model = new PagedList<PostCar>(listCars, page, pageSize);
            return View(model);
        }

        // Post: PostCars
        public ActionResult Index([Bind(Include = "CarsOrdered,CarsPaged,Order")] Ordered income, int page = 1, int pageSize = 5)
        {
            List<PostCar> listCars = db.PostCar.OrderByDescending(a => a.Date).ThenBy(b => b.Manufacturer).ToList();
            income.redirect = "Index";
            if (income.Order == Ordered.Ordering.Price_High_To_Low)
            {
                income.redirect = "HighToLow";
                listCars = db.PostCar.OrderByDescending(a => a.Price).ToList();
            }
            else if (income.Order == Ordered.Ordering.Price_Low_To_High)
            {
                income.redirect = "LowToHigh";
                listCars = db.PostCar.OrderBy(a => a.Price).ToList();
            }
            PagedList<PostCar> paged = new PagedList<PostCar>(listCars, page, pageSize);
            var model = new Ordered { CarsOrdered = listCars, CarsPaged = paged,Order = income.Order, redirect = income.redirect };

            return View(model);
        }

        public ActionResult HighToLow([Bind(Include = "CarsOrdered,CarsPaged,Order")] Ordered income, int page = 1, int pageSize = 5)
        {
            List<PostCar> listCars = db.PostCar.OrderByDescending(a => a.Price).ToList();
            PagedList<PostCar> paged = new PagedList<PostCar>(listCars, page, pageSize);
            var model = new Ordered { CarsOrdered = listCars, CarsPaged = paged };
            return View(model);
        }

        public ActionResult LowToHigh([Bind(Include = "CarsOrdered,CarsPaged,Order")] Ordered income, int page = 1, int pageSize = 5)
        {
            List<PostCar> listCars = db.PostCar.OrderBy(a => a.Price).ToList();
            PagedList<PostCar> paged = new PagedList<PostCar>(listCars, page, pageSize);
            var model = new Ordered { CarsOrdered = listCars, CarsPaged = paged };
            return View(model);
        }

        // GET: PostCars/Details/5
        public ActionResult Details(int? id)
        {
            var info = db.PostCar.Include(c => c.Author).Where(c => c.Id == id).ToList();
            ViewBag.userInfo = info;

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
        public ActionResult Create([Bind(Include = "Id,CarModel,CarDescription,Town,Author_UserName,Price,Date,CategoryId,DoorId,Manufacturer,FuelId,GearId,YearMin,HorsePower,ColorId,Climatronic,Climatic,Leather,ElWindows,ElMirrors,ElSeats,SeatsHeat,Audio,Retro,AllowWeels,DVDTV,Airbag,FourByFour,ABS,ESP,HallogenLights,NavigationSystem,SevenSeats,ASRTractionControl,Parktronic,Alarm,Imobilazer,CentralLocking,Insurance,Typetronic,Autopilot,TAXI,Computer,ServiceHistory,Tunning,BrandNew,SecondHand,Damaged")] PostCar model, HttpPostedFileBase upload0, HttpPostedFileBase upload1, HttpPostedFileBase upload2, HttpPostedFileBase upload3)
        {
           

            model.Files = new List<File>();
            if (ModelState.IsValid)
            {
                if (upload0 != null && upload0.ContentLength > 0)
                {
                    var avatar0 = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload0.FileName),
                        FileType = FileType.Photo,
                        ContentType = upload0.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload0.InputStream))
                    {
                        avatar0.Content = reader.ReadBytes(upload0.ContentLength);
                    }
                    model.Files.Add(avatar0);
                }

                if (upload1 != null && upload1.ContentLength > 0)
                {
                    var avatar1 = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload1.FileName),
                        FileType = FileType.Photo,
                        ContentType = upload1.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload1.InputStream))
                    {
                        avatar1.Content = reader.ReadBytes(upload1.ContentLength);
                    }
                    model.Files.Add(avatar1);
                }

                if (upload2 != null && upload2.ContentLength > 0)
                {
                    var avatar2 = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload2.FileName),
                        FileType = FileType.Photo,
                        ContentType = upload2.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload2.InputStream))
                    {
                        avatar2.Content = reader.ReadBytes(upload2.ContentLength);
                    }
                    model.Files.Add(avatar2);
                }

                if (upload3 != null && upload3.ContentLength > 0)
                {
                    var avatar3 = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload3.FileName),
                        FileType = FileType.Photo,
                        ContentType = upload3.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload3.InputStream))
                    {
                        avatar3.Content = reader.ReadBytes(upload3.ContentLength);
                    }
                    model.Files.Add(avatar3);
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
        public ActionResult Post(int? id, HttpPostedFileBase upload0, HttpPostedFileBase upload1, HttpPostedFileBase upload2, HttpPostedFileBase upload3)
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
                    carToUpdate.Files = new List<File>();
                    if (upload0 != null && upload0.ContentLength > 0)
                    {
                        if (carToUpdate.Files.Count > 0)
                        {
                            db.Files.Remove(carToUpdate.Files.ElementAt(0));
                        }
                        var avatar0 = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload0.FileName),
                            FileType = FileType.Photo,
                            ContentType = upload0.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload0.InputStream))
                        {
                            avatar0.Content = reader.ReadBytes(upload0.ContentLength);
                        }
                        carToUpdate.Files.Add(avatar0);
                    }

                    if (upload1 != null && upload1.ContentLength > 0)
                    {
                        if (carToUpdate.Files.Count > 1)
                        {
                            db.Files.Remove(carToUpdate.Files.ElementAt(1));
                        }
                        var avatar1 = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload1.FileName),
                            FileType = FileType.Photo,
                            ContentType = upload1.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload1.InputStream))
                        {
                            avatar1.Content = reader.ReadBytes(upload1.ContentLength);
                        }
                        carToUpdate.Files.Add(avatar1);
                    }

                   

                    if (upload2 != null && upload2.ContentLength > 0)
                    {
                        if (carToUpdate.Files.Count > 2)
                        {
                            db.Files.Remove(carToUpdate.Files.ElementAt(2));
                        }
                        var avatar2 = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload2.FileName),
                            FileType = FileType.Photo,
                            ContentType = upload2.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload2.InputStream))
                        {
                            avatar2.Content = reader.ReadBytes(upload2.ContentLength);
                        }
                        carToUpdate.Files.Add(avatar2);
                    }

                    if (upload3 != null && upload3.ContentLength > 0)
                    {
                        if (carToUpdate.Files.Count > 3)
                        {
                            db.Files.Remove(carToUpdate.Files.ElementAt(3));
                        }
                        var avatar3 = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload3.FileName),
                            FileType = FileType.Photo,
                            ContentType = upload3.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload3.InputStream))
                        {
                            avatar3.Content = reader.ReadBytes(upload3.ContentLength);
                        }
                        carToUpdate.Files.Add(avatar3);
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
