using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Controllers
{
    public class CompanyStatsController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        public ActionResult CompanyStatsList()
        {
            var companyStatsList = db.CompanyStats.ToList();
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
            db.CompanyStats.Add(companyStats);
            db.SaveChanges();
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
            return RedirectToAction("CompanyStatsList");
        }
    }
} 