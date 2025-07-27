using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSevenDayNight.Models.DataModels;
using System.Text.RegularExpressions;

namespace ProjectSevenDayNight.Helpers
{
    public static class AutoTranslationHelper
    {
        private static readonly Dictionary<string, string> _translationDictionary = new Dictionary<string, string>
        {
            // Genel kelimeler
            ["about"] = "über",
            ["us"] = "uns",
            ["we"] = "wir",
            ["are"] = "sind",
            ["here"] = "hier",
            ["to"] = "zu",
            ["help"] = "helfen",
            ["you"] = "ihnen",
            ["build"] = "aufbauen",
            ["your"] = "ihr",
            ["dream"] = "traum",
            ["professional"] = "professionell",
            ["services"] = "dienstleistungen",
            ["service"] = "dienstleistung",
            ["team"] = "team",
            ["quality"] = "qualität",
            ["support"] = "support",
            ["expert"] = "experte",
            ["experts"] = "experten",
            ["experienced"] = "erfahren",
            ["professionals"] = "fachleute",
            ["best"] = "beste",
            ["provide"] = "bieten",
            ["consists"] = "besteht",
            ["of"] = "von",
            ["and"] = "und",
            ["with"] = "mit",
            ["the"] = "der",
            ["a"] = "ein",
            ["an"] = "ein",
            ["our"] = "unser",
            ["features"] = "features",
            ["feature"] = "feature",
            ["explore"] = "entdecken",
            ["what"] = "was",
            ["offer"] = "angebot",
            ["secure"] = "sichern",
            ["future"] = "zukunft",
            ["insurance"] = "versicherung",
            ["make"] = "machen",
            ["life"] = "leben",
            ["easier"] = "einfacher",
            ["modern"] = "modern",
            ["design"] = "design",
            ["web"] = "web",
            ["development"] = "entwicklung",
            ["mobile"] = "mobil",
            ["app"] = "app",
            ["applications"] = "anwendungen",
            ["responsive"] = "responsive",
            ["native"] = "native",
            ["cross-platform"] = "cross-platform",
            ["apps"] = "apps",
            ["ui"] = "ui",
            ["ux"] = "ux",
            ["user-friendly"] = "benutzerfreundlich",
            ["solutions"] = "lösungen",
            ["solution"] = "lösung",
            ["business"] = "geschäft",
            ["company"] = "unternehmen",
            ["contact"] = "kontakt",
            ["get"] = "erhalten",
            ["in"] = "in",
            ["touch"] = "kontakt",
            ["reach"] = "erreichen",
            ["questions"] = "fragen",
            ["question"] = "frage",
            ["answers"] = "antworten",
            ["answer"] = "antwort",
            ["frequently"] = "häufig",
            ["asked"] = "gefragt",
            ["find"] = "finden",
            ["information"] = "informationen",
            ["more"] = "mehr",
            ["info"] = "info",
            ["learn"] = "lernen",
            ["watch"] = "ansehen",
            ["video"] = "video",
            ["years"] = "jahre",
            ["year"] = "jahr",
            ["experience"] = "erfahrung",
            ["happy"] = "zufrieden",
            ["customers"] = "kunden",
            ["customer"] = "kunde",
            ["projects"] = "projekte",
            ["project"] = "projekt",
            ["completed"] = "abgeschlossen",
            ["members"] = "mitglieder",
            ["member"] = "mitglied",
            ["welcome"] = "willkommen",
            ["welcome to"] = "willkommen bei",
            ["first"] = "erste",
            ["aid"] = "hilfe",
            ["ready"] = "bereit",
            ["whenever"] = "wann immer",
            ["need"] = "brauchen",
            ["care"] = "pflege",
            ["procedures"] = "verfahren",
            ["accessibility"] = "barrierefreiheit",
            ["nursing"] = "krankenpflege",
            ["available"] = "verfügbar",
            ["virus"] = "virus",
            ["defense"] = "abwehr",
            ["control"] = "kontrolle",
            ["protection"] = "schutz",
            ["against"] = "gegen",
            ["viral"] = "viral",
            ["threats"] = "bedrohungen",
            ["temperature"] = "temperatur",
            ["watch"] = "überwachung",
            ["health"] = "gesundheit",
            ["monitoring"] = "überwachung",
            ["tools"] = "werkzeuge",
            ["stay"] = "bleiben",
            ["safe"] = "sicher",
            ["rapid"] = "schnell",
            ["instant"] = "sofort",
            ["when"] = "wenn",
            ["most"] = "am meisten",
            ["home"] = "haus",
            ["how"] = "wie",
            ["do"] = "tun",
            ["i"] = "ich",
            ["file"] = "einreichen",
            ["claim"] = "anspruch",
            ["can"] = "kann",
            ["cancel"] = "kündigen",
            ["policy"] = "police",
            ["is"] = "ist",
            ["covered"] = "abgedeckt",
            ["under"] = "unter",
            ["health insurance"] = "krankenversicherung",
            ["update"] = "aktualisieren",
            ["personal"] = "persönlich",
            ["documents"] = "dokumente",
            ["required"] = "erforderlich",
            ["for"] = "für",
            ["long"] = "lang",
            ["does"] = "dauert",
            ["processing"] = "bearbeitung",
            ["take"] = "dauern",
            ["roadside"] = "pannenhilfe",
            ["assistance"] = "hilfe",
            ["included"] = "inbegriffen",
            ["renew"] = "verlängern",
            ["coverage"] = "versicherungsschutz",
            ["pre-existing"] = "vorerkrankungen",
            ["conditions"] = "bedingungen",
            ["payment"] = "zahlung",
            ["methods"] = "methoden",
            ["accepted"] = "akzeptiert",
            ["deductible"] = "selbstbeteiligung",
            ["premiums"] = "prämien",
            ["tax-deductible"] = "steuerlich absetzbar",
            ["limit"] = "grenze",
            ["add"] = "hinzufügen",
            ["family"] = "familie",
            ["happens"] = "passiert",
            ["if"] = "wenn",
            ["miss"] = "verpassen",
            ["discounts"] = "rabatte",
            ["change"] = "ändern",
            ["quote"] = "angebot",
            ["exclusions"] = "ausschlüsse",
            ["should"] = "sollte",
            ["know"] = "wissen",
            ["about"] = "über",
            ["log"] = "anmelden",
            ["account"] = "konto",
            ["select"] = "auswählen",
            ["new"] = "neu",
            ["yes"] = "ja",
            ["amount"] = "betrag",
            ["specified"] = "angegeben",
            ["documents"] = "dokumente",
            ["anytime"] = "jederzeit",
            ["covers"] = "deckt",
            ["medical"] = "medizinisch",
            ["treatments"] = "behandlungen",
            ["online"] = "online",
            ["include"] = "umfassen",
            ["bills"] = "rechnungen",
            ["doctor"] = "arzt",
            ["reports"] = "berichte",
            ["typically"] = "normalerweise",
            ["days"] = "tage",
            ["all"] = "alle",
            ["policies"] = "policen",
            ["telephone"] = "telefon",
            ["various"] = "verschiedene",
            ["may"] = "können",
            ["vary"] = "variieren",
            ["by"] = "nach",
            ["add"] = "hinzufügen",
            ["miss"] = "verpassen",
            ["contact"] = "kontaktieren",
            ["us"] = "uns",
            ["various"] = "verschiedene",
            ["online"] = "online",
            ["some"] = "einige"
        };

