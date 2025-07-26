using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace ProjectSevenDayNight.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Session'dan dil bilgisini al
            string currentLanguage = Session["CurrentLanguage"] as string;
            
            // Eğer session'da dil bilgisi yoksa, varsayılan olarak İngilizce kullan
            if (string.IsNullOrEmpty(currentLanguage))
            {
                currentLanguage = "en";
                Session["CurrentLanguage"] = currentLanguage;
            }

            // Culture'ı ayarla
            SetCulture(currentLanguage);

            base.OnActionExecuting(filterContext);
        }

        private void SetCulture(string language)
        {
            try
            {
                CultureInfo culture = null;
                
                switch (language.ToLower())
                {
                    case "en":
                        culture = new CultureInfo("en-US");
                        break;
                    case "de":
                        culture = new CultureInfo("de-DE");
                        break;
                    default:
                        culture = new CultureInfo("en-US");
                        break;
                }

                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
            catch (Exception ex)
            {
                // Hata durumunda varsayılan culture'ı kullan
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
        }

        protected string GetCurrentLanguage()
        {
            return Session["CurrentLanguage"] as string ?? "en";
        }
    }
} 