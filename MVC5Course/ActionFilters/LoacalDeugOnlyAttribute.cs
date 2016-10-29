using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    internal class LoacalDeugOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new RedirectResult("/");
            }
           
        }
    }
}