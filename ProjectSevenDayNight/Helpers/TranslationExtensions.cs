using System;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Helpers
{
    public static class TranslationExtensions
    {
        /// <summary>
        /// About entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this About about, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetAboutTranslation(about.AboutId, fieldName),
                GetPropertyValue(about, fieldName)
            );
        }

        /// <summary>
        /// Service entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this Service service, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetServiceTranslation(service.ServiceId, fieldName),
                GetPropertyValue(service, fieldName)
            );
        }

        /// <summary>
        /// Employee entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this Employee employee, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetEmployeeTranslation(employee.EmployeeId, fieldName),
                GetPropertyValue(employee, fieldName)
            );
        }

        /// <summary>
        /// FAQ entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this Faq faq, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetFaqTranslation(faq.FaqId, fieldName),
                GetPropertyValue(faq, fieldName)
            );
        }

        /// <summary>
        /// Category entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this TblCategory category, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetCategoryTranslation(category.CategoryId, fieldName),
                GetPropertyValue(category, fieldName)
            );
        }

        /// <summary>
        /// Product entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this TblProduct product, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetProductTranslation(product.ProductId, fieldName),
                GetPropertyValue(product, fieldName)
            );
        }

        /// <summary>
        /// CompanyStats entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this CompanyStats companyStats, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetCompanyStatsTranslation(companyStats.StatId, fieldName),
                GetPropertyValue(companyStats, fieldName)
            );
        }

        /// <summary>
        /// Crausel entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this Crausel crausel, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetCrauselTranslation(crausel.CrauselId, fieldName),
                GetPropertyValue(crausel, fieldName)
            );
        }

        /// <summary>
        /// Contact entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this Contact contact, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetContactTranslation(contact.ContactId, fieldName),
                GetPropertyValue(contact, fieldName)
            );
        }

        /// <summary>
        /// Feature entity'si için çeviri extension'ı
        /// </summary>
        public static string T(this Feature feature, string fieldName)
        {
            return DatabaseTranslationHelper.TranslateOrOriginal(
                DatabaseTranslationHelper.GetFeatureTranslation(feature.FeatureId, fieldName),
                GetPropertyValue(feature, fieldName)
            );
        }

        /// <summary>
        /// Entity'den property değerini alır
        /// </summary>
        private static string GetPropertyValue(object entity, string propertyName)
        {
            var property = entity.GetType().GetProperty(propertyName);
            return property?.GetValue(entity)?.ToString() ?? "";
        }
    }
} 