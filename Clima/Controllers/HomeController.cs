using Clima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clima.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = System.Web.HttpContext.Current.User.Identity.Name;
            using (climaEntities db = new climaEntities())
            {
                var idEncuesta = 1;

                var respuesta = db.Respuestas.Where(r => r.IdEncuesta == idEncuesta && r.login.Equals(user)).ToList();

                if (respuesta.Any())
                {
                    ViewData["realizado"] = "OK";
                }
            }

            return View();
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