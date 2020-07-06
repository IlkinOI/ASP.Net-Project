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
    
    public class AboutController : Controller
    {
        
        // GET: Admin/About
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<About> abouts = db.Abouts.ToList();
            return View(abouts);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                if (about.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(about);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                about.ImageFile.SaveAs(imagePath);
                about.Image = imageName;

                db.Abouts.Add(about);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(about);
        }

        public ActionResult Update(int id)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }

            return View(about);
        }

        [HttpPost]
        public ActionResult Update(About about)
        {
            if (ModelState.IsValid)
            {
                About abouty = db.Abouts.Find(about.Id);

                if (about.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), abouty.Image);
                    System.IO.File.Delete(oldImagePath);

                    about.ImageFile.SaveAs(imagePath);
                    abouty.Image = imageName;
                }
                abouty.Title1 = about.Title1;
                abouty.Title2 = about.Title2;
                abouty.WelcomeMessage1 = about.WelcomeMessage1;
                abouty.WelcomeMessage2 = about.WelcomeMessage2;
                
                db.Entry(abouty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }

        public ActionResult Delete(int id)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }

            db.Abouts.Remove(about);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}