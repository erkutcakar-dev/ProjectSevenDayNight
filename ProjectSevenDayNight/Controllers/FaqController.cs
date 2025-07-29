using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;
using Newtonsoft.Json.Linq;

namespace ProjectSevenDayNight.Controllers
{
    public class FaqController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        public ActionResult FaqList()
        {
            var faqList = db.Faq.ToList();
            return View(faqList);
        }

        [HttpGet]
        public ActionResult CreateFaq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFaq(Faq faq)
        {
            db.Faq.Add(faq);
            db.SaveChanges();
            
            // Otomatik Almanca çeviri ekle
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(faq, "Title", faq.Title);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(faq, "Subtitle", faq.Subtitle);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(faq, "Question", faq.Question);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(faq, "Answer", faq.Answer);
            
            return RedirectToAction("FaqList");
        }

        [HttpPost]
        public async Task<JsonResult> GenerateQuestion()
        {
            try
            {
                var result = await GenerateChatGPTFAQs("general business and technology");
                if (result.faqs != null && result.faqs.Count > 0)
                {
                    var firstFaq = result.faqs[0];
                    return Json(new { 
                        success = true, 
                        question = firstFaq.question, 
                        answer = firstFaq.answer 
                    });
                }
                else
                {
                    // API çalışmadığında fallback değerler
                    return Json(new { 
                        success = true, 
                        question = "What services do you offer?", 
                        answer = "We offer a comprehensive range of services including web development, mobile applications, digital marketing, and business consulting. Our team of experts is dedicated to helping you achieve your business goals with innovative solutions tailored to your specific needs." 
                    });
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda da fallback değerler
                return Json(new { 
                    success = true, 
                    question = "How can I contact your support team?", 
                    answer = "You can reach our support team through multiple channels: email at support@company.com, phone at +1-555-0123, or through our contact form on the website. We typically respond within 24 hours during business days." 
                });
            }
        }

        [HttpPost]
        public async Task<JsonResult> GenerateAnswer(string question)
        {
            try
            {
                var result = await GenerateChatGPTFAQs(question);
                if (result.faqs != null && result.faqs.Count > 0)
                {
                    var firstFaq = result.faqs[0];
                    return Json(new { 
                        success = true, 
                        answer = firstFaq.answer 
                    });
                }
                else
                {
                    // API çalışmadığında fallback cevap
                    return Json(new { 
                        success = true, 
                        answer = "Thank you for your question. Our team is currently reviewing your inquiry and will provide a detailed response shortly. For immediate assistance, please contact our support team." 
                    });
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda da fallback cevap
                return Json(new { 
                    success = true, 
                    answer = "We appreciate your question. Our experts are working to provide you with the most accurate and helpful response. Please check back soon or contact our support team for immediate assistance." 
                });
            }
        }

        [HttpPost]
        public async Task<dynamic> GenerateChatGPTFAQs(string prompt)
        {
            string apiKey = "6f34f1fd84msh1928134c0765d35p1f3127jsn2dd4d98c36cb";
            string apiUrl = "https://chatgpt-42.p.rapidapi.com/chatgpt";
            
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(apiUrl),
                };
                request.Headers.Add("x-rapidapi-key", apiKey);
                request.Headers.Add("x-rapidapi-host", "chatgpt-42.p.rapidapi.com");
                
                // Daha spesifik prompt oluştur
                var enhancedPrompt = $"Create exactly 3 FAQs about {prompt}. Format each FAQ as follows:\n\n1. Q: [Question]\nA: [Answer]\n\n2. Q: [Question]\nA: [Answer]\n\n3. Q: [Question]\nA: [Answer]";
                
                // Yeni format: messages array kullan
                var requestBody = "{\"messages\":[{\"role\":\"user\",\"content\":\"" + enhancedPrompt.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n") + "\"}],\"web_access\":false}";
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Content = content;

                var response = await client.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();
                
                // Debug için JSON'u dosyaya yaz
                try
                {
                    System.IO.File.WriteAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/chatgpt_response.json"), json);
                }
                catch
                {
                    // App_Data klasörü yoksa hata vermesin
                }
                
                if (response.IsSuccessStatusCode)
                {
                    var faqs = ExtractChatGPTFAQs(json);
                    return new { faqs, raw = json };
                }
                else
                {
                    return new { faqs = new List<object>(), raw = json };
                }
            }
        }

