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
    public class EventController : Controller
    {
        // GET: Admin/Event
        EduHomeContext db = new EduHomeContext();

        // Event Category CRUD starts
        public ActionResult EventCategoryIndex()
        {
            List<EventCategory> cats = db.EventCategories.ToList();
            return View(cats);
        }
        public ActionResult EventCategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EventCategoryCreate(EventCategory cat)
        {
            if (ModelState.IsValid)
            {
                db.EventCategories.Add(cat);
                db.SaveChanges();

                return RedirectToAction("EventCategoryIndex");
            }

            return View(cat);
        }

        public ActionResult EventCategoryUpdate(int id)
        {
            EventCategory cat = db.EventCategories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);
        }

        [HttpPost]
        public ActionResult EventCategoryUpdate(EventCategory cat)
        {
            if (ModelState.IsValid)
            {

                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EventCategoryIndex");
            }

            return View(cat);
        }

        public ActionResult EventCategoryDelete(int id)
        {
            EventCategory cat = db.EventCategories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            db.EventCategories.Remove(cat);
            db.SaveChanges();

            return RedirectToAction("EventCategoryIndex");
        }

        //Event Category CRUD ends

        //Event CRUD starts

        public ActionResult Index()
        {
            List<Event> events = db.Events.Include("EventCategory").ToList();
            return View(events);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = db.EventCategories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Event happening)
        {
            if (ModelState.IsValid)
            {
                if (happening.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(happening);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + happening.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                happening.ImageFile.SaveAs(imagePath);
                happening.Image = imageName;
                happening.CreatedDate = DateTime.Now;
                db.Events.Add(happening);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.EventCategories.ToList();
            return View(happening);
        }
        public ActionResult Update(int id)
        {
            Event happening = db.Events.Find(id);
            if (happening == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.EventCategories.ToList();
            return View(happening);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Event happening)
        {
            if (ModelState.IsValid)
            {
                Event eve = db.Events.Find(happening.Id);

                if (happening.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + happening.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), eve.Image);
                    System.IO.File.Delete(oldImagePath);

                    happening.ImageFile.SaveAs(imagePath);
                    eve.Image = imageName;
                }
                eve.Name = happening.Name;
                eve.Content = happening.Content;
                eve.EventDate = happening.EventDate;
                eve.EventTime = happening.EventTime;
                eve.EventVenue = happening.EventVenue;
                eve.Link = happening.Link;
                eve.EventCategoryId = happening.EventCategoryId;

                db.Entry(eve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.EventCategories.ToList();
            return View(happening);
        }

        public ActionResult Delete(int id)
        {
            Event happening = db.Events.Find(id);
            if (happening == null)
            {
                return HttpNotFound();
            }

            db.Events.Remove(happening);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}