using EduHomeAspProject.Areas.Admin.Filter;
using EduHomeAspProject.DAL;
using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Areas.Admin.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<Models.Admin> admins = db.Admins.ToList();
            return View(admins);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (admin.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(admin);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + admin.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                admin.ImageFile.SaveAs(imagePath);
                admin.Image = imageName;

                db.Admins.Add(admin);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(admin);
        }

        public ActionResult Update(int id)
        {
            Models.Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);
        }

        [HttpPost]
        public ActionResult Update(Models.Admin admin)
        {
            if (ModelState.IsValid)
            {
                Models.Admin admin1 = db.Admins.Find(admin.Id);
                if (admin.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + admin.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), admin1.Image);
                    System.IO.File.Delete(oldImagePath);

                    admin.ImageFile.SaveAs(imagePath);
                    admin1.Image = imageName;
                }
                admin1.Firstname = admin.Firstname;
                admin1.Lastname = admin.Lastname;
                admin1.Username = admin.Username;
                admin1.Email = admin.Email;

                db.Entry(admin1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        public ActionResult Delete(int id)
        {
            Models.Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            db.Admins.Remove(admin);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}