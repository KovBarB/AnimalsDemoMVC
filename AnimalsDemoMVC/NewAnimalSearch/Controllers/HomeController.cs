using NewAnimalSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAnimalSearch.Controllers
{
    public class HomeController : Controller
    {
        private AnimalSearchDB db = new AnimalSearchDB();
        SharedMethods m = new SharedMethods();

        public ActionResult Index()
        {
            ViewBag.AnimalsSum = db.Animals.Count();
            ViewBag.OrgSum = db.Organisations.Count();
            ViewBag.Photos = m.GetPhotos();
            ViewBag.Featured = m.GetRandomAnimals();

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