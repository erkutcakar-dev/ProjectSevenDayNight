using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Controllers
{
    public class CarouselController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        public ActionResult CarauselList()
        {
            var carouselList = db.Crausel.ToList();
            return View(carouselList);

        }
    }
}