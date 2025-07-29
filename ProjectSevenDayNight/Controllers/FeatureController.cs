using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Controllers
{
    public class FeatureController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        public ActionResult FeatureList()
        {
            var featureList = db.Feature.ToList();
            return View(featureList);
        }

        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFeature(Feature feature)
        {
            db.Feature.Add(feature);
            db.SaveChanges();
            
            // Otomatik Almanca çeviri ekle
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(feature, "Title", feature.Title);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(feature, "Subtitle", feature.Subtitle);
            
            return RedirectToAction("FeatureList");
        }
        
        public ActionResult DeleteFeature(int id)
        {
            var feature = db.Feature.Find(id);
            if (feature != null)
            {
                // Önce FeatureTranslations kayıtlarını sil
                var translations = db.FeatureTranslations.Where(t => t.FeatureId == id).ToList();
                foreach (var translation in translations)
                {
                    db.FeatureTranslations.Remove(translation);
                }
                
                // Sonra Feature'ı sil
                db.Feature.Remove(feature);
                db.SaveChanges();
            }
            return RedirectToAction("FeatureList");
        }
        
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var feature = db.Feature.Find(id);
            if (feature == null)
                return HttpNotFound();

            return View(feature);
        }

        [HttpPost]
        public ActionResult UpdateFeature(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View(feature);
            }

            var value = db.Feature.Find(feature.FeatureId);
            if (value == null)
                return HttpNotFound();

            value.Title = feature.Title;
            value.Subtitle = feature.Subtitle;
            value.ImageUrl = feature.ImageUrl;

            db.SaveChanges();

            // Otomatik Almanca çeviri güncelle
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Title", value.Title);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Subtitle", value.Subtitle);

            return RedirectToAction("FeatureList");
        }
    }
} 