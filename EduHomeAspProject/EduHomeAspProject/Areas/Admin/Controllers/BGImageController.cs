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
    [FilterAdmin]
    public class BGImageController : Controller
    {
        // GET: Admin/BGImage
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<BGImage> bgis = db.BGImages.ToList();
            return View(bgis);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BGImage bgi)
        {
            if (ModelState.IsValid)
            {
                if (bgi.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(bgi);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + bgi.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                bgi.ImageFile.SaveAs(imagePath);
                bgi.Image = imageName;

                db.BGImages.Add(bgi);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(bgi);
        }

        public ActionResult Update(int id)
        {
            BGImage bgi = db.BGImages.Find(id);
            if (bgi == null)
            {
                return HttpNotFound();
            }

            return View(bgi);
        }

        [HttpPost]
        public ActionResult Update(BGImage bgi)
        {
            if (ModelState.IsValid)
            {
                BGImage Bgi = db.BGImages.Find(bgi.Id);

                if (bgi.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + bgi.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Bgi.Image);
                    System.IO.File.Delete(oldImagePath);

                    bgi.ImageFile.SaveAs(imagePath);
                    Bgi.Image = imageName;
                }
                Bgi.TItle = bgi.TItle;
                Bgi.Page = bgi.Page;

                db.Entry(Bgi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bgi);
        }

        public ActionResult Delete(int id)
        {
            BGImage bgi = db.BGImages.Find(id);
            if (bgi == null)
            {
                return HttpNotFound();
            }

            db.BGImages.Remove(bgi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}