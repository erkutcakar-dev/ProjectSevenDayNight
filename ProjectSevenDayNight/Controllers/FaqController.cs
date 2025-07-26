using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Controllers
{
    public class FaqController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        public ActionResult FaqList()
        {
            var faqList = db.Faq.ToList();
            return View(faqList);
        }

        [HttpGet]
        public ActionResult CreateFaq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFaq(Faq faq)
        {
            db.Faq.Add(faq);
            db.SaveChanges();
            return RedirectToAction("FaqList");
        }
        
        public ActionResult DeleteFaq(int id)
        {
            var faq = db.Faq.Find(id);
            db.Faq.Remove(faq);
            db.SaveChanges();
            return RedirectToAction("FaqList");
        }
        
        [HttpGet]
        public ActionResult UpdateFaq(int id)
        {
            var faq = db.Faq.Find(id);
            if (faq == null)
                return HttpNotFound();

            return View(faq);
        }

        [HttpPost]
        public ActionResult UpdateFaq(Faq faq)
        {
            if (!ModelState.IsValid)
            {
                return View(faq);
            }

            var value = db.Faq.Find(faq.FaqId);
            if (value == null)
                return HttpNotFound();

            value.Title = faq.Title;
            value.Subtitle = faq.Subtitle;
            value.Question = faq.Question;
            value.Answer = faq.Answer;

            db.SaveChanges();
            return RedirectToAction("FaqList");
        }
    }
} 