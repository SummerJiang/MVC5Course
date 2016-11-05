using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    //public class HomeController : Controller
    public class HomeController:BaseController
    {
        public ActionResult Index()
        {
            //Session["aa"] = 1;
            //Thread.Sleep(10000);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //var a=Session["aa"];
            return View();
        }
        public ActionResult GetTimer()
        {
            return Content(DateTime.Now.ToString());
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login,string ReturUrl)
        {
            if (ModelState.IsValid)
            {
                if (login.Email == "123@yahoo.com.tw" && login.Password =="123")
                {
                    FormsAuthentication.RedirectFromLoginPage(login.Email, false);
                    return Redirect(ReturUrl ?? "/");
                }

            }
            return View();
        }
    }
}