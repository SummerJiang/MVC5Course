using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController:BaseController
    //public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return PartialView();
        }
        public ActionResult ContentTest()
        {
            return Content("開發實戰","text/plain",Encoding.GetEncoding("Big5"));
        }
        public ActionResult FileTest()
        {
            var FilePath = Server.MapPath("~/Content/螢幕擷取畫面 (1).png");
            return File(FilePath,"image,jpeg");
        }
        public ActionResult FileTest2()
        {
            var FilePath=Server.MapPath("~/Content/螢幕擷取畫面 (1).png");
            return File(FilePath,"image/jpeg","Cut.jpg");
        }
        public ActionResult JsonTest()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.OrderBy(p => p.ProductId).Take(10);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        
    }
}