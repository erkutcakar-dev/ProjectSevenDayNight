using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;
using ProjectSevenDayNight.Helpers;

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
            
            // Otomatik çeviri ekle
            AutoTranslationHelper.AddAutoTranslation(about, "Title", about.Title);
            AutoTranslationHelper.AddAutoTranslation(about, "Subtitle", about.Subtitle);
            AutoTranslationHelper.AddAutoTranslation(about, "Description", about.Description);
            AutoTranslationHelper.AddAutoTranslation(about, "BulletPoint1", about.BulletPoint1);
            AutoTranslationHelper.AddAutoTranslation(about, "BulletPoint2", about.BulletPoint2);
            AutoTranslationHelper.AddAutoTranslation(about, "BulletPoint3", about.BulletPoint3);
            AutoTranslationHelper.AddAutoTranslation(about, "ButtonText", about.ButtonText);
            
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
            
            // Otomatik çeviri güncelle
            AutoTranslationHelper.AddAutoTranslation(value, "Title", about.Title);
            AutoTranslationHelper.AddAutoTranslation(value, "Subtitle", about.Subtitle);
            AutoTranslationHelper.AddAutoTranslation(value, "Description", about.Description);
            AutoTranslationHelper.AddAutoTranslation(value, "BulletPoint1", about.BulletPoint1);
            AutoTranslationHelper.AddAutoTranslation(value, "BulletPoint2", about.BulletPoint2);
            AutoTranslationHelper.AddAutoTranslation(value, "BulletPoint3", about.BulletPoint3);
            AutoTranslationHelper.AddAutoTranslation(value, "ButtonText", about.ButtonText);
            return RedirectToAction("AboutList");
        }


    }
}