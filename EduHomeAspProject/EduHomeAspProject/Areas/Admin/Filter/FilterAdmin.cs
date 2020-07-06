using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Areas.Admin.Filter
{
    public class FilterAdmin : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{

        //    if (HttpContext.Current.Session["Admin"] == null)
        //    {
        //        filterContext.Result = new RedirectResult("~/Admin/Login/Login");
        //        return;
        //    }

        //    base.OnActionExecuting(filterContext);
        //}

    }
}