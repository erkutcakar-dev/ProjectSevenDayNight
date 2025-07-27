using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;
using ProjectSevenDayNight.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System;

namespace ProjectSevenDayNight.Controllers
{
    public class ServiceController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        // HuggingFace API bilgileri
        private const string HUGGINGFACE_API_URL = "https://api-inference.huggingface.co/models/black-forest-labs/FLUX.1-dev";
        private const string API_KEY = "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";
        
        public ActionResult ServiceList()
        {
            var serviceList = db.Service.ToList();
            return View(serviceList);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            db.Service.Add(service);
            db.SaveChanges();
            
            // Otomatik çeviri ekle
            AutoTranslationHelper.AddAutoTranslation(service, "Title", service.Title);
            AutoTranslationHelper.AddAutoTranslation(service, "Subtitle", service.Subtitle);
            AutoTranslationHelper.AddAutoTranslation(service, "CardTitle", service.CardTitle);
            AutoTranslationHelper.AddAutoTranslation(service, "CardDescription", service.CardDescription);
            
            return RedirectToAction("ServiceList");
        }
        
        /// <summary>
        /// HuggingFace API kullanarak görsel oluşturur
        /// </summary>
        /// <param name="prompt">Görsel açıklaması</param>
        /// <returns>Base64 formatında görsel verisi</returns>
        [HttpPost]
        public async Task<JsonResult> GenerateImage(string prompt)
        {
            try
            {
                if (string.IsNullOrEmpty(prompt))
                {
                    return Json(new { success = false, message = "Prompt field cannot be empty!" });
                }

                using (var httpClient = new HttpClient())
                {
                    // API key'i header'a ekle
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {API_KEY}");
                    
                    // API isteği için JSON verisi hazırla
                    var requestData = new
                    {
                        inputs = prompt,
                        parameters = new
                        {
                            num_inference_steps = 25,
                            guidance_scale = 7.5,
                            width = 512,
                            height = 512
                        }
                    };

                    var jsonContent = JsonConvert.SerializeObject(requestData);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // API çağrısı yap
                    var response = await httpClient.PostAsync(HUGGINGFACE_API_URL, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Görsel verisini al
                        var imageBytes = await response.Content.ReadAsByteArrayAsync();
                        
                        // Base64 formatına çevir
                        var base64Image = Convert.ToBase64String(imageBytes);
                        var imageDataUrl = $"data:image/png;base64,{base64Image}";

                        return Json(new { 
                            success = true, 
                            imageData = imageDataUrl,
                            message = "Image generated successfully!"
                        });
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        return Json(new { 
                            success = false, 
                            message = $"API Error: {response.StatusCode} - {errorContent}" 
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { 
                    success = false, 
                    message = $"An error occurred: {ex.Message}" 
                });
            }
        }
        
        public ActionResult DeleteService(int id)
        {
            var service = db.Service.Find(id);
            db.Service.Remove(service);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service = db.Service.Find(id);
            if (service == null)
                return HttpNotFound();

            return View(service);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            var value = db.Service.Find(service.ServiceId);
            if (value == null)
                return HttpNotFound();

            value.Title = service.Title;
            value.Subtitle = service.Subtitle;
            value.CardTitle = service.CardTitle;
            value.CardDescription = service.CardDescription;
            value.CardImageUrl = service.CardImageUrl;

            db.SaveChanges();
            
            // Otomatik çeviri güncelle
            AutoTranslationHelper.AddAutoTranslation(value, "Title", service.Title);
            AutoTranslationHelper.AddAutoTranslation(value, "Subtitle", service.Subtitle);
            AutoTranslationHelper.AddAutoTranslation(value, "CardTitle", service.CardTitle);
            AutoTranslationHelper.AddAutoTranslation(value, "CardDescription", service.CardDescription);
            return RedirectToAction("ServiceList");
        }
    }
} 