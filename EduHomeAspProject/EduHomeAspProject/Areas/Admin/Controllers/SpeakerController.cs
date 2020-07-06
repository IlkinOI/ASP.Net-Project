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
    public class SpeakerController : Controller
    {
        // GET: Admin/Speaker
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<Speaker> speakers = db.Speakers.ToList();
            return View(speakers);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                if (speaker.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(speaker);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                speaker.ImageFile.SaveAs(imagePath);
                speaker.Image = imageName;

                db.Speakers.Add(speaker);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(speaker);
        }

        public ActionResult Update(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        [HttpPost]
        public ActionResult Update(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                Speaker speak = db.Speakers.Find(speaker.Id);

                if (speaker.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), speak.Image);
                    System.IO.File.Delete(oldImagePath);

                    speaker.ImageFile.SaveAs(imagePath);
                    speak.Image = imageName;
                }
                speak.Fullname = speaker.Fullname;
                speak.Position = speaker.Position;

                db.Entry(speak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speaker);
        }

        public ActionResult Delete(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }

            db.Speakers.Remove(speaker);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}