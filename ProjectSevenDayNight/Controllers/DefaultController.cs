using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSevenDayNight.Models;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Controllers
{
    public class DefaultController : BaseController
    {
     DayNightDbEntities DayNightDbEntities = new DayNightDbEntities();
        public ActionResult Index_En()
        {
            return View();
        }
        public ActionResult Index_De()
        {
            return View();
        }

        public ActionResult IndexTurkish()
        {
            return View();
        }

        public PartialViewResult _Topbar()
        {
            return PartialView();
        }
        public PartialViewResult _NavbarHero()
        {
            return PartialView();
        }
        public PartialViewResult _Carousel()
        {
            var carouselList = DayNightDbEntities.Crausel.ToList();
            return PartialView(carouselList);

        }
        public PartialViewResult _Feature()
        {

            var featureList = DayNightDbEntities.Feature.ToList();
            return PartialView(featureList);
        }
        public PartialViewResult _About()
        {

            var aboutList = DayNightDbEntities.About.ToList();
            return PartialView(aboutList);
        }
        public PartialViewResult _Service()
        {
            var serviceList = DayNightDbEntities.Service.ToList();
            return PartialView(serviceList);
           ViewBag.Maintitle = "Our Services";
            ViewBag.MainSubtitle = "We provide a wide range of services to meet your needs.";
           ViewBag.Description = "From web development to digital marketing, our team is here to help you succeed.";

        }

        public PartialViewResult _Faq()
        {

            var faqList = DayNightDbEntities.Faq.ToList();
            return PartialView(faqList);
        }      
        public PartialViewResult _Empoloyee()
        {

            var employeeList = DayNightDbEntities.Employee.ToList();
            return PartialView(employeeList);
           
        }      
        public PartialViewResult _Footer()
        {
            return PartialView();
        }
        public PartialViewResult _Copyright()
        {
            return PartialView();
        }


        public PartialViewResult _HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult _FooterPartial()
        {
            var values = DayNightDbEntities.Contact.ToList();
            return PartialView(values);

        }

        public PartialViewResult _ScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult _ModalSearch()
        {
            return PartialView();
        }

        public PartialViewResult _CompanyStats()
        {
           var companyStats = DayNightDbEntities.CompanyStats.ToList();
            return PartialView(companyStats);
        }


    }
}