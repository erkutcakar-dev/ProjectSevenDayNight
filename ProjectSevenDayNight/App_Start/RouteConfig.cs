using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectSevenDayNight
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Dil değiştirme route'u
            routes.MapRoute(
                name: "Language",
                url: "Language/{action}/{language}",
                defaults: new { controller = "Language", action = "ChangeLanguage", language = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index_En", id = UrlParameter.Optional }
            );
        }
    }
}
