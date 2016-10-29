using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class Share頁面上常用的ViewBag變數資料AttributeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["Number1"] = "NO.1";
        }
    }
}