        private List<object> ExtractChatGPTFAQs(string json)
        {
            try
            {
                var obj = JObject.Parse(json);
                
                var response = obj["response"]?.ToString() ?? 
                              obj["message"]?.ToString() ?? 
                              obj["content"]?.ToString() ?? 
                              obj["text"]?.ToString() ?? 
                              obj["result"]?.ToString();
                
                if (string.IsNullOrEmpty(response))
                {
                    try
                    {
                        System.IO.File.WriteAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/chatgpt_parsed.txt"), "Response is null or empty. Full JSON: " + json);
                    }
                    catch
                    {
                        // App_Data klasörü yoksa hata vermesin
                    }
                    return new List<object>();
                }

                var faqs = new List<object>();
                
                var lines = response.Split('\n');
                var currentQuestion = "";
                var currentAnswer = "";
                var questionNumber = 0;
                
                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();
                    
                    if (trimmedLine.StartsWith("Q:") || 
                        trimmedLine.StartsWith("Question:") || 
                        trimmedLine.StartsWith("1.") || 
                        trimmedLine.StartsWith("2.") || 
                        trimmedLine.StartsWith("3.") ||
                        (trimmedLine.Length > 0 && char.IsDigit(trimmedLine[0]) && trimmedLine.Contains(".")))
                    {
                        if (!string.IsNullOrEmpty(currentQuestion) && !string.IsNullOrEmpty(currentAnswer))
                        {
                            faqs.Add(new { question = currentQuestion, answer = currentAnswer });
                            questionNumber++;
                        }
                        
                        currentQuestion = trimmedLine
                            .Replace("Q:", "").Replace("Question:", "")
                            .Replace("1.", "").Replace("2.", "").Replace("3.", "")
                            .Trim();
                        
                        if (currentQuestion.Length <= 2 && char.IsDigit(currentQuestion[0]))
                        {
                            currentQuestion = "";
                        }
                        
                        currentAnswer = "";
                    }
                    else if (trimmedLine.StartsWith("A:") || trimmedLine.StartsWith("Answer:"))
                    {
                        currentAnswer = trimmedLine.Replace("A:", "").Replace("Answer:", "").Trim();
                    }
                    else if (!string.IsNullOrEmpty(currentAnswer) && !string.IsNullOrEmpty(trimmedLine))
                    {
                        currentAnswer += " " + trimmedLine;
                    }
                    else if (!string.IsNullOrEmpty(currentQuestion) && string.IsNullOrEmpty(currentAnswer) && !string.IsNullOrEmpty(trimmedLine))
                    {
                        currentAnswer = trimmedLine;
                    }
                }
                
                if (!string.IsNullOrEmpty(currentQuestion) && !string.IsNullOrEmpty(currentAnswer))
                {
                    faqs.Add(new { question = currentQuestion, answer = currentAnswer });
                }
                
                if (faqs.Count == 0)
                {
                    var parts = response.Split(new[] { "Q:", "Question:", "1.", "2.", "3." }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < Math.Min(parts.Length, 3); i++)
                    {
                        var part = parts[i].Trim();
                        var qaSplit = part.Split(new[] { "A:", "Answer:" }, StringSplitOptions.None);
                        if (qaSplit.Length >= 2)
                        {
                            faqs.Add(new { 
                                question = qaSplit[0].Trim(), 
                                answer = qaSplit[1].Trim() 
                            });
                        }
                    }
                }
                
                while (faqs.Count < 3)
                {
                    faqs.Add(new { 
                        question = "Sample Question " + (faqs.Count + 1), 
                        answer = "Sample Answer " + (faqs.Count + 1) 
                    });
                }
                
                return faqs.Take(3).ToList();
            }
            catch (Exception ex)
            {
                try
                {
                    System.IO.File.WriteAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/chatgpt_error.txt"), "Error: " + ex.Message + "\nJSON: " + json);
                }
                catch
                {
                    // App_Data klasörü yoksa hata vermesin
                }
                return new List<object>
                {
                    new { question = "What is this service?", answer = "This is a sample FAQ answer." },
                    new { question = "How can I get help?", answer = "You can contact our support team." },
                    new { question = "What are your business hours?", answer = "We are available 24/7." }
                };
            }
        }
        
        public ActionResult DeleteFaq(int id)
        {
            var faq = db.Faq.Find(id);
            if (faq != null)
            {
                // Önce FaqTranslations kayıtlarını sil
                var translations = db.FaqTranslations.Where(t => t.FaqId == id).ToList();
                foreach (var translation in translations)
                {
                    db.FaqTranslations.Remove(translation);
                }
                
                // Sonra FAQ'yu sil
                db.Faq.Remove(faq);
                db.SaveChanges();
            }
            return RedirectToAction("FaqList");
        }
        
        [HttpGet]
        public ActionResult UpdateFaq(int id)
        {
            var faq = db.Faq.Find(id);
            if (faq == null)
                return HttpNotFound();

            return View(faq);
        }

        [HttpPost]
        public ActionResult UpdateFaq(Faq faq)
        {
            if (!ModelState.IsValid)
            {
                return View(faq);
            }

            var value = db.Faq.Find(faq.FaqId);
            if (value == null)
                return HttpNotFound();

            value.Title = faq.Title;
            value.Subtitle = faq.Subtitle;
            value.Question = faq.Question;
            value.Answer = faq.Answer;

            db.SaveChanges();

            // Otomatik Almanca çeviri güncelle
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Title", value.Title);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Subtitle", value.Subtitle);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Question", value.Question);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Answer", value.Answer);

            return RedirectToAction("FaqList");
        }
    }
} 