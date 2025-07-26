using System.Linq;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

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
            db.Employee.Add(employee);
            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
        
        public ActionResult DeleteEmployee(int id)
        {
            var employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
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

            value.Title = employee.Title;
            value.Subtitle = employee.Subtitle;
            value.ImageUrl = employee.ImageUrl;
            value.NameSurname = employee.NameSurname;
            value.Job = employee.Job;

            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
    }
} 