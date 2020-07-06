using EduHomeAspProject.Areas.Admin.Filter;
using EduHomeAspProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Areas.Admin.Controllers
{
    [FilterAdmin]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}