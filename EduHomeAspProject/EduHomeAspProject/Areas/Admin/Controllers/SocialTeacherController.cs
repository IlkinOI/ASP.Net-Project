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
    public class SocialTeacherController : Controller
    {
        // GET: Admin/SocialTeacher
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<SocialTeacher> socials = db.SocialTeachers.Include("Teacher").ToList();
            return View(socials);
        }
        public ActionResult Create()
        {
            ViewBag.Teachers = db.Teachers.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SocialTeacher social)
        {
            if (ModelState.IsValid)
            {
                db.SocialTeachers.Add(social);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Teachers = db.Teachers.ToList();
            return View(social);
        }

        public ActionResult Update(int id)
        {
            SocialTeacher social = db.SocialTeachers.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            ViewBag.Teachers = db.Teachers.ToList();

            return View(social);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(SocialTeacher social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teachers = db.Teachers.ToList();
            return View(social);
        }

        public ActionResult Delete(int id)
        {
            SocialTeacher social = db.SocialTeachers.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }

            db.SocialTeachers.Remove(social);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}