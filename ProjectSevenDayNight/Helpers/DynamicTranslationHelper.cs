using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ProjectSevenDayNight.Helpers
{
    public static class DynamicTranslationHelper
    {
        // Dinamik çeviri sözlükleri
        private static readonly Dictionary<string, Dictionary<string, string>> _dynamicTranslations = new Dictionary<string, Dictionary<string, string>>
        {
            ["en"] = new Dictionary<string, string>
            {
                // About tablosu çevirileri
                ["About Us"] = "About Us",
                ["We Are Here To Help You Build Your Dream"] = "We Are Here To Help You Build Your Dream",
                ["Professional Team"] = "Professional Team",
                ["Quality Service"] = "Quality Service",
                ["24/7 Support"] = "24/7 Support",
                ["Read More"] = "Read More",
                ["Learn More"] = "Learn More",
                ["Get Started"] = "Get Started",
                ["Contact Us"] = "Contact Us",
                ["Our Services"] = "Our Services",
                ["Expert Team"] = "Expert Team",
                ["Best Quality"] = "Best Quality",
                ["Fast Delivery"] = "Fast Delivery",
                ["Customer Support"] = "Customer Support",
                ["Professional Service"] = "Professional Service",
                ["Modern Solutions"] = "Modern Solutions",
                ["Creative Design"] = "Creative Design",
                ["Innovative Technology"] = "Innovative Technology",
                ["Reliable Service"] = "Reliable Service",
                ["Trusted Partner"] = "Trusted Partner",
                
                // Service tablosu çevirileri
                ["Web Development"] = "Web Development",
                ["Mobile Development"] = "Mobile Development",
                ["Digital Marketing"] = "Digital Marketing",
                ["SEO Optimization"] = "SEO Optimization",
                ["Graphic Design"] = "Graphic Design",
                ["IT Consulting"] = "IT Consulting",
                
                // Employee tablosu çevirileri
                ["CEO"] = "CEO",
                ["CTO"] = "CTO",
                ["Lead Developer"] = "Lead Developer",
                ["Senior Designer"] = "Senior Designer",
                ["Marketing Manager"] = "Marketing Manager",
                ["Project Manager"] = "Project Manager",
                
                // FAQ tablosu çevirileri
                ["What services do you offer?"] = "What services do you offer?",
                ["How long does a project take?"] = "How long does a project take?",
                ["What are your prices?"] = "What are your prices?",
                ["Do you provide support?"] = "Do you provide support?",
                ["Can you work remotely?"] = "Can you work remotely?",
                ["What technologies do you use?"] = "What technologies do you use?",
                
                // Feature tablosu çevirileri
                ["Modern Design"] = "Modern Design",
                ["Responsive Layout"] = "Responsive Layout",
                ["Fast Performance"] = "Fast Performance",
                ["Secure Code"] = "Secure Code",
                ["Easy Maintenance"] = "Easy Maintenance",
                ["24/7 Support"] = "24/7 Support",
                
                // Carousel tablosu çevirileri
                ["Welcome to Our Company"] = "Welcome to Our Company",
                ["Professional Services"] = "Professional Services",
                ["Quality Solutions"] = "Quality Solutions",
                
                // Company Stats tablosu çevirileri
                ["Happy Clients"] = "Happy Clients",
                ["Projects Completed"] = "Projects Completed",
                ["Team Members"] = "Team Members",
                ["Years Experience"] = "Years Experience",
                
                // Product/Category çevirileri
                ["Electronics"] = "Electronics",
                ["Clothing"] = "Clothing",
                ["Books"] = "Books",
                ["Home & Garden"] = "Home & Garden",
                ["Sports"] = "Sports",
                ["Health"] = "Health"
            },
            
            ["de"] = new Dictionary<string, string>
            {
                // About tablosu çevirileri
                ["About Us"] = "Über uns",
                ["We Are Here To Help You Build Your Dream"] = "Wir sind hier, um Ihnen beim Aufbau Ihres Traums zu helfen",
                ["Professional Team"] = "Professionelles Team",
                ["Quality Service"] = "Qualitätsservice",
                ["24/7 Support"] = "24/7 Support",
                ["Read More"] = "Mehr lesen",
                ["Learn More"] = "Mehr erfahren",
                ["Get Started"] = "Loslegen",
                ["Contact Us"] = "Kontaktieren Sie uns",
                ["Our Services"] = "Unsere Dienstleistungen",
                ["Expert Team"] = "Expertenteam",
                ["Best Quality"] = "Beste Qualität",
                ["Fast Delivery"] = "Schnelle Lieferung",
                ["Customer Support"] = "Kundenservice",
                ["Professional Service"] = "Professioneller Service",
                ["Modern Solutions"] = "Moderne Lösungen",
                ["Creative Design"] = "Kreatives Design",
                ["Innovative Technology"] = "Innovative Technologie",
                ["Reliable Service"] = "Zuverlässiger Service",
                ["Trusted Partner"] = "Vertrauenswürdiger Partner",
                
                // Service tablosu çevirileri
                ["Web Development"] = "Webentwicklung",
                ["Mobile Development"] = "Mobile Entwicklung",
                ["Digital Marketing"] = "Digitales Marketing",
                ["SEO Optimization"] = "SEO-Optimierung",
                ["Graphic Design"] = "Grafikdesign",
                ["IT Consulting"] = "IT-Beratung",
                
                // Employee tablosu çevirileri
                ["CEO"] = "Geschäftsführer",
                ["CTO"] = "Technischer Leiter",
                ["Lead Developer"] = "Lead-Entwickler",
                ["Senior Designer"] = "Senior Designer",
                ["Marketing Manager"] = "Marketing Manager",
                ["Project Manager"] = "Projektmanager",
                
                // FAQ tablosu çevirileri
                ["What services do you offer?"] = "Welche Dienstleistungen bieten Sie an?",
                ["How long does a project take?"] = "Wie lange dauert ein Projekt?",
                ["What are your prices?"] = "Was sind Ihre Preise?",
                ["Do you provide support?"] = "Bieten Sie Support an?",
                ["Can you work remotely?"] = "Können Sie remote arbeiten?",
                ["What technologies do you use?"] = "Welche Technologien verwenden Sie?",
                
                // Feature tablosu çevirileri
                ["Modern Design"] = "Modernes Design",
                ["Responsive Layout"] = "Responsives Layout",
                ["Fast Performance"] = "Schnelle Leistung",
                ["Secure Code"] = "Sicherer Code",
                ["Easy Maintenance"] = "Einfache Wartung",
                ["24/7 Support"] = "24/7 Support",
                
                // Carousel tablosu çevirileri
                ["Welcome to Our Company"] = "Willkommen in unserem Unternehmen",
                ["Professional Services"] = "Professionelle Dienstleistungen",
                ["Quality Solutions"] = "Qualitätslösungen",
                
                // Company Stats tablosu çevirileri
                ["Happy Clients"] = "Zufriedene Kunden",
                ["Projects Completed"] = "Abgeschlossene Projekte",
                ["Team Members"] = "Teammitglieder",
                ["Years Experience"] = "Jahre Erfahrung",
                
                // Product/Category çevirileri
                ["Electronics"] = "Elektronik",
                ["Clothing"] = "Kleidung",
                ["Books"] = "Bücher",
                ["Home & Garden"] = "Haus & Garten",
                ["Sports"] = "Sport",
                ["Health"] = "Gesundheit"
            }
        };

        /// <summary>
        /// Verilen metni mevcut dile çevirir
        /// </summary>
        public static string Translate(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string currentLanguage = GetCurrentLanguage();
            
            // Debug için log
            System.Diagnostics.Debug.WriteLine($"Translating: '{text}' to language: {currentLanguage}");
            
            if (_dynamicTranslations.ContainsKey(currentLanguage) && 
                _dynamicTranslations[currentLanguage].ContainsKey(text))
            {
                var translated = _dynamicTranslations[currentLanguage][text];
                System.Diagnostics.Debug.WriteLine($"Found translation: '{translated}'");
                return translated;
            }

            // Çeviri bulunamazsa orijinal metni döndür
            System.Diagnostics.Debug.WriteLine($"No translation found, returning original: '{text}'");
            return text;
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
        /// Belirli bir dil için metni çevirir
        /// </summary>
        public static string Translate(string text, string language)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (_dynamicTranslations.ContainsKey(language) && 
                _dynamicTranslations[language].ContainsKey(text))
            {
                return _dynamicTranslations[language][text];
            }

            return text;
        }

        /// <summary>
        /// Yeni çeviri ekler
        /// </summary>
        public static void AddTranslation(string key, string englishText, string germanText)
        {
            if (!_dynamicTranslations["en"].ContainsKey(key))
            {
                _dynamicTranslations["en"][key] = englishText;
            }
            
            if (!_dynamicTranslations["de"].ContainsKey(key))
            {
                _dynamicTranslations["de"][key] = germanText;
            }
        }
    }
} 