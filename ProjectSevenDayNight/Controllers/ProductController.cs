using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using ProjectSevenDayNight.Models.DataModels;
using System.Data.Entity;

namespace ProjectSevenDayNight.Controllers
{
    public class ProductController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        public ActionResult ProductList()
        {
            var values = db.TblProduct.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(TblProduct product)
        {
            product.ProductStatus = true;
            db.TblProduct.Add(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult DeleteProduct(int id)
        {
            var product = db.TblProduct.Find(id);
            db.TblProduct.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]

        public ActionResult UpdateProduct(int id)
        {
            var product = db.TblProduct.Find(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(TblProduct product)
        {
            var value = db.TblProduct.Find(product.ProductId);
            value.ProductName = product.ProductName;
            value.ProductPrice = product.ProductPrice;
            value.ProductStock = product.ProductStock;
            value.ProductStatus =true; 
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult ProductListWithCategory()
        {
           var values = db.TblProduct.Include(p => p.TblCategory).ToList();
            return View(values);
        }
    }


}