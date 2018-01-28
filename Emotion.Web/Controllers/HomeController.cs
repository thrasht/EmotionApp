using Emotion.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emotion.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.WelcomeMessage = "Bienvenido";
            ViewBag.ValorEntero = 1;
            return View();
        }

        public ActionResult IndexAlt()
        {
            var model = new Home();
            model.WelcomeMessage = "Bienvenido al Index Alternativo";
            return View(model);
        }

    }
}