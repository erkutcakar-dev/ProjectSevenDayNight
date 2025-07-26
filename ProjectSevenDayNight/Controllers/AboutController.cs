using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        DayNightDbEntities db = new DayNightDbEntities();
        public ActionResult AboutList()
        {
            var aboutList = db.About.ToList();
            return View(aboutList);

        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateAbout(About about)
        {
            db.About.Add(about);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult DeleteAbout(int id)
        {
            var about = db.About.Find(id);
            db.About.Remove(about);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = db.About.Find(id);
            if (about == null)
                return HttpNotFound();  // veya kendi hata sayfan

            return View(about);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            if (!ModelState.IsValid)
            {
                return View(about); // Hata varsa tekrar formu göster
            }

            var value = db.About.Find(about.AboutId);
            if (value == null)
                return HttpNotFound();

            value.Title = about.Title;
            value.Subtitle = about.Subtitle;
            value.Description = about.Description;
            value.BulletPoint1 = about.BulletPoint1;
            value.BulletPoint2 = about.BulletPoint2;
            value.BulletPoint3 = about.BulletPoint3;
            value.ButtonText = about.ButtonText;

            db.SaveChanges();
            return RedirectToAction("AboutList");
        }


    }
}