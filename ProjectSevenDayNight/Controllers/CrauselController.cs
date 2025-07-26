using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Controllers
{
    public class CrauselController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        public ActionResult CrauselList()
        {
            var crauselList = db.Crausel.ToList();
            return View(crauselList);
        }

        [HttpGet]
        public ActionResult CreateCrausel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCrausel(Crausel crausel)
        {
            db.Crausel.Add(crausel);
            db.SaveChanges();
            return RedirectToAction("CrauselList");
        }
        
        public ActionResult DeleteCrausel(int id)
        {
            var crausel = db.Crausel.Find(id);
            db.Crausel.Remove(crausel);
            db.SaveChanges();
            return RedirectToAction("CrauselList");
        }
        
        [HttpGet]
        public ActionResult UpdateCrausel(int id)
        {
            var crausel = db.Crausel.Find(id);
            if (crausel == null)
                return HttpNotFound();

            return View(crausel);
        }

        [HttpPost]
        public ActionResult UpdateCrausel(Crausel crausel)
        {
            if (!ModelState.IsValid)
            {
                return View(crausel);
            }

            var value = db.Crausel.Find(crausel.CrauselId);
            if (value == null)
                return HttpNotFound();

            value.Title = crausel.Title;
            value.Subtitle = crausel.Subtitle;
            value.Description = crausel.Description;

            db.SaveChanges();
            return RedirectToAction("CrauselList");
        }
    }
} 