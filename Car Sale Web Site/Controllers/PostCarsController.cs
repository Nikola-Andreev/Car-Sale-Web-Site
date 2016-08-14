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

        public ActionResult Search( )
        {           
            return View();
        }

        [HttpPost]
        public ActionResult SearchedCars([Bind(Include = "PriceMax,HorsePowerMax,YearMaximum,Id,CarModel,CarDescription,Town,Author_UserName,Price,Date,CategoryId,DoorId,Manufacturer,FuelId,GearId,YearId,HorsePower,ColorId,Climatronic,Climatic,Leather,ElWindows,ElMirrors,ElSeats,SeatsHeat,Audio,Retro,AllowWeels,DVDTV,Airbag,FourByFour,ABS,ESP,HallogenLights,NavigationSystem,SevenSeats,ASRTractionControl,Parktronic,Alarm,Imobilazer,CentralLocking,Insurance,Typetronic,Autopilot,TAXI,Computer,ServiceHistory,Tunning,BrandNew,SecondHand,Damaged")] PostCar values, int page = 1, int pageSize = 5)
        {
            List<PostCar> result = new List<PostCar>();
            if (values.Manufacturer!=null)
            {
                result = db.PostCar.Where(a => a.Manufacturer == values.Manufacturer).ToList();
            }
            if (values.CarModel != null)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.CarModel == values.CarModel).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
                           
            }

            if (values.Town != null)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Town == values.Town).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.CategoryId != 0)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.CategoryId == values.CategoryId).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.DoorId != 0)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.DoorId == values.DoorId).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.FuelId != 0)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.FuelId == values.FuelId).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.GearId != 0)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.GearId == values.GearId).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.YearId != 0 || values.YearMaximum != 0)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.YearId.ToString().CompareTo(values.YearId.ToString()) != -1 && a.YearId.ToString().CompareTo(values.YearMaximum.ToString()) !=1).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Price != 0 || values.PriceMax != 0)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Price >= values.Price && a.Price <= values.PriceMax ).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.HorsePower != 0 || values.HorsePowerMax != 0)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.HorsePower >= values.HorsePower || a.HorsePower <= values.HorsePowerMax).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.ColorId != 0)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.ColorId == values.ColorId).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Climatronic == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Climatronic == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Climatic == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Climatic == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Insurance == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Insurance == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Leather == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Leather == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.ElWindows == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.ElWindows == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Typetronic == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Typetronic == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }
            if (values.ElSeats == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.ElSeats == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.SeatsHeat == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.SeatsHeat == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Autopilot == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Autopilot == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Audio == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Audio == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Retro == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Retro == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.TAXI == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.TAXI == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.AllowWeels == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.AllowWeels == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.DVDTV == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.DVDTV == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Computer == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Computer == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Airbag == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Airbag == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.FourByFour == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.FourByFour == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.ServiceHistory == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.ServiceHistory == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.ABS == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.ABS == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.ESP == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.ESP == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Tunning == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Tunning == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.HallogenLights == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.HallogenLights == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.NavigationSystem == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.NavigationSystem == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.ElMirrors == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.ElMirrors == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.SevenSeats == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.SevenSeats == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.ASRTractionControl == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.ASRTractionControl == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.BrandNew == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.BrandNew == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Parktronic == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Parktronic == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Alarm == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Alarm == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.SecondHand == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.SecondHand == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Imobilazer == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Imobilazer == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.CentralLocking == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.CentralLocking == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            if (values.Damaged == true)
            {
                List<PostCar> cars = db.PostCar.Where(a => a.Damaged == true).ToList();
                if (result.Count == 0)
                {
                    result.AddRange(cars);
                }
                else
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int s = 0; s < cars.Count; s++)
                        {
                            if (cars[s] != result[i])
                            {
                                result.Add(cars[s]);
                            }
                        }
                    }
                }
            }

            PagedList<PostCar> model = new PagedList<PostCar>(result, page, pageSize);

            return View(model);
        }

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
            List<PostCar> listCars = db.PostCar.ToList();
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
        public ActionResult Create([Bind(Include = "Id,CarModel,CarDescription,Town,Author_UserName,Price,Date,CategoryId,DoorId,Manufacturer,FuelId,GearId,YearId,HorsePower,ColorId,Climatronic,Climatic,Leather,ElWindows,ElMirrors,ElSeats,SeatsHeat,Audio,Retro,AllowWeels,DVDTV,Airbag,FourByFour,ABS,ESP,HallogenLights,NavigationSystem,SevenSeats,ASRTractionControl,Parktronic,Alarm,Imobilazer,CentralLocking,Insurance,Typetronic,Autopilot,TAXI,Computer,ServiceHistory,Tunning,BrandNew,SecondHand,Damaged")] PostCar model, HttpPostedFileBase upload)
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
                this.AddNotification("Success! You just added a new listing!", NotificationType.INFO);
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
        public ActionResult Edit([Bind(Include = "Id,CarModel,CarDescription,Town,Author_UserName,Price,Date,CategoryId,DoorId,Manufacturer,FuelId,GearId,YearId,HorsePower,ColorId,Climatronic,Climatic,Leather,ElWindows,ElMirrors,ElSeats,SeatsHeat,Audio,Retro,AllowWeels,DVDTV,Airbag,FourByFour,ABS,ESP,HallogenLights,NavigationSystem,SevenSeats,ASRTractionControl,Parktronic,Alarm,Imobilazer,CentralLocking,Insurance,Typetronic,Autopilot,TAXI,Computer,ServiceHistory,Tunning,BrandNew,SecondHand,Damaged")] PostCar postCar, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                postCar.AuthorId = db.PostCar.Find(postCar.Id).AuthorId;
                postCar.Author_UserName = User.Identity.Name;
                postCar.Date = db.PostCar.Find(postCar.Id).Date;
                postCar.EditedDate = DateTime.Now;
                var local = db.Set<PostCar>().Local.FirstOrDefault(f => f.Id == postCar.Id);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }


                    if (upload != null && upload.ContentLength > 0)
                {
                    if (db.PostCar.Find(postCar.Id).Files.Any(f => f.FileType == FileType.Photo))
                    {
                        db.Files.Remove(db.PostCar.Find(postCar.Id).Files.First(f => f.FileType == FileType.Photo));
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
                    db.PostCar.Find(postCar.Id).Files = new List<File> { avatar };
                }


                db.Entry(postCar).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification("Success! Your Ad is edited.", NotificationType.INFO);
                return RedirectToAction("MyCars");
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
