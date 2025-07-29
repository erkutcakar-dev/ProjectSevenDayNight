using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;
using ProjectSevenDayNight.Helpers;
using System.Collections.Generic; // Added for List

namespace ProjectSevenDayNight.Controllers
{
    public class CompanyStatsController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        public ActionResult CompanyStatsList()
        {
            var companyStatsList = db.CompanyStats.ToList();
            
            // Eğer hiç veri yoksa örnek veriler ekle
            if (!companyStatsList.Any())
            {
                var sampleStats = new List<CompanyStats>
                {
                    new CompanyStats { Title = "Happy Clients", Value = 150, Unit = "", DisplayOrder = 1 },
                    new CompanyStats { Title = "Projects Completed", Value = 250, Unit = "+", DisplayOrder = 2 },
                    new CompanyStats { Title = "Years Experience", Value = 10, Unit = "+", DisplayOrder = 3 },
                    new CompanyStats { Title = "Team Members", Value = 25, Unit = "+", DisplayOrder = 4 }
                };
                
                foreach (var stat in sampleStats)
                {
                    db.CompanyStats.Add(stat);
                }
                db.SaveChanges();
                
                // Sayfayı yenile
                companyStatsList = db.CompanyStats.ToList();
            }
            
            return View(companyStatsList);
        }

        [HttpGet]
        public ActionResult CreateCompanyStats()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCompanyStats(CompanyStats companyStats)
        {
            // Eğer DisplayOrder null ise otomatik sıra ver
            if (!companyStats.DisplayOrder.HasValue)
            {
                var maxOrder = db.CompanyStats.Max(x => x.DisplayOrder) ?? 0;
                companyStats.DisplayOrder = maxOrder + 1;
            }
            
            db.CompanyStats.Add(companyStats);
            db.SaveChanges();
            
            // Otomatik Almanca çeviri ekle
            AutoTranslationHelper.AddAutoTranslation(companyStats, "Title", companyStats.Title);
            
            return RedirectToAction("CompanyStatsList");
        }
        
        public ActionResult DeleteCompanyStats(int id)
        {
            var companyStats = db.CompanyStats.Find(id);
            if (companyStats != null)
            {
                // Önce CompanyStatsTranslations kayıtlarını sil
                var translations = db.CompanyStatsTranslations.Where(t => t.StatId == id).ToList();
                foreach (var translation in translations)
                {
                    db.CompanyStatsTranslations.Remove(translation);
                }
                
                // Sonra CompanyStats'ı sil
                db.CompanyStats.Remove(companyStats);
                db.SaveChanges();
            }
            return RedirectToAction("CompanyStatsList");
        }
        
        [HttpGet]
        public ActionResult UpdateCompanyStats(int id)
        {
            var companyStats = db.CompanyStats.Find(id);
            if (companyStats == null)
                return HttpNotFound();

            return View(companyStats);
        }

        [HttpPost]
        public ActionResult UpdateCompanyStats(CompanyStats companyStats)
        {
            if (!ModelState.IsValid)
            {
                return View(companyStats);
            }

            var value = db.CompanyStats.Find(companyStats.StatId);
            if (value == null)
                return HttpNotFound();

            value.Title = companyStats.Title;
            value.Value = companyStats.Value;
            value.Unit = companyStats.Unit;
            value.DisplayOrder = companyStats.DisplayOrder;

            db.SaveChanges();
            
            // Otomatik Almanca çeviri güncelle
            AutoTranslationHelper.AddAutoTranslation(value, "Title", companyStats.Title);
            
            return RedirectToAction("CompanyStatsList");
        }
    }
} 