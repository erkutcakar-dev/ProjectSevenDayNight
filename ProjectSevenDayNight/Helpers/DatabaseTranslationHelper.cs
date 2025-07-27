using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Helpers
{
    public static class DatabaseTranslationHelper
    {
        /// <summary>
        /// About tablosu için çeviri yapar
        /// </summary>
        public static string GetAboutTranslation(int aboutId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.AboutTranslations
                    .FirstOrDefault(t => t.AboutId == aboutId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "title": return translation.Title;
                        case "subtitle": return translation.Subtitle;
                        case "description": return translation.Description;
                        case "bulletpoint1": return translation.BulletPoint1;
                        case "bulletpoint2": return translation.BulletPoint2;
                        case "bulletpoint3": return translation.BulletPoint3;
                        case "buttontext": return translation.ButtonText;
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// Service tablosu için çeviri yapar
        /// </summary>
        public static string GetServiceTranslation(int serviceId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.ServiceTranslations
                    .FirstOrDefault(t => t.ServiceId == serviceId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "title": return translation.Title;
                        case "subtitle": return translation.Subtitle;
                        case "cardtitle": return translation.CardTitle;
                        case "carddescription": return translation.CardDescription;
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// Employee tablosu için çeviri yapar
        /// </summary>
        public static string GetEmployeeTranslation(int employeeId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.EmployeeTranslations
                    .FirstOrDefault(t => t.EmployeeId == employeeId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "title": return translation.Title;
                        case "subtitle": return translation.Subtitle;
                        case "namesurname": return translation.NameSurname;
                        case "job": return translation.Job;
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// FAQ tablosu için çeviri yapar
        /// </summary>
        public static string GetFaqTranslation(int faqId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.FaqTranslations
                    .FirstOrDefault(t => t.FaqId == faqId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "title": return translation.Title;
                        case "subtitle": return translation.Subtitle;
                        case "question": return translation.Question;
                        case "answer": return translation.Answer;
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// Category tablosu için çeviri yapar
        /// </summary>
        public static string GetCategoryTranslation(int categoryId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.CategoryTranslations
                    .FirstOrDefault(t => t.CategoryId == categoryId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "categoryname": return translation.CategoryName;
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// Product tablosu için çeviri yapar
        /// </summary>
        public static string GetProductTranslation(int productId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.ProductTranslations
                    .FirstOrDefault(t => t.ProductId == productId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "productname": return translation.ProductName;
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// CompanyStats tablosu için çeviri yapar
        /// </summary>
        public static string GetCompanyStatsTranslation(int statId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.CompanyStatsTranslations
                    .FirstOrDefault(t => t.StatId == statId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "title": return translation.Title;
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// Crausel tablosu için çeviri yapar
        /// </summary>
        public static string GetCrauselTranslation(int crauselId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.CrauselTranslations
                    .FirstOrDefault(t => t.CrauselId == crauselId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "title": return translation.Title;
                        case "subtitle": return translation.Subtitle;
                        case "description": return translation.Description;
                        case "buttontext": return translation.ButtonText ?? "Mehr erfahren";
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// Contact tablosu için çeviri yapar
        /// </summary>
        public static string GetContactTranslation(int contactId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.ContactTranslations
                    .FirstOrDefault(t => t.ContactId == contactId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "title": return translation.Title;
                        case "subtitle": return translation.Subtitle;
                        case "description": return translation.Description;
                        case "address": return translation.Address;
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// Feature tablosu için çeviri yapar
        /// </summary>
        public static string GetFeatureTranslation(int featureId, string fieldName)
        {
            string currentLanguage = GetCurrentLanguage();
            
            using (var db = new DayNightDbEntities())
            {
                var translation = db.FeatureTranslations
                    .FirstOrDefault(t => t.FeatureId == featureId && t.LanguageCode == currentLanguage);
                
                if (translation != null)
                {
                    switch (fieldName.ToLower())
                    {
                        case "title": return translation.Title;
                        case "subtitle": return translation.Subtitle;
                    }
                }
            }
            
            return null; // Çeviri bulunamadı
        }

        /// <summary>
        /// Mevcut dili session'dan alır
        /// </summary>
        private static string GetCurrentLanguage()
        {
            if (HttpContext.Current?.Session != null)
            {
                return HttpContext.Current.Session["CurrentLanguage"] as string ?? "en";
            }
            return "en";
        }

        /// <summary>
        /// Çeviri varsa çeviriyi, yoksa orijinal metni döndürür
        /// </summary>
        public static string TranslateOrOriginal(string translatedText, string originalText)
        {
            return !string.IsNullOrEmpty(translatedText) ? translatedText : originalText;
        }
    }
} 