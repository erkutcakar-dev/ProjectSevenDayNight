using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;

namespace ProjectSevenDayNight.Controllers
{
    public class CategoryController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        public ActionResult CategoryList()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }
    }
}
