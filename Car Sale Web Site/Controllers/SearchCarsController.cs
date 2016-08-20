using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Sale_Web_Site.Models;
using PagedList;

namespace Car_Sale_Web_Site.Controllers
{
    public class SearchCarsController : BaseController
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchedCars(Ordered values, int page = 1, int pageSize = 5)
        {
            if (values.Car != null)
            {
                bool flag = false;
                List<PostCar> result = new List<PostCar>();
                List<PostCar> model = new List<PostCar>();
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
                if (values.Car.Town != null)
                {
                    carTown = db.PostCar.Where(a => a.Town == values.Car.Town).ToList();
                }

                List<PostCar> carDoorsNumber = new List<PostCar>();
                if (values.Car.DoorId != 0)
                {
                    carDoorsNumber = db.PostCar.Where(a => a.DoorId == values.Car.DoorId).ToList();
                }

                List<PostCar> carFuelType = new List<PostCar>();
                if (values.Car.FuelId != 0)
                {
                    carFuelType = db.PostCar.Where(a => a.FuelId == values.Car.FuelId).ToList();
                }

                List<PostCar> carTransmission = new List<PostCar>();
                if (values.Car.GearId != 0)
                {
                    carTransmission = db.PostCar.Where(a => a.GearId == values.Car.GearId).ToList();
                }

                List<PostCar> carColor = new List<PostCar>();
                if (values.Car.ColorId != 0)
                {
                    carColor = db.PostCar.Where(a => a.ColorId == values.Car.ColorId).ToList();
                }

                List<PostCar> carHorsePower = new List<PostCar>();
                if (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0)
                {
                    if (values.Car.HorsePower != 0 && values.Car.HorsePowerMax != 0)
                    {
                        carHorsePower = db.PostCar.Where(a => a.HorsePower >= values.Car.HorsePower && a.HorsePower <= values.Car.HorsePowerMax).ToList();
                    }
                    else
                    {
                        if (values.Car.HorsePower != 0)
                        {
                            carHorsePower = db.PostCar.Where(a => a.HorsePower >= values.Car.HorsePower).ToList();
                        }
                        else
                        {
                            carHorsePower = db.PostCar.Where(a => a.HorsePower <= values.Car.HorsePowerMax).ToList();
                        }
                    }
                }

                List<PostCar> carClimatronic = new List<PostCar>();
                if (values.Car.Climatronic != false)
                {
                    carClimatronic = db.PostCar.Where(a => a.Climatronic == true).ToList();
                }

                List<PostCar> carClimatic = new List<PostCar>();
                if (values.Car.Climatic != false)
                {
                    carClimatic = db.PostCar.Where(a => a.Climatic == true).ToList();
                }

                List<PostCar> carInshurance = new List<PostCar>();
                if (values.Car.Insurance != false)
                {
                    carInshurance = db.PostCar.Where(a => a.Insurance == true).ToList();
                }

                List<PostCar> carLeather = new List<PostCar>();
                if (values.Car.Leather != false)
                {
                    carLeather = db.PostCar.Where(a => a.Leather == true).ToList();
                }

                List<PostCar> carElWindows = new List<PostCar>();
                if (values.Car.ElWindows != false)
                {
                    carElWindows = db.PostCar.Where(a => a.ElWindows == true).ToList();
                }

                List<PostCar> carTypetronic = new List<PostCar>();
                if (values.Car.Typetronic != false)
                {
                    carTypetronic = db.PostCar.Where(a => a.Typetronic == true).ToList();
                }

                List<PostCar> carElSeats = new List<PostCar>();
                if (values.Car.ElSeats != false)
                {
                    carElSeats = db.PostCar.Where(a => a.ElSeats == true).ToList();
                }

                List<PostCar> carSeatHeat = new List<PostCar>();
                if (values.Car.SeatsHeat != false)
                {
                    carSeatHeat = db.PostCar.Where(a => a.SeatsHeat == true).ToList();
                }

                List<PostCar> carAutopilot = new List<PostCar>();
                if (values.Car.Autopilot != false)
                {
                    carAutopilot = db.PostCar.Where(a => a.Autopilot == true).ToList();
                }

                List<PostCar> carAudio = new List<PostCar>();
                if (values.Car.Audio != false)
                {
                    carAudio = db.PostCar.Where(a => a.Audio == true).ToList();
                }

                List<PostCar> carRetro = new List<PostCar>();
                if (values.Car.Retro != false)
                {
                    carRetro = db.PostCar.Where(a => a.Retro == true).ToList();
                }

                List<PostCar> carTAXI = new List<PostCar>();
                if (values.Car.TAXI != false)
                {
                    carTAXI = db.PostCar.Where(a => a.TAXI == true).ToList();
                }

                List<PostCar> carAllowWeels = new List<PostCar>();
                if (values.Car.AllowWeels != false)
                {
                    carAllowWeels = db.PostCar.Where(a => a.AllowWeels == true).ToList();
                }

                List<PostCar> carDVD = new List<PostCar>();
                if (values.Car.DVDTV != false)
                {
                    carDVD = db.PostCar.Where(a => a.DVDTV == true).ToList();
                }

                List<PostCar> carCompiuter = new List<PostCar>();
                if (values.Car.Computer != false)
                {
                    carCompiuter = db.PostCar.Where(a => a.Computer == true).ToList();
                }

                List<PostCar> carAirBag = new List<PostCar>();
                if (values.Car.Airbag != false)
                {
                    carAirBag = db.PostCar.Where(a => a.Airbag == true).ToList();
                }

                List<PostCar> carFourByFour = new List<PostCar>();
                if (values.Car.FourByFour != false)
                {
                    carFourByFour = db.PostCar.Where(a => a.FourByFour == true).ToList();
                }

                List<PostCar> carServisHistory = new List<PostCar>();
                if (values.Car.ServiceHistory != false)
                {
                    carServisHistory = db.PostCar.Where(a => a.ServiceHistory == true).ToList();
                }

                List<PostCar> carABS = new List<PostCar>();
                if (values.Car.ABS != false)
                {
                    carABS = db.PostCar.Where(a => a.ABS == true).ToList();
                }

                List<PostCar> carESP = new List<PostCar>();
                if (values.Car.ESP != false)
                {
                    carESP = db.PostCar.Where(a => a.ESP == true).ToList();
                }

                List<PostCar> carTunning = new List<PostCar>();
                if (values.Car.Tunning != false)
                {
                    carTunning = db.PostCar.Where(a => a.Tunning == true).ToList();
                }

                List<PostCar> carHallogen = new List<PostCar>();
                if (values.Car.HallogenLights != false)
                {
                    carHallogen = db.PostCar.Where(a => a.HallogenLights == true).ToList();
                }

                List<PostCar> carNavigation = new List<PostCar>();
                if (values.Car.NavigationSystem != false)
                {
                    carNavigation = db.PostCar.Where(a => a.NavigationSystem == true).ToList();
                }

                List<PostCar> carElMirrors = new List<PostCar>();
                if (values.Car.ElMirrors != false)
                {
                    carElMirrors = db.PostCar.Where(a => a.ElMirrors == true).ToList();
                }

                List<PostCar> carSevenSeats = new List<PostCar>();
                if (values.Car.SevenSeats != false)
                {
                    carSevenSeats = db.PostCar.Where(a => a.SevenSeats == true).ToList();
                }

                List<PostCar> carTructionControll = new List<PostCar>();
                if (values.Car.ASRTractionControl != false)
                {
                    carTructionControll = db.PostCar.Where(a => a.ASRTractionControl == true).ToList();
                }

                List<PostCar> carBrandNew = new List<PostCar>();
                if (values.Car.BrandNew != false)
                {
                    carBrandNew = db.PostCar.Where(a => a.BrandNew == true).ToList();
                }

                List<PostCar> carParktronic = new List<PostCar>();
                if (values.Car.Parktronic != false)
                {
                    carParktronic = db.PostCar.Where(a => a.Parktronic == true).ToList();
                }

                List<PostCar> carAlarm = new List<PostCar>();
                if (values.Car.Alarm != false)
                {
                    carAlarm = db.PostCar.Where(a => a.Alarm == true).ToList();
                }

                List<PostCar> carSecondHand = new List<PostCar>();
                if (values.Car.SecondHand != false)
                {
                    carSecondHand = db.PostCar.Where(a => a.SecondHand == true).ToList();
                }

                List<PostCar> carImobilazer = new List<PostCar>();
                if (values.Car.Imobilazer != false)
                {
                    carImobilazer = db.PostCar.Where(a => a.Imobilazer == true).ToList();
                }

                List<PostCar> carCentrallLocking = new List<PostCar>();
                if (values.Car.CentralLocking != false)
                {
                    carCentrallLocking = db.PostCar.Where(a => a.CentralLocking == true).ToList();
                }

                List<PostCar> carDamaged = new List<PostCar>();
                if (values.Car.Damaged != false)
                {
                    carDamaged = db.PostCar.Where(a => a.Damaged == true).ToList();
                }


                // The real selecting starts here
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

                    if (carDoorsNumber.Count > 0 || (values.Car.DoorId != 0))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carDoorsNumber.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carFuelType.Count > 0 || (values.Car.FuelId != 0))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carFuelType.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carTransmission.Count > 0 || (values.Car.GearId != 0))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carTransmission.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carColor.Count > 0 || (values.Car.ColorId != 0))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carColor.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carHorsePower.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carClimatronic.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carClimatic.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carInshurance.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carLeather.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carElWindows.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carTypetronic.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carElSeats.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carSeatHeat.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carAutopilot.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carAudio.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carRetro.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carTAXI.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carAllowWeels.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carDVD.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carCompiuter.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carAirBag.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carFourByFour.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carServisHistory.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carABS.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carESP.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carTunning.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carHallogen.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carNavigation.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carElMirrors.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carSevenSeats.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carTructionControll.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carBrandNew.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carParktronic.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carAlarm.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carSecondHand.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carImobilazer.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (!carDamaged.Contains(result[i]))
                            {
                                result.Remove(result[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(result.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The second selecting starts here
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

                    if (carDoorsNumber.Count > 0 || (values.Car.DoorId != 0))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carDoorsNumber.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carFuelType.Count > 0 || (values.Car.FuelId != 0))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carFuelType.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carTransmission.Count > 0 || (values.Car.GearId != 0))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carTransmission.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carColor.Count > 0 || (values.Car.ColorId != 0))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carColor.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carHorsePower.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carClimatronic.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carClimatic.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carInshurance.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carLeather.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carElWindows.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carTypetronic.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carElSeats.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carAutopilot.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carAudio.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carRetro.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carTAXI.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carDVD.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carCompiuter.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carAirBag.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carFourByFour.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carServisHistory.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carABS.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carESP.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carTunning.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carHallogen.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carNavigation.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carElMirrors.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carTructionControll.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carBrandNew.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carParktronic.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carAlarm.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carSecondHand.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carImobilazer.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carModel.Count; i++)
                        {
                            if (!carDamaged.Contains(carModel[i]))
                            {
                                carModel.Remove(carModel[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carModel.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }


                // The third selecting starts here
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
                    if (carTown.Count > 0 || (values.Car.Town != null))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carTown.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carDoorsNumber.Count > 0 || (values.Car.DoorId != 0))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carDoorsNumber.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carFuelType.Count > 0 || (values.Car.FuelId != 0))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carFuelType.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carTransmission.Count > 0 || (values.Car.GearId != 0))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carTransmission.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carColor.Count > 0 || (values.Car.ColorId != 0))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carColor.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carHorsePower.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carClimatronic.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carClimatic.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carInshurance.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carLeather.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carElWindows.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carTypetronic.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carElSeats.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carAutopilot.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carAudio.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carRetro.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carTAXI.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carDVD.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carCompiuter.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carAirBag.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carFourByFour.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carServisHistory.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carABS.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carESP.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carTunning.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carHallogen.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carNavigation.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carElMirrors.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carTructionControll.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carBrandNew.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carParktronic.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carAlarm.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carSecondHand.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carImobilazer.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carCategory.Count; i++)
                        {
                            if (!carDamaged.Contains(carCategory[i]))
                            {
                                carCategory.Remove(carCategory[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carCategory.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }


                // The fourth selecting starts here
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
                    if (carTown.Count > 0 || (values.Car.Town != null))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carTown.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carDoorsNumber.Count > 0 || (values.Car.DoorId != 0))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carDoorsNumber.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carFuelType.Count > 0 || (values.Car.FuelId != 0))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carFuelType.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carTransmission.Count > 0 || (values.Car.GearId != 0))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carTransmission.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carColor.Count > 0 || (values.Car.ColorId != 0))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carColor.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carHorsePower.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carClimatronic.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carClimatic.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carInshurance.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carLeather.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carElWindows.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carTypetronic.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carElSeats.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carAutopilot.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carAudio.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carRetro.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carTAXI.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carDVD.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carCompiuter.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carAirBag.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carFourByFour.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carServisHistory.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carABS.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carESP.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carTunning.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carHallogen.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carNavigation.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carElMirrors.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carTructionControll.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carBrandNew.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carParktronic.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carAlarm.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carSecondHand.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carImobilazer.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carPrice.Count; i++)
                        {
                            if (!carDamaged.Contains(carPrice[i]))
                            {
                                carPrice.Remove(carPrice[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carPrice.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The fifth selecting starts here
                else if (carYear.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carTown.Count > 0 || (values.Car.Town != null))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carTown.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carDoorsNumber.Count > 0 || (values.Car.DoorId != 0))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carDoorsNumber.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carFuelType.Count > 0 || (values.Car.FuelId != 0))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carFuelType.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carTransmission.Count > 0 || (values.Car.GearId != 0))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carTransmission.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carColor.Count > 0 || (values.Car.ColorId != 0))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carColor.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carHorsePower.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carClimatronic.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carClimatic.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carInshurance.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carLeather.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carElWindows.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carTypetronic.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carElSeats.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carAutopilot.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carAudio.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carRetro.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carTAXI.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carDVD.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carCompiuter.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carAirBag.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carFourByFour.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carServisHistory.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carABS.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carESP.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carTunning.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carHallogen.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carNavigation.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carElMirrors.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carTructionControll.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carBrandNew.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carParktronic.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carAlarm.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carSecondHand.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carImobilazer.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carDamaged.Contains(carYear[i]))
                            {
                                carYear.Remove(carYear[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carYear.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The sixth selecting starts here
                else if (carTown.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carDoorsNumber.Count > 0 || (values.Car.DoorId != 0))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carDoorsNumber.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carFuelType.Count > 0 || (values.Car.FuelId != 0))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carFuelType.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carTransmission.Count > 0 || (values.Car.GearId != 0))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carTransmission.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carColor.Count > 0 || (values.Car.ColorId != 0))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carColor.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carHorsePower.Contains(carTown[i]))
                            {
                                carYear.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carClimatronic.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carClimatic.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carInshurance.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carLeather.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carElWindows.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carTypetronic.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carElSeats.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carAutopilot.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carAudio.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carRetro.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carTAXI.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carDVD.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carCompiuter.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carAirBag.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carFourByFour.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carServisHistory.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carABS.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carESP.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carTunning.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carHallogen.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carNavigation.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carElMirrors.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carYear.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carTructionControll.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carBrandNew.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carParktronic.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carAlarm.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carSecondHand.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carImobilazer.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carTown.Count; i++)
                        {
                            if (!carDamaged.Contains(carTown[i]))
                            {
                                carTown.Remove(carTown[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carTown.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                else // The seventh selecting starts here
                 if (carDoorsNumber.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carFuelType.Count > 0 || (values.Car.FuelId != 0))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carFuelType.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carTransmission.Count > 0 || (values.Car.GearId != 0))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carTransmission.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carColor.Count > 0 || (values.Car.ColorId != 0))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carColor.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carHorsePower.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carClimatronic.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carClimatic.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carInshurance.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carLeather.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carElWindows.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carTypetronic.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carElSeats.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carAutopilot.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carAudio.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carRetro.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carTAXI.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carDVD.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carCompiuter.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carAirBag.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carFourByFour.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carServisHistory.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carABS.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carESP.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carTunning.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carHallogen.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carNavigation.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carElMirrors.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carTructionControll.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carBrandNew.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carParktronic.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carAlarm.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carSecondHand.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carImobilazer.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carDoorsNumber.Count; i++)
                        {
                            if (!carDamaged.Contains(carDoorsNumber[i]))
                            {
                                carDoorsNumber.Remove(carDoorsNumber[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carDoorsNumber.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }


                // The eight selecting starts here
                else if (carFuelType.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carTransmission.Count > 0 || (values.Car.GearId != 0))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carTransmission.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carColor.Count > 0 || (values.Car.ColorId != 0))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carColor.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carHorsePower.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carClimatronic.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carClimatic.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carInshurance.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carLeather.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carElWindows.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carTypetronic.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carElSeats.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carAutopilot.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carAudio.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carRetro.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carTAXI.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carDVD.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carCompiuter.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carAirBag.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carFourByFour.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carServisHistory.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carABS.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carESP.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carTunning.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carHallogen.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carNavigation.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carElMirrors.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carTructionControll.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carBrandNew.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carParktronic.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carAlarm.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carSecondHand.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carImobilazer.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carFuelType.Count; i++)
                        {
                            if (!carDamaged.Contains(carFuelType[i]))
                            {
                                carFuelType.Remove(carFuelType[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carFuelType.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));

                }

                // The nine selecting starts here
                else if (carTransmission.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carColor.Count > 0 || (values.Car.ColorId != 0))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carColor.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carHorsePower.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carClimatronic.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carClimatic.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carInshurance.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carLeather.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carElWindows.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carTypetronic.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carElSeats.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carAutopilot.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carAudio.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carRetro.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carTAXI.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carDVD.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carCompiuter.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carAirBag.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carFourByFour.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carServisHistory.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carABS.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carESP.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carTunning.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carHallogen.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carNavigation.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carElMirrors.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carTructionControll.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carBrandNew.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carParktronic.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carAlarm.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carSecondHand.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carImobilazer.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carTransmission.Count; i++)
                        {
                            if (!carDamaged.Contains(carTransmission[i]))
                            {
                                carTransmission.Remove(carTransmission[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carTransmission.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The ten selecting starts here
                else if (carColor.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carHorsePower.Count > 0 || (values.Car.HorsePower != 0 || values.Car.HorsePowerMax != 0))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carHorsePower.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carClimatronic.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carClimatic.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carInshurance.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carLeather.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carElWindows.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carTypetronic.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carElSeats.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carAutopilot.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carAudio.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carRetro.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carTAXI.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carDVD.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carCompiuter.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carAirBag.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carFourByFour.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carServisHistory.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carABS.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carESP.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carTunning.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carHallogen.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carNavigation.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carElMirrors.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carTructionControll.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carBrandNew.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carParktronic.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carAlarm.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carSecondHand.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carImobilazer.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carColor.Count; i++)
                        {
                            if (!carDamaged.Contains(carColor[i]))
                            {
                                carColor.Remove(carColor[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carColor.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The eleven selecting starts here
                else if (carHorsePower.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carClimatronic.Count > 0 || (values.Car.Climatronic != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carClimatronic.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carClimatic.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carInshurance.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carLeather.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carElWindows.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carTypetronic.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carElSeats.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carAutopilot.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carAudio.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carRetro.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carTAXI.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carDVD.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carCompiuter.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carAirBag.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carFourByFour.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carServisHistory.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carABS.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carESP.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carTunning.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carHallogen.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carNavigation.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carElMirrors.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carTructionControll.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carBrandNew.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carParktronic.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carAlarm.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carSecondHand.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carImobilazer.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carHorsePower.Count; i++)
                        {
                            if (!carDamaged.Contains(carHorsePower[i]))
                            {
                                carHorsePower.Remove(carHorsePower[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carHorsePower.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The twelve selecting starts here
                else if (carClimatronic.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carClimatic.Count > 0 || (values.Car.Climatic != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carClimatic.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carInshurance.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carLeather.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carElWindows.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carTypetronic.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carElSeats.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carAutopilot.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carAudio.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carRetro.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carTAXI.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carDVD.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carCompiuter.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carAirBag.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carFourByFour.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carServisHistory.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carABS.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carESP.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carTunning.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carHallogen.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carNavigation.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carElMirrors.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carTructionControll.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carBrandNew.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carParktronic.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carAlarm.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carSecondHand.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carImobilazer.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carClimatronic.Count; i++)
                        {
                            if (!carDamaged.Contains(carClimatronic[i]))
                            {
                                carClimatronic.Remove(carClimatronic[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carClimatronic.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The thirteen selecting starts here
                else if (carClimatic.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carInshurance.Count > 0 || (values.Car.Insurance != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carInshurance.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carLeather.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carElWindows.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carTypetronic.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carElSeats.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carAutopilot.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carAudio.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carRetro.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carTAXI.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carDVD.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carCompiuter.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carAirBag.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carFourByFour.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carServisHistory.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carABS.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carESP.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carTunning.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carHallogen.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carNavigation.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carElMirrors.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carTructionControll.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carBrandNew.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carParktronic.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carAlarm.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carSecondHand.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carImobilazer.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carClimatic.Count; i++)
                        {
                            if (!carDamaged.Contains(carClimatic[i]))
                            {
                                carClimatic.Remove(carClimatic[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carClimatic.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The fourteen selecting starts here
                else if (carInshurance.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carLeather.Count > 0 || (values.Car.Leather != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carLeather.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carElWindows.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carTypetronic.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carElSeats.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carAutopilot.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carAudio.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carRetro.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carTAXI.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carDVD.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carCompiuter.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carAirBag.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carFourByFour.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carServisHistory.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carABS.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carESP.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carTunning.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carHallogen.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carNavigation.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carElMirrors.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carTructionControll.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carBrandNew.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carParktronic.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carAlarm.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carSecondHand.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carImobilazer.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carInshurance.Count; i++)
                        {
                            if (!carDamaged.Contains(carInshurance[i]))
                            {
                                carInshurance.Remove(carInshurance[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carInshurance.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The fiftheen selecting starts here
                else if (carLeather.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carElWindows.Count > 0 || (values.Car.ElWindows != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carElWindows.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carTypetronic.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carElSeats.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carAutopilot.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carAudio.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carRetro.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carTAXI.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carDVD.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carCompiuter.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carAirBag.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carFourByFour.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carServisHistory.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carABS.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carESP.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carTunning.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carHallogen.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carNavigation.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carElMirrors.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carTructionControll.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carBrandNew.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carParktronic.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carAlarm.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carSecondHand.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carImobilazer.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carLeather.Count; i++)
                        {
                            if (!carDamaged.Contains(carLeather[i]))
                            {
                                carLeather.Remove(carLeather[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carLeather.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }


                // The sixteen selecting starts here
                else if (carElWindows.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carTypetronic.Count > 0 || (values.Car.Typetronic != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carTypetronic.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carElSeats.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carAutopilot.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carAudio.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carRetro.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carTAXI.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carDVD.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carCompiuter.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carAirBag.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carFourByFour.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carServisHistory.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carABS.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carESP.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carTunning.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carHallogen.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carNavigation.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carElMirrors.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carTructionControll.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carBrandNew.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carParktronic.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carAlarm.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carSecondHand.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carImobilazer.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carDamaged.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carElWindows.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The seventheen selecting starts here
                else if (carTypetronic.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carElSeats.Count > 0 || (values.Car.ElSeats != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carElSeats.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carAutopilot.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carAudio.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carRetro.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carTAXI.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carDVD.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carCompiuter.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carAirBag.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carFourByFour.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carElWindows.Count; i++)
                        {
                            if (!carServisHistory.Contains(carElWindows[i]))
                            {
                                carElWindows.Remove(carElWindows[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carABS.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carESP.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carTunning.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carHallogen.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carNavigation.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carElMirrors.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carTructionControll.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carBrandNew.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carParktronic.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carAlarm.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carSecondHand.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carImobilazer.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carTypetronic.Count; i++)
                        {
                            if (!carDamaged.Contains(carTypetronic[i]))
                            {
                                carTypetronic.Remove(carTypetronic[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carTypetronic.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }


                // The eighteen selecting starts here
                else if (carElSeats.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carSeatHeat.Count > 0 || (values.Car.SeatsHeat != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carSeatHeat.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carAutopilot.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carAudio.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carRetro.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carTAXI.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carDVD.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carCompiuter.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carAirBag.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carFourByFour.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carServisHistory.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carABS.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carESP.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carTunning.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carHallogen.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carNavigation.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carElMirrors.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carTructionControll.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carBrandNew.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carParktronic.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carAlarm.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carSecondHand.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carImobilazer.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carElSeats.Count; i++)
                        {
                            if (!carDamaged.Contains(carElSeats[i]))
                            {
                                carElSeats.Remove(carElSeats[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carElSeats.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The nintheen selecting starts here
                else if (carSeatHeat.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carAutopilot.Count > 0 || (values.Car.Autopilot != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carAutopilot.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carAudio.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carRetro.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carTAXI.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carDVD.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carCompiuter.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carAirBag.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carFourByFour.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carServisHistory.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carABS.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carESP.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carTunning.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carHallogen.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carNavigation.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carElMirrors.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carTructionControll.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carBrandNew.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carParktronic.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carAlarm.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carSecondHand.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carImobilazer.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carSeatHeat.Count; i++)
                        {
                            if (!carDamaged.Contains(carSeatHeat[i]))
                            {
                                carSeatHeat.Remove(carSeatHeat[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carSeatHeat.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The twenthy selecting starts here
                else if (carAutopilot.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carAudio.Count > 0 || (values.Car.Audio != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carAudio.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carRetro.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carTAXI.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carDVD.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carCompiuter.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carAirBag.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carFourByFour.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carServisHistory.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carABS.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carESP.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carTunning.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carHallogen.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carNavigation.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carElMirrors.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carTructionControll.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carBrandNew.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carParktronic.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carAlarm.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carSecondHand.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carImobilazer.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carAutopilot.Count; i++)
                        {
                            if (!carDamaged.Contains(carAutopilot[i]))
                            {
                                carAutopilot.Remove(carAutopilot[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carAutopilot.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }


                // The twenthy-first selecting starts here
                else if (carAudio.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carRetro.Count > 0 || (values.Car.Retro != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carRetro.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carTAXI.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carDVD.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carCompiuter.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carAirBag.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carFourByFour.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carServisHistory.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carABS.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carESP.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carTunning.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carHallogen.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carNavigation.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carElMirrors.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carTructionControll.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carBrandNew.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carParktronic.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carAlarm.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carSecondHand.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carImobilazer.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carAudio.Count; i++)
                        {
                            if (!carDamaged.Contains(carAudio[i]))
                            {
                                carAudio.Remove(carAudio[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carAudio.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The twenthy-second selecting starts here
                else if (carRetro.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carTAXI.Count > 0 || (values.Car.TAXI != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carTAXI.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carDVD.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carCompiuter.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carAirBag.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carFourByFour.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carServisHistory.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carABS.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carESP.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carTunning.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carHallogen.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carNavigation.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carElMirrors.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carTructionControll.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carBrandNew.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carParktronic.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carAlarm.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carSecondHand.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carImobilazer.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carRetro.Count; i++)
                        {
                            if (!carDamaged.Contains(carRetro[i]))
                            {
                                carRetro.Remove(carRetro[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carRetro.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The twenthy-third selecting starts here
                else if (carTAXI.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carAllowWeels.Count > 0 || (values.Car.AllowWeels != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carAllowWeels.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carDVD.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carCompiuter.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carAirBag.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carFourByFour.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carServisHistory.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carABS.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carESP.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carTunning.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carHallogen.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carNavigation.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carElMirrors.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carTructionControll.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carBrandNew.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carParktronic.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carAlarm.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carSecondHand.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carImobilazer.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carTAXI.Count; i++)
                        {
                            if (!carDamaged.Contains(carTAXI[i]))
                            {
                                carTAXI.Remove(carTAXI[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carTAXI.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The twenthy-fourth selecting starts here
                else if (carAllowWeels.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carDVD.Count > 0 || (values.Car.DVDTV != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carDVD.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carCompiuter.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carAirBag.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carFourByFour.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carServisHistory.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carABS.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carESP.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carTunning.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carHallogen.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carNavigation.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carElMirrors.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carTructionControll.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carBrandNew.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carParktronic.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carAlarm.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carSecondHand.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carImobilazer.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carAllowWeels.Count; i++)
                        {
                            if (!carDamaged.Contains(carAllowWeels[i]))
                            {
                                carAllowWeels.Remove(carAllowWeels[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carAllowWeels.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The twenthy-sixth selecting starts here
                else if (carDVD.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carCompiuter.Count > 0 || (values.Car.Computer != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carCompiuter.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carAirBag.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carFourByFour.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carServisHistory.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carABS.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carESP.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carTunning.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carHallogen.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carNavigation.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carElMirrors.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carTructionControll.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carBrandNew.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carParktronic.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carAlarm.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carSecondHand.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carImobilazer.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carDVD.Count; i++)
                        {
                            if (!carDamaged.Contains(carDVD[i]))
                            {
                                carDVD.Remove(carDVD[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carDVD.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The twenthy-seventh selecting starts here
                else if (carCompiuter.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carAirBag.Count > 0 || (values.Car.Airbag != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carAirBag.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carFourByFour.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carServisHistory.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carABS.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carESP.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carTunning.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carHallogen.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carNavigation.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carElMirrors.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carTructionControll.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carBrandNew.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carParktronic.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carAlarm.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carSecondHand.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carImobilazer.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carCompiuter.Count; i++)
                        {
                            if (!carDamaged.Contains(carCompiuter[i]))
                            {
                                carCompiuter.Remove(carCompiuter[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carCompiuter.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The twenthy-eight selecting starts here
                else if (carAirBag.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carFourByFour.Count > 0 || (values.Car.FourByFour != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carFourByFour.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carServisHistory.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carABS.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carESP.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carTunning.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carHallogen.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carNavigation.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carElMirrors.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carTructionControll.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carBrandNew.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carParktronic.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carAlarm.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carSecondHand.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carImobilazer.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carAirBag.Count; i++)
                        {
                            if (!carDamaged.Contains(carAirBag[i]))
                            {
                                carAirBag.Remove(carAirBag[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carAirBag.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The twenthy-ninth selecting starts here
                else if (carFourByFour.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carServisHistory.Count > 0 || (values.Car.ServiceHistory != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carServisHistory.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carABS.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carESP.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carTunning.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carHallogen.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carNavigation.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carElMirrors.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carTructionControll.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carBrandNew.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carParktronic.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carAlarm.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carSecondHand.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carImobilazer.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carFourByFour.Count; i++)
                        {
                            if (!carDamaged.Contains(carFourByFour[i]))
                            {
                                carFourByFour.Remove(carFourByFour[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carFourByFour.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The thirty selecting starts here
                else if (carServisHistory.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carABS.Count > 0 || (values.Car.ABS != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carABS.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carESP.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carTunning.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carHallogen.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carNavigation.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carElMirrors.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carTructionControll.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carBrandNew.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carParktronic.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carAlarm.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carSecondHand.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carImobilazer.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carServisHistory.Count; i++)
                        {
                            if (!carDamaged.Contains(carServisHistory[i]))
                            {
                                carServisHistory.Remove(carServisHistory[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carServisHistory.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The thirty-first selecting starts here
                else if (carABS.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carESP.Count > 0 || (values.Car.ESP != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carESP.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carTunning.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carHallogen.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carNavigation.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carElMirrors.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carTructionControll.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carBrandNew.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carParktronic.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carAlarm.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carSecondHand.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carImobilazer.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carABS.Count; i++)
                        {
                            if (!carDamaged.Contains(carABS[i]))
                            {
                                carABS.Remove(carABS[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carABS.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The thirty-second selecting starts here
                else if (carESP.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carTunning.Count > 0 || (values.Car.Tunning != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carTunning.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carHallogen.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carNavigation.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carElMirrors.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carTructionControll.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carBrandNew.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carParktronic.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carAlarm.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carSecondHand.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carImobilazer.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carESP.Count; i++)
                        {
                            if (!carDamaged.Contains(carESP[i]))
                            {
                                carESP.Remove(carESP[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carESP.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The thirty-second selecting starts here
                else if (carTunning.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carHallogen.Count > 0 || (values.Car.HallogenLights != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carHallogen.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carNavigation.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carElMirrors.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carTructionControll.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carBrandNew.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carParktronic.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carAlarm.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carSecondHand.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carImobilazer.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carTunning.Count; i++)
                        {
                            if (!carDamaged.Contains(carTunning[i]))
                            {
                                carTunning.Remove(carTunning[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carTunning.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The thirty-third selecting starts here
                else if (carHallogen.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carNavigation.Count > 0 || (values.Car.NavigationSystem != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carNavigation.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carElMirrors.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carTructionControll.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carBrandNew.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carParktronic.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carAlarm.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carSecondHand.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carImobilazer.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carHallogen.Count; i++)
                        {
                            if (!carDamaged.Contains(carHallogen[i]))
                            {
                                carHallogen.Remove(carHallogen[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carHallogen.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The thirty-fourth selecting starts here
                else if (carNavigation.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carElMirrors.Count > 0 || (values.Car.ElMirrors != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carElMirrors.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carTructionControll.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carBrandNew.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carParktronic.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carAlarm.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carSecondHand.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carImobilazer.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carNavigation.Count; i++)
                        {
                            if (!carDamaged.Contains(carNavigation[i]))
                            {
                                carNavigation.Remove(carNavigation[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carNavigation.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The thirty-fifth selecting starts here
                else if (carElMirrors.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carSevenSeats.Count > 0 || (values.Car.SevenSeats != false))
                    {
                        for (int i = 0; i < carElMirrors.Count; i++)
                        {
                            if (!carSevenSeats.Contains(carElMirrors[i]))
                            {
                                carElMirrors.Remove(carElMirrors[i]);
                                i--;
                            }
                        }
                    }

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carElMirrors.Count; i++)
                        {
                            if (!carTructionControll.Contains(carElMirrors[i]))
                            {
                                carElMirrors.Remove(carElMirrors[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carElMirrors.Count; i++)
                        {
                            if (!carBrandNew.Contains(carElMirrors[i]))
                            {
                                carElMirrors.Remove(carElMirrors[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carElMirrors.Count; i++)
                        {
                            if (!carParktronic.Contains(carElMirrors[i]))
                            {
                                carElMirrors.Remove(carElMirrors[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carElMirrors.Count; i++)
                        {
                            if (!carAlarm.Contains(carElMirrors[i]))
                            {
                                carElMirrors.Remove(carElMirrors[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carElMirrors.Count; i++)
                        {
                            if (!carSecondHand.Contains(carElMirrors[i]))
                            {
                                carElMirrors.Remove(carElMirrors[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carElMirrors.Count; i++)
                        {
                            if (!carImobilazer.Contains(carElMirrors[i]))
                            {
                                carElMirrors.Remove(carElMirrors[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carElMirrors.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carElMirrors[i]))
                            {
                                carElMirrors.Remove(carElMirrors[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carElMirrors.Count; i++)
                        {
                            if (!carDamaged.Contains(carElMirrors[i]))
                            {
                                carElMirrors.Remove(carElMirrors[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carElMirrors.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The thirty-sixth selecting starts here
                else if (carSevenSeats.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carTructionControll.Count > 0 || (values.Car.ASRTractionControl != false))
                    {
                        for (int i = 0; i < carSevenSeats.Count; i++)
                        {
                            if (!carTructionControll.Contains(carSevenSeats[i]))
                            {
                                carSevenSeats.Remove(carSevenSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carSevenSeats.Count; i++)
                        {
                            if (!carBrandNew.Contains(carSevenSeats[i]))
                            {
                                carSevenSeats.Remove(carSevenSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carSevenSeats.Count; i++)
                        {
                            if (!carParktronic.Contains(carSevenSeats[i]))
                            {
                                carSevenSeats.Remove(carSevenSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carSevenSeats.Count; i++)
                        {
                            if (!carAlarm.Contains(carSevenSeats[i]))
                            {
                                carSevenSeats.Remove(carSevenSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carSevenSeats.Count; i++)
                        {
                            if (!carSecondHand.Contains(carSevenSeats[i]))
                            {
                                carSevenSeats.Remove(carSevenSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carSevenSeats.Count; i++)
                        {
                            if (!carImobilazer.Contains(carSevenSeats[i]))
                            {
                                carSevenSeats.Remove(carSevenSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carSevenSeats.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carSevenSeats[i]))
                            {
                                carSevenSeats.Remove(carSevenSeats[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carSevenSeats.Count; i++)
                        {
                            if (!carDamaged.Contains(carSevenSeats[i]))
                            {
                                carSevenSeats.Remove(carSevenSeats[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carSevenSeats.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }


                // The thirty-seventh selecting starts here
                else if (carTructionControll.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carBrandNew.Count > 0 || (values.Car.BrandNew != false))
                    {
                        for (int i = 0; i < carTructionControll.Count; i++)
                        {
                            if (!carBrandNew.Contains(carTructionControll[i]))
                            {
                                carTructionControll.Remove(carTructionControll[i]);
                                i--;
                            }
                        }
                    }

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carTructionControll.Count; i++)
                        {
                            if (!carParktronic.Contains(carTructionControll[i]))
                            {
                                carTructionControll.Remove(carTructionControll[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carTructionControll.Count; i++)
                        {
                            if (!carAlarm.Contains(carTructionControll[i]))
                            {
                                carTructionControll.Remove(carTructionControll[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carTructionControll.Count; i++)
                        {
                            if (!carSecondHand.Contains(carTructionControll[i]))
                            {
                                carTructionControll.Remove(carTructionControll[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carTructionControll.Count; i++)
                        {
                            if (!carImobilazer.Contains(carTructionControll[i]))
                            {
                                carTructionControll.Remove(carTructionControll[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carTructionControll.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carTructionControll[i]))
                            {
                                carTructionControll.Remove(carTructionControll[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carTructionControll.Count; i++)
                        {
                            if (!carDamaged.Contains(carTructionControll[i]))
                            {
                                carTructionControll.Remove(carTructionControll[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carTructionControll.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }


                // The thirty-eight selecting starts here
                else if (carBrandNew.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carParktronic.Count > 0 || (values.Car.Parktronic != false))
                    {
                        for (int i = 0; i < carBrandNew.Count; i++)
                        {
                            if (!carParktronic.Contains(carBrandNew[i]))
                            {
                                carBrandNew.Remove(carBrandNew[i]);
                                i--;
                            }
                        }
                    }

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carBrandNew.Count; i++)
                        {
                            if (!carAlarm.Contains(carBrandNew[i]))
                            {
                                carBrandNew.Remove(carBrandNew[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carBrandNew.Count; i++)
                        {
                            if (!carSecondHand.Contains(carBrandNew[i]))
                            {
                                carBrandNew.Remove(carBrandNew[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carBrandNew.Count; i++)
                        {
                            if (!carImobilazer.Contains(carBrandNew[i]))
                            {
                                carBrandNew.Remove(carBrandNew[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carBrandNew.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carBrandNew[i]))
                            {
                                carBrandNew.Remove(carBrandNew[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carBrandNew.Count; i++)
                        {
                            if (!carDamaged.Contains(carBrandNew[i]))
                            {
                                carBrandNew.Remove(carBrandNew[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carBrandNew.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }


                // The thirty-nine selecting starts here
                else if (carParktronic.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carAlarm.Count > 0 || (values.Car.Alarm != false))
                    {
                        for (int i = 0; i < carParktronic.Count; i++)
                        {
                            if (!carAlarm.Contains(carParktronic[i]))
                            {
                                carParktronic.Remove(carParktronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carParktronic.Count; i++)
                        {
                            if (!carSecondHand.Contains(carParktronic[i]))
                            {
                                carParktronic.Remove(carParktronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carParktronic.Count; i++)
                        {
                            if (!carImobilazer.Contains(carParktronic[i]))
                            {
                                carParktronic.Remove(carParktronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carParktronic.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carParktronic[i]))
                            {
                                carParktronic.Remove(carParktronic[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carParktronic.Count; i++)
                        {
                            if (!carDamaged.Contains(carParktronic[i]))
                            {
                                carParktronic.Remove(carParktronic[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carParktronic.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }



                // The fourthy selecting starts here
                else if (carAlarm.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carSecondHand.Count > 0 || (values.Car.SecondHand != false))
                    {
                        for (int i = 0; i < carAlarm.Count; i++)
                        {
                            if (!carSecondHand.Contains(carAlarm[i]))
                            {
                                carAlarm.Remove(carAlarm[i]);
                                i--;
                            }
                        }
                    }

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carAlarm.Count; i++)
                        {
                            if (!carImobilazer.Contains(carAlarm[i]))
                            {
                                carAlarm.Remove(carAlarm[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carAlarm.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carAlarm[i]))
                            {
                                carAlarm.Remove(carAlarm[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carAlarm.Count; i++)
                        {
                            if (!carDamaged.Contains(carAlarm[i]))
                            {
                                carAlarm.Remove(carAlarm[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carAlarm.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The fourthy-first selecting starts here
                else if (carSecondHand.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carImobilazer.Count > 0 || (values.Car.Imobilazer != false))
                    {
                        for (int i = 0; i < carSecondHand.Count; i++)
                        {
                            if (!carImobilazer.Contains(carSecondHand[i]))
                            {
                                carSecondHand.Remove(carSecondHand[i]);
                                i--;
                            }
                        }
                    }

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carSecondHand.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carSecondHand[i]))
                            {
                                carSecondHand.Remove(carSecondHand[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carSecondHand.Count; i++)
                        {
                            if (!carDamaged.Contains(carSecondHand[i]))
                            {
                                carSecondHand.Remove(carSecondHand[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carSecondHand.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The fourthy-second selecting starts here
                else if (carImobilazer.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carCentrallLocking.Count > 0 || (values.Car.CentralLocking != false))
                    {
                        for (int i = 0; i < carImobilazer.Count; i++)
                        {
                            if (!carCentrallLocking.Contains(carImobilazer[i]))
                            {
                                carImobilazer.Remove(carImobilazer[i]);
                                i--;
                            }
                        }
                    }

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carImobilazer.Count; i++)
                        {
                            if (!carDamaged.Contains(carImobilazer[i]))
                            {
                                carImobilazer.Remove(carImobilazer[i]);
                                i--;
                            }
                        }
                    }
                    model = new List<PostCar>(carImobilazer.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The fourthy-third selecting starts here
                else if (carCentrallLocking.Count > 0 && flag == false)
                {
                    flag = true;

                    if (carDamaged.Count > 0 || (values.Car.Damaged != false))
                    {
                        for (int i = 0; i < carCentrallLocking.Count; i++)
                        {
                            if (!carDamaged.Contains(carCentrallLocking[i]))
                            {
                                carCentrallLocking.Remove(carCentrallLocking[i]);
                                i--;
                            }
                        }
                    }

                    model = new List<PostCar>(carCentrallLocking.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                // The fourthy-third selecting starts here
                else if (carDamaged.Count > 0 && flag == false)
                {
                    flag = true;

                    model = new List<PostCar>(carDamaged.OrderByDescending(a => a.Date).ThenBy(m => m.Manufacturer));
                }

                PagedList<PostCar> paged = new PagedList<PostCar>(model, page, pageSize);
                var output = new Ordered { CarsPaged = paged, Car = values.Car, CarsOrdered = model };
                TempData["ModelName"] = output;
                return View(output);

            }
            else
            {
                Ordered test = (Ordered)TempData["ModelName"];

                List<PostCar> result = test.CarsOrdered.OrderByDescending(a => a.Date).ThenBy(b => b.Manufacturer).ToList();

                string redirect = "SearchedCars";

                if (values.Order == Ordered.Ordering.Price_High_To_Low)
                {
                    redirect = "HighToLow";
                    result = test.CarsOrdered.OrderByDescending(a => a.Price).ToList();
                }
                else if (values.Order == Ordered.Ordering.Price_Low_To_High)
                {
                    redirect = "LowToHigh";
                    result = test.CarsOrdered.OrderBy(a => a.Price).ToList();
                }

                PagedList<PostCar> paged = new PagedList<PostCar>(result, page, pageSize);
                var output = new Ordered { CarsPaged = paged, CarsOrdered = result, Order = test.Order, redirect = redirect, Car = test.Car };
                TempData["ModelName"] = output;
                return View(output);

            }
        }
        public ActionResult LowToHigh(Ordered income, int page = 1, int pageSize = 5)
        {
            Ordered test = (Ordered)TempData["ModelName"];
            List<PostCar> listCars = test.CarsOrdered.OrderBy(a => a.Price).ToList();
            PagedList<PostCar> paged = new PagedList<PostCar>(listCars, page, pageSize);
            var model = new Ordered { CarsOrdered = listCars, CarsPaged = paged };
            TempData["ModelName"] = model;
            return View(model);
        }

        public ActionResult HighToLow(Ordered income, int page = 1, int pageSize = 5)
        {
            Ordered test = (Ordered)TempData["ModelName"];
            List<PostCar> listCars = test.CarsOrdered.OrderByDescending(a => a.Price).ToList();
            PagedList<PostCar> paged = new PagedList<PostCar>(listCars, page, pageSize);
            var model = new Ordered { CarsOrdered = listCars, CarsPaged = paged };
            TempData["ModelName"] = model;
            return View(model);
        }
    }
}
