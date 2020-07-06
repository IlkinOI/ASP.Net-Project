using EduHomeAspProject.Areas.Admin.Filter;
using EduHomeAspProject.DAL;
using EduHomeAspProject.Models;
using EduHomeAspProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EduHomeAspProject.Controllers
{
    
    public class HomeController : Controller
    {
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            VMHome homemodel = new VMHome();
            homemodel.Sliders = db.Sliders.ToList();
            homemodel.Teachers = db.Teachers.OrderByDescending(t=>t.Id).Take(3).ToList();
            homemodel.Courses = db.Courses.OrderByDescending(t=>t.Id).Take(3).ToList();
            homemodel.Events = db.Events.OrderByDescending(t=>t.Id).Take(4).ToList();
            homemodel.Blogs = db.Blogs.Include("User").OrderByDescending(t=>t.Id).Take(3).ToList();
            homemodel.Common = db.Commons.FirstOrDefault();
            homemodel.About = db.Abouts.FirstOrDefault();
            homemodel.TestMorials = db.TestMorials.ToList();
            homemodel.TestMorial = db.TestMorials.FirstOrDefault();

            return View(homemodel);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "This Email is already in use");
                    return View(user);
                }

                if (db.Users.Any(u => u.Username == user.Username))
                {
                    ModelState.AddModelError("Username", "This Username is already in use");
                    return View(user);
                }
                if (user.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(user);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + user.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                user.ImageFile.SaveAs(imagePath);
                user.Image = imageName;
                user.CreatedDate = DateTime.Now;

                user.Password = Crypto.HashPassword(user.Password);

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.Username == login.Username);

                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, login.Password))
                    {
                        Session["User"] = user;
                        Session["UserId"] = user.Id;
                        Session.Timeout = 60;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password!");
                        return View(login);
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Incorrect Username!");
                    return View(login);
                }
            }

            return View(login);
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["UserId"] = null;

            return RedirectToAction("Login", "Home");
        }
    }
}