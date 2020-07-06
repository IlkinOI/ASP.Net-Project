using EduHomeAspProject.DAL;
using EduHomeAspProject.Models;
using EduHomeAspProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index(int page = 1)
        {
            ViewBag.Event = true;
            VMEvent model = new VMEvent();
            model.BGImage = db.BGImages.FirstOrDefault(b => b.Page == "Event");
            model.Events = db.Events.Include("EventCategory").OrderByDescending(o => o.Id).Skip((page - 1) * 6).Take(6).ToList();
            model.PageCount = Convert.ToInt32(Math.Ceiling(db.Events.Count() / 6.0));
            model.CurrentPage = page;
            model.LatestBlogs = db.Blogs.Include("BlogCategory").Include("User").OrderByDescending(t => t.Id).Take(3).ToList();
            model.Common = db.Commons.FirstOrDefault();
            model.Categories = db.EventCategories.ToList();
            return View(model);
        }
        public ActionResult EventDetails(int id)
        {
            VMEventDetail model = new VMEventDetail();
            model.Event = db.Events.FirstOrDefault(e => e.Id == id);
            model.Events = db.Events.ToList();
            model.EventSpeakers = db.EventSpeakers.Include("Speaker").Where(v => v.EventId == id).ToList();
            model.BGImage = db.BGImages.FirstOrDefault(b => b.Page == "EventDetails");
            model.LatestBlogs = db.Blogs.Include("BlogCategory").Include("User").OrderByDescending(t => t.Id).Take(3).ToList();
            model.Common = db.Commons.FirstOrDefault();
            model.Categories = db.EventCategories.ToList();
            return View(model);
        }

        public ActionResult Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Searched = db.Events.Where(s => s.Name.Contains(search)).ToList();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}