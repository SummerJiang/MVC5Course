using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index()
        {
            var db = new FabricsEntities();
            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            return View(data);
        }
        public ActionResult Creat()
        {
            var product = new Product()
            {
                ProductName = "White Cat",
                Active = true,
                Price = 100,
                Stock = 5
            };

            db.Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);
            //使用
            db.OrderLine.RemoveRange(product.OrderLine);
            db.Product.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult Details(int id)
        {
            var data = db.Product.Find(id);
            return View(data);
        }

        public ActionResult Update(int id)
        {
            var product = db.Product.Find(id);
            product.ProductName += "!";
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityErrors in ex.EntityValidationErrors)
                {
                    foreach (var vErrors in entityErrors.ValidationErrors)
                    {
                        throw new DbEntityValidationException(vErrors.PropertyName + "錯誤訊息" + vErrors.ErrorMessage);
                    }
                }
                
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Add20Percent()
        {
            var data = db.Product.Where(p => p.ProductName.Contains("White"));

            foreach (var item in data)
            {

                if (item.Price.HasValue)
                    item.Price = item.Price.Value * 1.2m;

            }

            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
    
}