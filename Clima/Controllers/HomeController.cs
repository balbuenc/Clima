using Clima.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clima.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Country model)
        {
            List<City> cities = new List<City>() {
                new City(){Id = 1, CityName="Hyderabad"},
                new City(){Id = 2, CityName="Ongole"},
                new City(){Id = 3, CityName="Guntur"},
                new City(){Id = 4, CityName="Vijayawada"}
            };

            model.Cities = cities;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}