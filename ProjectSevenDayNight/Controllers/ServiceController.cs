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
        private const string API_KEY = "api key";
        
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
        /// HuggingFace API kullanarak görsel oluşturur ve dosya olarak kaydeder
        /// </summary>
        /// <param name="prompt">Görsel açıklaması</param>
        /// <returns>Dosya yolu ve görsel verisi</returns>
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
                        
                        // Dosya adı oluştur
                        var fileName = $"{Guid.NewGuid()}.png";
                        var relativePath = $"/Content/AiImages/{fileName}";
                        var serverPath = Server.MapPath(relativePath);
                        
                        // Klasörü oluştur (yoksa)
                        Directory.CreateDirectory(Path.GetDirectoryName(serverPath));
                        
                        // Dosyayı kaydet
                        System.IO.File.WriteAllBytes(serverPath, imageBytes);
                        
                        // Base64 formatına da çevir (UI'da göstermek için)
                        var base64Image = Convert.ToBase64String(imageBytes);
                        var imageDataUrl = $"data:image/png;base64,{base64Image}";

                        return Json(new { 
                            success = true, 
                            imageData = imageDataUrl,
                            imagePath = relativePath,
                            message = "Image generated and saved successfully!"
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
            if (service != null)
            {
                // Önce ServiceTranslations kayıtlarını sil
                var translations = db.ServiceTranslations.Where(t => t.ServiceId == id).ToList();
                foreach (var translation in translations)
                {
                    db.ServiceTranslations.Remove(translation);
                }
                
                // Sonra Service'i sil
                db.Service.Remove(service);
                db.SaveChanges();
            }
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
            // ModelState validation'ı geçici olarak devre dışı bırak
            // if (!ModelState.IsValid)
            // {
            //     return View(service);
            // }

            var value = db.Service.Find(service.ServiceId);
            if (value == null)
                return HttpNotFound();

            // Debug: Gelen verileri logla
            System.Diagnostics.Debug.WriteLine($"Incoming Service Data:");
            System.Diagnostics.Debug.WriteLine($"ServiceId: {service.ServiceId}");
            System.Diagnostics.Debug.WriteLine($"Title: {service.Title}");
            System.Diagnostics.Debug.WriteLine($"Subtitle: {service.Subtitle}");
            System.Diagnostics.Debug.WriteLine($"CardTitle: {service.CardTitle}");
            System.Diagnostics.Debug.WriteLine($"CardDescription: {service.CardDescription}");
            System.Diagnostics.Debug.WriteLine($"CardImageUrl: {service.CardImageUrl}");

            value.Title = service.Title;
            value.Subtitle = service.Subtitle;
            value.CardTitle = service.CardTitle;
            value.CardDescription = service.CardDescription;
            
            // CardImageUrl'i güncelle
            value.CardImageUrl = service.CardImageUrl;

            // Debug: Kaydedilecek verileri logla
            System.Diagnostics.Debug.WriteLine($"Saving Service Data:");
            System.Diagnostics.Debug.WriteLine($"ServiceId: {value.ServiceId}");
            System.Diagnostics.Debug.WriteLine($"Title: {value.Title}");
            System.Diagnostics.Debug.WriteLine($"Subtitle: {value.Subtitle}");
            System.Diagnostics.Debug.WriteLine($"CardTitle: {value.CardTitle}");
            System.Diagnostics.Debug.WriteLine($"CardDescription: {value.CardDescription}");
            System.Diagnostics.Debug.WriteLine($"CardImageUrl: {value.CardImageUrl}");

            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                // Validation hatalarını detaylı logla
                System.Diagnostics.Debug.WriteLine("=== VALIDATION ERRORS ===");
                foreach (var eve in ex.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine($"Entity: {eve.Entry.Entity.GetType().Name}, State: {eve.Entry.State}");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine($"Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                    }
                }
                
                // Hata mesajını kullanıcıya göster
                var errorMessage = "Validation errors occurred: ";
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        errorMessage += $"{ve.PropertyName}: {ve.ErrorMessage}; ";
                    }
                }
                
                ModelState.AddModelError("", errorMessage);
                return View(service);
            }
            
            // Otomatik çeviri güncelle
            AutoTranslationHelper.AddAutoTranslation(value, "Title", service.Title);
            AutoTranslationHelper.AddAutoTranslation(value, "Subtitle", service.Subtitle);
            AutoTranslationHelper.AddAutoTranslation(value, "CardTitle", service.CardTitle);
            AutoTranslationHelper.AddAutoTranslation(value, "CardDescription", service.CardDescription);
            return RedirectToAction("ServiceList");
        }
    }
} 