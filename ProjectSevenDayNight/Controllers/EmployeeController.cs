using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;
using System.IO;
using System;

namespace ProjectSevenDayNight.Controllers
{
    public class EmployeeController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        
        public ActionResult EmployeeList()
        {
            var employeeList = db.Employee.ToList();
            return View(employeeList);
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            // Fotoğraf yükleme işlemi
            if (Request.Files.Count > 0 && Request.Files["employeeImage"] != null)
            {
                var file = Request.Files["employeeImage"];
                if (file.ContentLength > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Content/EmployeeImages"), fileName);
                    
                    // Klasörü oluştur (yoksa)
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    
                    // Dosyayı kaydet
                    file.SaveAs(filePath);
                    
                    // ImageUrl'i güncelle
                    employee.ImageUrl = "/Content/EmployeeImages/" + fileName;
                }
            }
            
            db.Employee.Add(employee);
            db.SaveChanges();
            
            // Otomatik Almanca çeviri ekle
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(employee, "Title", employee.Title);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(employee, "Subtitle", employee.Subtitle);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(employee, "NameSurname", employee.NameSurname);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(employee, "Job", employee.Job);
            
            return RedirectToAction("EmployeeList");
        }
        
        public ActionResult DeleteEmployee(int id)
        {
            var employee = db.Employee.Find(id);
            if (employee != null)
            {
                // Önce EmployeeTranslations kayıtlarını sil
                var translations = db.EmployeeTranslations.Where(t => t.EmployeeId == id).ToList();
                foreach (var translation in translations)
                {
                    db.EmployeeTranslations.Remove(translation);
                }
                
                // Sonra Employee'yi sil
                db.Employee.Remove(employee);
                db.SaveChanges();
            }
            return RedirectToAction("EmployeeList");
        }
        
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var employee = db.Employee.Find(id);
            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            var value = db.Employee.Find(employee.EmployeeId);
            if (value == null)
                return HttpNotFound();

            // Fotoğraf yükleme işlemi
            if (Request.Files.Count > 0 && Request.Files["employeeImage"] != null)
            {
                var file = Request.Files["employeeImage"];
                if (file.ContentLength > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Content/EmployeeImages"), fileName);
                    
                    // Klasörü oluştur (yoksa)
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    
                    // Dosyayı kaydet
                    file.SaveAs(filePath);
                    
                    // ImageUrl'i güncelle
                    value.ImageUrl = "/Content/EmployeeImages/" + fileName;
                }
            }
            else if (!string.IsNullOrEmpty(employee.ImageUrl))
            {
                // Eğer yeni fotoğraf yüklenmemişse ama URL girilmişse
                value.ImageUrl = employee.ImageUrl;
            }

            value.Title = employee.Title;
            value.Subtitle = employee.Subtitle;
            value.NameSurname = employee.NameSurname;
            value.Job = employee.Job;

            db.SaveChanges();

            // Otomatik Almanca çeviri güncelle
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Title", value.Title);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Subtitle", value.Subtitle);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "NameSurname", value.NameSurname);
            ProjectSevenDayNight.Helpers.AutoTranslationHelper.AddAutoTranslation(value, "Job", value.Job);

            return RedirectToAction("EmployeeList");
        }
    }
} 