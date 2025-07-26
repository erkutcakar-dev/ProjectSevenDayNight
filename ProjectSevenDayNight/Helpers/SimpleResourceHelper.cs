using System;
using System.Collections.Generic;
using System.Web;

namespace ProjectSevenDayNight.Helpers
{
    public static class SimpleResourceHelper
    {
        private static readonly Dictionary<string, Dictionary<string, string>> _resources = new Dictionary<string, Dictionary<string, string>>
        {
            ["en"] = new Dictionary<string, string>
            {
                ["Home"] = "Home",
                ["About"] = "About",
                ["Services"] = "Services",
                ["Contact"] = "Contact",
                ["FAQ"] = "FAQ",
                ["Team"] = "Team",
                ["FindLocation"] = "Find A Location",
                ["Email"] = "Email",
                ["Language"] = "Language",
                ["LanguageEnglish"] = "English",
                ["LanguageGerman"] = "German",
                ["HeroTitle"] = "We Build Your Dream",
                ["HeroSubtitle"] = "Professional & Dedicated Team",
                ["GetQuote"] = "Get A Quote",
                ["LearnMore"] = "Learn More",
                ["AboutTitle"] = "About Us",
                ["AboutSubtitle"] = "We Are Here To Help You Build Your Dream",
                ["ServicesTitle"] = "Our Services",
                ["ServicesSubtitle"] = "We provide a wide range of services to meet your needs",
                ["ServicesDescription"] = "From web development to digital marketing, our team is here to help you succeed",
                ["FAQTitle"] = "Frequently Asked Questions",
                ["FAQSubtitle"] = "Find answers to common questions",
                ["TeamTitle"] = "Our Team",
                ["TeamSubtitle"] = "Meet our professional team",
                ["ContactUs"] = "Contact Us",
                ["Address"] = "Address",
                ["Phone"] = "Phone",
                ["FollowUs"] = "Follow Us",
                ["Copyright"] = "© 2024 All Rights Reserved",
                ["Navigation"] = "Navigation",
                ["Topbar"] = "Topbar",
                ["Hero Section"] = "Hero Section"
            },
            ["de"] = new Dictionary<string, string>
            {
                ["Home"] = "Startseite",
                ["About"] = "Über uns",
                ["Services"] = "Dienstleistungen",
                ["Contact"] = "Kontakt",
                ["FAQ"] = "FAQ",
                ["Team"] = "Team",
                ["FindLocation"] = "Standort finden",
                ["Email"] = "E-Mail",
                ["Language"] = "Sprache",
                ["LanguageEnglish"] = "Englisch",
                ["LanguageGerman"] = "Deutsch",
                ["HeroTitle"] = "Wir bauen Ihren Traum",
                ["HeroSubtitle"] = "Professionelles & engagiertes Team",
                ["GetQuote"] = "Angebot anfordern",
                ["LearnMore"] = "Mehr erfahren",
                ["AboutTitle"] = "Über uns",
                ["AboutSubtitle"] = "Wir sind hier, um Ihnen beim Aufbau Ihres Traums zu helfen",
                ["ServicesTitle"] = "Unsere Dienstleistungen",
                ["ServicesSubtitle"] = "Wir bieten eine breite Palette von Dienstleistungen, um Ihre Bedürfnisse zu erfüllen",
                ["ServicesDescription"] = "Von der Webentwicklung bis zum digitalen Marketing ist unser Team hier, um Ihnen zum Erfolg zu verhelfen",
                ["FAQTitle"] = "Häufig gestellte Fragen",
                ["FAQSubtitle"] = "Finden Sie Antworten auf häufige Fragen",
                ["TeamTitle"] = "Unser Team",
                ["TeamSubtitle"] = "Lernen Sie unser professionelles Team kennen",
                ["ContactUs"] = "Kontaktieren Sie uns",
                ["Address"] = "Adresse",
                ["Phone"] = "Telefon",
                ["FollowUs"] = "Folgen Sie uns",
                ["Copyright"] = "© 2024 Alle Rechte vorbehalten",
                ["Navigation"] = "Navigation",
                ["Topbar"] = "Topbar",
                ["Hero Section"] = "Hero-Bereich"
            }
        };

        public static string GetString(string key)
        {
            try
            {
                string currentLanguage = HttpContext.Current?.Session["CurrentLanguage"] as string ?? "en";
                
                if (_resources.ContainsKey(currentLanguage) && _resources[currentLanguage].ContainsKey(key))
                {
                    return _resources[currentLanguage][key];
                }
                
                return key;
            }
            catch (Exception)
            {
                return key;
            }
        }
    }
} 