using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LCA_SUPPORT_APPROVAL.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = Session["user"];
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}