using System;
using System.Globalization;
using System.Resources;
using System.Web;

namespace ProjectSevenDayNight.Helpers
{
    public static class ResourceHelper
    {
        private static ResourceManager _resourceManager;

        static ResourceHelper()
        {
            _resourceManager = new ResourceManager("ProjectSevenDayNight.App_GlobalResources.English", typeof(ResourceHelper).Assembly);
        }

        public static string GetString(string key)
        {
            try
            {
                // Session'dan dil bilgisini al
                string currentLanguage = HttpContext.Current?.Session["CurrentLanguage"] as string ?? "en";
                
                // Dil bilgisine göre resource manager'ı değiştir
                switch (currentLanguage.ToLower())
                {
                    case "de":
                        _resourceManager = new ResourceManager("ProjectSevenDayNight.App_GlobalResources.German", typeof(ResourceHelper).Assembly);
                        break;
                    case "en":
                    default:
                        _resourceManager = new ResourceManager("ProjectSevenDayNight.App_GlobalResources.English", typeof(ResourceHelper).Assembly);
                        break;
                }

                return _resourceManager.GetString(key) ?? key;
            }
            catch (Exception)
            {
                return key;
            }
        }

        public static string GetString(string key, CultureInfo culture)
        {
            try
            {
                return _resourceManager.GetString(key, culture) ?? key;
            }
            catch (Exception)
            {
                return key;
            }
        }
    }
} 