using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;
using ProjectSevenDayNight.Helpers;

namespace ProjectSevenDayNight.Controllers
{
    public class ServiceController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        public ActionResult ServiceList()
        {
            var serviceList = db.Service.ToList();
            return View(serviceList);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            db.Service.Add(service);
            db.SaveChanges();
            
            // Otomatik çeviri ekle
            AutoTranslationHelper.AddAutoTranslation(service, "Title", service.Title);
            AutoTranslationHelper.AddAutoTranslation(service, "Subtitle", service.Subtitle);
            AutoTranslationHelper.AddAutoTranslation(service, "CardTitle", service.CardTitle);
            AutoTranslationHelper.AddAutoTranslation(service, "CardDescription", service.CardDescription);
            
            return RedirectToAction("ServiceList");
        }
        
        public ActionResult DeleteService(int id)
        {
            var service = db.Service.Find(id);
            db.Service.Remove(service);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service = db.Service.Find(id);
            if (service == null)
                return HttpNotFound();

            return View(service);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            var value = db.Service.Find(service.ServiceId);
            if (value == null)
                return HttpNotFound();

            value.Title = service.Title;
            value.Subtitle = service.Subtitle;
            value.CardTitle = service.CardTitle;
            value.CardDescription = service.CardDescription;
            value.CardImageUrl = service.CardImageUrl;

            db.SaveChanges();
            
            // Otomatik çeviri güncelle
            AutoTranslationHelper.AddAutoTranslation(value, "Title", service.Title);
            AutoTranslationHelper.AddAutoTranslation(value, "Subtitle", service.Subtitle);
            AutoTranslationHelper.AddAutoTranslation(value, "CardTitle", service.CardTitle);
            AutoTranslationHelper.AddAutoTranslation(value, "CardDescription", service.CardDescription);
            return RedirectToAction("ServiceList");
        }
    }
} 