using System;
using System.Collections.Generic;
using System.Web;

namespace ProjectSevenDayNight.Helpers
{
    public static class SimpleLanguageHelper
    {
        // Basit çeviri sözlüğü
        private static readonly Dictionary<string, string> _translations = new Dictionary<string, string>
        {
            // About tablosu için
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
            ["More Services"] = "Weitere Dienstleistungen",
            ["Our team consists of experts and experienced professionals. We are here to provide you with the best service."] = "Unser Team besteht aus Experten und erfahrenen Fachleuten. Wir sind hier, um Ihnen den besten Service zu bieten.",
            
            // Service tablosu için
            ["Web Development"] = "Webentwicklung",
            ["Mobile Development"] = "Mobile Entwicklung",
            ["Digital Marketing"] = "Digitales Marketing",
            ["SEO Optimization"] = "SEO-Optimierung",
            ["Graphic Design"] = "Grafikdesign",
            ["IT Consulting"] = "IT-Beratung",
            ["Software Development"] = "Softwareentwicklung",
            ["Cloud Solutions"] = "Cloud-Lösungen",
            ["Data Analytics"] = "Datenanalyse",
            ["UI/UX Design"] = "UI/UX-Design",
            ["Software Development"] = "Softwareentwicklung",
            ["Cloud Computing"] = "Cloud Computing",
            ["Artificial Intelligence"] = "Künstliche Intelligenz",
            ["Machine Learning"] = "Maschinelles Lernen",
            ["Big Data"] = "Big Data",
            ["Cybersecurity"] = "Cybersicherheit",
            ["Blockchain"] = "Blockchain",
            ["IoT Solutions"] = "IoT-Lösungen",
            ["API Development"] = "API-Entwicklung",
            ["Database Design"] = "Datenbankdesign",
            ["System Integration"] = "Systemintegration",
            ["Performance Optimization"] = "Leistungsoptimierung",
            ["Code Review"] = "Code-Review",
            ["Testing & QA"] = "Testing & QA",
            ["Deployment"] = "Deployment",
            ["Maintenance"] = "Wartung",
            ["Consulting"] = "Beratung",
            ["Training"] = "Schulung",
            ["Software Engineer"] = "Softwareingenieur",
            ["Web Designer"] = "Webdesigner",
            ["Mobile Developer"] = "Mobile Entwickler",
            ["Full Stack Developer"] = "Full Stack Entwickler",
            ["Frontend Developer"] = "Frontend Entwickler",
            ["Backend Developer"] = "Backend Entwickler",
            ["Database Administrator"] = "Datenbankadministrator",
            ["System Administrator"] = "Systemadministrator",
            ["Network Engineer"] = "Netzwerkingenieur",
            ["Security Specialist"] = "Sicherheitsspezialist",
            ["Quality Assurance"] = "Qualitätssicherung",
            ["Business Analyst"] = "Business Analyst",
            ["Product Manager"] = "Produktmanager",
            ["Scrum Master"] = "Scrum Master",
            ["Technical Lead"] = "Technischer Leiter",
            ["Architect"] = "Architekt",
            ["Consultant"] = "Berater",
            ["Trainer"] = "Trainer",
            ["Support Specialist"] = "Support-Spezialist",
            
            // Employee tablosu için
            ["CEO"] = "Geschäftsführer",
            ["CTO"] = "Technischer Leiter",
            ["Lead Developer"] = "Lead-Entwickler",
            ["Senior Designer"] = "Senior Designer",
            ["Marketing Manager"] = "Marketing Manager",
            ["Project Manager"] = "Projektmanager",
            ["Software Engineer"] = "Softwareingenieur",
            ["UX Designer"] = "UX-Designer",
            ["Data Scientist"] = "Datenwissenschaftler",
            ["DevOps Engineer"] = "DevOps-Ingenieur",
            
            // FAQ tablosu için
            ["What services do you offer?"] = "Welche Dienstleistungen bieten Sie an?",
            ["How long does a project take?"] = "Wie lange dauert ein Projekt?",
            ["What are your prices?"] = "Was sind Ihre Preise?",
            ["Do you provide support?"] = "Bieten Sie Support an?",
            ["Can you work remotely?"] = "Können Sie remote arbeiten?",
            ["What technologies do you use?"] = "Welche Technologien verwenden Sie?",
            ["How can I contact you?"] = "Wie kann ich Sie kontaktieren?",
            ["Do you offer maintenance?"] = "Bieten Sie Wartung an?",
            ["What is your process?"] = "Wie ist Ihr Prozess?",
            ["Do you have references?"] = "Haben Sie Referenzen?",
            
            // Product/Category için
            ["Electronics"] = "Elektronik",
            ["Clothing"] = "Kleidung",
            ["Books"] = "Bücher",
            ["Home & Garden"] = "Haus & Garten",
            ["Sports"] = "Sport",
            ["Health"] = "Gesundheit",
            ["Automotive"] = "Automobil",
            ["Toys"] = "Spielzeug",
            ["Food"] = "Lebensmittel",
            ["Beauty"] = "Schönheit"
        };

        /// <summary>
        /// Metni mevcut dile çevirir
        /// </summary>
        public static string Translate(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string currentLanguage = GetCurrentLanguage();
            
            // Eğer İngilizce ise orijinal metni döndür
            if (currentLanguage == "en")
                return text;
            
            // Eğer Almanca ise çeviri yap
            if (currentLanguage == "de" && _translations.ContainsKey(text))
                return _translations[text];
            
            // Çeviri bulunamazsa orijinal metni döndür
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
        /// Yeni çeviri ekler
        /// </summary>
        public static void AddTranslation(string englishText, string germanText)
        {
            if (!_translations.ContainsKey(englishText))
            {
                _translations[englishText] = germanText;
            }
        }
    }
} 