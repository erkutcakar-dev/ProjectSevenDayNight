using System;
using System.Web.Mvc;
using ProjectSevenDayNight.Helpers;

namespace ProjectSevenDayNight.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Resource(this HtmlHelper htmlHelper, string key)
        {
            string value = ResourceHelper.GetString(key);
            return MvcHtmlString.Create(value);
        }

        public static MvcHtmlString Resource(this HtmlHelper htmlHelper, string key, params object[] args)
        {
            string value = ResourceHelper.GetString(key);
            if (args != null && args.Length > 0)
            {
                value = string.Format(value, args);
            }
            return MvcHtmlString.Create(value);
        }

        public static MvcHtmlString LanguageLink(this HtmlHelper htmlHelper, string language, string text, string returnUrl = null)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            string url = urlHelper.Action("ChangeLanguage", "Language", new { language = language });
            
            if (!string.IsNullOrEmpty(returnUrl))
            {
                url += "&returnUrl=" + System.Web.HttpUtility.UrlEncode(returnUrl);
            }

            return MvcHtmlString.Create($"<a href=\"{url}\">{text}</a>");
        }

        public static MvcHtmlString CurrentLanguage(this HtmlHelper htmlHelper)
        {
            string currentLanguage = System.Web.HttpContext.Current?.Session["CurrentLanguage"] as string ?? "en";
            return MvcHtmlString.Create(currentLanguage);
        }
    }
} 