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
            return RedirectToAction("ContactList");
        }
        
        public ActionResult DeleteContact(int id)
        {
            var contact = db.Contact.Find(id);
            db.Contact.Remove(contact);
            db.SaveChanges();
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
            value.Telephone = contact.Telephone;

            db.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
} 