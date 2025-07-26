using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace ProjectSevenDayNight.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult ChangeLanguage(string language)
        {
            // Desteklenen dilleri kontrol et
            if (language != null)
            {
                switch (language.ToLower())
                {
                    case "en":
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        break;
                    case "de":
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
                        break;
                    default:
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        break;
                }
            }

            // Seçilen dili session'a kaydet
            Session["CurrentLanguage"] = language ?? "en";

            // Referrer URL'ini al, yoksa ana sayfaya yönlendir
            string returnUrl = Request.UrlReferrer?.ToString();
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index_En", "Default");
            }

            return Redirect(returnUrl);
        }

        public ActionResult SetLanguage(string language, string returnUrl)
        {
            // Desteklenen dilleri kontrol et
            if (language != null)
            {
                switch (language.ToLower())
                {
                    case "en":
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        break;
                    case "de":
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
                        break;
                    default:
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        break;
                }
            }

            // Seçilen dili session'a kaydet
            Session["CurrentLanguage"] = language ?? "en";

            // Return URL'i kontrol et ve yönlendir
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index_En", "Default");
        }
    }
} 