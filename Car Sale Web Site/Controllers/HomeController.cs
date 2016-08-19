using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Sale_Web_Site.Models;
using PagedList;
using System.Data.Entity;
using System.IO.Compression;
using Newtonsoft.Json;
using System.Text;
using System.IO;


namespace Car_Sale_Web_Site.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var cars = db.PostCar.Include(c => c.Author).OrderByDescending(p => p.Date).Take(6).ToList();
            var count = db.PostCar.Count();
            ViewBag.Count = count;
            var model = new Ordered { CarsOrdered = cars, };
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult QuickSearch(Ordered values, int page = 1, int pageSize = 5)
        {

            if (values.Car != null)
            {
                bool flag = false;
                List<PostCar> result = new List<PostCar>();
                List<PostCar> model = new List<PostCar>(result);
                if (values.Car.Manufacturer != null)
                {
                    result = db.PostCar.Where(a => a.Manufacturer == values.Car.Manufacturer).ToList();
                }
                List<PostCar> carModel = new List<PostCar>();
                if (values.Car.CarModel != null)
                {
                    carModel = db.PostCar.Where(a => a.CarModel == values.Car.CarModel).ToList();
                }
                List<PostCar> carCategory = new List<PostCar>();
                if (values.Car.CategoryId != 0)
                {
                    carCategory = db.PostCar.Where(a => a.CategoryId == values.Car.CategoryId).ToList();
                }
                List<PostCar> carPrice = new List<PostCar>();
                if (values.Car.Price != 0 || values.Car.PriceMax != 0)
                {
                    if (values.Car.Price != 0 && values.Car.PriceMax != 0)
                    {
                        carPrice = db.PostCar.Where(a => a.Price >= values.Car.Price && a.Price <= values.Car.PriceMax).ToList();
                    }
                    else
                    {
                        if (values.Car.Price != 0)
                        {
                            carPrice = db.PostCar.Where(a => a.Price >= values.Car.Price).ToList();
                        }
                        else
                        {
                            carPrice = db.PostCar.Where(a => a.Price <= values.Car.PriceMax).ToList();
                        }
                    }
                }
                List<PostCar> carYear = new List<PostCar>();
                if (values.Car.YearMin != 0 || values.Car.YearMax != 0)
                {
                    if (values.Car.YearMin != 0 && values.Car.YearMax != 0)
                    {
                        carYear = db.PostCar.Where(a => a.YearMin >= values.Car.YearMin && a.YearMin <= values.Car.YearMax).ToList();
                    }
                    else
                    {
                        if (values.Car.YearMin != 0)
                        {
                            carYear = db.PostCar.Where(a => a.YearMin >= values.Car.YearMin).ToList();
                        }
                        else
                        {
                            carYear = db.PostCar.Where(a => a.YearMin <= values.Car.YearMax).ToList();
                        }
                    }
                }
                List<PostCar> carTown = new List<PostCar>();
                if (values.Car.Town != null || values.Car.Town != null)
                {
                    carTown = db.PostCar.Where(a => a.Town == values.Car.Town).ToList();
                }

                if (result.Count > 0)
                {
                    flag = true;
                    if (carModel.Count > 0 || values.Car.CarModel != null)
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carModel.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }
                    if (carCategory.Count > 0 || values.Car.CategoryId != 0)
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carCategory.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }
                    if (carPrice.Count > 0 || (values.Car.Price != 0 || values.Car.PriceMax != 0))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carPrice.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }
                    if (carYear.Count > 0 || (values.Car.YearMin != 0 || values.Car.YearMax != 0))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carYear.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }
                    if (carTown.Count > 0 || (values.Car.Town != null))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carTown.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }
                    model = new List<PostCar>(result.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                else if (carModel.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carCategory.Count > 0 || values.Car.CategoryId != 0)
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carCategory.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }
                    if (carPrice.Count > 0 || (values.Car.Price != 0 || values.Car.PriceMax != 0))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carPrice.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }
                    if (carYear.Count > 0 || (values.Car.YearMin != 0 || values.Car.YearMax != 0))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carYear.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }
                    if (carTown.Count > 0 || (values.Car.Town != null))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carTown.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }
                    model = new List<PostCar>(carModel.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                else if (carTown.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carCategory.Count > 0 || values.Car.CategoryId != 0)
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carCategory.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carPrice.Count > 0 || (values.Car.Price != 0 || values.Car.PriceMax != 0))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carPrice.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }
                    if (carYear.Count > 0 || (values.Car.YearMin != 0 || values.Car.YearMax != 0))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carYear.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }
                    model = new List<PostCar>(carTown.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                else if (carCategory.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carPrice.Count > 0 || (values.Car.Price != 0 || values.Car.PriceMax != 0))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carPrice.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }
                    if (carYear.Count > 0 || (values.Car.YearMin != 0 || values.Car.YearMax != 0))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carYear.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }
                    model = new List<PostCar>(carCategory.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                else if (carPrice.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carYear.Count > 0 || (values.Car.YearMin != 0 || values.Car.YearMax != 0))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carYear.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }
                    model = new List<PostCar>(carPrice.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                else if (carYear.Count > 0 && flag == false)
                {
                    flag = true;
                    model = new List<PostCar>(carYear.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                PagedList<PostCar> paged = new PagedList<PostCar>(model, page, pageSize);
                var output = new Ordered { CarsPaged = paged, Car = values.Car, CarsOrdered = model };
                TempData["ModelName"] = output;
                return View(output);
            }
            else
            {
                Ordered test = (Ordered)TempData["ModelName"];
                PagedList<PostCar> paged = new PagedList<PostCar>(test.CarsOrdered, page, pageSize);
                var output = new Ordered { CarsPaged = paged, CarsOrdered = test.CarsOrdered };
                TempData["ModelName"] = output;
                return View(output);
            }
        }
    }
}