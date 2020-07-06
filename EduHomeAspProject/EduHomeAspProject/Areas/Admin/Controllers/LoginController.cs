using EduHomeAspProject.DAL;
using EduHomeAspProject.ViewModels;
using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EduHomeAspProject.Areas.Admin.Filter;
using System.IO;

namespace EduHomeAspProject.Areas.Admin.Controllers
{
    
    public class LoginController : Controller
    {
        // GET: Admin/Login
        EduHomeContext db = new EduHomeContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Models.Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (db.Admins.Any(u => u.Email == admin.Email))
                {
                    ModelState.AddModelError("Email", "This Email is already in use");
                    return View(admin);
                }

                if (db.Users.Any(u => u.Username == admin.Username))
                {
                    ModelState.AddModelError("Username", "This Username is already in use");
                    return View(admin);
                }
                if (admin.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(admin);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + admin.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                admin.ImageFile.SaveAs(imagePath);
                admin.Image = imageName;

                admin.Password = Crypto.HashPassword(admin.Password);

                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Login", "Login");
            }
            return View();
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
                Models.Admin admin = db.Admins.FirstOrDefault(a => a.Username == login.Username);
                if(admin != null)
                {
                    if (Crypto.VerifyHashedPassword(admin.Password, login.Password))
                    {
                        Session["Admin"] = admin;
                        Session["AdminId"] = admin.Id;
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
            Session["Admin"] = null;
            Session["AdminId"] = null;

            return RedirectToAction("Login", "Home");
        }
    }
}