﻿using MVC5Course.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData["Number1"] = "NO.1";

            var b = new ClientLoginViewModel()
            {
                FirstName = "Summer",
                LastName = "Jiang"
            };
            ViewData["Number2"] = b;
            ViewBag.Temp3 = b;
            return View();
        }

        public ActionResult MyForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyForm(ClientLoginViewModel c)
        {
            if (ModelState.IsValid)
            {
                TempData["MyFormData"] = c;
                return RedirectToAction("MyFormResult");
            }
            return View();
        }
        public ActionResult MyFormResult()
        {
            return View();
        }

        public ActionResult ProductList()
        {
            var data = db.Product.OrderByDescending(p => p.ProductId).Take(10);
            return View(data);
        }
        public ActionResult BatchUpdate(ProductBathUpdateViewModel[] items)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in items)
                {
                    var product = db.Product.Find(item.ProductId);
                    product.ProductName = item.ProductName;
                    product.Active = item.Active;
                    product.Stock = item.Stock;
                    product.Price = item.Price;
                }
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View();
        }
    }
}