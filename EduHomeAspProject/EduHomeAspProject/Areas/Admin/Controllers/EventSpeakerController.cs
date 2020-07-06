using EduHomeAspProject.Areas.Admin.Filter;
using EduHomeAspProject.DAL;
using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Areas.Admin.Controllers
{
    [FilterAdmin]
    public class EventSpeakerController : Controller
    {
        // GET: Admin/EventSpeaker
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<EventSpeaker> shares = db.EventSpeakers.Include("Event").Include("Speaker").ToList();
            return View(shares);
        }
        public ActionResult Create()
        {
            ViewBag.Events = db.Events.ToList();
            ViewBag.Speakers = db.Speakers.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EventSpeaker evsp)
        {
            if (ModelState.IsValid)
            {
                db.EventSpeakers.Add(evsp);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Events = db.Events.ToList();
            ViewBag.Speakers = db.Speakers.ToList();
            return View(evsp);
        }

        public ActionResult Update(int id)
        {
            EventSpeaker evsp = db.EventSpeakers.Find(id);
            if (evsp == null)
            {
                return HttpNotFound();
            }
            ViewBag.Events = db.Events.ToList();
            ViewBag.Speakers = db.Speakers.ToList();

            return View(evsp);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EventSpeaker evsp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evsp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Events = db.Events.ToList();
            ViewBag.Speakers = db.Speakers.ToList();
            return View(evsp);
        }

        public ActionResult Delete(int id)
        {
            EventSpeaker evsp = db.EventSpeakers.Find(id);
            if (evsp == null)
            {
                return HttpNotFound();
            }

            db.EventSpeakers.Remove(evsp);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}