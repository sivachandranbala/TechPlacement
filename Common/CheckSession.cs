using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TechPlacement.Common
{
    public class CheckSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Session["UserId"] as string))
            {
                filterContext.HttpContext.Session.Abandon();
                filterContext.Controller.ControllerContext.RequestContext.HttpContext.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "action","Login"},
                    { "controller" ,"Account"},
                    { "returnUrl",filterContext.HttpContext.Request.RawUrl}
                });
            }
        }
    }
}