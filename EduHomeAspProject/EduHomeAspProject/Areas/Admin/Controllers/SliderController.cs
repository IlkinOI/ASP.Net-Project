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
    public class SliderController : Controller
    {
        // GET: Admin/Slider
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<Slider> sliders = db.Sliders.ToList();
            return View(sliders);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                if (slider.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(slider);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slider.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                slider.ImageFile.SaveAs(imagePath);
                slider.Image = imageName;
                slider.CreatedDate = DateTime.Now;
                db.Sliders.Add(slider);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(slider);
        }

        public ActionResult Update(int id)
        {
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }

            return View(slider);
        }

        [HttpPost]
        public ActionResult Update(Slider slider)
        {
            if (ModelState.IsValid)
            {
                Slider slidery = db.Sliders.Find(slider.Id);

                if (slider.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slider.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), slidery.Image);
                    System.IO.File.Delete(oldImagePath);

                    slider.ImageFile.SaveAs(imagePath);
                    slidery.Image = imageName;
                }
                slidery.Title = slider.Title;
                slidery.Text = slider.Text;

                db.Entry(slidery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        public ActionResult Delete(int id)
        {
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }

            db.Sliders.Remove(slider);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}