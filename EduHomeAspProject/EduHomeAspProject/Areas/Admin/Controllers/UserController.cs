using EduHomeAspProject.Areas.Admin.Filter;
using EduHomeAspProject.DAL;
using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EduHomeAspProject.Areas.Admin.Controllers
{
    [FilterAdmin]
    public class UserController : Controller
    {
        // GET: Admin/User
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<User> users = db.Users.ToList();
            return View(users);
        }

        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}