        /// <summary>
        /// İngilizce metni Almanca'ya çevirir
        /// </summary>
        public static string TranslateToGerman(string englishText)
        {
            if (string.IsNullOrEmpty(englishText))
                return englishText;

            string result = englishText;
            
            // Büyük/küçük harf duyarlılığını koruyarak çeviri yap
            foreach (var translation in _translationDictionary)
            {
                // Tam kelime eşleşmesi için regex kullan
                string pattern = $@"\b{Regex.Escape(translation.Key)}\b";
                result = Regex.Replace(result, pattern, translation.Value, RegexOptions.IgnoreCase);
            }

            return result;
        }

        /// <summary>
        /// Veritabanına otomatik çeviri ekler
        /// </summary>
        public static void AddAutoTranslation<T>(T entity, string fieldName, string originalValue) where T : class
        {
            try
            {
                using (var db = new DayNightDbEntities())
                {
                    string translatedValue = TranslateToGerman(originalValue);
                    
                    // Entity tipine göre çeviri tablosunu belirle
                    if (typeof(T) == typeof(About))
                    {
                        var about = entity as About;
                        if (about != null)
                        {
                            var existingTranslation = db.AboutTranslations
                                .FirstOrDefault(t => t.AboutId == about.AboutId && t.LanguageCode == "de");
                            
                            if (existingTranslation == null)
                            {
                                existingTranslation = new AboutTranslations
                                {
                                    AboutId = about.AboutId,
                                    LanguageCode = "de"
                                };
                                db.AboutTranslations.Add(existingTranslation);
                            }
                            
                            SetPropertyValue(existingTranslation, fieldName, translatedValue);
                        }
                    }
                    else if (typeof(T) == typeof(Service))
                    {
                        var service = entity as Service;
                        if (service != null)
                        {
                            var existingTranslation = db.ServiceTranslations
                                .FirstOrDefault(t => t.ServiceId == service.ServiceId && t.LanguageCode == "de");
                            
                            if (existingTranslation == null)
                            {
                                existingTranslation = new ServiceTranslations
                                {
                                    ServiceId = service.ServiceId,
                                    LanguageCode = "de"
                                };
                                db.ServiceTranslations.Add(existingTranslation);
                            }
                            
                            SetPropertyValue(existingTranslation, fieldName, translatedValue);
                        }
                    }
                    else if (typeof(T) == typeof(Employee))
                    {
                        var employee = entity as Employee;
                        if (employee != null)
                        {
                            var existingTranslation = db.EmployeeTranslations
                                .FirstOrDefault(t => t.EmployeeId == employee.EmployeeId && t.LanguageCode == "de");
                            
                            if (existingTranslation == null)
                            {
                                existingTranslation = new EmployeeTranslations
                                {
                                    EmployeeId = employee.EmployeeId,
                                    LanguageCode = "de"
                                };
                                db.EmployeeTranslations.Add(existingTranslation);
                            }
                            
                            SetPropertyValue(existingTranslation, fieldName, translatedValue);
                        }
                    }
                    else if (typeof(T) == typeof(Faq))
                    {
                        var faq = entity as Faq;
                        if (faq != null)
                        {
                            var existingTranslation = db.FaqTranslations
                                .FirstOrDefault(t => t.FaqId == faq.FaqId && t.LanguageCode == "de");
                            
                            if (existingTranslation == null)
                            {
                                existingTranslation = new FaqTranslations
                                {
                                    FaqId = faq.FaqId,
                                    LanguageCode = "de"
                                };
                                db.FaqTranslations.Add(existingTranslation);
                            }
                            
                            SetPropertyValue(existingTranslation, fieldName, translatedValue);
                        }
                    }
                    else if (typeof(T) == typeof(Feature))
                    {
                        var feature = entity as Feature;
                        if (feature != null)
                        {
                            var existingTranslation = db.FeatureTranslations
                                .FirstOrDefault(t => t.FeatureId == feature.FeatureId && t.LanguageCode == "de");
                            
                            if (existingTranslation == null)
                            {
                                existingTranslation = new FeatureTranslations
                                {
                                    FeatureId = feature.FeatureId,
                                    LanguageCode = "de"
                                };
                                db.FeatureTranslations.Add(existingTranslation);
                            }
                            
                            SetPropertyValue(existingTranslation, fieldName, translatedValue);
                        }
                    }
                    else if (typeof(T) == typeof(Contact))
                    {
                        var contact = entity as Contact;
                        if (contact != null)
                        {
                            var existingTranslation = db.ContactTranslations
                                .FirstOrDefault(t => t.ContactId == contact.ContactId && t.LanguageCode == "de");
                            
                            if (existingTranslation == null)
                            {
                                existingTranslation = new ContactTranslations
                                {
                                    ContactId = contact.ContactId,
                                    LanguageCode = "de"
                                };
                                db.ContactTranslations.Add(existingTranslation);
                            }
                            
                            SetPropertyValue(existingTranslation, fieldName, translatedValue);
                        }
                    }
                    else if (typeof(T) == typeof(CompanyStats))
                    {
                        var companyStats = entity as CompanyStats;
                        if (companyStats != null)
                        {
                            var existingTranslation = db.CompanyStatsTranslations
                                .FirstOrDefault(t => t.StatId == companyStats.StatId && t.LanguageCode == "de");
                            
                            if (existingTranslation == null)
                            {
                                existingTranslation = new CompanyStatsTranslations
                                {
                                    StatId = companyStats.StatId,
                                    LanguageCode = "de"
                                };
                                db.CompanyStatsTranslations.Add(existingTranslation);
                            }
                            
                            SetPropertyValue(existingTranslation, fieldName, translatedValue);
                        }
                    }
                    else if (typeof(T) == typeof(Crausel))
                    {
                        var crausel = entity as Crausel;
                        if (crausel != null)
                        {
                            var existingTranslation = db.CrauselTranslations
                                .FirstOrDefault(t => t.CrauselId == crausel.CrauselId && t.LanguageCode == "de");
                            
                            if (existingTranslation == null)
                            {
                                existingTranslation = new CrauselTranslations
                                {
                                    CrauselId = crausel.CrauselId,
                                    LanguageCode = "de"
                                };
                                db.CrauselTranslations.Add(existingTranslation);
                            }
                            
                            SetPropertyValue(existingTranslation, fieldName, translatedValue);
                        }
                    }
                    
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda log tutabilirsiniz
                System.Diagnostics.Debug.WriteLine($"Auto translation error: {ex.Message}");
            }
        }

        private static void SetPropertyValue(object entity, string propertyName, string value)
        {
            var property = entity.GetType().GetProperty(propertyName);
            if (property != null && property.CanWrite)
            {
                property.SetValue(entity, value);
            }
        }
    }
} 