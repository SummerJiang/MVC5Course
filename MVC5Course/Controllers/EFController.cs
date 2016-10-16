using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
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
            //var data = db.Product.Where(p => p.ProductName.Contains("White"));
            var data = db.Product.OrderByDescending(p => p.ProductId).Take(10);
            return View(data);
        }
        //public ActionResult Creat()
        //{
        //    var product = new Product()
        //    {
        //        ProductName = "White Cat",
        //        Active = true,
        //        Price = 100,
        //        Stock = 5
        //    };

        //    db.Product.Add(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "ProductName");

            return View();
        }

        // POST: Clients/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "ProductName", product.ProductId);
            return View(product);
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

        public ActionResult Edit(int id)
        {
            var product = db.Product.Find(id);
            try
            {
                product.ProductName = "中文";
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

        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            product.is刪除 = true;
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