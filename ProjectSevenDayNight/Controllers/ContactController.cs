using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Controllers
{
    public class ContactController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        public ActionResult ContactList()
        {
            var contactList = db.Contact.ToList();
            return View(contactList);
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            db.Contact.Add(contact);
            db.SaveChanges();
            
            // Otomatik Almanca çeviri ekle
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(contact, "Title", contact.Title);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(contact, "Subtitle", contact.Subtitle);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(contact, "Description", contact.Description);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(contact, "Address", contact.Address);
            
            return RedirectToAction("ContactList");
        }
        
        public ActionResult DeleteContact(int id)
        {
            var contact = db.Contact.Find(id);
            if (contact != null)
            {
                // Önce ContactTranslations kayıtlarını sil
                var translations = db.ContactTranslations.Where(t => t.ContactId == id).ToList();
                foreach (var translation in translations)
                {
                    db.ContactTranslations.Remove(translation);
                }
                
                // Sonra Contact'ı sil
                db.Contact.Remove(contact);
                db.SaveChanges();
            }
            return RedirectToAction("ContactList");
        }
        
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact = db.Contact.Find(id);
            if (contact == null)
                return HttpNotFound();

            return View(contact);
        }

        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            var value = db.Contact.Find(contact.ContactId);
            if (value == null)
                return HttpNotFound();

            value.Title = contact.Title;
            value.Subtitle = contact.Subtitle;
            value.Description = contact.Description;
            value.SocialMedia = contact.SocialMedia;
            value.SocialMediaImageUrl = contact.SocialMediaImageUrl;
            value.Address = contact.Address;
            value.Mail = contact.Mail;

            db.SaveChanges();

            // Otomatik Almanca çeviri güncelle
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Title", value.Title);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Subtitle", value.Subtitle);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Description", value.Description);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Address", value.Address);

            return RedirectToAction("ContactList");
        }
    }
} 